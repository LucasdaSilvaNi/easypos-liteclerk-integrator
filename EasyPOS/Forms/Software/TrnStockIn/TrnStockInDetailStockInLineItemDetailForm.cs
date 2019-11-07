using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.TrnStockIn
{
    public partial class TrnStockInDetailStockInLineItemDetailForm : Form
    {
        public TrnStockInDetailForm trnStockInDetailForm;
        public Entities.TrnStockInLineEntity trnStockInLineEntity;

        public TrnStockInDetailStockInLineItemDetailForm(TrnStockInDetailForm stockInDetailForm, Entities.TrnStockInLineEntity stockInLineEntity)
        {
            InitializeComponent();

            trnStockInDetailForm = stockInDetailForm;
            trnStockInLineEntity = stockInLineEntity;

            GetAssetAccountList();

            textBoxStockInLineQuantity.Focus();
            textBoxStockInLineQuantity.SelectAll();
        }

        public void GetAssetAccountList()
        {
            Controllers.TrnStockInLineController trnPOSStockInLineController = new Controllers.TrnStockInLineController();
            if (trnPOSStockInLineController.DropdownListStockInLineAccount().Any())
            {
                comboBoxStockInLineAssetAccount.DataSource = trnPOSStockInLineController.DropdownListStockInLineAccount();
                comboBoxStockInLineAssetAccount.ValueMember = "Id";
                comboBoxStockInLineAssetAccount.DisplayMember = "Account";

                GetStockInLineItemDetail();
            }
        }

        public void GetStockInLineItemDetail()
        {
            textBoxStockInLineItemDescription.Text = trnStockInLineEntity.ItemDescription;
            textBoxStockInLineQuantity.Text = trnStockInLineEntity.Quantity.ToString("#,##0.00");
            textBoxStockInLineUnit.Text = trnStockInLineEntity.Unit;
            textBoxStockInLineCost.Text = trnStockInLineEntity.Cost.ToString("#,##0.00");
            textBoxStockInLineAmount.Text = trnStockInLineEntity.Amount.ToString("#,##0.00");

            if (String.IsNullOrEmpty(trnStockInLineEntity.ExpiryDate) == true)
            {
                dateTimePickerStockInLineExpiryDate.Format = DateTimePickerFormat.Custom;
                dateTimePickerStockInLineExpiryDate.CustomFormat = " ";
            }
            else
            {
                dateTimePickerStockInLineExpiryDate.Value = Convert.ToDateTime(trnStockInLineEntity.ExpiryDate);
            }

            textBoxStockInLineLotNumber.Text = trnStockInLineEntity.LotNumber;
            comboBoxStockInLineAssetAccount.SelectedValue = trnStockInLineEntity.AssetAccountId;
            textBoxStockInLinePrice.Text = trnStockInLineEntity.Price != null ? Convert.ToDecimal(trnStockInLineEntity.Price).ToString("#,##0.00") : "0.00";
        }

        public void ComputeAmount()
        {
            try
            {
                if (String.IsNullOrEmpty(textBoxStockInLineQuantity.Text) == false && String.IsNullOrEmpty(textBoxStockInLineCost.Text) == false)
                {
                    Decimal quantity = Convert.ToDecimal(textBoxStockInLineQuantity.Text);
                    Decimal cost = Convert.ToDecimal(textBoxStockInLineCost.Text);
                    Decimal amount = cost * quantity;

                    textBoxStockInLineAmount.Text = amount.ToString("#,##0.00");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveStockInLine();
        }

        public void SaveStockInLine()
        {
            var id = trnStockInLineEntity.Id;
            var stockInId = trnStockInLineEntity.StockInId;
            var itemId = trnStockInLineEntity.ItemId;
            var itemDescription = trnStockInLineEntity.ItemDescription;
            var unitId = trnStockInLineEntity.UnitId;
            var unit = trnStockInLineEntity.Unit;
            var quantity = Convert.ToDecimal(textBoxStockInLineQuantity.Text);
            var cost = Convert.ToDecimal(textBoxStockInLineCost.Text);
            var amount = Convert.ToDecimal(textBoxStockInLineAmount.Text);
            var expiryDate = dateTimePickerStockInLineExpiryDate.Text == "" ? null : dateTimePickerStockInLineExpiryDate.Value.ToShortDateString();
            var lotNumber = textBoxStockInLineLotNumber.Text;
            var assetAccountId = trnStockInLineEntity.AssetAccountId;
            var assetAccount = trnStockInLineEntity.AssetAccount;
            var price = Convert.ToDecimal(textBoxStockInLinePrice.Text);

            Entities.TrnStockInLineEntity newStockInLineEntity = new Entities.TrnStockInLineEntity()
            {
                Id = id,
                StockInId = stockInId,
                ItemId = itemId,
                ItemDescription = itemDescription,
                UnitId = unitId,
                Unit = unit,
                Quantity = quantity,
                Cost = cost,
                Amount = amount,
                ExpiryDate = expiryDate,
                LotNumber = lotNumber,
                AssetAccountId = assetAccountId,
                AssetAccount = assetAccount,
                Price = price
            };

            Controllers.TrnStockInLineController trnPOSStockInLineController = new Controllers.TrnStockInLineController();
            if (newStockInLineEntity.Id == 0)
            {
                String[] addStockIn = trnPOSStockInLineController.AddStockInLine(newStockInLineEntity);
                if (addStockIn[1].Equals("0") == false)
                {
                    trnStockInDetailForm.UpdateStockInLineListDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(addStockIn[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                String[] addStockIn = trnPOSStockInLineController.UpdateStockInLine(trnStockInLineEntity.Id, newStockInLineEntity);
                if (addStockIn[1].Equals("0") == false)
                {
                    trnStockInDetailForm.UpdateStockInLineListDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(addStockIn[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxStockInLineQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxStockInLineCost_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxStockInLineQuantity_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxStockInLineQuantity.Text))
            {
                textBoxStockInLineQuantity.Text = "0.00";
            }

            ComputeAmount();
        }

        private void textBoxStockInLineCost_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxStockInLineCost.Text))
            {
                textBoxStockInLineCost.Text = "0.00";
            }

            ComputeAmount();
        }

        private void textBoxStockInLineQuantity_Leave(object sender, EventArgs e)
        {
            textBoxStockInLineQuantity.Text = Convert.ToDecimal(textBoxStockInLineQuantity.Text).ToString("#,##0.00");
        }

        private void textBoxStockInLineCost_Leave(object sender, EventArgs e)
        {
            textBoxStockInLineCost.Text = Convert.ToDecimal(textBoxStockInLineCost.Text).ToString("#,##0.00");
        }

        private void dateTimePickerStockInLineExpiryDate_ValueChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(trnStockInLineEntity.ExpiryDate) == true)
            {
                dateTimePickerStockInLineExpiryDate.Format = DateTimePickerFormat.Custom;
                dateTimePickerStockInLineExpiryDate.CustomFormat = "M/d/yyyy";
            }
        }
    }
}
