using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.SysUtilities
{
    public partial class SysUtilitiesListForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public static List<Entities.DgvSysUtilitiesAuditTrailListEntity> auditTrailListData = new List<Entities.DgvSysUtilitiesAuditTrailListEntity>();
        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;
        public PagedList<Entities.DgvSysUtilitiesAuditTrailListEntity> auditTrailListPageList = new PagedList<Entities.DgvSysUtilitiesAuditTrailListEntity>(auditTrailListData, pageNumber, pageSize);
        public BindingSource audiTrailListDataSource = new BindingSource();

        public static List<Entities.DgvUtilitiesBarcodePrintingItemList> itemListData = new List<Entities.DgvUtilitiesBarcodePrintingItemList>();
        public static Int32 itemListPageNumber = 1;
        public static Int32 itemListPageSize = 50;
        public PagedList<Entities.DgvUtilitiesBarcodePrintingItemList> itemListPageList = new PagedList<Entities.DgvUtilitiesBarcodePrintingItemList>(itemListData, pageNumber, pageSize);
        public BindingSource itemListDataSource = new BindingSource();

        public SysUtilitiesListForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            GetUserList();
            CreateItemListDataGridView();
        }

        public void UpdateAuditTrailListDataSource()
        {
            DateTime startDateFilter = dateTimePickerSysAuditTrailListStartDateFilter.Value.Date;
            DateTime endDateFilter = dateTimePickerSysAuditTrailListEndDateFilter.Value.Date;
            Int32 userId = 0;
            if (comboBoxUserFilter.SelectedValue != null)
            {
                userId = Convert.ToInt32(comboBoxUserFilter.SelectedValue);
            }

            SetAuditTrailListDataSourceAsync(startDateFilter, endDateFilter, userId);
        }

        public void GetUserList()
        {
            Controllers.SysAuditTrailController sysAuditTrailController = new Controllers.SysAuditTrailController();
            var users = sysAuditTrailController.DropDownUserList();
            if (users.Any())
            {
                comboBoxUserFilter.DataSource = users;
                comboBoxUserFilter.ValueMember = "Id";
                comboBoxUserFilter.DisplayMember = "FullName";

                CreateAuditTrailListDataGridView();
            }
        }

        public async void SetAuditTrailListDataSourceAsync(DateTime startDate, DateTime endDate, Int32 userId)
        {
            List<Entities.DgvSysUtilitiesAuditTrailListEntity> getAuditTrailListData = await GetAuditTrailListDataTask(startDate, endDate, userId);
            if (getAuditTrailListData.Any())
            {
                auditTrailListData = getAuditTrailListData;
                auditTrailListPageList = new PagedList<Entities.DgvSysUtilitiesAuditTrailListEntity>(auditTrailListData, pageNumber, pageSize);

                if (auditTrailListPageList.PageCount == 1)
                {
                    buttonAuditTrailListPageListFirst.Enabled = false;
                    buttonAuditTrailListPageListPrevious.Enabled = false;
                    buttonAuditTrailListPageListNext.Enabled = false;
                    buttonAuditTrailListPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonAuditTrailListPageListFirst.Enabled = false;
                    buttonAuditTrailListPageListPrevious.Enabled = false;
                    buttonAuditTrailListPageListNext.Enabled = true;
                    buttonAuditTrailListPageListLast.Enabled = true;
                }
                else if (pageNumber == auditTrailListPageList.PageCount)
                {
                    buttonAuditTrailListPageListFirst.Enabled = true;
                    buttonAuditTrailListPageListPrevious.Enabled = true;
                    buttonAuditTrailListPageListNext.Enabled = false;
                    buttonAuditTrailListPageListLast.Enabled = false;
                }
                else
                {
                    buttonAuditTrailListPageListFirst.Enabled = true;
                    buttonAuditTrailListPageListPrevious.Enabled = true;
                    buttonAuditTrailListPageListNext.Enabled = true;
                    buttonAuditTrailListPageListLast.Enabled = true;
                }

                textBoxAuditTrailListPageNumber.Text = pageNumber + " / " + auditTrailListPageList.PageCount;
                audiTrailListDataSource.DataSource = auditTrailListPageList;
            }
            else
            {
                buttonAuditTrailListPageListFirst.Enabled = false;
                buttonAuditTrailListPageListPrevious.Enabled = false;
                buttonAuditTrailListPageListNext.Enabled = false;
                buttonAuditTrailListPageListLast.Enabled = false;

                pageNumber = 1;

                auditTrailListData = new List<Entities.DgvSysUtilitiesAuditTrailListEntity>();
                audiTrailListDataSource.Clear();
                textBoxAuditTrailListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvSysUtilitiesAuditTrailListEntity>> GetAuditTrailListDataTask(DateTime startDate, DateTime endDate, Int32 userId)
        {


            Controllers.SysAuditTrailController sysAuditTrailController = new Controllers.SysAuditTrailController();

            List<Entities.SysAuditTrailEntity> listAuditTrail = sysAuditTrailController.ListAuditTrail(startDate, endDate, userId);
            if (listAuditTrail.Any())
            {
                var auditTrail = from d in listAuditTrail
                                 select new Entities.DgvSysUtilitiesAuditTrailListEntity
                                 {
                                     ColumnAuditTrailListId = d.Id,
                                     ColumnAuditTrailListUserId = d.UserId,
                                     ColumnAuditTrailListUser = d.User,
                                     ColumnAuditTrailListAuditDate = d.AuditDate.ToString(),
                                     ColumnAuditTrailListTableInformation = d.TableInformation,
                                     ColumnAuditTrailListRecordInformation = d.RecordInformation,
                                     ColumnAuditTrailListFormInformation = d.FormInformation,
                                     ColumnAuditTrailListActionInformation = d.ActionInformation
                                 };
                return Task.FromResult(auditTrail.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvSysUtilitiesAuditTrailListEntity>());
            }
        }

        public void CreateAuditTrailListDataGridView()
        {
            UpdateAuditTrailListDataSource();

            dataGridViewAuditTrailList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewAuditTrailList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewAuditTrailList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewAuditTrailList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewAuditTrailList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewAuditTrailList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewAuditTrailList.DataSource = audiTrailListDataSource;
        }


        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }

        private void dateTimePickerStockOutListFilter_ValueChanged(object sender, EventArgs e)
        {
            UpdateAuditTrailListDataSource();
        }

        private void textBoxStockOutListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateAuditTrailListDataSource();
            }
        }

        private void buttonAudiTrailListPageListLastFirst_Click(object sender, EventArgs e)
        {
            auditTrailListPageList = new PagedList<Entities.DgvSysUtilitiesAuditTrailListEntity>(auditTrailListData, 1, pageSize);
            audiTrailListDataSource.DataSource = auditTrailListPageList;

            buttonAuditTrailListPageListFirst.Enabled = false;
            buttonAuditTrailListPageListPrevious.Enabled = false;
            buttonAuditTrailListPageListNext.Enabled = true;
            buttonAuditTrailListPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxAuditTrailListPageNumber.Text = pageNumber + " / " + auditTrailListPageList.PageCount;
        }

        private void buttonAudiTrailListPageListLastPrevious_Click(object sender, EventArgs e)
        {
            if (auditTrailListPageList.HasPreviousPage == true)
            {
                auditTrailListPageList = new PagedList<Entities.DgvSysUtilitiesAuditTrailListEntity>(auditTrailListData, --pageNumber, pageSize);
                audiTrailListDataSource.DataSource = auditTrailListPageList;
            }

            buttonAuditTrailListPageListNext.Enabled = true;
            buttonAuditTrailListPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonAuditTrailListPageListFirst.Enabled = false;
                buttonAuditTrailListPageListPrevious.Enabled = false;
            }

            textBoxAuditTrailListPageNumber.Text = pageNumber + " / " + auditTrailListPageList.PageCount;
        }

        private void buttonAudiTrailListPageListLastNext_Click(object sender, EventArgs e)
        {
            if (auditTrailListPageList.HasNextPage == true)
            {
                auditTrailListPageList = new PagedList<Entities.DgvSysUtilitiesAuditTrailListEntity>(auditTrailListData, ++pageNumber, pageSize);
                audiTrailListDataSource.DataSource = auditTrailListPageList;
            }

            buttonAuditTrailListPageListFirst.Enabled = true;
            buttonAuditTrailListPageListPrevious.Enabled = true;

            if (pageNumber == auditTrailListPageList.PageCount)
            {
                buttonAuditTrailListPageListNext.Enabled = false;
                buttonAuditTrailListPageListLast.Enabled = false;
            }

            textBoxAuditTrailListPageNumber.Text = pageNumber + " / " + auditTrailListPageList.PageCount;
        }

        private void buttonAudiTrailListPageListLastLast_Click(object sender, EventArgs e)
        {
            auditTrailListPageList = new PagedList<Entities.DgvSysUtilitiesAuditTrailListEntity>(auditTrailListData, auditTrailListPageList.PageCount, pageSize);
            audiTrailListDataSource.DataSource = auditTrailListPageList;

            buttonAuditTrailListPageListFirst.Enabled = true;
            buttonAuditTrailListPageListPrevious.Enabled = true;
            buttonAuditTrailListPageListNext.Enabled = false;
            buttonAuditTrailListPageListLast.Enabled = false;

            pageNumber = auditTrailListPageList.PageCount;
            textBoxAuditTrailListPageNumber.Text = pageNumber + " / " + auditTrailListPageList.PageCount;
        }

        private void AuditTrailList_Filter(object sender, EventArgs e)
        {
            UpdateAuditTrailListDataSource();
        }

        private void dateTimePickerSysAuditTrailListEndDateFilter_ValueChanged(object sender, EventArgs e)
        {
            UpdateAuditTrailListDataSource();
        }

        private void dateTimePickerSysAuditTrailListStartDateFilter_ValueChanged(object sender, EventArgs e)
        {
            UpdateAuditTrailListDataSource();
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = folderBrowserDialogGenerateCSV.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    

                    StringBuilder csv = new StringBuilder();
                    String[] header = { "Date", "User", "Module", "Action Taken", "Old Value", "New Value" };
                    csv.AppendLine(String.Join(",", header));

                    if (auditTrailListPageList.Any())
                    {
                        foreach (var auditTrail in auditTrailListPageList)
                        {
                            String[] data = {auditTrail.ColumnAuditTrailListAuditDate,
                                        auditTrail.ColumnAuditTrailListUser.Replace("," , ""),
                                        auditTrail.ColumnAuditTrailListTableInformation.Replace("," , "-"),
                                        auditTrail.ColumnAuditTrailListRecordInformation.Replace("," , "-"),
                                        auditTrail.ColumnAuditTrailListFormInformation.Replace("," , "-"),
                                        auditTrail.ColumnAuditTrailListActionInformation.Replace("," , "-")
                            };

                            csv.AppendLine(String.Join(",", data));
                        }
                    }

                    String executingUser = WindowsIdentity.GetCurrent().Name;

                    DirectorySecurity securityRules = new DirectorySecurity();
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.Read, AccessControlType.Allow));
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.FullControl, AccessControlType.Allow));

                    DirectoryInfo createDirectorySTCSV = Directory.CreateDirectory(folderBrowserDialogGenerateCSV.SelectedPath, securityRules);
                    File.WriteAllText(createDirectorySTCSV.FullName + "\\AuditSummaryReport_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".csv", csv.ToString(), Encoding.GetEncoding("iso-8859-1"));

                    MessageBox.Show("Generate CSV Successful!", "Generate CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateItemListDataSource()
        {
            SetItemListDataSourceAsync();
        }

        public async void SetItemListDataSourceAsync()
        {
            List<Entities.DgvUtilitiesBarcodePrintingItemList> getItemListData = await GetItemListDataTask();
            if (getItemListData.Any())
            {
                itemListData = getItemListData;
                itemListPageList = new PagedList<Entities.DgvUtilitiesBarcodePrintingItemList>(itemListData, itemListPageNumber, itemListPageSize);

                if (itemListPageList.PageCount == 1)
                {
                    buttonItemListPageListFirst.Enabled = false;
                    buttonItemListPageListPrevious.Enabled = false;
                    buttonItemListPageListNext.Enabled = false;
                    buttonItemListPageListLast.Enabled = false;
                }
                else if (itemListPageNumber == 1)
                {
                    buttonItemListPageListFirst.Enabled = false;
                    buttonItemListPageListPrevious.Enabled = false;
                    buttonItemListPageListNext.Enabled = true;
                    buttonItemListPageListLast.Enabled = true;
                }
                else if (itemListPageNumber == itemListPageList.PageCount)
                {
                    buttonItemListPageListFirst.Enabled = true;
                    buttonItemListPageListPrevious.Enabled = true;
                    buttonItemListPageListNext.Enabled = false;
                    buttonItemListPageListLast.Enabled = false;
                }
                else
                {
                    buttonItemListPageListFirst.Enabled = true;
                    buttonItemListPageListPrevious.Enabled = true;
                    buttonItemListPageListNext.Enabled = true;
                    buttonItemListPageListLast.Enabled = true;
                }

                textBoxItemListPageNumber.Text = itemListPageNumber + " / " + itemListPageList.PageCount;
                itemListDataSource.DataSource = itemListPageList;
            }
            else
            {
                buttonItemListPageListFirst.Enabled = false;
                buttonItemListPageListPrevious.Enabled = false;
                buttonItemListPageListNext.Enabled = false;
                buttonItemListPageListLast.Enabled = false;

                itemListPageNumber = 1;

                itemListData = new List<Entities.DgvUtilitiesBarcodePrintingItemList>();
                itemListDataSource.Clear();
                textBoxItemListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvUtilitiesBarcodePrintingItemList>> GetItemListDataTask()
        {
            String filter = textBoxItemListFilter.Text;
            Controllers.MstItemController mstItemController = new Controllers.MstItemController();

            List<Entities.MstItemEntity> listItem = mstItemController.ListItem(filter);
            if (listItem.Any())
            {
                var items = from d in listItem
                            select new Entities.DgvUtilitiesBarcodePrintingItemList
                            {
                                ColumnItemListButtonPick = "Pick",
                                ColumnItemListId = d.Id,
                                ColumnItemListCode = d.ItemCode,
                                ColumnItemListDescription = d.ItemDescription,
                                ColumnItemListBarcode = d.BarCode,
                                ColumnItemListUnit = d.Unit,
                                ColumnItemListCategory = d.Category,
                                ColumnItemListAlias = d.Alias,
                                ColumnItemListPrice = d.Price.ToString("#,##0.00"),
                                ColumnItemListIsInventory = d.IsInventory,
                                ColumnItemListIsLocked = d.IsLocked
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvUtilitiesBarcodePrintingItemList>());
            }
        }

        public void CreateItemListDataGridView()
        {
            UpdateItemListDataSource();

            dataGridViewItemList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewItemList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewItemList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewItemList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewItemList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewItemList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewItemList.DataSource = itemListDataSource;
        }

        public void GetItemListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewItemList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetItemListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewItemList.CurrentCell.ColumnIndex == dataGridViewItemList.Columns["ColumnItemListButtonPick"].Index)
            {
                Int32 itemId = Convert.ToInt32(dataGridViewItemList.Rows[dataGridViewItemList.CurrentCell.RowIndex].Cells[dataGridViewItemList.Columns["ColumnItemListId"].Index].Value);
                SysUtilitiesBarcodePrintingQuantity sysUtilitiesBarcodePrintingQuantity = new SysUtilitiesBarcodePrintingQuantity(itemId);
                sysUtilitiesBarcodePrintingQuantity.ShowDialog();
            }
        }

        private void textBoxItemListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateItemListDataSource();
            }
        }

        private void buttonItemListPageListFirst_Click(object sender, EventArgs e)
        {
            itemListPageList = new PagedList<Entities.DgvUtilitiesBarcodePrintingItemList>(itemListData, 1, itemListPageSize);
            itemListDataSource.DataSource = itemListPageList;

            buttonItemListPageListFirst.Enabled = false;
            buttonItemListPageListPrevious.Enabled = false;
            buttonItemListPageListNext.Enabled = true;
            buttonItemListPageListLast.Enabled = true;

            itemListPageNumber = 1;
            textBoxItemListPageNumber.Text = itemListPageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonItemListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (itemListPageList.HasPreviousPage == true)
            {
                itemListPageList = new PagedList<Entities.DgvUtilitiesBarcodePrintingItemList>(itemListData, --itemListPageNumber, itemListPageSize);
                itemListDataSource.DataSource = itemListPageList;
            }

            buttonItemListPageListNext.Enabled = true;
            buttonItemListPageListLast.Enabled = true;

            if (itemListPageNumber == 1)
            {
                buttonItemListPageListFirst.Enabled = false;
                buttonItemListPageListPrevious.Enabled = false;
            }

            textBoxItemListPageNumber.Text = itemListPageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonItemListPageListNext_Click(object sender, EventArgs e)
        {
            if (itemListPageList.HasNextPage == true)
            {
                itemListPageList = new PagedList<Entities.DgvUtilitiesBarcodePrintingItemList>(itemListData, ++itemListPageNumber, itemListPageSize);
                itemListDataSource.DataSource = itemListPageList;
            }

            buttonItemListPageListFirst.Enabled = true;
            buttonItemListPageListPrevious.Enabled = true;

            if (itemListPageNumber == itemListPageList.PageCount)
            {
                buttonItemListPageListNext.Enabled = false;
                buttonItemListPageListLast.Enabled = false;
            }

            textBoxItemListPageNumber.Text = itemListPageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonItemListPageListLast_Click(object sender, EventArgs e)
        {
            itemListPageList = new PagedList<Entities.DgvUtilitiesBarcodePrintingItemList>(itemListData, itemListPageList.PageCount, itemListPageSize);
            itemListDataSource.DataSource = itemListPageList;

            buttonItemListPageListFirst.Enabled = true;
            buttonItemListPageListPrevious.Enabled = true;
            buttonItemListPageListNext.Enabled = false;
            buttonItemListPageListLast.Enabled = false;

            itemListPageNumber = itemListPageList.PageCount;
            textBoxItemListPageNumber.Text = itemListPageNumber + " / " + itemListPageList.PageCount;
        }
    }
}
