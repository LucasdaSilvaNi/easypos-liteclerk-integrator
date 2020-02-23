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
    public partial class TrnPOSTouchForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        private Modules.SysUserRightsModule sysUserRights;

        public List<Entities.DgvSalesListSalesEntity> salesList;

        public BindingSource dataOpenSalesListSource = new BindingSource();
        public BindingSource dataBilledOutSalesListSource = new BindingSource();
        public BindingSource dataCollectedSalesListSource = new BindingSource();

        public TrnPOSTouchActivityForm trnPOSTouchActivityForm;

        public TrnPOSTouchForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();

            dateTimePickerSalesDate.Value = Convert.ToDateTime(Modules.SysCurrentModule.GetCurrentSettings().CurrentDate);

            sysUserRights = new Modules.SysUserRightsModule("TrnSales");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (sysUserRights.GetUserRights().CanAdd == false)
                {
                    buttonWalkIn.Enabled = false;
                }

                GetTerminalList();
                //timerRefreshSalesListGrid.Start();
            }

            Controllers.TrnSalesController trnPOSSalesController = new Controllers.TrnSalesController();
            textBoxLastChange.Text = trnPOSSalesController.GetLastChange(Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().TerminalId)).ToString("#,##0.00");

            sysSoftwareForm = softwareForm;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }

        private void buttonWalkIn_Click(object sender, EventArgs e)
        {
            Controllers.TrnSalesController trnPOSSalesController = new Controllers.TrnSalesController();
            String[] addSales = trnPOSSalesController.AddSales();
            if (addSales[1].Equals("0") == false)
            {
                sysSoftwareForm.AddTabPagePOSTouchSalesDetail(this, trnPOSSalesController.DetailSales(Convert.ToInt32(addSales[1])));
                UpdateSalesListGridDataSource();
            }
            else
            {
                MessageBox.Show(addSales[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControlSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateSalesListGridDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePickerSalesDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateSalesListGridDataSource();
        }

        public void GetTerminalList()
        {
            Controllers.TrnSalesController trnPOSSalesController = new Controllers.TrnSalesController();
            if (trnPOSSalesController.DropdownListTerminal().Any())
            {
                comboBoxTerminal.DataSource = trnPOSSalesController.DropdownListTerminal();
                comboBoxTerminal.ValueMember = "Id";
                comboBoxTerminal.DisplayMember = "Terminal";

                comboBoxTerminal.SelectedValue = Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().TerminalId);

                UpdateSalesListGridDataSource();
                CreateSalesListDataGrid();
            }
        }

        private void comboBoxTerminal_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSalesListGridDataSource();
        }

        private void textBoxSalesListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateSalesListGridDataSource();
            }
        }

        public void UpdateSalesListGridDataSource()
        {
            DateTime salesDate = dateTimePickerSalesDate.Value.Date;
            Int32 terminalId = Convert.ToInt32(comboBoxTerminal.SelectedValue);

            GetSalesListDataAsync(salesDate, terminalId, "");

            Controllers.TrnSalesController trnPOSSalesController = new Controllers.TrnSalesController();
            textBoxLastChange.Text = trnPOSSalesController.GetLastChange(Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().TerminalId)).ToString("#,##0.00");
        }

        public async void GetSalesListDataAsync(DateTime salesDate, Int32 terminalId, String filter)
        {
            var salesList = await GetSalesListDataTask(salesDate, terminalId, filter);
            if (salesList.Any())
            {
                if (tabControlSales.SelectedTab == tabPageOpen)
                {
                    var openSales = from d in salesList where d.ColumnIsLocked == false select d;
                    if (openSales.Any())
                    {
                        dataOpenSalesListSource.DataSource = openSales;
                    }
                    else
                    {
                        dataOpenSalesListSource.Clear();
                    }
                }

                if (tabControlSales.SelectedTab == tabPageBilledOut)
                {
                    var billedOutSales = from d in salesList where d.ColumnIsLocked == true && d.ColumnIsTendered == false select d;
                    if (billedOutSales.Any())
                    {
                        dataBilledOutSalesListSource.DataSource = billedOutSales;
                    }
                    else
                    {
                        dataBilledOutSalesListSource.Clear();
                    }
                }

                if (tabControlSales.SelectedTab == tabPageCollected)
                {
                    var collectedSales = from d in salesList where d.ColumnIsTendered == true select d;
                    if (collectedSales.Any())
                    {
                        dataCollectedSalesListSource.DataSource = collectedSales;
                    }
                    else
                    {
                        dataCollectedSalesListSource.Clear();
                    }
                }
            }
            else
            {
                dataOpenSalesListSource.Clear();
                dataBilledOutSalesListSource.Clear();
                dataCollectedSalesListSource.Clear();
            }
        }

        public async Task<List<Entities.DgvSalesListSalesEntity>> GetSalesListDataTask(DateTime salesDate, Int32 terminalId, String filter)
        {
            return await Task.Factory.StartNew(() =>
            {
                List<Entities.DgvSalesListSalesEntity> rowList = new List<Entities.DgvSalesListSalesEntity>();

                Controllers.TrnSalesController trnPOSSalesController = new Controllers.TrnSalesController();
                var salesList = trnPOSSalesController.POSTTouchListSales(salesDate, terminalId);
                if (salesList.Any())
                {
                    var row = from d in salesList
                              select new Entities.DgvSalesListSalesEntity
                              {
                                  ColumnEdit = "Edit",
                                  ColumnDelete = "Delete",
                                  ColumnId = d.Id,
                                  ColumnTerminal = d.Terminal,
                                  ColumnSalesDate = d.SalesDate,
                                  ColumnSalesNumber = d.SalesNumber,
                                  ColumnRececiptInvoiceNumber = d.CollectionNumber,
                                  ColumnCustomer = d.Customer,
                                  ColumnSalesAgent = d.SalesAgentUserName,
                                  ColumnAmount = d.Amount.ToString("#,##0.00"),
                                  ColumnIsLocked = d.IsLocked,
                                  ColumnIsTendered = d.IsTendered,
                                  ColumnIsCancelled = d.IsCancelled,
                                  ColumnSpace = ""
                              };

                    rowList = row.ToList();
                }

                return rowList;
            });
        }

        public void CreateSalesListDataGrid()
        {
            dataGridViewOpenSalesList.DataSource = dataOpenSalesListSource;
            dataGridViewBilledOutSalesList.DataSource = dataBilledOutSalesListSource;
            dataGridViewCollectedSalesList.DataSource = dataCollectedSalesListSource;
        }

        private void dataGridViewOpenSalesList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && dataGridViewOpenSalesList.CurrentCell.ColumnIndex == dataGridViewOpenSalesList.Columns["TabPageOpenColumnSalesNumber"].Index)
            {
                Controllers.TrnSalesController trnSalesController = new Controllers.TrnSalesController();
                Entities.TrnSalesEntity salesEntity = trnSalesController.DetailSales(Convert.ToInt32(dataGridViewOpenSalesList.Rows[dataGridViewOpenSalesList.CurrentCell.RowIndex].Cells[dataGridViewOpenSalesList.Columns["TabPageOpenColumnId"].Index].Value));

                trnPOSTouchActivityForm = new TrnPOSTouchActivityForm(sysSoftwareForm, this, salesEntity);
                trnPOSTouchActivityForm.ShowDialog();
            }
        }

        private void dataGridViewBilledOutSalesList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && dataGridViewBilledOutSalesList.CurrentCell.ColumnIndex == dataGridViewBilledOutSalesList.Columns["tabPageBilledOutColumnSalesNumber"].Index)
            {
                Controllers.TrnSalesController trnSalesController = new Controllers.TrnSalesController();
                Entities.TrnSalesEntity salesEntity = trnSalesController.DetailSales(Convert.ToInt32(dataGridViewBilledOutSalesList.Rows[dataGridViewBilledOutSalesList.CurrentCell.RowIndex].Cells[dataGridViewBilledOutSalesList.Columns["tabPageBilledOutColumnId"].Index].Value));

                trnPOSTouchActivityForm = new TrnPOSTouchActivityForm(sysSoftwareForm, this, salesEntity);
                trnPOSTouchActivityForm.ShowDialog();
            }
        }

        private void dataGridViewCollectedSalesList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && dataGridViewCollectedSalesList.CurrentCell.ColumnIndex == dataGridViewCollectedSalesList.Columns["tabPageCollectedColumnSalesNumber"].Index)
            {
                Controllers.TrnSalesController trnSalesController = new Controllers.TrnSalesController();
                Entities.TrnSalesEntity salesEntity = trnSalesController.DetailSales(Convert.ToInt32(dataGridViewCollectedSalesList.Rows[dataGridViewCollectedSalesList.CurrentCell.RowIndex].Cells[dataGridViewCollectedSalesList.Columns["tabPageCollectedColumnId"].Index].Value));

                trnPOSTouchActivityForm = new TrnPOSTouchActivityForm(sysSoftwareForm, this, salesEntity);
                trnPOSTouchActivityForm.ShowDialog();
            }
        }

        public void ClosePOSTouchActivity()
        {
            trnPOSTouchActivityForm.Close();
        }

        private void buttonDelivery_Click(object sender, EventArgs e)
        {

        }
    }
}
