using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.TrnStockOut
{
    public partial class TrnStockOutDetailStockOutLineItemDetailForm : Form
    {
        public TrnStockOutDetailForm trnStockOutDetailForm;
        public Entities.TrnStockOutLineEntity trnStockOutLineEntity;

        public TrnStockOutDetailStockOutLineItemDetailForm(TrnStockOutDetailForm stockOutDetailForm, Entities.TrnStockOutLineEntity stockOutLineEntity)
        {
            InitializeComponent();

            trnStockOutDetailForm = stockOutDetailForm;
            trnStockOutLineEntity = stockOutLineEntity;

            GetStockOutLineItemDetail();

            textBoxStockOutLineQuantity.Focus();
            textBoxStockOutLineQuantity.SelectAll();
        }

        public void GetStockOutLineItemDetail()
        {
            textBoxStockOutLineItemDescription.Text = trnStockOutLineEntity.ItemDescription;
            textBoxStockOutLineQuantity.Text = trnStockOutLineEntity.Quantity.ToString("#,##0.00");
            textBoxStockOutLineUnit.Text = trnStockOutLineEntity.Unit;
            textBoxStockOutLineCost.Text = trnStockOutLineEntity.Cost.ToString("#,##0.00");
            textBoxStockOutLineAmount.Text = trnStockOutLineEntity.Amount.ToString("#,##0.00");
        }

        public void ComputeAmount()
        {
            try
            {
                if (String.IsNullOrEmpty(textBoxStockOutLineQuantity.Text) == false && String.IsNullOrEmpty(textBoxStockOutLineCost.Text) == false)
                {
                    Decimal quantity = Convert.ToDecimal(textBoxStockOutLineQuantity.Text);
                    Decimal cost = Convert.ToDecimal(textBoxStockOutLineCost.Text);
                    Decimal amount = cost * quantity;

                    textBoxStockOutLineAmount.Text = amount.ToString("#,##0.00");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveStockOutLine();
        }

        public void SaveStockOutLine()
        {
            var id = trnStockOutLineEntity.Id;
            var stockOutId = trnStockOutLineEntity.StockOutId;
            var itemId = trnStockOutLineEntity.ItemId;
            var itemDescription = trnStockOutLineEntity.ItemDescription;
            var unitId = trnStockOutLineEntity.UnitId;
            var unit = trnStockOutLineEntity.Unit;
            var quantity = Convert.ToDecimal(textBoxStockOutLineQuantity.Text);
            var cost = Convert.ToDecimal(textBoxStockOutLineCost.Text);
            var amount = Convert.ToDecimal(textBoxStockOutLineAmount.Text);
            var assetAccountId = trnStockOutLineEntity.AssetAccountId;
            var assetAccount = trnStockOutLineEntity.AssetAccount;

            Entities.TrnStockOutLineEntity newStockOutLineEntity = new Entities.TrnStockOutLineEntity()
            {
                Id = id,
                StockOutId = stockOutId,
                ItemId = itemId,
                ItemDescription = itemDescription,
                UnitId = unitId,
                Unit = unit,
                Quantity = quantity,
                Cost = cost,
                Amount = amount,
                AssetAccountId = assetAccountId,
                AssetAccount = assetAccount
            };

            Controllers.TrnStockOutLineController trnPOSStockOutLineController = new Controllers.TrnStockOutLineController();
            if (newStockOutLineEntity.Id == 0)
            {
                String[] addStockOut = trnPOSStockOutLineController.AddStockOutLine(newStockOutLineEntity);
                if (addStockOut[1].Equals("0") == false)
                {
                    trnStockOutDetailForm.UpdateStockOutLineListDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(addStockOut[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                String[] addStockOut = trnPOSStockOutLineController.UpdateStockOutLine(trnStockOutLineEntity.Id, newStockOutLineEntity);
                if (addStockOut[1].Equals("0") == false)
                {
                    trnStockOutDetailForm.UpdateStockOutLineListDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(addStockOut[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxStockOutLineQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxStockOutLineCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxStockOutLineQuantity_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxStockOutLineQuantity.Text))
            {
                textBoxStockOutLineQuantity.Text = "0.00";
            }

            ComputeAmount();
        }

        private void textBoxStockOutLineCost_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxStockOutLineCost.Text))
            {
                textBoxStockOutLineCost.Text = "0.00";
            }

            ComputeAmount();
        }

        private void textBoxStockOutLineQuantity_Leave(object sender, EventArgs e)
        {
            textBoxStockOutLineQuantity.Text = Convert.ToDecimal(textBoxStockOutLineQuantity.Text).ToString("#,##0.00");
        }

        private void textBoxStockOutLineCost_Leave(object sender, EventArgs e)
        {
            textBoxStockOutLineCost.Text = Convert.ToDecimal(textBoxStockOutLineCost.Text).ToString("#,##0.00");
        }
    }
}
