using EasyPOS.Entities;
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
        private const int kitchenNoOfButtons = 5;
        private int kitchenPages;
        private int kitchenPage = 1;
        private String selectedKitchen;
        Button[] kitchenButtons;

        private List<Entities.SysKitchenItemEntity> listKitchenItems = new List<Entities.SysKitchenItemEntity>();
        private ToolTip kitchenItemToolTip = new ToolTip();
        private ToolTip kitchenItemToolTip2 = new ToolTip();
        private const int kitchenItemNoOfButtons = 20;
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
                buttonKitchen5
            };

            for (int i = 0; i < kitchenNoOfButtons; i++)
            {
                kitchenButtons[i].Click += new EventHandler(buttonKitchen_Click);
            }

            buttonKitchen1.BackColor = ColorTranslator.FromHtml("#7fbc00");

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
                buttonKitchenItem20
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
                DateTime salesDate = dateTimePickerSalesDate.Value.Date;
                Controllers.SysKitchenController sysKitchenController = new Controllers.SysKitchenController();

                listKitchenItems = sysKitchenController.ListKitchenItems(kitchen, salesDate);
                kitchenItemPages = listKitchenItems.Count();

                for (int i = 0; i < kitchenItemNoOfButtons; i++)
                {
                    kitchenItemToolTip.SetToolTip(kitchenItemButtons[i], "");
                    kitchenItemToolTip2.SetToolTip(kitchenItemButtons[i], "");

                    kitchenItemButtons[i].Text = "";

                    kitchenItemButtons[i].BackColor = SystemColors.Control;
                    kitchenItemButtons[i].ForeColor = Color.Black;
                }

                var listKitchenItemPage = listKitchenItems.Skip((kitchenItemPage - 1) * kitchenItemNoOfButtons).Take(kitchenItemNoOfButtons).ToList();
                if (listKitchenItemPage.Any())
                {
                    for (int i = 0; i < listKitchenItemPage.Count(); i++)
                    {
                        kitchenItemToolTip.SetToolTip(kitchenItemButtons[i], listKitchenItemPage[i].SalesId.ToString());
                        kitchenItemToolTip2.SetToolTip(kitchenItemButtons[i], listKitchenItemPage[i].BarCode.ToString());

                        if (listKitchenItemPage[i].IsPrepared == true)
                        {
                            kitchenItemButtons[i].BackColor = ColorTranslator.FromHtml("#F25022");
                            kitchenItemButtons[i].ForeColor = Color.White;
                        }
                        else
                        {
                            kitchenItemButtons[i].BackColor = SystemColors.Control;
                            kitchenItemButtons[i].ForeColor = Color.Black;
                        }

                        kitchenItemButtons[i].Text = listKitchenItemPage[i].OrderNumber + "\n"
                            + listKitchenItemPage[i].ItemDescription + "\n"
                            + listKitchenItemPage[i].Quantity.ToString("#,##0.00") + " " + listKitchenItemPage[i].Unit;
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
                buttonKitchen1.BackColor = ColorTranslator.FromHtml("#01A6F0");
                buttonKitchen2.BackColor = ColorTranslator.FromHtml("#01A6F0");
                buttonKitchen3.BackColor = ColorTranslator.FromHtml("#01A6F0");
                buttonKitchen4.BackColor = ColorTranslator.FromHtml("#01A6F0");
                buttonKitchen5.BackColor = ColorTranslator.FromHtml("#01A6F0");

                Button b = sender as Button;
                String kitchen = b.Text;

                b.BackColor = ColorTranslator.FromHtml("#7fbc00");

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

                String salesId = kitchenItemToolTip.GetToolTip(b);
                String barcode = kitchenItemToolTip2.GetToolTip(b);

                if (String.IsNullOrEmpty(salesId) == false && String.IsNullOrEmpty(barcode) == false)
                {
                    DialogResult doneDialogResult = MessageBox.Show("Done Item?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (doneDialogResult == DialogResult.Yes)
                    {
                        Controllers.SysKitchenController sysKitchenController = new Controllers.SysKitchenController();
                        String[] donePrepareItems = sysKitchenController.DonePrepareItem(Convert.ToInt32(salesId), barcode);
                        if (donePrepareItems[1].Equals("0") == false)
                        {
                            FillKitchenItem(selectedKitchen);
                        }
                        else
                        {
                            MessageBox.Show(donePrepareItems[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
