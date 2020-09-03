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
    public partial class TrnPOSDeliveryCustomerInformation : Form
    {
        public TrnPOSTouchForm trnPOSTouchForm;
        public Int32 customerId = 0;

        public TrnPOSDeliveryCustomerInformation(TrnPOSTouchForm POSTouchForm)
        {
            InitializeComponent();

            trnPOSTouchForm = POSTouchForm;
            GetCustomerList();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void GetCustomerList()
        {
            Controllers.TrnSalesController trnPOSSalesController = new Controllers.TrnSalesController();
            if (trnPOSSalesController.TenderSalesDropdownListCustomer().Any())
            {
                comboBoxTenderSalesCustomer.DataSource = trnPOSSalesController.TenderSalesDropdownListCustomer();
                comboBoxTenderSalesCustomer.ValueMember = "Id";
                comboBoxTenderSalesCustomer.DisplayMember = "Customer";
            }
        }

        private void comboBoxTenderSalesCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTenderSalesCustomer.SelectedItem == null)
            {
                return;
            }

            var selectedItemCustomer = (Entities.MstCustomerEntity)comboBoxTenderSalesCustomer.SelectedItem;
            if (selectedItemCustomer != null)
            {
                customerId = selectedItemCustomer.Id;
                textBoxCustomerPhoneNumber.Text = selectedItemCustomer.ContactNumber;
                textBoxCustomerContactName.Text = selectedItemCustomer.ContactPerson;
                textBoxCustomerAddress.Text = selectedItemCustomer.Address;
            }
        }

        private void textBoxCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                List<Entities.MstCustomerEntity> customers = (List<Entities.MstCustomerEntity>)comboBoxTenderSalesCustomer.DataSource;
                var customer = from d in customers
                               where d.CustomerCode == textBoxCustomerCode.Text
                               select d;

                if (customer.Any())
                {
                    comboBoxTenderSalesCustomer.SelectedValue = customer.FirstOrDefault().Id;
                }
                else
                {
                    MessageBox.Show("Invalid customer code.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (customerId == 0)
            {
                MessageBox.Show("Please select customer.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                trnPOSTouchForm.NewSales("delivery", customerId);
                Close();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    {
                        if (buttonOK.Enabled == true)
                        {
                            buttonOK.PerformClick();
                            Focus();
                        }

                        break;
                    }
                case Keys.Escape:
                    {
                        if (buttonClose.Enabled == true)
                        {
                            buttonClose.PerformClick();
                            Focus();
                        }

                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
