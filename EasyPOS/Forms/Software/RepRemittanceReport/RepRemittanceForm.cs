using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.RepRemittanceReport
{
    public partial class RepRemittanceForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        private Modules.SysUserRightsModule sysUserRights;

        public RepRemittanceForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            GetTerminalList();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void GetTerminalList()
        {
            Controllers.RepPOSReportController repPOSReportController = new Controllers.RepPOSReportController();
            if (repPOSReportController.DropdownListTerminal().Any())
            {
                comboBoxTerminal.DataSource = repPOSReportController.DropdownListTerminal();
                comboBoxTerminal.ValueMember = "Id";
                comboBoxTerminal.DisplayMember = "Terminal";

                GetUserList();
            }
        }

        public void GetUserList()
        {
            Controllers.RepPOSReportController repPOSReportController = new Controllers.RepPOSReportController();
            if (repPOSReportController.DropdownListUser().Any())
            {
                comboBoxUser.DataSource = repPOSReportController.DropdownListUser();
                comboBoxUser.ValueMember = "Id";
                comboBoxUser.DisplayMember = "FullName";
            }
        }

        private void listBoxRemittanceReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxRemittanceReport.SelectedItem != null)
            {
                String selectedItem = listBoxRemittanceReport.SelectedItem.ToString();
                switch (selectedItem)
                {
                    case "Remittance Report":
                        labelTerminal.Visible = true;
                        comboBoxTerminal.Visible = true;
                        dateTimePickerDate.Visible = true;
                        labelDate.Visible = true;
                        comboBoxUser.Visible = true;
                        labelUser.Visible = true;
                        textBoxRemittanceNumber.Visible = true;
                        labelRemittanceNumber.Visible = true;
                        comboBoxTerminal.Focus();
                        break;
                    default:
                        labelTerminal.Visible = false;
                        comboBoxTerminal.Visible = false;
                        dateTimePickerDate.Visible = false;
                        labelDate.Visible = false;
                        comboBoxUser.Visible = false;
                        labelUser.Visible = false;
                        textBoxRemittanceNumber.Visible = false;
                        labelRemittanceNumber.Visible = false;
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please select a report.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            if (listBoxRemittanceReport.SelectedItem != null)
            {
                String selectedItem = listBoxRemittanceReport.SelectedItem.ToString();
                switch (selectedItem)
                {
                    case "Remittance Report":
                        sysUserRights = new Modules.SysUserRightsModule("RepDisbursementRemittance");
                        if (sysUserRights.GetUserRights() == null)
                        {
                            MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (sysUserRights.GetUserRights().CanView == true)
                            {
                                RepRemittanceReportForm repRemittanceReportRemittanceReport = new RepRemittanceReportForm(this, dateTimePickerDate.Value.Date, Convert.ToInt32(comboBoxTerminal.SelectedValue), Convert.ToInt32(comboBoxUser.SelectedValue), textBoxRemittanceNumber.Text);
                                repRemittanceReportRemittanceReport.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        break;
                    default:
                        MessageBox.Show("Please select a report.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        break;
                }
            }
            else
            {
                MessageBox.Show("Please select a report.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_OnClick(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }
    }
}
