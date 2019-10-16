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
    public partial class TrnSalesDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        public TrnSalesListForm trnSalesListForm;
        public Entities.TrnSalesEntity trnSalesEntity;

        public TrnSalesDetailForm(SysSoftwareForm softwareForm, TrnSalesListForm salesListForm, Entities.TrnSalesEntity salesEntity)
        {
            InitializeComponent();

            sysSoftwareForm = softwareForm;
            trnSalesListForm = salesListForm;
            trnSalesEntity = salesEntity;

            GetSalesDetail();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();

            trnSalesListForm.GetSalesList();
            sysSoftwareForm.RemoveTabPage();
        }

        public void GetSalesDetail()
        {
            textBoxTotalSalesAmount.Text = trnSalesEntity.Amount.ToString("#,##0.00");
            labelInvoiceNumber.Text = trnSalesEntity.SalesNumber;
            labelInvoiceDate.Text = trnSalesEntity.SalesDate;
            labelCustomer.Text = trnSalesEntity.Customer;

            GetSalesLineList();
        }

        private void buttonTender_Click(object sender, EventArgs e)
        {
            TrnSalesDetailTenderForm trnSalesDetailTenderForm = new TrnSalesDetailTenderForm();
            trnSalesDetailTenderForm.ShowDialog();
        }

        private void buttonSearchItem_Click(object sender, EventArgs e)
        {
            TrnSalesDetailSearchItemForm trnSalesDetailSearchItemForm = new TrnSalesDetailSearchItemForm(this, trnSalesEntity);
            trnSalesDetailSearchItemForm.ShowDialog();
        }

        public void GetSalesLineList()
        {
            dataGridViewSalesLineList.Rows.Clear();
            dataGridViewSalesLineList.Refresh();

            Controllers.TrnPOSSalesLineController trnPOSSalesLineController = new Controllers.TrnPOSSalesLineController();

            var salesLineList = trnPOSSalesLineController.ListSalesLine(trnSalesEntity.Id);
            if (salesLineList.Any())
            {
                dataGridViewSalesLineList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
                dataGridViewSalesLineList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
                dataGridViewSalesLineList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

                dataGridViewSalesLineList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
                dataGridViewSalesLineList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
                dataGridViewSalesLineList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

                Decimal totalSalesAmount = 0;

                foreach (var objSalesLineList in salesLineList)
                {
                    totalSalesAmount += objSalesLineList.Amount;

                    dataGridViewSalesLineList.Rows.Add(
                        "Edit",
                        "Delete",
                        objSalesLineList.Id,
                        objSalesLineList.SalesId,
                        objSalesLineList.ItemId,
                        objSalesLineList.ItemDescription,
                        objSalesLineList.UnitId,
                        objSalesLineList.Unit,
                        objSalesLineList.Price.ToString("#,##0.00"),
                        objSalesLineList.DiscountId,
                        objSalesLineList.Discount,
                        objSalesLineList.DiscountRate.ToString("#,##0.00"),
                        objSalesLineList.DiscountAmount.ToString("#,##0.00"),
                        objSalesLineList.NetPrice.ToString("#,##0.00"),
                        objSalesLineList.Quantity.ToString("#,##0.00"),
                        objSalesLineList.Amount.ToString("#,##0.00"),
                        objSalesLineList.TaxId,
                        objSalesLineList.Tax,
                        objSalesLineList.TaxRate.ToString("#,##0.00"),
                        objSalesLineList.TaxAmount.ToString("#,##0.00"),
                        objSalesLineList.SalesAccountId,
                        objSalesLineList.AssetAccountId,
                        objSalesLineList.CostAccountId,
                        objSalesLineList.TaxAccountId,
                        objSalesLineList.SalesLineTimeStamp,
                        objSalesLineList.UserId,
                        objSalesLineList.Preparation,
                        objSalesLineList.Price1.ToString("#,##0.00"),
                        objSalesLineList.Price2.ToString("#,##0.00"),
                        objSalesLineList.Price2LessTax.ToString("#,##0.00"),
                        objSalesLineList.PriceSplitPercentage.ToString("#,##0.00")
                    );
                }

                textBoxTotalSalesAmount.Text = totalSalesAmount.ToString("#,##0.00");
            }
        }

        private void dataGridViewSalesLineList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSalesLineList.CurrentCell.ColumnIndex == dataGridViewSalesLineList.Columns["ColumnSalesLineEdit"].Index)
            {
                Int32 Id = Convert.ToInt32(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[2].Value);
                Int32 SalesId = Convert.ToInt32(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[3].Value);
                Int32 ItemId = Convert.ToInt32(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[4].Value);
                String ItemDescription = dataGridViewSalesLineList.Rows[e.RowIndex].Cells[5].Value.ToString();
                Int32 UnitId = Convert.ToInt32(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[6].Value);
                String Unit = dataGridViewSalesLineList.Rows[e.RowIndex].Cells[7].Value.ToString();
                Decimal Price = Convert.ToDecimal(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[8].Value);
                Int32 DiscountId = Convert.ToInt32(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[9].Value);
                String Discount = dataGridViewSalesLineList.Rows[e.RowIndex].Cells[10].Value.ToString(); ;
                Decimal DiscountRate = Convert.ToDecimal(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[11].Value);
                Decimal DiscountAmount = Convert.ToDecimal(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[12].Value);
                Decimal NetPrice = Convert.ToDecimal(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[13].Value);
                Decimal Quantity = Convert.ToDecimal(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[14].Value);
                Decimal Amount = Convert.ToDecimal(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[15].Value);
                Int32 TaxId = Convert.ToInt32(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[16].Value);
                String Tax = dataGridViewSalesLineList.Rows[e.RowIndex].Cells[17].Value.ToString();
                Decimal TaxRate = Convert.ToDecimal(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[18].Value);
                Decimal TaxAmount = Convert.ToDecimal(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[19].Value);
                Int32 SalesAccountId = Convert.ToInt32(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[20].Value);
                Int32 AssetAccountId = Convert.ToInt32(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[21].Value);
                Int32 CostAccountId = Convert.ToInt32(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[22].Value);
                Int32 TaxAccountId = Convert.ToInt32(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[23].Value);
                String SalesLineTimeStamp = dataGridViewSalesLineList.Rows[e.RowIndex].Cells[24].Value.ToString();
                Int32 UserId = Convert.ToInt32(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[25].Value);
                String Preparation = dataGridViewSalesLineList.Rows[e.RowIndex].Cells[26].Value.ToString();
                Decimal Price1 = Convert.ToDecimal(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[27].Value);
                Decimal Price2 = Convert.ToDecimal(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[28].Value);
                Decimal Price2LessTax = Convert.ToDecimal(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[29].Value);
                Decimal PriceSplitPercentage = Convert.ToDecimal(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[30].Value);

                Entities.TrnSalesLineEntity trnSalesLineEntity = new Entities.TrnSalesLineEntity()
                {
                    Id = Id,
                    SalesId = SalesId,
                    ItemId = ItemId,
                    ItemDescription = ItemDescription,
                    UnitId = UnitId,
                    Unit = Unit,
                    Price = Price,
                    DiscountId = DiscountId,
                    Discount = Discount,
                    DiscountRate = DiscountRate,
                    DiscountAmount = DiscountAmount,
                    NetPrice = NetPrice,
                    Quantity = Quantity,
                    Amount = Amount,
                    TaxId = TaxId,
                    Tax = Tax,
                    TaxRate = TaxRate,
                    TaxAmount = TaxAmount,
                    SalesAccountId = SalesAccountId,
                    AssetAccountId = AssetAccountId,
                    CostAccountId = CostAccountId,
                    TaxAccountId = TaxAccountId,
                    SalesLineTimeStamp = SalesLineTimeStamp,
                    UserId = UserId,
                    Preparation = Preparation,
                    Price1 = Price1,
                    Price2 = Price2,
                    Price2LessTax = Price2LessTax,
                    PriceSplitPercentage = PriceSplitPercentage,
                };

                TrnSalesDetailSalesItemDetailForm trnSalesDetailSalesItemDetailForm = new TrnSalesDetailSalesItemDetailForm(this, trnSalesLineEntity);
                trnSalesDetailSalesItemDetailForm.ShowDialog();
            }

            if (dataGridViewSalesLineList.CurrentCell.ColumnIndex == dataGridViewSalesLineList.Columns["ColumnSalesLineDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Sales?", "Delete Sales", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    Controllers.TrnPOSSalesLineController trnPOSSalesLineController = new Controllers.TrnPOSSalesLineController();

                    String[] deleteSales = trnPOSSalesLineController.DeleteSalesLine(Convert.ToInt32(dataGridViewSalesLineList.Rows[e.RowIndex].Cells[2].Value));
                    if (deleteSales[1].Equals("0") == false)
                    {
                        GetSalesLineList();
                    }
                    else
                    {
                        MessageBox.Show(deleteSales[0], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
