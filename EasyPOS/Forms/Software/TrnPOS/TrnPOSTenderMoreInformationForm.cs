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
    public partial class TrnPOSTenderMoreInformationForm : Form
    {
        public TrnPOSTenderForm trnSalesDetailTenderForm;
        public DataGridView mstDataGridViewTenderPayType;

        public TrnPOSTenderMoreInformationForm(TrnPOSTenderForm salesDetailTenderForm, DataGridView dataGridViewTenderPayType)
        {
            InitializeComponent();

            trnSalesDetailTenderForm = salesDetailTenderForm;
            mstDataGridViewTenderPayType = dataGridViewTenderPayType;

            textBoxCollectionLineOtherInformation.Text = dataGridViewTenderPayType.CurrentRow.Cells[5].Value.ToString();
            textBoxCollectionLineOtherInformation.Focus();
            textBoxCollectionLineOtherInformation.SelectAll();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveMoreInformation();
        }

        public void SaveMoreInformation()
        {
            if (mstDataGridViewTenderPayType.Rows.Contains(mstDataGridViewTenderPayType.CurrentRow))
            {
                Int32 id = Convert.ToInt32(mstDataGridViewTenderPayType.CurrentRow.Cells[0].Value);
                String payTypeCode = mstDataGridViewTenderPayType.CurrentRow.Cells[1].Value.ToString();
                String payType = mstDataGridViewTenderPayType.CurrentRow.Cells[2].Value.ToString();
                Decimal amount = Convert.ToDecimal(mstDataGridViewTenderPayType.CurrentRow.Cells[4].Value);
                String otherInformation = textBoxCollectionLineOtherInformation.Text;

                mstDataGridViewTenderPayType.CurrentRow.Cells[0].Value = id;
                mstDataGridViewTenderPayType.CurrentRow.Cells[1].Value = payTypeCode;
                mstDataGridViewTenderPayType.CurrentRow.Cells[2].Value = payType;
                mstDataGridViewTenderPayType.CurrentRow.Cells[4].Value = amount.ToString("#,##0.00");
                mstDataGridViewTenderPayType.CurrentRow.Cells[5].Value = otherInformation;
                mstDataGridViewTenderPayType.CurrentRow.Cells[6].Value = "";
            }

            mstDataGridViewTenderPayType.Refresh();
            Close();

            mstDataGridViewTenderPayType.Focus();
            mstDataGridViewTenderPayType.CurrentRow.Cells[4].Selected = true;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();

            mstDataGridViewTenderPayType.Focus();
            mstDataGridViewTenderPayType.CurrentRow.Cells[4].Selected = true;
        }

        private void TrnSalesDetailTenderMoreInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mstDataGridViewTenderPayType.Focus();
            mstDataGridViewTenderPayType.CurrentRow.Cells[4].Selected = true;
        }
    }
}
