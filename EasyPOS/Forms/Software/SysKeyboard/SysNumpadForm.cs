using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.SysKeyboard
{
    public partial class SysNumpadForm : Form
    {
        public TrnPOS.TrnPOSTenderForm trnSalesDetailTenderForm;
        public DataGridView mstDataGridViewTenderPayType;

        public SysNumpadForm(TrnPOS.TrnPOSTenderForm salesDetailTenderForm, DataGridView dataGridViewTenderPayType)
        {
            InitializeComponent();

            trnSalesDetailTenderForm = salesDetailTenderForm;
            mstDataGridViewTenderPayType = dataGridViewTenderPayType;
        }

        private void button50_Click(object sender, EventArgs e)
        {
            textBoxNumber.Text = "50";
        }

        private void button100_Click(object sender, EventArgs e)
        {
            textBoxNumber.Text = "100";
        }

        private void button500_Click(object sender, EventArgs e)
        {
            textBoxNumber.Text = "500";
        }

        private void button1000_Click(object sender, EventArgs e)
        {
            textBoxNumber.Text = "1000";
        }

        private void buttonDEL_Click(object sender, EventArgs e)
        {
            textBoxNumber.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxNumber.Text.Length <= 13)
            {
                textBoxNumber.Text += "1";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxNumber.Text.Length <= 13)
            {
                textBoxNumber.Text += "2";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBoxNumber.Text.Length <= 13)
            {
                textBoxNumber.Text += "3";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBoxNumber.Text.Length <= 13)
            {
                textBoxNumber.Text += "4";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBoxNumber.Text.Length <= 13)
            {
                textBoxNumber.Text += "5";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBoxNumber.Text.Length <= 13)
            {
                textBoxNumber.Text += "6";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBoxNumber.Text.Length <= 13)
            {
                textBoxNumber.Text += "7";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBoxNumber.Text.Length <= 13)
            {
                textBoxNumber.Text += "8";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBoxNumber.Text.Length <= 13)
            {
                textBoxNumber.Text += "9";
            }
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (textBoxNumber.Text.Length <= 13)
            {
                textBoxNumber.Text += "0";
            }
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            if (textBoxNumber.Text.Length <= 13)
            {
                textBoxNumber.Text += ".";
            }
        }

        private void buttonComma_Click(object sender, EventArgs e)
        {
            if (textBoxNumber.Text.Length <= 13)
            {
                textBoxNumber.Text += ",";
            }
        }

        private void buttonNegative_Click(object sender, EventArgs e)
        {
            if (textBoxNumber.Text.Length == 0)
            {
                textBoxNumber.Text += "-";
            }
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if (textBoxNumber.Text.Length > 0)
            {
                textBoxNumber.Text = textBoxNumber.Text.Remove(textBoxNumber.Text.Length - 1);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal amount = Convert.ToDecimal(textBoxNumber.Text);
                mstDataGridViewTenderPayType.CurrentRow.Cells[4].Value = amount.ToString("#,##0.00");

                mstDataGridViewTenderPayType.Refresh();
                Close();

                mstDataGridViewTenderPayType.Focus();
                mstDataGridViewTenderPayType.CurrentRow.Cells[2].Selected = true;

                trnSalesDetailTenderForm.ComputeAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SysKeyboardNumpadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mstDataGridViewTenderPayType.Focus();
            mstDataGridViewTenderPayType.CurrentRow.Cells[2].Selected = true;
        }
    }
}
