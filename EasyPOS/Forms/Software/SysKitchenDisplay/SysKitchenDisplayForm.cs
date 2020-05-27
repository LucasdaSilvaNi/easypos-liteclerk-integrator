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

        private List<Entities.SysKitchenEntity> listKitchens = new List<Entities.SysKitchenEntity>();
        private const int kitchenNoOfButtons = 10;
        private int kitchenPages;
        private int kitchenPage = 1;
        private String selectedKitchen;
        Button[] kitchenButtons;

        private List<Entities.SysKitchenItemEntity> listKitchenItems = new List<Entities.SysKitchenItemEntity>();
        private const int kitchenItemNoOfButtons = 60;
        private int kitchenItemPages;
        private int kitchenItemPage = 1;
        Button[] kitchenItemButtons;

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

            kitchenButtons = new Button[] {
                    buttonKitchen1,
                    buttonKitchen2,
                    buttonKitchen3,
                    buttonKitchen4,
                    buttonKitchen5,
                    buttonKitchen6,
                    buttonKitchen7,
                    buttonKitchen8,
                    buttonKitchen9,
                    buttonKitchen10
                };

            for (int i = 0; i < kitchenNoOfButtons; i++)
            {
                kitchenButtons[i].Click += new EventHandler(buttonKitchen_Click);
            }

            kitchenItemButtons = new Button[] {
                    buttonKitchenItem1,
                    buttonKitchenItem2,
                    buttonKitchenItem3,
                    buttonKitchenItem4,
                    buttonKitchenItem5,
                    buttonKitchenItem6,
                    buttonKitchenItem7,
                    buttonKitchenItem8,
                    buttonKitchenItem9,
                    buttonKitchenItem10,
                    buttonKitchenItem11,
                    buttonKitchenItem12,
                    buttonKitchenItem13,
                    buttonKitchenItem14,
                    buttonKitchenItem15,
                    buttonKitchenItem16,
                    buttonKitchenItem17,
                    buttonKitchenItem18,
                    buttonKitchenItem19,
                    buttonKitchenItem20,
                    buttonKitchenItem21,
                    buttonKitchenItem22,
                    buttonKitchenItem23,
                    buttonKitchenItem24,
                    buttonKitchenItem25,
                    buttonKitchenItem26,
                    buttonKitchenItem27,
                    buttonKitchenItem28,
                    buttonKitchenItem29,
                    buttonKitchenItem30,
                    buttonKitchenItem31,
                    buttonKitchenItem32,
                    buttonKitchenItem33,
                    buttonKitchenItem34,
                    buttonKitchenItem35,
                    buttonKitchenItem36,
                    buttonKitchenItem37,
                    buttonKitchenItem38,
                    buttonKitchenItem39,
                    buttonKitchenItem40,
                    buttonKitchenItem41,
                    buttonKitchenItem42,
                    buttonKitchenItem43,
                    buttonKitchenItem44,
                    buttonKitchenItem45,
                    buttonKitchenItem46,
                    buttonKitchenItem47,
                    buttonKitchenItem48,
                    buttonKitchenItem49,
                    buttonKitchenItem50,
                    buttonKitchenItem51,
                    buttonKitchenItem52,
                    buttonKitchenItem53,
                    buttonKitchenItem54,
                    buttonKitchenItem55,
                    buttonKitchenItem56,
                    buttonKitchenItem57,
                    buttonKitchenItem58,
                    buttonKitchenItem59,
                    buttonKitchenItem60
                };

            for (int i = 0; i < kitchenItemNoOfButtons; i++)
            {
                kitchenItemButtons[i].Click += new EventHandler(buttonKitchenItem_Click);
            }

            Controllers.SysKitchenController sysKitchenController = new Controllers.SysKitchenController();
            listKitchens = sysKitchenController.ListKitchen();
            kitchenPages = listKitchens.Count();

            FillKitchen();
        }

        private void FillKitchen()
        {
            try
            {
                for (int i = 0; i < kitchenNoOfButtons; i++)
                {
                    kitchenButtons[i].Text = "";
                }

                var listKitchenPage = listKitchens.Skip((kitchenPage - 1) * kitchenNoOfButtons).Take(kitchenNoOfButtons).ToList();
                if (listKitchenPage.Any())
                {
                    for (int i = 0; i < listKitchenPage.Count(); i++)
                    {
                        kitchenButtons[i].Text = listKitchenPage[i].Kitchen;
                    }
                }

                selectedKitchen = listKitchenPage[0].Kitchen;
                FillKitchenItem(selectedKitchen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillKitchenItem(String kitchen)
        {
            try
            {

                Controllers.SysKitchenController sysKitchenController = new Controllers.SysKitchenController();

                listKitchenItems = sysKitchenController.ListKitchenItems(kitchen);
                kitchenItemPages = listKitchenItems.Count();

                for (int i = 0; i < kitchenItemNoOfButtons; i++)
                {
                    kitchenItemButtons[i].Text = "";
                }

                var listKitchenItemPage = listKitchenItems.Skip((kitchenItemPage - 1) * kitchenItemNoOfButtons).Take(kitchenItemNoOfButtons).ToList();
                if (listKitchenItemPage.Any())
                {
                    for (int i = 0; i < listKitchenItemPage.Count(); i++)
                    {
                        kitchenItemButtons[i].Text = listKitchenItemPage[i].ItemDescription;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonKitchen_Click(object sender, EventArgs e)
        {
            try
            {
                Button b = sender as Button;
                String kitchen = b.Text;

                kitchenItemPage = 1;

                if (kitchen != "")
                {
                    FillKitchenItem(kitchen);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonKitchenItem_Click(object sender, EventArgs e)
        {
            try
            {
                Button b = sender as Button;
                String kitchenItem = b.Text;

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

        private void buttonKitchenPagePrevious_Click(object sender, EventArgs e)
        {
            kitchenPage--;
            if (kitchenPage == 0)
            {
                kitchenPage = 1;
            }

            kitchenItemPage = 1;

            FillKitchen();
        }

        private void buttonKitchenPageNext_Click(object sender, EventArgs e)
        {
            kitchenPage++;

            Int32 modulosPage = kitchenPages % kitchenNoOfButtons;
            Int32 maximumNoOfPages = (kitchenPages - modulosPage) / kitchenNoOfButtons;

            if (modulosPage > 0)
            {
                maximumNoOfPages += 1;
            }

            if (kitchenPage > maximumNoOfPages)
            {
                kitchenPage = maximumNoOfPages;
            }

            kitchenItemPage = 1;

            FillKitchen();
        }

        private void buttonKitchenItemPrevious_Click(object sender, EventArgs e)
        {
            kitchenItemPage--;
            if (kitchenItemPage == 0)
            {
                kitchenItemPage = 1;
            }

            FillKitchenItem(selectedKitchen);
        }

        private void buttonKitchenItemNext_Click(object sender, EventArgs e)
        {
            kitchenItemPage++;

            Int32 modulosPage = kitchenItemPages % kitchenItemNoOfButtons;
            Int32 maximumNoOfPages = (kitchenItemPages - modulosPage) / kitchenItemNoOfButtons;

            if (modulosPage > 0)
            {
                maximumNoOfPages += 1;
            }

            if (kitchenItemPage > maximumNoOfPages)
            {
                kitchenItemPage = maximumNoOfPages;
            }

            FillKitchenItem(selectedKitchen);
        }
    }
}
