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

namespace EasyPOS.Forms.Software.TrnPOS
{
    public partial class TrnPOSReturn : Form
    {
        TrnPOSBarcodeDetailForm trnPOSBarcodeDetailForm;
        TrnPOSTouchDetailForm trnPOSTouchDetailForm;

        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;

        public static List<Entities.DgvTrnSalesReturnEntity> returnData = new List<Entities.DgvTrnSalesReturnEntity>();
        public PagedList<Entities.DgvTrnSalesReturnEntity> returnPageList = new PagedList<Entities.DgvTrnSalesReturnEntity>(returnData, pageNumber, pageSize);
        public BindingSource returnDataSource = new BindingSource();

        public TrnPOSReturn(TrnPOSBarcodeDetailForm POSBarcodeDetailForm, TrnPOSTouchDetailForm POSTouchDetailForm)
        {
            InitializeComponent();

            trnPOSBarcodeDetailForm = POSBarcodeDetailForm;
            trnPOSTouchDetailForm = POSTouchDetailForm;

            LoadReturnItems();
        }

        public void LoadReturnItems()
        {
            CreateReturnDataGridView();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void UpdateReturnDataSource()
        {
            SetReturnDataSourceAsync();
        }

        public async void SetReturnDataSourceAsync()
        {
            List<Entities.DgvTrnSalesReturnEntity> getReturnData = await GetReturnDataTask();
            if (getReturnData.Any())
            {
                returnData = getReturnData;
                returnPageList = new PagedList<Entities.DgvTrnSalesReturnEntity>(returnData, pageNumber, pageSize);

                if (returnPageList.PageCount == 1)
                {
                    buttonReturnPageListFirst.Enabled = false;
                    buttonReturnPageListPrevious.Enabled = false;
                    buttonReturnPageListNext.Enabled = false;
                    buttonReturnPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonReturnPageListFirst.Enabled = false;
                    buttonReturnPageListPrevious.Enabled = false;
                    buttonReturnPageListNext.Enabled = true;
                    buttonReturnPageListLast.Enabled = true;
                }
                else if (pageNumber == returnPageList.PageCount)
                {
                    buttonReturnPageListFirst.Enabled = true;
                    buttonReturnPageListPrevious.Enabled = true;
                    buttonReturnPageListNext.Enabled = false;
                    buttonReturnPageListLast.Enabled = false;
                }
                else
                {
                    buttonReturnPageListFirst.Enabled = true;
                    buttonReturnPageListPrevious.Enabled = true;
                    buttonReturnPageListNext.Enabled = true;
                    buttonReturnPageListLast.Enabled = true;
                }

                textBoxReturnPageNumber.Text = pageNumber + " / " + returnPageList.PageCount;
                returnDataSource.DataSource = returnPageList;
            }
            else
            {
                buttonReturnPageListFirst.Enabled = false;
                buttonReturnPageListPrevious.Enabled = false;
                buttonReturnPageListNext.Enabled = false;
                buttonReturnPageListLast.Enabled = false;

                pageNumber = 1;

                returnData = new List<Entities.DgvTrnSalesReturnEntity>();
                returnDataSource.Clear();
                textBoxReturnPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvTrnSalesReturnEntity>> GetReturnDataTask()
        {
            Controllers.TrnSalesController trnSalesController = new Controllers.TrnSalesController();
            List<Entities.TrnSalesLineEntity> listReturnItems = trnSalesController.ListReturnSalesItems(textBoxReturnORNumber.Text);

            if (listReturnItems.Any())
            {
                var returnItemss = from d in listReturnItems
                                   select new Entities.DgvTrnSalesReturnEntity
                                   {
                                       ColumnReturnItemId = d.ItemId,
                                       ColumnReturnItemDescription = d.ItemDescription,
                                       ColumnReturnUnit = d.Unit,
                                       ColumnReturnPrice = d.Price.ToString("#,##0.00"),
                                       ColumnReturnQuantity = d.Quantity.ToString("#,##0.00"),
                                       ColumnReturnAmount = d.Amount.ToString("#,##0.00"),
                                       ColumnReturnPickItem = "Pick",
                                       ColumnReturnUnpickItem = "Unpick",
                                       ColumnReturnReturnQuantity = "0.00",
                                   };

                return Task.FromResult(returnItemss.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvTrnSalesReturnEntity>());
            }
        }

        public void CreateReturnDataGridView()
        {
            UpdateReturnDataSource();

            dataGridViewReturnItems.Columns[6].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewReturnItems.Columns[6].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewReturnItems.Columns[6].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewReturnItems.Columns[7].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewReturnItems.Columns[7].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewReturnItems.Columns[7].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewReturnItems.DataSource = returnDataSource;
        }

        public void GetReturnCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonReturnPageListFirst_Click(object sender, EventArgs e)
        {
            returnPageList = new PagedList<Entities.DgvTrnSalesReturnEntity>(returnData, 1, pageSize);
            returnDataSource.DataSource = returnPageList;

            buttonReturnPageListFirst.Enabled = false;
            buttonReturnPageListPrevious.Enabled = false;
            buttonReturnPageListNext.Enabled = true;
            buttonReturnPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxReturnPageNumber.Text = pageNumber + " / " + returnPageList.PageCount;
        }

        private void buttonReturnPageListPrevious_Click(object sender, EventArgs e)
        {
            if (returnPageList.HasPreviousPage == true)
            {
                returnPageList = new PagedList<Entities.DgvTrnSalesReturnEntity>(returnData, --pageNumber, pageSize);
                returnDataSource.DataSource = returnPageList;
            }

            buttonReturnPageListNext.Enabled = true;
            buttonReturnPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonReturnPageListFirst.Enabled = false;
                buttonReturnPageListPrevious.Enabled = false;
            }

            textBoxReturnPageNumber.Text = pageNumber + " / " + returnPageList.PageCount;
        }

        private void buttonReturnPageListNext_Click(object sender, EventArgs e)
        {
            if (returnPageList.HasNextPage == true)
            {
                returnPageList = new PagedList<Entities.DgvTrnSalesReturnEntity>(returnData, ++pageNumber, pageSize);
                returnDataSource.DataSource = returnPageList;
            }

            buttonReturnPageListFirst.Enabled = true;
            buttonReturnPageListPrevious.Enabled = true;

            if (pageNumber == returnPageList.PageCount)
            {
                buttonReturnPageListNext.Enabled = false;
                buttonReturnPageListLast.Enabled = false;
            }

            textBoxReturnPageNumber.Text = pageNumber + " / " + returnPageList.PageCount;
        }

        private void buttonReturnPageListLast_Click(object sender, EventArgs e)
        {
            returnPageList = new PagedList<Entities.DgvTrnSalesReturnEntity>(returnData, returnPageList.PageCount, pageSize);
            returnDataSource.DataSource = returnPageList;

            buttonReturnPageListFirst.Enabled = true;
            buttonReturnPageListPrevious.Enabled = true;
            buttonReturnPageListNext.Enabled = false;
            buttonReturnPageListLast.Enabled = false;

            pageNumber = returnPageList.PageCount;
            textBoxReturnPageNumber.Text = pageNumber + " / " + returnPageList.PageCount;
        }

        private void dataGridViewReturn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetReturnCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewReturnItems.CurrentCell.ColumnIndex == dataGridViewReturnItems.Columns["ColumnReturnPickItem"].Index)
            {
                Decimal quantity = Convert.ToDecimal(dataGridViewReturnItems.Rows[dataGridViewReturnItems.CurrentCell.RowIndex].Cells[dataGridViewReturnItems.Columns["ColumnReturnQuantity"].Index].Value);

                TrnPOSReturnPickQuantity trnPOSReturnPickQuantity = new TrnPOSReturnPickQuantity(this, quantity);
                trnPOSReturnPickQuantity.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewReturnItems.CurrentCell.ColumnIndex == dataGridViewReturnItems.Columns["ColumnReturnUnpickItem"].Index)
            {
                UpdateReturnQuantity(0);
            }
        }

