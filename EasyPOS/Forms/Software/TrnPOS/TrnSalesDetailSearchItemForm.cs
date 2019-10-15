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
        TrnSalesDetailForm trnSalesDetailForm;

        public TrnSalesDetailSearchItemForm(TrnSalesDetailForm salesDetailForm)
        {
            InitializeComponent();
            trnSalesDetailForm = salesDetailForm;

            GetSearchItemList();
        }

        public Entities.TrnSalesLineEntity trnSalesLineEntity;

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void GetSearchItemList()
        {
            dataGridViewSearchItemList.Rows.Clear();
            dataGridViewSearchItemList.Refresh();

            Controllers.TrnPOSSalesLineController trnPOSSalesLineController = new Controllers.TrnPOSSalesLineController();

            var itemList = trnPOSSalesLineController.ListSearchItem(textBoxFilter.Text);
            if (itemList.Any())
            {
                dataGridViewSearchItemList.Columns[10].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
                dataGridViewSearchItemList.Columns[10].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
                dataGridViewSearchItemList.Columns[10].DefaultCellStyle.ForeColor = Color.White;

                foreach (var objItemList in itemList)
                {
                    dataGridViewSearchItemList.Rows.Add(
                        objItemList.Id,
                        objItemList.BarCode,
                        objItemList.ItemDescription,
                        objItemList.GenericName,
                        objItemList.OutTaxId,
                        objItemList.OutTax,
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
                Int32 Id = Convert.ToInt32(dataGridViewSearchItemList.Rows[e.RowIndex].Cells[0].Value);
                String Barcode = dataGridViewSearchItemList.Rows[e.RowIndex].Cells[1].Value.ToString();
                String ItemDescription = dataGridViewSearchItemList.Rows[e.RowIndex].Cells[2].Value.ToString();
                String GenericName = dataGridViewSearchItemList.Rows[e.RowIndex].Cells[3].Value.ToString();
                Int32 OutTaxId = Convert.ToInt32(dataGridViewSearchItemList.Rows[e.RowIndex].Cells[4].Value);
                String OutTax = dataGridViewSearchItemList.Rows[e.RowIndex].Cells[5].Value.ToString();
                Int32 UnitId = Convert.ToInt32(dataGridViewSearchItemList.Rows[e.RowIndex].Cells[6].Value);
                String Unit = dataGridViewSearchItemList.Rows[e.RowIndex].Cells[7].Value.ToString();
                Decimal Price = Convert.ToDecimal(dataGridViewSearchItemList.Rows[e.RowIndex].Cells[8].Value);
                Decimal OnhandQuantity = Convert.ToDecimal(dataGridViewSearchItemList.Rows[e.RowIndex].Cells[9].Value);

                trnSalesLineEntity = new Entities.TrnSalesLineEntity()
                {
                    Id = 0,
                    SalesId = trnSalesDetailForm.trnSalesEntity.Id,
                    ItemId = Id,
                    ItemDescription = ItemDescription,
                    UnitId = UnitId,
                    Unit = Unit,
                    Price = Price,
                    DiscountId = Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().DefaultDiscountId),
                    DiscountRate = 0,
                    DiscountAmount = 0,
                    NetPrice = 0,
                    Quantity = 1,
                    Amount = Price,
                    TaxId = OutTaxId,
                    Tax = OutTax,
                    TaxRate = 0,
                    TaxAmount = 0
                };
                
                TrnSalesDetailSalesItemDetailForm trnSalesDetailSalesItemDetailForm = new TrnSalesDetailSalesItemDetailForm(trnSalesDetailForm, this);
                trnSalesDetailSalesItemDetailForm.ShowDialog();
            }
        }
    }
}
