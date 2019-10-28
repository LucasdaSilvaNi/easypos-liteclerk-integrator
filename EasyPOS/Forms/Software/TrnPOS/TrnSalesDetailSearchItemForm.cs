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
    public partial class TrnSalesDetailSearchItemForm : Form
    {
        public TrnSalesDetailForm trnSalesDetailForm;
        public Entities.TrnSalesEntity trnSalesEntity;

        public TrnSalesDetailSearchItemForm(TrnSalesDetailForm salesDetailForm, Entities.TrnSalesEntity salesEntity)
        {
            InitializeComponent();

            trnSalesDetailForm = salesDetailForm;
            trnSalesEntity = salesEntity;

            GetSearchItemList();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void GetSearchItemList()
        {
            dataGridViewSearchItemList.Rows.Clear();
            dataGridViewSearchItemList.Refresh();

            Controllers.TrnSalesLineController trnPOSSalesLineController = new Controllers.TrnSalesLineController();

            var itemList = trnPOSSalesLineController.ListSearchItem(textBoxFilter.Text);
            if (itemList.Any())
            {
                dataGridViewSearchItemList.Columns[11].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
                dataGridViewSearchItemList.Columns[11].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
                dataGridViewSearchItemList.Columns[11].DefaultCellStyle.ForeColor = Color.White;

                foreach (var objItemList in itemList)
                {
                    dataGridViewSearchItemList.Rows.Add(
                        objItemList.Id,
                        objItemList.BarCode,
                        objItemList.ItemDescription,
                        objItemList.GenericName,
                        objItemList.OutTaxId,
                        objItemList.OutTax,
                        objItemList.OutTaxRate.ToString("#,##0.00"),
                        objItemList.UnitId,
                        objItemList.Unit,
                        objItemList.Price.ToString("#,##0.00"),
                        objItemList.OnhandQuantity.ToString("#,##0.00"),
                        "Pick"
                    );
                }
            }
        }

        private void textBoxFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetSearchItemList();
            }
        }

        private void dataGridViewSearchItemList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSearchItemList.CurrentCell.ColumnIndex == dataGridViewSearchItemList.Columns["ColumnSearchItemButtonPick"].Index)
            {
                Int32 ItemId = Convert.ToInt32(dataGridViewSearchItemList.Rows[e.RowIndex].Cells[0].Value);
                Int32 SalesId = trnSalesEntity.Id;
                String ItemDescription = dataGridViewSearchItemList.Rows[e.RowIndex].Cells[2].Value.ToString();
                Int32 TaxId = Convert.ToInt32(dataGridViewSearchItemList.Rows[e.RowIndex].Cells[4].Value);
                String Tax = dataGridViewSearchItemList.Rows[e.RowIndex].Cells[5].Value.ToString();
                Decimal TaxRate = Convert.ToDecimal(dataGridViewSearchItemList.Rows[e.RowIndex].Cells[6].Value);
                Int32 UnitId = Convert.ToInt32(dataGridViewSearchItemList.Rows[e.RowIndex].Cells[7].Value);
                String Unit = dataGridViewSearchItemList.Rows[e.RowIndex].Cells[8].Value.ToString();
                Decimal Price = Convert.ToDecimal(dataGridViewSearchItemList.Rows[e.RowIndex].Cells[9].Value);
                Int32 DiscountId = Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().DefaultDiscountId);
                Int32 UserId = Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId);

                Entities.TrnSalesLineEntity trnSalesLineEntity = new Entities.TrnSalesLineEntity()
                {
                    Id = 0,
                    SalesId = SalesId,
                    ItemId = ItemId,
                    ItemDescription = ItemDescription,
                    UnitId = UnitId,
                    Unit = Unit,
                    Price = Price,
                    DiscountId = DiscountId,
                    Discount = "",
                    DiscountRate = 0,
                    DiscountAmount = 0,
                    NetPrice = Price,
                    Quantity = 1,
                    Amount = Price,
                    TaxId = TaxId,
                    Tax = Tax,
                    TaxRate = TaxRate,
                    TaxAmount = 0,
                    SalesAccountId = 159,
                    AssetAccountId = 255,
                    CostAccountId = 238,
                    TaxAccountId = 87,
                    SalesLineTimeStamp = DateTime.Now.Date.ToShortDateString(),
                    UserId = UserId,
                    Preparation = "NA",
                    Price1 = 0,
                    Price2 = 0,
                    Price2LessTax = 0,
                    PriceSplitPercentage = 0
                };

                TrnSalesDetailSalesItemDetailForm trnSalesDetailSalesItemDetailForm = new TrnSalesDetailSalesItemDetailForm(trnSalesDetailForm, trnSalesLineEntity);
                trnSalesDetailSalesItemDetailForm.ShowDialog();
            }
        }
    }
}