        public void UpdateReturnQuantity(Decimal quantity)
        {
            dataGridViewReturnItems.Rows[dataGridViewReturnItems.CurrentCell.RowIndex].Cells[dataGridViewReturnItems.Columns["ColumnReturnReturnQuantity"].Index].Value = quantity.ToString("#,##0.00");
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            DialogResult deleteDialogResult = MessageBox.Show("Return these items?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (deleteDialogResult == DialogResult.Yes)
            {
                List<Entities.TrnSalesLineEntity> newStockInLines = new List<Entities.TrnSalesLineEntity>();

                foreach (DataGridViewRow row in dataGridViewReturnItems.Rows)
                {
                    if (Convert.ToDecimal(row.Cells["ColumnReturnReturnQuantity"].Value) > 0)
                    {
                        newStockInLines.Add(new Entities.TrnSalesLineEntity()
                        {
                            Id = 0,
                            SalesId = 0,
                            ItemId = Convert.ToInt32(row.Cells["ColumnReturnItemId"].Value),
                            UnitId = 0,
                            Unit = "",
                            Price = Convert.ToDecimal(row.Cells["ColumnReturnPrice"].Value),
                            DiscountId = 0,
                            DiscountRate = 0,
                            DiscountAmount = 0,
                            NetPrice = 0,
                            Quantity = Convert.ToDecimal(row.Cells["ColumnReturnReturnQuantity"].Value),
                            Amount = 0,
                            TaxId = 0,
                            TaxRate = 0,
                            TaxAmount = 0,
                            SalesAccountId = 159,
                            AssetAccountId = 255,
                            CostAccountId = 238,
                            TaxAccountId = 87,
                            SalesLineTimeStamp = "",
                            UserId = Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId),
                            Preparation = "NA",
                            IsPrepared = false,
                            Price1 = 0,
                            Price2 = 0,
                            Price2LessTax = 0,
                            PriceSplitPercentage = 0,
                        });
                    }
                }

                Controllers.TrnSalesController trnSalesController = new Controllers.TrnSalesController();
                if (trnSalesController.GetCurrentCollection(textBoxReturnORNumber.Text) != null)
                {
                    Int32 currentSalesId = 0;

                    if (trnPOSBarcodeDetailForm != null)
                    {
                        currentSalesId = trnPOSBarcodeDetailForm.trnSalesEntity.Id;
                    }

                    if (trnPOSTouchDetailForm != null)
                    {
                        currentSalesId = trnPOSTouchDetailForm.trnSalesEntity.Id;
                    }

                    Int32 collectionId = trnSalesController.GetCurrentCollection(textBoxReturnORNumber.Text).Id;

                    String[] returnSalesItems = trnSalesController.ReturnSalesItems(currentSalesId, collectionId, newStockInLines);
                    if (returnSalesItems[1].Equals("0") == false)
                    {
                        MessageBox.Show("Items were successfully returned.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (trnPOSBarcodeDetailForm != null)
                        {
                            trnPOSBarcodeDetailForm.GetSalesLineList();
                        }

                        if (trnPOSTouchDetailForm != null)
                        {
                            trnPOSTouchDetailForm.GetSalesLineList();
                        }

                        Close();
                    }
                    else
                    {
                        MessageBox.Show(returnSalesItems[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonRefund_Click(object sender, EventArgs e)
        {

        }

        private void textBoxReturnORNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateReturnDataSource();

                Controllers.TrnSalesController trnSalesController = new Controllers.TrnSalesController();

                if (trnSalesController.GetCurrentCollection(textBoxReturnORNumber.Text) != null)
                {
                    textBoxReturnSalesNumber.Text = trnSalesController.GetCurrentCollection(textBoxReturnORNumber.Text).SalesNumber;
                }
                else
                {
                    textBoxReturnSalesNumber.Text = "";
                }
            }
        }
    }
}
