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
    public partial class TrnSalesListForm : Form
    {
        SysSoftwareForm sysSoftwareForm;

        public TrnSalesListForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            GetTerminalList();
        }

        public Entities.TrnSalesEntity trnSalesEntity;

        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }

        private void buttonSales_Click(object sender, EventArgs e)
        {
            Controllers.TrnPOSSalesController trnPOSSalesController = new Controllers.TrnPOSSalesController();
            String[] addSales = trnPOSSalesController.AddSales();
            if (addSales[1].Equals("0") == false)
            {
                trnSalesEntity = trnPOSSalesController.DetailSales(Convert.ToInt32(addSales[1]));
                sysSoftwareForm.AddTabPagePOSSalesDetail(this);

                GetSalesList();
            }
            else
            {
                MessageBox.Show(addSales[0], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GetTerminalList()
        {
            Controllers.TrnPOSSalesController trnPOSSalesController = new Controllers.TrnPOSSalesController();
            if (trnPOSSalesController.DropdownListTerminal().Any())
            {
                comboBoxTerminal.DataSource = trnPOSSalesController.DropdownListTerminal();
                comboBoxTerminal.ValueMember = "Id";
                comboBoxTerminal.DisplayMember = "Terminal";

                GetSalesList();
            }
        }

        public void GetSalesList()
        {
            dataGridViewSalesList.Rows.Clear();
            dataGridViewSalesList.Refresh();

            Controllers.TrnPOSSalesController trnPOSSalesController = new Controllers.TrnPOSSalesController();

            var salesList = trnPOSSalesController.ListSales(dateTimePickerSalesDate.Value.Date, Convert.ToInt32(comboBoxTerminal.SelectedValue), textBoxSalesListFilter.Text);
            if (salesList.Any())
            {
                dataGridViewSalesList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
                dataGridViewSalesList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
                dataGridViewSalesList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

                dataGridViewSalesList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
                dataGridViewSalesList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
                dataGridViewSalesList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

                foreach (var objSalesList in salesList)
                {
                    dataGridViewSalesList.Rows.Add(
                        "Edit",
                        "Delete",
                        objSalesList.Id,
                        objSalesList.Terminal,
                        objSalesList.SalesDate,
                        objSalesList.SalesNumber,
                        objSalesList.Customer,
                        objSalesList.SalesAgentUserName,
                        objSalesList.Amount.ToString("#,##0.00"),
                        objSalesList.IsLocked,
                        objSalesList.IsTendered,
                        objSalesList.IsCancelled
                    );
                }
            }
        }

        private void comboBoxTerminal_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSalesList();
        }

        private void dateTimePickerSalesDate_ValueChanged(object sender, EventArgs e)
        {
            GetSalesList();
        }

        private void dataGridViewSalesList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                labelInvoiceNumber.Text = dataGridViewSalesList.Rows[e.RowIndex].Cells[5].Value.ToString();
                labelTerminal.Text = dataGridViewSalesList.Rows[e.RowIndex].Cells[3].Value.ToString();
                labelPreparedBy.Text = dataGridViewSalesList.Rows[e.RowIndex].Cells[7].Value.ToString();
                labelTransactionDate.Text = dataGridViewSalesList.Rows[e.RowIndex].Cells[4].Value.ToString();

                dataGridViewSalesLineItemDisplay.Rows.Clear();
                dataGridViewSalesLineItemDisplay.Refresh();

                Controllers.TrnPOSSalesLineController trnPOSSalesLineController = new Controllers.TrnPOSSalesLineController();
                if (trnPOSSalesLineController.ListSalesLine(Convert.ToInt32(dataGridViewSalesList.Rows[e.RowIndex].Cells[2].Value)).Any())
                {
                    var groupedSalesLineItems = from d in trnPOSSalesLineController.ListSalesLine(Convert.ToInt32(dataGridViewSalesList.Rows[e.RowIndex].Cells[2].Value))
                                                group d by new
                                                {
                                                    d.ItemDescription,
                                                    d.Unit,
                                                    d.Price,
                                                    d.Tax
                                                } into g
                                                select new
                                                {
                                                    g.Key.ItemDescription,
                                                    g.Key.Unit,
                                                    g.Key.Price,
                                                    g.Key.Tax,
                                                    Quantity = g.Sum(s => s.Quantity),
                                                    DiscountAmount = g.Sum(s => s.DiscountAmount),
                                                    Amount = g.Sum(s => s.Amount)
                                                };

                    var salesLineItemList = groupedSalesLineItems.ToList();
                    if (salesLineItemList.Any())
                    {
                        foreach (var salesLineItem in salesLineItemList)
                        {
                            dataGridViewSalesLineItemDisplay.Rows.Add(
                                salesLineItem.Quantity.ToString("#,##0.00"),
                                salesLineItem.ItemDescription + "   " + salesLineItem.Unit + Environment.NewLine + " @P" + salesLineItem.Price.ToString("#,##0.00") + " Less: " + salesLineItem.DiscountAmount.ToString("#,##0.00") + " - " + salesLineItem.Tax,
                                salesLineItem.Amount.ToString("#,##0.00")
                            );
                        }
                    }
                }
            }

            if (dataGridViewSalesList.CurrentCell.ColumnIndex == dataGridViewSalesList.Columns["ColumnEdit"].Index)
            {
                Controllers.TrnPOSSalesController trnPOSSalesController = new Controllers.TrnPOSSalesController();
                trnSalesEntity = trnPOSSalesController.DetailSales(Convert.ToInt32(dataGridViewSalesList.Rows[e.RowIndex].Cells[2].Value));

                sysSoftwareForm.AddTabPagePOSSalesDetail(this);
            }

            if (dataGridViewSalesList.CurrentCell.ColumnIndex == dataGridViewSalesList.Columns["ColumnDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Sales?", "Delete Sales", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    Controllers.TrnPOSSalesController trnPOSSalesController = new Controllers.TrnPOSSalesController();

                    String[] deleteSales = trnPOSSalesController.DeleteSales(Convert.ToInt32(dataGridViewSalesList.Rows[e.RowIndex].Cells[2].Value));
                    if (deleteSales[1].Equals("0") == false)
                    {
                        GetSalesList();
                    }
                    else
                    {
                        MessageBox.Show(deleteSales[0], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void textBoxSalesListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetSalesList();
            }
        }
    }
}
