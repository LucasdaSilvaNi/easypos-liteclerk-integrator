using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.TrnDisbursement
{
    public partial class TrnDisbursementListForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public static List<Entities.DgvDisbursementListDisbursementEntity> itemListData = new List<Entities.DgvDisbursementListDisbursementEntity>();
        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;
        public PagedList<Entities.DgvDisbursementListDisbursementEntity> itemListPageList = new PagedList<Entities.DgvDisbursementListDisbursementEntity>(itemListData, pageNumber, pageSize);
        public BindingSource itemListDataSource = new BindingSource();

        public TrnDisbursementListForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            CreateDisbursementListDataGridView();
        }

        public void UpdateDisbursementListDataSource()
        {
            SetDisbursementListDataSourceAsync();
        }

        public async void SetDisbursementListDataSourceAsync()
        {
            List<Entities.DgvDisbursementListDisbursementEntity> getDisbursementListData = await GetDisbursementListDataTask();
            if (getDisbursementListData.Any())
            {
                itemListData = getDisbursementListData;
                itemListPageList = new PagedList<Entities.DgvDisbursementListDisbursementEntity>(itemListData, pageNumber, pageSize);

                if (itemListPageList.PageCount == 1)
                {
                    buttonDisbursementListPageListFirst.Enabled = false;
                    buttonDisbursementListPageListPrevious.Enabled = false;
                    buttonDisbursementListPageListNext.Enabled = false;
                    buttonDisbursementListPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonDisbursementListPageListFirst.Enabled = false;
                    buttonDisbursementListPageListPrevious.Enabled = false;
                    buttonDisbursementListPageListNext.Enabled = true;
                    buttonDisbursementListPageListLast.Enabled = true;
                }
                else if (pageNumber == itemListPageList.PageCount)
                {
                    buttonDisbursementListPageListFirst.Enabled = true;
                    buttonDisbursementListPageListPrevious.Enabled = true;
                    buttonDisbursementListPageListNext.Enabled = false;
                    buttonDisbursementListPageListLast.Enabled = false;
                }
                else
                {
                    buttonDisbursementListPageListFirst.Enabled = true;
                    buttonDisbursementListPageListPrevious.Enabled = true;
                    buttonDisbursementListPageListNext.Enabled = true;
                    buttonDisbursementListPageListLast.Enabled = true;
                }

                textBoxDisbursementListPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
                itemListDataSource.DataSource = itemListPageList;
            }
            else
            {
                buttonDisbursementListPageListFirst.Enabled = false;
                buttonDisbursementListPageListPrevious.Enabled = false;
                buttonDisbursementListPageListNext.Enabled = false;
                buttonDisbursementListPageListLast.Enabled = false;

                pageNumber = 1;

                itemListData = new List<Entities.DgvDisbursementListDisbursementEntity>();
                itemListDataSource.Clear();
                textBoxDisbursementListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvDisbursementListDisbursementEntity>> GetDisbursementListDataTask()
        {
            DateTime dateFilter = dateTimePickerDisbursementListFilter.Value.Date;
            String filter = textBoxDisbursementListFilter.Text;
            Controllers.TrnDisbursementController trnDisbursementController = new Controllers.TrnDisbursementController();

            List<Entities.TrnDisbursementEntity> listDisbursement = trnDisbursementController.ListDisbursement(dateFilter, filter);
            if (listDisbursement.Any())
            {
                var items = from d in listDisbursement
                            select new Entities.DgvDisbursementListDisbursementEntity
                            {
                                ColumnDisbursementListButtonEdit = "Edit",
                                ColumnDisbursementListButtonDelete = "Delete",
                                ColumnDisbursementListId = d.Id,
                                ColumnDisbursementListDisbursementDate = d.DisbursementDate,
                                ColumnDisbursementListDisbursementNumber = d.DisbursementNumber,
                                ColumnDisbursementListAmount = d.Amount.ToString("#,##0.00"),
                                ColumnDisbursementListRemarks = d.Remarks,
                                ColumnDisbursementListIsLocked = d.IsLocked
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvDisbursementListDisbursementEntity>());
            }
        }

        public void CreateDisbursementListDataGridView()
        {
            UpdateDisbursementListDataSource();

            dataGridViewDisbursementList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewDisbursementList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewDisbursementList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewDisbursementList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewDisbursementList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewDisbursementList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewDisbursementList.DataSource = itemListDataSource;
        }

        public void GetDisbursementListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Controllers.TrnDisbursementController trnDisbursementController = new Controllers.TrnDisbursementController();
            String[] addDisbursement = trnDisbursementController.AddDisbursement();
            if (addDisbursement[1].Equals("0") == false)
            {
                //sysSoftwareForm.AddTabPageDisbursementDetail(this, trnDisbursementController.DetailDisbursement(Convert.ToInt32(addDisbursement[1])));
                UpdateDisbursementListDataSource();
            }
            else
            {
                MessageBox.Show(addDisbursement[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            sysSoftwareForm.RemoveTabPage();
        }

        private void dateTimePickerDisbursementListFilter_ValueChanged(object sender, EventArgs e)
        {
            UpdateDisbursementListDataSource();
        }

        private void textBoxDisbursementListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateDisbursementListDataSource();
            }
        }

        private void dataGridViewDisbursementList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetDisbursementListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewDisbursementList.CurrentCell.ColumnIndex == dataGridViewDisbursementList.Columns["ColumnDisbursementListButtonEdit"].Index)
            {
                Controllers.TrnDisbursementController trnDisbursementController = new Controllers.TrnDisbursementController();
                sysSoftwareForm.AddTabPageDisbursementDetail(this, trnDisbursementController.DetailDisbursement(Convert.ToInt32(dataGridViewDisbursementList.Rows[e.RowIndex].Cells[2].Value)));
            }

            if (e.RowIndex > -1 && dataGridViewDisbursementList.CurrentCell.ColumnIndex == dataGridViewDisbursementList.Columns["ColumnDisbursementListButtonDelete"].Index)
            {
                Boolean isLocked = Convert.ToBoolean(dataGridViewDisbursementList.Rows[e.RowIndex].Cells[7].Value);

                if (isLocked == true)
                {
                    MessageBox.Show("Already locked.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult deleteDialogResult = MessageBox.Show("Delete Disbursement?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (deleteDialogResult == DialogResult.Yes)
                    {
                        Controllers.TrnDisbursementController trnDisbursementController = new Controllers.TrnDisbursementController();

                        String[] deleteDisbursement = trnDisbursementController.DeleteDisbursement(Convert.ToInt32(dataGridViewDisbursementList.Rows[e.RowIndex].Cells[2].Value));
                        if (deleteDisbursement[1].Equals("0") == false)
                        {
                            pageNumber = 1;
                            UpdateDisbursementListDataSource();
                        }
                        else
                        {
                            MessageBox.Show(deleteDisbursement[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void buttonDisbursementListPageListFirst_Click(object sender, EventArgs e)
        {
            itemListPageList = new PagedList<Entities.DgvDisbursementListDisbursementEntity>(itemListData, 1, pageSize);
            itemListDataSource.DataSource = itemListPageList;

            buttonDisbursementListPageListFirst.Enabled = false;
            buttonDisbursementListPageListPrevious.Enabled = false;
            buttonDisbursementListPageListNext.Enabled = true;
            buttonDisbursementListPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxDisbursementListPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonDisbursementListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (itemListPageList.HasPreviousPage == true)
            {
                itemListPageList = new PagedList<Entities.DgvDisbursementListDisbursementEntity>(itemListData, --pageNumber, pageSize);
                itemListDataSource.DataSource = itemListPageList;
            }

            buttonDisbursementListPageListNext.Enabled = true;
            buttonDisbursementListPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonDisbursementListPageListFirst.Enabled = false;
                buttonDisbursementListPageListPrevious.Enabled = false;
            }

            textBoxDisbursementListPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonDisbursementListPageListNext_Click(object sender, EventArgs e)
        {
            if (itemListPageList.HasNextPage == true)
            {
                itemListPageList = new PagedList<Entities.DgvDisbursementListDisbursementEntity>(itemListData, ++pageNumber, pageSize);
                itemListDataSource.DataSource = itemListPageList;
            }

            buttonDisbursementListPageListFirst.Enabled = true;
            buttonDisbursementListPageListPrevious.Enabled = true;

            if (pageNumber == itemListPageList.PageCount)
            {
                buttonDisbursementListPageListNext.Enabled = false;
                buttonDisbursementListPageListLast.Enabled = false;
            }

            textBoxDisbursementListPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }

        private void buttonDisbursementListPageListLast_Click(object sender, EventArgs e)
        {
            itemListPageList = new PagedList<Entities.DgvDisbursementListDisbursementEntity>(itemListData, itemListPageList.PageCount, pageSize);
            itemListDataSource.DataSource = itemListPageList;

            buttonDisbursementListPageListFirst.Enabled = true;
            buttonDisbursementListPageListPrevious.Enabled = true;
            buttonDisbursementListPageListNext.Enabled = false;
            buttonDisbursementListPageListLast.Enabled = false;

            pageNumber = itemListPageList.PageCount;
            textBoxDisbursementListPageNumber.Text = pageNumber + " / " + itemListPageList.PageCount;
        }
    }
}
