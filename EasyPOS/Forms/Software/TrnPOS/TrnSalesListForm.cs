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
        public SysSoftwareForm sysSoftwareForm;

        public TrnSalesListForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            GetTerminalList();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }

        private void buttonSales_Click(object sender, EventArgs e)
        {
            newSales();
        }

        public void newSales()
        {
            Controllers.TrnPOSSalesController trnPOSSalesController = new Controllers.TrnPOSSalesController();
            String[] addSales = trnPOSSalesController.AddSales();
            if (addSales[1].Equals("0") == false)
            {
                sysSoftwareForm.AddTabPagePOSSalesDetail(this, trnPOSSalesController.DetailSales(Convert.ToInt32(addSales[1])));
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

                CurrentCelectedCell(0);
            }
            else
            {
                CurrentCelectedCell(-1);
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

        public void CurrentCelectedCell(Int32 rowIndex)
        {
            dataGridViewSalesLineItemDisplay.Rows.Clear();
            dataGridViewSalesLineItemDisplay.Refresh();

            if (rowIndex == -1)
            {
                labelInvoiceNumber.Text = "";
                labelTerminal.Text = "";
                labelPreparedBy.Text = "";
                labelTransactionDate.Text = "";
            }
            else
            {
                labelInvoiceNumber.Text = dataGridViewSalesList.Rows[rowIndex].Cells[5].Value.ToString();
                labelTerminal.Text = dataGridViewSalesList.Rows[rowIndex].Cells[3].Value.ToString();
                labelPreparedBy.Text = dataGridViewSalesList.Rows[rowIndex].Cells[7].Value.ToString();
                labelTransactionDate.Text = dataGridViewSalesList.Rows[rowIndex].Cells[4].Value.ToString();

                Controllers.TrnPOSSalesLineController trnPOSSalesLineController = new Controllers.TrnPOSSalesLineController();
                if (trnPOSSalesLineController.ListSalesLine(Convert.ToInt32(dataGridViewSalesList.Rows[rowIndex].Cells[2].Value)).Any())
                {
                    var groupedSalesLineItems = from d in trnPOSSalesLineController.ListSalesLine(Convert.ToInt32(dataGridViewSalesList.Rows[rowIndex].Cells[2].Value))
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
        }

        private void dataGridViewSalesList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                CurrentCelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewSalesList.CurrentCell.ColumnIndex == dataGridViewSalesList.Columns["ColumnEdit"].Index)
            {
                Boolean isLocked = Convert.ToBoolean(dataGridViewSalesList.Rows[e.RowIndex].Cells[9].Value);
                Boolean isTendered = Convert.ToBoolean(dataGridViewSalesList.Rows[e.RowIndex].Cells[10].Value);

                if (isLocked == true)
                {
                    MessageBox.Show("Already locked.", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (isTendered == true)
                {
                    MessageBox.Show("Already tendered.", "Tendered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Controllers.TrnPOSSalesController trnPOSSalesController = new Controllers.TrnPOSSalesController();
                    sysSoftwareForm.AddTabPagePOSSalesDetail(this, trnPOSSalesController.DetailSales(Convert.ToInt32(dataGridViewSalesList.Rows[e.RowIndex].Cells[2].Value)));
                }
            }

            if (e.RowIndex > -1 && dataGridViewSalesList.CurrentCell.ColumnIndex == dataGridViewSalesList.Columns["ColumnDelete"].Index)
            {
                Boolean isLocked = Convert.ToBoolean(dataGridViewSalesList.Rows[e.RowIndex].Cells[9].Value);
                Boolean isTendered = Convert.ToBoolean(dataGridViewSalesList.Rows[e.RowIndex].Cells[10].Value);

                if (isLocked == true)
                {
                    MessageBox.Show("Already locked.", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (isTendered == true)
                {
                    MessageBox.Show("Already tendered.", "Tendered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
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
        }

        private void textBoxSalesListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetSalesList();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (dataGridViewSalesList.Rows.Count > 1)
            {
                if (dataGridViewSalesList.CurrentCell.RowIndex != -1)
                {
                    DialogResult cancelDialogResult = MessageBox.Show("Cancel Transaction? ", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (cancelDialogResult == DialogResult.Yes)
                    {
                        Controllers.TrnPOSSalesController trnPOSSalesController = new Controllers.TrnPOSSalesController();

                        String[] cancelSales = trnPOSSalesController.CancelSales(Convert.ToInt32(dataGridViewSalesList.Rows[dataGridViewSalesList.CurrentCell.RowIndex].Cells[2].Value));
                        if (cancelSales[1].Equals("0") == false)
                        {
                            GetSalesList();
                        }
                        else
                        {
                            MessageBox.Show(cancelSales[0], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select sales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Sales empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonTender_Click(object sender, EventArgs e)
        {
            if (dataGridViewSalesList.Rows.Count > 1)
            {
                if (dataGridViewSalesList.CurrentCell.RowIndex != -1)
                {
                    Entities.TrnSalesEntity newSalesEntity = new Entities.TrnSalesEntity
                    {
                        Id = Convert.ToInt32(dataGridViewSalesList.Rows[dataGridViewSalesList.CurrentCell.RowIndex].Cells[2].Value),
                        Amount = Convert.ToDecimal(dataGridViewSalesList.Rows[dataGridViewSalesList.CurrentCell.RowIndex].Cells[8].Value),
                        SalesNumber = dataGridViewSalesList.Rows[dataGridViewSalesList.CurrentCell.RowIndex].Cells[5].Value.ToString(),
                        SalesDate = dataGridViewSalesList.Rows[dataGridViewSalesList.CurrentCell.RowIndex].Cells[4].Value.ToString(),
                        Customer = dataGridViewSalesList.Rows[dataGridViewSalesList.CurrentCell.RowIndex].Cells[6].Value.ToString()
                    };

                    TrnSalesDetailTenderForm trnSalesDetailTenderForm = new TrnSalesDetailTenderForm(sysSoftwareForm, this, null, newSalesEntity);
                    trnSalesDetailTenderForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please select sales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Sales empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonReprint_Click(object sender, EventArgs e)
        {
            if (dataGridViewSalesList.Rows.Count > 1)
            {
                if (dataGridViewSalesList.CurrentCell.RowIndex != -1)
                {
                    Boolean isLocked = Convert.ToBoolean(dataGridViewSalesList.Rows[dataGridViewSalesList.CurrentCell.RowIndex].Cells[9].Value);
                    Boolean isTendered = Convert.ToBoolean(dataGridViewSalesList.Rows[dataGridViewSalesList.CurrentCell.RowIndex].Cells[10].Value);

                    if (isTendered != true)
                    {
                        MessageBox.Show("Not tendered.", "Tendered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (isLocked != true)
                    {
                        MessageBox.Show("Not locked.", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DialogResult cancelDialogResult = MessageBox.Show("Reprint Sales?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (cancelDialogResult == DialogResult.Yes)
                        {
                            Int32 salesId = Convert.ToInt32(dataGridViewSalesList.Rows[dataGridViewSalesList.CurrentCell.RowIndex].Cells[2].Value);

                            Controllers.TrnPOSSalesController trnPOSSalesController = new Controllers.TrnPOSSalesController();
                            Int32 collectionId = trnPOSSalesController.GetCollectionId(Convert.ToInt32(dataGridViewSalesList.Rows[dataGridViewSalesList.CurrentCell.RowIndex].Cells[2].Value));
                            if (collectionId != 0)
                            {
                                new Reports.RepOfficialReceiptReportForm(salesId, collectionId, true);
                            }
                            else
                            {
                                MessageBox.Show("No collection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select sales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Sales empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
