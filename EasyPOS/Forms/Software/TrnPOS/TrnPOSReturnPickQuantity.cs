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
    public partial class TrnPOSReturnPickQuantity : Form
    {
        public TrnPOSReturn trnPOSReturn;

        public TrnPOSReturnPickQuantity(TrnPOSReturn POSReturn)
        {
            InitializeComponent();

            textBoxReturnQuantity.Text = "0.00";
            trnPOSReturn = POSReturn;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Decimal quantity = Convert.ToDecimal(textBoxReturnQuantity.Text);
            trnPOSReturn.UpdateReturnQuantity(quantity);

            Close();
        }

        private void textBoxReturnQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxReturnQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Decimal quantity = Convert.ToDecimal(textBoxReturnQuantity.Text);
                trnPOSReturn.UpdateReturnQuantity(quantity);

                Close();
            }
        }
    }
}
