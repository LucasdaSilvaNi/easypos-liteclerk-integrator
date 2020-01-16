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

        public TrnSalesDetailDiscountForm(TrnSalesDetailForm salesDetailForm)
        {
            InitializeComponent();
            trnSalesDetailForm = salesDetailForm;

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
            if (trnSalesController.DiscountDetailSales(trnSalesDetailForm.trnSalesEntity.Id).DiscountId != null)
            {
                comboBoxDiscount.SelectedValue = trnSalesController.DiscountDetailSales(trnSalesDetailForm.trnSalesEntity.Id).DiscountId;
                textBoxSeniorCitizenID.Text = trnSalesController.DiscountDetailSales(trnSalesDetailForm.trnSalesEntity.Id).SeniorCitizenId;
                textBoxSeniorCitizenName.Text = trnSalesController.DiscountDetailSales(trnSalesDetailForm.trnSalesEntity.Id).SeniorCitizenName;
                textBoxSeniorCitizenAge.Text = trnSalesController.DiscountDetailSales(trnSalesDetailForm.trnSalesEntity.Id).SeniorCitizenAge.ToString();
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
            String[] discountSales = trnSalesController.DiscountSales(trnSalesDetailForm.trnSalesEntity.Id, salesEntity);
            if (discountSales[1].Equals("0") == false)
            {
                trnSalesDetailForm.trnSalesEntity.DiscountId = discountId;

                trnSalesDetailForm.GetSalesLineList();
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
