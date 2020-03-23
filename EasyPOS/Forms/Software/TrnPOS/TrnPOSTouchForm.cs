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

        public List<Entities.DgvTrnSalesListEntity> salesList;

        public BindingSource dataOpenSalesListSource = new BindingSource();
        public BindingSource dataBilledOutSalesListSource = new BindingSource();
        public BindingSource dataCollectedSalesListSource = new BindingSource();

        public TrnPOSTouchActivityForm trnPOSTouchActivityForm;

        private List<Entities.MstTableGroupEntity> listTableGroups = new List<Entities.MstTableGroupEntity>();
        private ToolTip tableGroupToolTip = new ToolTip();
        private const int tableGroupNoOfButtons = 6;
        private int tableGroupPages;
        private int tableGroupPage = 1;
        private Int32 selectedTableGroupId;

        private List<Entities.MstTableEntity> listTables = new List<Entities.MstTableEntity>();
        private ToolTip tableToolTip = new ToolTip();
        private const int tableNoOfButtons = 30;
        private int tablePages;
        private int tablePage = 1;

        public TrnPOSTouchForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();

            String currentDate = DateTime.Today.ToShortDateString() + "\t\t";
            if (Modules.SysCurrentModule.GetCurrentSettings().IsLoginDate == "True")
            {
                currentDate = Modules.SysCurrentModule.GetCurrentSettings().CurrentDate + "\t\t";
            }

            dateTimePickerSalesDate.Value = Convert.ToDateTime(currentDate);

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
            }

            Controllers.TrnSalesController trnPOSSalesController = new Controllers.TrnSalesController();
            textBoxLastChange.Text = trnPOSSalesController.GetLastChange(Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().TerminalId)).ToString("#,##0.00");

            sysSoftwareForm = softwareForm;

            Controllers.TrnSalesController trnSalesController = new Controllers.TrnSalesController();
            listTableGroups = trnSalesController.ListTableGroup();
            tableGroupPages = listTableGroups.Count();

            FillTableGroup();
        }

        private void FillTableGroup()
        {
            try
            {
                Button[] tableGroupButtons = new Button[] {
                    buttonTableGroup1,
                    buttonTableGroup2,
                    buttonTableGroup3,
                    buttonTableGroup4,
                    buttonTableGroup5,
                    buttonTableGroup6
                };

                for (int i = 0; i < tableGroupNoOfButtons; i++)
                {
                    tableGroupToolTip.SetToolTip(tableGroupButtons[i], "");
                    tableGroupButtons[i].Text = "";
                }

                var listTableGroupPage = listTableGroups.Skip((tableGroupPage - 1) * tableGroupNoOfButtons).Take(tableGroupNoOfButtons).ToList();
                if (listTableGroupPage.Any())
                {
                    for (int i = 0; i < listTableGroupPage.Count(); i++)
                    {
                        tableGroupToolTip.SetToolTip(tableGroupButtons[i], listTableGroupPage[i].Id.ToString());
                        tableGroupButtons[i].Text = listTableGroupPage[i].TableGroup;
                    }
                }

                selectedTableGroupId = listTableGroupPage[0].Id;
                FillTable(selectedTableGroupId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillTable(Int32 tableGroupId)
        {
            try
            {
                Controllers.TrnSalesController trnSalesController = new Controllers.TrnSalesController();

                listTables = trnSalesController.ListTable(tableGroupId);
                tablePages = listTables.Count();

                Button[] tableButtons = new Button[] {
                    buttonTable1,
                    buttonTable2,
                    buttonTable3,
                    buttonTable4,
                    buttonTable5,
                    buttonTable6,
                    buttonTable7,
                    buttonTable8,
                    buttonTable9,
                    buttonTable10,
                    buttonTable11,
                    buttonTable12,
                    buttonTable13,
                    buttonTable14,
                    buttonTable15,
                    buttonTable16,
                    buttonTable17,
                    buttonTable18,
                    buttonTable19,
                    buttonTable20,
                    buttonTable21,
                    buttonTable22,
                    buttonTable23,
                    buttonTable24,
                    buttonTable25,
                    buttonTable26,
                    buttonTable27,
                    buttonTable28,
                    buttonTable29,
                    buttonTable30
                };

                for (int i = 0; i < tableNoOfButtons; i++)
                {
                    tableToolTip.SetToolTip(tableButtons[i], "");
                    tableButtons[i].Text = "";
                }

                var listTablePage = listTables.Skip((tablePage - 1) * tableNoOfButtons).Take(tableNoOfButtons).ToList();
                if (listTablePage.Any())
                {
                    for (int i = 0; i < listTablePage.Count(); i++)
                    {
                        tableToolTip.SetToolTip(tableButtons[i], listTablePage[i].Id.ToString());
                        tableButtons[i].Text = listTablePage[i].TableCode;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }

        private void buttonWalkIn_Click(object sender, EventArgs e)
        {
            NewWalkInSales();
        }

        public void NewWalkInSales()
        {
            Controllers.TrnSalesController trnPOSSalesController = new Controllers.TrnSalesController();
            String[] addSales = trnPOSSalesController.AddSales("Walk-in");
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

        public async Task<List<Entities.DgvTrnSalesListEntity>> GetSalesListDataTask(DateTime salesDate, Int32 terminalId, String filter)
        {
            return await Task.Factory.StartNew(() =>
            {
                List<Entities.DgvTrnSalesListEntity> rowList = new List<Entities.DgvTrnSalesListEntity>();

                Controllers.TrnSalesController trnPOSSalesController = new Controllers.TrnSalesController();
                var salesList = trnPOSSalesController.POSTTouchListSales(salesDate, terminalId);
                if (salesList.Any())
                {
                    var row = from d in salesList
                              select new Entities.DgvTrnSalesListEntity
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
                                  ColumnTable = d.Table,
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

        private void buttonTableGroupPagePrevious_Click(object sender, EventArgs e)
        {
            tableGroupPage--;
            if (tableGroupPage == 0)
            {
                tableGroupPage = 1;
            }

            tablePage = 1;

            FillTableGroup();
        }

        private void buttonTableGroupPageNext_Click(object sender, EventArgs e)
        {
            tableGroupPage++;

            Int32 modulosPage = tableGroupPages % tableGroupNoOfButtons;
            Int32 maximumNoOfPages = (tableGroupPages - modulosPage) / tableGroupNoOfButtons;

            if (modulosPage > 0)
            {
                maximumNoOfPages += 1;
            }

            if (tableGroupPage > maximumNoOfPages)
            {
                tableGroupPage = maximumNoOfPages;
            }

            tablePage = 1;

            FillTableGroup();
        }

        private void buttonTableGroup1_Click(object sender, EventArgs e)
        {
            tablePage = 1;

            if (tableGroupToolTip.GetToolTip(buttonTableGroup1) != "")
            {
                Int32 tableGroupId = Convert.ToInt32(tableGroupToolTip.GetToolTip(buttonTableGroup1));
                selectedTableGroupId = tableGroupId;
                FillTable(tableGroupId);
            }
        }

        private void buttonTableGroup2_Click(object sender, EventArgs e)
        {
            tablePage = 1;

            if (tableGroupToolTip.GetToolTip(buttonTableGroup2) != "")
            {
                Int32 tableGroupId = Convert.ToInt32(tableGroupToolTip.GetToolTip(buttonTableGroup2));
                selectedTableGroupId = tableGroupId;
                FillTable(tableGroupId);
            }
        }

        private void buttonTableGroup3_Click(object sender, EventArgs e)
        {
            tablePage = 1;

            if (tableGroupToolTip.GetToolTip(buttonTableGroup3) != "")
            {
                Int32 tableGroupId = Convert.ToInt32(tableGroupToolTip.GetToolTip(buttonTableGroup3));
                selectedTableGroupId = tableGroupId;
                FillTable(tableGroupId);
            }
        }

        private void buttonTableGroup4_Click(object sender, EventArgs e)
        {
            tablePage = 1;

            if (tableGroupToolTip.GetToolTip(buttonTableGroup4) != "")
            {
                Int32 tableGroupId = Convert.ToInt32(tableGroupToolTip.GetToolTip(buttonTableGroup4));
                selectedTableGroupId = tableGroupId;
                FillTable(tableGroupId);
            }
        }

        private void buttonTableGroup5_Click(object sender, EventArgs e)
        {
            tablePage = 1;

            if (tableGroupToolTip.GetToolTip(buttonTableGroup5) != "")
            {
                Int32 tableGroupId = Convert.ToInt32(tableGroupToolTip.GetToolTip(buttonTableGroup5));
                selectedTableGroupId = tableGroupId;
                FillTable(tableGroupId);
            }
        }

        private void buttonTableGroup6_Click(object sender, EventArgs e)
        {
            tablePage = 1;

            if (tableGroupToolTip.GetToolTip(buttonTableGroup5) != "")
            {
                Int32 tableGroupId = Convert.ToInt32(tableGroupToolTip.GetToolTip(buttonTableGroup5));
                selectedTableGroupId = tableGroupId;
                FillTable(tableGroupId);
            }
        }

        private void buttonTablePrevious_Click(object sender, EventArgs e)
        {
            tablePage--;
            if (tablePage == 0)
            {
                tablePage = 1;
            }

            FillTable(selectedTableGroupId);
        }

        private void buttonTableNext_Click(object sender, EventArgs e)
        {
            tablePage++;

            Int32 modulosPage = tablePages % tableNoOfButtons;
            Int32 maximumNoOfPages = (tablePages - modulosPage) / tableNoOfButtons;

            if (modulosPage > 0)
            {
                maximumNoOfPages += 1;
            }

            if (tablePage > maximumNoOfPages)
            {
                tablePage = maximumNoOfPages;
            }

            FillTable(selectedTableGroupId);
        }
    }
}
