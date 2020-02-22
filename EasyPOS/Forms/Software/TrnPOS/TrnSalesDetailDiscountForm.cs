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
    public partial class TrnSalesDetailDiscountForm : Form
    {
        public TrnSalesDetailForm trnSalesDetailForm;
        public TrnPOSTouchDetailForm trnPOSTouchDetailForm;

        public TrnSalesDetailDiscountForm(TrnSalesDetailForm salesDetailForm, TrnPOSTouchDetailForm POSTouchDetailForm)
        {
            InitializeComponent();

            trnSalesDetailForm = salesDetailForm;
            trnPOSTouchDetailForm = POSTouchDetailForm;

            GetDiscount();
        }

        public void GetDiscount()
        {
            Controllers.TrnSalesController trnSalesController = new Controllers.TrnSalesController();
            if (trnSalesController.DropdownListDiscount().Any())
            {
                comboBoxDiscount.DataSource = trnSalesController.DropdownListDiscount();
                comboBoxDiscount.ValueMember = "Id";
                comboBoxDiscount.DisplayMember = "Discount";

                GetSalesDiscountInformation();
            }
        }

        public void GetSalesDiscountInformation()
        {
            Controllers.TrnSalesController trnSalesController = new Controllers.TrnSalesController();

            Int32? discountId = null;
            String seniorCitizenID = "";
            String seniorCitizenName = "";
            String seniorCitizenAge = "";

            if (trnSalesDetailForm != null)
            {
                discountId = trnSalesController.DiscountDetailSales(trnSalesDetailForm.trnSalesEntity.Id).DiscountId;
                seniorCitizenID = trnSalesController.DiscountDetailSales(trnSalesDetailForm.trnSalesEntity.Id).SeniorCitizenId;
                seniorCitizenName = trnSalesController.DiscountDetailSales(trnSalesDetailForm.trnSalesEntity.Id).SeniorCitizenName;
                seniorCitizenAge = trnSalesController.DiscountDetailSales(trnSalesDetailForm.trnSalesEntity.Id).SeniorCitizenAge.ToString();
            }

            if (trnPOSTouchDetailForm != null)
            {
                discountId = trnSalesController.DiscountDetailSales(trnPOSTouchDetailForm.trnSalesEntity.Id).DiscountId;
                seniorCitizenID = trnSalesController.DiscountDetailSales(trnPOSTouchDetailForm.trnSalesEntity.Id).SeniorCitizenId;
                seniorCitizenName = trnSalesController.DiscountDetailSales(trnPOSTouchDetailForm.trnSalesEntity.Id).SeniorCitizenName;
                seniorCitizenAge = trnSalesController.DiscountDetailSales(trnPOSTouchDetailForm.trnSalesEntity.Id).SeniorCitizenAge.ToString();
            }

            if (discountId != null)
            {
                comboBoxDiscount.SelectedValue = discountId;
                textBoxSeniorCitizenID.Text = seniorCitizenID;
                textBoxSeniorCitizenName.Text = seniorCitizenName;
                textBoxSeniorCitizenAge.Text = seniorCitizenAge;
            }
            else
            {
                textBoxSeniorCitizenAge.Text = "0";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Int32 discountId = Convert.ToInt32(comboBoxDiscount.SelectedValue);
            String seniorCitizenID = textBoxSeniorCitizenID.Text;
            String seniorCitizenName = textBoxSeniorCitizenName.Text;
            Int32 seniorCitizenAge = Convert.ToInt32(textBoxSeniorCitizenAge.Text);

            Entities.TrnSalesEntity salesEntity = new Entities.TrnSalesEntity()
            {
                DiscountId = discountId,
                SeniorCitizenId = seniorCitizenID,
                SeniorCitizenName = seniorCitizenName,
                SeniorCitizenAge = seniorCitizenAge
            };

            Controllers.TrnSalesController trnSalesController = new Controllers.TrnSalesController();

            String[] discountSales = new String[2];

            if (trnSalesDetailForm != null)
            {
                discountSales = trnSalesController.DiscountSales(trnSalesDetailForm.trnSalesEntity.Id, salesEntity);
            }

            if (trnPOSTouchDetailForm != null)
            {
                discountSales = trnSalesController.DiscountSales(trnPOSTouchDetailForm.trnSalesEntity.Id, salesEntity);
            }

            if (discountSales[1].Equals("0") == false)
            {
                if (trnSalesDetailForm != null)
                {
                    trnSalesDetailForm.trnSalesEntity.DiscountId = discountId;
                    trnSalesDetailForm.GetSalesLineList();
                }

                if (trnPOSTouchDetailForm != null)
                {
                    trnPOSTouchDetailForm.trnSalesEntity.DiscountId = discountId;
                    trnPOSTouchDetailForm.GetSalesLineList();
                }

                Close();
            }
            else
            {
                MessageBox.Show(discountSales[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxSeniorCitizenAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void comboBoxDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDiscount.SelectedItem == null)
            {
                return;
            }

            var selectedItemDiscount = (Entities.MstDiscountEntity)comboBoxDiscount.SelectedItem;
            if (selectedItemDiscount != null)
            {
                if (selectedItemDiscount.Id == 7 || selectedItemDiscount.Id == 16)
                {
                    textBoxSeniorCitizenID.Enabled = true;
                    textBoxSeniorCitizenName.Enabled = true;
                    textBoxSeniorCitizenAge.Enabled = true;
                }
                else
                {
                    textBoxSeniorCitizenID.Enabled = false;
                    textBoxSeniorCitizenName.Enabled = false;
                    textBoxSeniorCitizenAge.Enabled = false;

                    textBoxSeniorCitizenID.Text = String.Empty;
                    textBoxSeniorCitizenName.Text = String.Empty;
                    textBoxSeniorCitizenAge.Text = "0";
                }
            }
        }

        private void textBoxSeniorCitizenAge_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxSeniorCitizenAge.Text))
            {
                textBoxSeniorCitizenAge.Text = "0";
            }
            else
            {
                textBoxSeniorCitizenAge.Text = Convert.ToDecimal(textBoxSeniorCitizenAge.Text).ToString("#,##0");
            }
        }
    }
}
