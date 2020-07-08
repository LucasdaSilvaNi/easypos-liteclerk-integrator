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
    public partial class TrnPOSTouchActivityDeliver : Form
    {
        TrnPOSTouchForm trnPOSTouchForm;
        TrnPOSTouchActivityForm trnPOSTouchActivityForm;
        public Int32 salesId;

        public TrnPOSTouchActivityDeliver(TrnPOSTouchForm POSTouchForm, TrnPOSTouchActivityForm POSTouchActivityForm, Int32 currentSalesId, String remarks)
        {
            InitializeComponent();

            trnPOSTouchForm = POSTouchForm;
            trnPOSTouchActivityForm = POSTouchActivityForm;
            salesId = currentSalesId;

            textBoxRemarks.Text = remarks;

            ListDrivers();
        }

        public void ListDrivers()
        {
            Controllers.TrnSalesController trnPOSSalesController = new Controllers.TrnSalesController();
            if (trnPOSSalesController.DropdownListDriver().Any())
            {
                comboBoxDeliveredBy.DataSource = trnPOSSalesController.DropdownListDriver();
                comboBoxDeliveredBy.ValueMember = "FullName";
                comboBoxDeliveredBy.DisplayMember = "FullName";
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            AssignDeliveryMan();
        }

        public void AssignDeliveryMan()
        {
            String driverName = comboBoxDeliveredBy.Text;

            DialogResult assignDriverDialogResult = MessageBox.Show("Assign Driver? ", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (assignDriverDialogResult == DialogResult.Yes)
            {
                Controllers.TrnSalesController trnSalesController = new Controllers.TrnSalesController();

                String[] assignDriver = trnSalesController.AssignDriverSales(salesId, driverName);
                if (assignDriver[1].Equals("0") == false)
                {
                    MessageBox.Show("Assign Successful.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    trnPOSTouchForm.UpdateSalesListGridDataSource();
                    trnPOSTouchActivityForm.Close();
                }
                else
                {
                    MessageBox.Show(assignDriver[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBoxDeliveredBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AssignDeliveryMan();
            }
        }
    }
}
