using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.RepPOSReport
{
    public partial class RepPOSReportForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public RepPOSReportForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            GetTerminalList();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
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

        private void listBoxPOSReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedItem = listBoxPOSReport.SelectedItem.ToString();
            switch (selectedItem)
            {
                case "Z Reading Report":
                    labelTerminal.Visible = true;
                    comboBoxTerminal.Visible = true;
                    dateTimePickerDate.Visible = true;
                    labelDate.Visible = true;
                    comboBoxUser.Visible = false;
                    labelUser.Visible = false;

                    break;
                case "X Reading Report":
                    labelTerminal.Visible = true;
                    comboBoxTerminal.Visible = true;
                    dateTimePickerDate.Visible = true;
                    labelDate.Visible = true;
                    comboBoxUser.Visible = true;
                    labelUser.Visible = true;

                    break;
                default:
                    break;
            }
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            if (listBoxPOSReport.SelectedItem != null)
            {
                String selectedItem = listBoxPOSReport.SelectedItem.ToString();
                switch (selectedItem)
                {
                    case "Z Reading Report":
                        Reports.RepZReadingReportForm repZReadingReportForm = new Reports.RepZReadingReportForm(this, Convert.ToInt32(comboBoxTerminal.SelectedValue), Convert.ToDateTime(dateTimePickerDate.Value.ToShortDateString()));
                        repZReadingReportForm.ShowDialog();

                        break;
                    case "X Reading Report":
                        Reports.RepXReadingReportForm repXReadingReportForm = new Reports.RepXReadingReportForm(this, Convert.ToInt32(comboBoxTerminal.SelectedValue), Convert.ToDateTime(dateTimePickerDate.Value.ToShortDateString()), Convert.ToInt32(comboBoxUser.SelectedValue));
                        repXReadingReportForm.ShowDialog();

                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please select a report.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
