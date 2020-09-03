using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.TrnPOS
{
    public partial class TrnPOSTenderEasypayInformationForm : Form
    {
        public Entities.SysCurrentEntity systemCurrent = Modules.SysCurrentModule.GetCurrentSettings();
        public String EasyPayAccessToken = "";

        public TrnPOSTenderForm trnSalesDetailTenderForm;
        public DataGridView mstDataGridViewTenderPayType;

        public Int32 trnSalesId = 0;

        public TrnPOSTenderEasypayInformationForm(TrnPOSTenderForm salesDetailTenderForm, DataGridView dataGridViewTenderPayType, Decimal totalSalesAmount, Int32 salesId)
        {
            InitializeComponent();

            trnSalesDetailTenderForm = salesDetailTenderForm;
            mstDataGridViewTenderPayType = dataGridViewTenderPayType;

            textBoxTotalSalesAmount.Text = totalSalesAmount.ToString("#,##0.00");

            textBoxBeginningBalance.Text = Convert.ToDecimal(0).ToString("#,##0.00");
            textBoxAmountCharge.Text = totalSalesAmount.ToString("#,##0.00");
            textBoxEndingBalance.Text = Convert.ToDecimal(totalSalesAmount * -1).ToString("#,##0.00");

            buttonPay.Enabled = false;

            trnSalesId = salesId;

            CheckConnection();
        }

        public void CheckConnection()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    using (client.OpenRead(systemCurrent.EasypayAPIURL))
                    {
                        labelConnectionStatus.Text = "Connected";
                        labelConnectionStatus.ForeColor = Color.Lime;
                    }
                }
            }
            catch (Exception ex)
            {
                labelConnectionStatus.Text = "Not Connected";
                labelConnectionStatus.ForeColor = Color.OrangeRed;

                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();

            mstDataGridViewTenderPayType.Focus();
            mstDataGridViewTenderPayType.CurrentRow.Cells[2].Selected = true;
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            TransferAmount();
        }

        public void GetEasypayToken()
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(systemCurrent.EasypayAPIURL + "/token");
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    String username = systemCurrent.EasypayDefaultUsername;
                    String password = systemCurrent.EasypayDefaultPassword;

                    String body = "username=" + username + "&password=" + password + "&grant_type=password";
                    streamWriter.Write(body);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    if (result != null)
                    {
                        Entities.EspTokenEntity tokenResults = new JavaScriptSerializer().Deserialize<Entities.EspTokenEntity>(result);
                        EasyPayAccessToken = tokenResults.access_token;

                        GetEasypayCardDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GetEasypayCardDetails()
        {
            try
            {
                if (String.IsNullOrEmpty(EasyPayAccessToken) == false)
                {
                    String cardNumber = textBoxTappedCardNumber.Text;

                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(systemCurrent.EasypayAPIURL + "/api/cards/detail/" + cardNumber);
                    httpWebRequest.Method = "GET";
                    httpWebRequest.Headers["Authorization"] = "Bearer " + EasyPayAccessToken;
                    httpWebRequest.ContentType = "application/json";

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        if (result != "null")
                        {
                            JavaScriptSerializer js = new JavaScriptSerializer();
                            Entities.EspCardDetailsEntity cardDetails = (Entities.EspCardDetailsEntity)js.Deserialize(result, typeof(Entities.EspCardDetailsEntity));

                            textBoxCustomer.Text = cardDetails.FullName;
                            textBoxBeginningBalance.Text = cardDetails.Balance.ToString("#,##0.00");
                        }
                        else
                        {
                            textBoxCustomer.Text = "";
                            textBoxBeginningBalance.Text = Convert.ToDecimal(0).ToString("#,##0.00");
                        }

                        ComputeEndingBalanceAmount();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid easypay credentials.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    textBoxCustomer.Text = "";
                    textBoxBeginningBalance.Text = Convert.ToDecimal(0).ToString("#,##0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBoxCustomer.Text = "";
                textBoxBeginningBalance.Text = Convert.ToDecimal(0).ToString("#,##0.00");
            }
        }

        public void TransferAmount()
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(systemCurrent.EasypayAPIURL + "/api/Ledger/Transfer");
                httpWebRequest.Headers["Authorization"] = "Bearer " + EasyPayAccessToken;
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var cardDetails = new Entities.EspCardDetailsEntity()
                    {
                        SourceCardNumber = textBoxTappedCardNumber.Text,
                        DestinationCardNumber = systemCurrent.EasypayMotherCardNumber,
                        Amount = Convert.ToDecimal(textBoxAmountCharge.Text),
                        Particulars = "Sales Id - " + trnSalesId.ToString()
                    };

                    String json = new JavaScriptSerializer().Serialize(cardDetails);

                    Entities.EspCardDetailsEntity objCardDetails = new JavaScriptSerializer().Deserialize<Entities.EspCardDetailsEntity>(json);
                    streamWriter.Write(new JavaScriptSerializer().Serialize(objCardDetails));
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    if (result != null)
                    {
                        if (Convert.ToInt32(result) > 0)
                        {
                            Pay(Convert.ToInt32(result), textBoxTappedCardNumber.Text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Pay(Int32 creditLedgerId, String cardNumber)
        {
            try
            {
                Decimal endingBalance = Convert.ToDecimal(textBoxEndingBalance.Text);
                if (endingBalance >= 0)
                {
                    if (mstDataGridViewTenderPayType.Rows.Contains(mstDataGridViewTenderPayType.CurrentRow))
                    {
                        Int32 id = Convert.ToInt32(mstDataGridViewTenderPayType.CurrentRow.Cells[0].Value);
                        String payTypeCode = mstDataGridViewTenderPayType.CurrentRow.Cells[1].Value.ToString();
                        String payType = mstDataGridViewTenderPayType.CurrentRow.Cells[2].Value.ToString();
                        Decimal amount = Convert.ToDecimal(textBoxAmountCharge.Text);
                        String otherInformation = "Easypay - " + creditLedgerId + " - " + cardNumber;

                        mstDataGridViewTenderPayType.CurrentRow.Cells[0].Value = id;
                        mstDataGridViewTenderPayType.CurrentRow.Cells[1].Value = payTypeCode;
                        mstDataGridViewTenderPayType.CurrentRow.Cells[2].Value = payType;
                        mstDataGridViewTenderPayType.CurrentRow.Cells[4].Value = amount.ToString("#,##0.00");
                        mstDataGridViewTenderPayType.CurrentRow.Cells[5].Value = otherInformation;
                        mstDataGridViewTenderPayType.CurrentRow.Cells[6].Value = null;
                        mstDataGridViewTenderPayType.CurrentRow.Cells[7].Value = "";
                        mstDataGridViewTenderPayType.CurrentRow.Cells[8].Value = "NA";
                        mstDataGridViewTenderPayType.CurrentRow.Cells[9].Value = null;
                        mstDataGridViewTenderPayType.CurrentRow.Cells[10].Value = "NA";
                        mstDataGridViewTenderPayType.CurrentRow.Cells[11].Value = "NA";
                        mstDataGridViewTenderPayType.CurrentRow.Cells[12].Value = "NA";
                        mstDataGridViewTenderPayType.CurrentRow.Cells[13].Value = "NA";
                        mstDataGridViewTenderPayType.CurrentRow.Cells[14].Value = "NA";
                        mstDataGridViewTenderPayType.CurrentRow.Cells[15].Value = "NA";
                        mstDataGridViewTenderPayType.CurrentRow.Cells[16].Value = "NA";
                        mstDataGridViewTenderPayType.CurrentRow.Cells[17].Value = "NA";
                        mstDataGridViewTenderPayType.CurrentRow.Cells[18].Value = "NA";
                    }

                    mstDataGridViewTenderPayType.Refresh();
                    Close();

                    mstDataGridViewTenderPayType.Focus();
                    mstDataGridViewTenderPayType.CurrentRow.Cells[2].Selected = true;

                    trnSalesDetailTenderForm.ComputeAmount();
                    trnSalesDetailTenderForm.CreateCollection(null);
                }
                else
                {
                    MessageBox.Show("Cannot pay if balance is zero.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxTappedCardAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetEasypayToken();
            }
        }

        public void ComputeEndingBalanceAmount()
        {
            try
            {
                Decimal begBalance = Convert.ToDecimal(textBoxBeginningBalance.Text);
                Decimal amountCharge = Convert.ToDecimal(textBoxAmountCharge.Text);
                Decimal endingBalance = begBalance - amountCharge;

                textBoxEndingBalance.Text = endingBalance.ToString("#,##0.00");

                if (endingBalance >= 0)
                {
                    buttonPay.Enabled = true;
                }
                else
                {
                    buttonPay.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    {
                        if (buttonPay.Enabled == true)
                        {
                            buttonPay.PerformClick();
                            Close();
                        }

                        break;
                    }
                case Keys.Escape:
                    {
                        Close();
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
