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

        public Int32 orderNumberSelectedValue = 0;

        public SysKitchenDisplayForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();

            sysUserRights = new Modules.SysUserRightsModule("TrnSales");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void GetorderNumberList(String kitchen)
        {
            DateTime salesDate = dateTimePickerSalesDate.Value.Date;

            Controllers.SysKitchenController sysKitchenController = new Controllers.SysKitchenController();
            if (sysKitchenController.DropdownListOrderNumber(kitchen, salesDate).Any())
            {
                List<SysKitchenItemEntity> newSalesList = new List<SysKitchenItemEntity>();
                newSalesList.Add(new SysKitchenItemEntity
                {
                    SalesId = 0,
                    OrderNumber = "ALL"
                });

                foreach (var obj in sysKitchenController.DropdownListOrderNumber(kitchen, salesDate))
                {
                    newSalesList.Add(new SysKitchenItemEntity
                    {
                        SalesId = obj.SalesId,
                        OrderNumber = obj.OrderNumber
                    });
                };

                comboBoxSINumber.DataSource = newSalesList;
                comboBoxSINumber.ValueMember = "SalesId";
                comboBoxSINumber.DisplayMember = "OrderNumber";

                FillKitchenItem(kitchen);
                GetDoneItems();
            }
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

                GetorderNumberList(selectedKitchen);
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

                Int32 salesId = orderNumberSelectedValue;
               
                listKitchenItems = sysKitchenController.ListKitchenItems(kitchen, salesDate, salesId);
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
                    Int32 Number = 1;

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

                        kitchenItemButtons[i].Text = "No. " + Number.ToString() + " " + "("
                            + listKitchenItemPage[i].OrderNumber + ")" + "\n"
                            + listKitchenItemPage[i].UpdateDateTime + "\n"
                            + listKitchenItemPage[i].Alias + "\n"
                            + listKitchenItemPage[i].Quantity.ToString("#,##0.00") + " " + listKitchenItemPage[i].Unit + "\n"
                            + listKitchenItemPage[i].Preparation;

                        Number += 1;
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
                for (int i = 0; i < kitchenNoOfButtons; i++)
                {
                    kitchenButtons[i].BackColor = ColorTranslator.FromHtml("#01A6F0");
                }

                Button b = sender as Button;
                String kitchen = b.Text;

                selectedKitchen = kitchen;

                b.BackColor = ColorTranslator.FromHtml("#7fbc00");

                kitchenItemPage = 1;

                if (kitchen != "")
                {
                    FillKitchenItem(kitchen);
                    GetDoneItems();
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
                for (int i = 0; i < kitchenItemNoOfButtons; i++)
                {
                    kitchenItemButtons[i].BackColor = SystemColors.Control;
                    kitchenItemButtons[i].ForeColor = Color.Black;
                }

                Button b = sender as Button;
                String kitchenItem = b.Text;

                b.BackColor = ColorTranslator.FromHtml("#F25022");
                b.ForeColor = Color.White;

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
                            GetDoneItems();
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

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            FillKitchenItem(selectedKitchen);
            GetDoneItems();
        }

        public void GetDoneItems()
        {
            DateTime salesDate = dateTimePickerSalesDate.Value.Date;

            dataGridViewDoneItemDisplay.Rows.Clear();
            dataGridViewDoneItemDisplay.Refresh();

            Controllers.SysKitchenController sysKitchenController = new Controllers.SysKitchenController();
            if (sysKitchenController.ListKitchenPreparedItems(selectedKitchen, salesDate).Any())
            {
                var doneItems = sysKitchenController.ListKitchenPreparedItems(selectedKitchen, salesDate).ToList();
                if (doneItems.Any())
                {
                    string nl = Environment.NewLine;

                    foreach (var doneItem in doneItems)
                    {
                        dataGridViewDoneItemDisplay.Rows.Add(
                            doneItem.OrderNumber + nl + doneItem.Alias,
                            doneItem.Quantity.ToString("#,##0")
                        );
                    }
                }
            }
        }

        private void dateTimePickerSalesDate_ValueChanged(object sender, EventArgs e)
        {
            GetorderNumberList(selectedKitchen);
        }

        private void comboBoxSINumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            int selectedValue = (int)cmb.SelectedValue;

            orderNumberSelectedValue = selectedValue;

            FillKitchenItem(selectedKitchen);
            GetDoneItems();
        }
    }
}
