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
    public partial class TrnSalesDetailSalesItemDetailForm : Form
    {
        TrnSalesDetailForm trnSalesDetailForm;
        TrnSalesDetailSearchItemForm trnSalesDetailSearchItemForm;

        public TrnSalesDetailSalesItemDetailForm(TrnSalesDetailForm salesDetailForm, TrnSalesDetailSearchItemForm salesDetailSearchItemForm)
        {
            InitializeComponent();

            trnSalesDetailForm = salesDetailForm;
            trnSalesDetailSearchItemForm = salesDetailSearchItemForm;

            GetDiscountList();
        }

        public Entities.TrnSalesLineEntity trnSalesLineEntity;

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void GetDiscountList()
        {
            trnSalesLineEntity = trnSalesDetailSearchItemForm.trnSalesLineEntity;

            Controllers.TrnPOSSalesLineController trnPOSSalesLineController = new Controllers.TrnPOSSalesLineController();
            if (trnPOSSalesLineController.DropdownListDiscount().Any())
            {
                comboBoxSalesLineDiscount.DataSource = trnPOSSalesLineController.DropdownListDiscount();
                comboBoxSalesLineDiscount.ValueMember = "Id";
                comboBoxSalesLineDiscount.DisplayMember = "Discount";

                GetSalesLineItemDetail();
            }
        }

        private void GetSalesLineItemDetail()
        {
            textBoxItemDescription.Text = trnSalesLineEntity.ItemDescription;
            textBoxSalesLineQuantity.Text = trnSalesLineEntity.Quantity.ToString("#,##0.00");
            textBoxSalesLineUnit.Text = trnSalesLineEntity.Unit;
            textBoxSalesLinePrice.Text = trnSalesLineEntity.Price.ToString("#,##0.00");
            comboBoxSalesLineDiscount.SelectedValue = trnSalesLineEntity.DiscountId;
            textBoxSalesLineDiscountRate.Text = trnSalesLineEntity.DiscountRate.ToString("#,##0.00");
            textBoxSalesLineDiscountAmount.Text = trnSalesLineEntity.DiscountAmount.ToString("#,##0.00");
            textBoxSalesLineNetPrice.Text = trnSalesLineEntity.NetPrice.ToString("#,##0.00");
            textBoxSalesLineAmount.Text = trnSalesLineEntity.Amount.ToString("#,##0.00");
            textBoxSalesLineVAT.Text = trnSalesLineEntity.Tax;
            textBoxSalesLineVATRate.Text = trnSalesLineEntity.TaxRate.ToString("#,##0.00");
            textBoxSalesLineVATAmount.Text = trnSalesLineEntity.TaxAmount.ToString("#,##0.00");
            textBoxSalesLineRemarks.Text = "NA";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Controllers.TrnPOSSalesLineController trnPOSSalesLineController = new Controllers.TrnPOSSalesLineController();
            String[] addSales = trnPOSSalesLineController.AddSalesLine(trnSalesLineEntity);
            if (addSales[1].Equals("0") == false)
            {

                Close();
            }
            else
            {
                MessageBox.Show(addSales[0], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
