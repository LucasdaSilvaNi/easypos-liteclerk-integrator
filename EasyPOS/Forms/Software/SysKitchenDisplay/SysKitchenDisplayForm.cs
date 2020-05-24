using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.SysKitchenDisplay
{
    public partial class SysKitchenDisplayForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        private Modules.SysUserRightsModule sysUserRights;

        public List<Entities.DgvTrnSalesListEntity> salesList;

        public BindingSource dataOpenSalesListSource = new BindingSource();
        public BindingSource dataBilledOutSalesListSource = new BindingSource();
        public BindingSource dataCollectedSalesListSource = new BindingSource();

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
        Button[] tableButtons;

        public SysKitchenDisplayForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();

            sysUserRights = new Modules.SysUserRightsModule("TrnSales");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                GetTerminalList();
            }

            sysSoftwareForm = softwareForm;

            Controllers.TrnSalesController trnSalesController = new Controllers.TrnSalesController();
            listTableGroups = trnSalesController.ListTableGroup();
            tableGroupPages = listTableGroups.Count();

            tableButtons = new Button[] {
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
                tableButtons[i].Click += new EventHandler(buttonTable_Click);
            }

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

                //for (int i = 0; i < tableGroupNoOfButtons; i++)
                //{
                //    tableGroupToolTip.SetToolTip(tableGroupButtons[i], "");
                //    tableGroupButtons[i].Text = "";
                //}

                //var listTableGroupPage = listTableGroups.Skip((tableGroupPage - 1) * tableGroupNoOfButtons).Take(tableGroupNoOfButtons).ToList();
                //if (listTableGroupPage.Any())
                //{
                //    for (int i = 0; i < listTableGroupPage.Count(); i++)
                //    {
                //        tableGroupToolTip.SetToolTip(tableGroupButtons[i], listTableGroupPage[i].Id.ToString());
                //        tableGroupButtons[i].Text = listTableGroupPage[i].TableGroup;
                //    }
                //}

                //selectedTableGroupId = listTableGroupPage[0].Id;
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
                //Controllers.TrnSalesController trnSalesController = new Controllers.TrnSalesController();

                //listTables = trnSalesController.ListTable(tableGroupId);
                //tablePages = listTables.Count();

                //for (int i = 0; i < tableNoOfButtons; i++)
                //{
                //    tableToolTip.SetToolTip(tableButtons[i], "");
                //    tableButtons[i].Text = "";
                //}

                //var listTablePage = listTables.Skip((tablePage - 1) * tableNoOfButtons).Take(tableNoOfButtons).ToList();
                //if (listTablePage.Any())
                //{
                //    for (int i = 0; i < listTablePage.Count(); i++)
                //    {
                //        tableToolTip.SetToolTip(tableButtons[i], listTablePage[i].TableCode.ToString());
                //        tableButtons[i].Text = listTablePage[i].TableCode;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonTable_Click(object sender, EventArgs e)
        {
            try
            {
                Button b = sender as Button;
                String tableCode = tableToolTip.GetToolTip(b);

                //Controllers.TrnSalesController trnPOSSalesController = new Controllers.TrnSalesController();
                //String[] addSales = trnPOSSalesController.AddSales(tableCode);

                //if (addSales[1].Equals("0") == false)
                //{
                //    sysSoftwareForm.AddTabPagePOSTouchSalesDetail(this, trnPOSSalesController.DetailSales(Convert.ToInt32(addSales[1])));
                //    UpdateSalesListGridDataSource();
                //}
                //else
                //{
                //    MessageBox.Show(addSales[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
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

        private void tabControlSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GetTerminalList()
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
