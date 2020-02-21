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
    public partial class TrnSalesDetailTenderMoreInformationForm : Form
    {
        public TrnSalesDetailTenderForm trnSalesDetailTenderForm;
        public DataGridView mstDataGridViewTenderPayType;

        public TrnSalesDetailTenderMoreInformationForm(TrnSalesDetailTenderForm salesDetailTenderForm, DataGridView dataGridViewTenderPayType)
        {
            InitializeComponent();

            trnSalesDetailTenderForm = salesDetailTenderForm;
            mstDataGridViewTenderPayType = dataGridViewTenderPayType;

            textBoxCollectionLineOtherInformation.Text = dataGridViewTenderPayType.CurrentRow.Cells[4].Value.ToString();
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
                Decimal amount = Convert.ToDecimal(mstDataGridViewTenderPayType.CurrentRow.Cells[3].Value);
                String otherInformation = textBoxCollectionLineOtherInformation.Text;

                mstDataGridViewTenderPayType.CurrentRow.Cells[0].Value = id;
                mstDataGridViewTenderPayType.CurrentRow.Cells[1].Value = payTypeCode;
                mstDataGridViewTenderPayType.CurrentRow.Cells[2].Value = payType;
                mstDataGridViewTenderPayType.CurrentRow.Cells[3].Value = amount;
                mstDataGridViewTenderPayType.CurrentRow.Cells[4].Value = otherInformation;
            }

            mstDataGridViewTenderPayType.Refresh();
            Close();

            mstDataGridViewTenderPayType.Focus();
            mstDataGridViewTenderPayType.CurrentRow.Cells[2].Selected = true;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();

            mstDataGridViewTenderPayType.Focus();
            mstDataGridViewTenderPayType.CurrentRow.Cells[2].Selected = true;
        }

        private void TrnSalesDetailTenderMoreInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mstDataGridViewTenderPayType.Focus();
            mstDataGridViewTenderPayType.CurrentRow.Cells[2].Selected = true;
        }
    }
}
