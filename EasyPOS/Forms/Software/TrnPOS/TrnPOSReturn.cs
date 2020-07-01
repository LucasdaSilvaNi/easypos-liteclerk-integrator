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

        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;

        public static List<Entities.DgvTrnSalesReturnEntity> returnData = new List<Entities.DgvTrnSalesReturnEntity>();
        public PagedList<Entities.DgvTrnSalesReturnEntity> returnPageList = new PagedList<Entities.DgvTrnSalesReturnEntity>(returnData, pageNumber, pageSize);
        public BindingSource returnDataSource = new BindingSource();

        public TrnPOSReturn(TrnPOSBarcodeDetailForm POSBarcodeDetailForm)
        {
            InitializeComponent();

            trnPOSBarcodeDetailForm = POSBarcodeDetailForm;
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
                                       ColumnReturnReturnQuantity = d.Quantity.ToString("#,##0.00"),
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
                TrnPOSReturnPickQuantity trnPOSReturnPickQuantity = new TrnPOSReturnPickQuantity(this);
                trnPOSReturnPickQuantity.ShowDialog();
            }
        }

        public void UpdateReturnQuantity(Decimal quantity)
        {
            dataGridViewReturnItems.Rows[dataGridViewReturnItems.CurrentCell.RowIndex].Cells[dataGridViewReturnItems.Columns["ColumnReturnReturnQuantity"].Index].Value = quantity;
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            DialogResult deleteDialogResult = MessageBox.Show("Return these items?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (deleteDialogResult == DialogResult.Yes)
            {
                List<Entities.TrnStockInLineEntity> newStockInLines = new List<Entities.TrnStockInLineEntity>();

                foreach (DataGridViewRow row in dataGridViewReturnItems.Rows)
                {
                    if (Convert.ToDecimal(row.Cells["ColumnReturnReturnQuantity"].Value) > 0)
                    {
                        newStockInLines.Add(new Entities.TrnStockInLineEntity()
                        {
                            Id = 0,
                            StockInId = 0,
                            ItemId = Convert.ToInt32(row.Cells["ColumnReturnItemId"].Value),
                            ItemDescription = "",
                            UnitId = 0,
                            Unit = row.Cells["ColumnReturnUnit"].Value.ToString(),
                            Quantity = Convert.ToDecimal(row.Cells["ColumnReturnReturnQuantity"].Value),
                            Cost = 0,
                            Amount = Convert.ToDecimal(row.Cells["ColumnReturnAmount"].Value),
                            ExpiryDate = "",
                            LotNumber = "",
                            AssetAccountId = 0,
                            AssetAccount = "",
                            Price = Convert.ToDecimal(row.Cells["ColumnReturnPrice"].Value),
                        });
                    }
                }

                Controllers.TrnSalesController trnSalesController = new Controllers.TrnSalesController();
                if (trnSalesController.GetCurrentCollection(textBoxReturnORNumber.Text) != null)
                {
                    Int32 collectionId = trnSalesController.GetCurrentCollection(textBoxReturnORNumber.Text).Id;
                    Int32 salesId = Convert.ToInt32(trnSalesController.GetCurrentCollection(textBoxReturnORNumber.Text).SalesId);

                    trnSalesController.ReturnSalesItems(collectionId, salesId, newStockInLines);

                    MessageBox.Show("Items were successfully returned.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
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
            }
        }
    }
}
