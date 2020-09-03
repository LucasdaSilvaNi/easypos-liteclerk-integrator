using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.TrnPOS
{
    public partial class TrnPOSTenderFacepayCameraForm : Form
    {
        public FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        public VideoCaptureDevice videoDevice;
        public Boolean captured = false;

        public Entities.SysCurrentEntity systemCurrent = Modules.SysCurrentModule.GetCurrentSettings();
        public TrnPOSTenderForm trnSalesDetailTenderForm;
        public DataGridView mstDataGridViewTenderPayType;

        public TrnPOSTenderFacepayCameraForm(TrnPOSTenderForm salesDetailTenderForm, DataGridView dataGridViewTenderPayType, Decimal totalSalesAmount)
        {
            InitializeComponent();

            trnSalesDetailTenderForm = salesDetailTenderForm;
            mstDataGridViewTenderPayType = dataGridViewTenderPayType;

            textBoxTotalSalesAmount.Text = totalSalesAmount.ToString("#,##0.00");

            GetCameraDevicesList();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();

            mstDataGridViewTenderPayType.Focus();
            mstDataGridViewTenderPayType.CurrentRow.Cells[2].Selected = true;
        }

        public void Pay(Image capturedImage)
        {
            try
            {
                Decimal amount = Convert.ToDecimal(textBoxTotalSalesAmount.Text);
                if (amount >= 0)
                {
                    if (mstDataGridViewTenderPayType.Rows.Contains(mstDataGridViewTenderPayType.CurrentRow))
                    {
                        Int32 id = Convert.ToInt32(mstDataGridViewTenderPayType.CurrentRow.Cells[0].Value);
                        String payTypeCode = mstDataGridViewTenderPayType.CurrentRow.Cells[1].Value.ToString();
                        String payType = mstDataGridViewTenderPayType.CurrentRow.Cells[2].Value.ToString();
                        String otherInformation = payType + " Payment " + DateTime.Now.ToLongDateString();

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

                    mstDataGridViewTenderPayType.Focus();
                    mstDataGridViewTenderPayType.CurrentRow.Cells[2].Selected = true;

                    trnSalesDetailTenderForm.ComputeAmount();
                    trnSalesDetailTenderForm.CreateCollection(capturedImage);
                }
                else
                {
                    MessageBox.Show("Cannot pay if amount is zero or below.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveImageCaptured(Image facepayCapturedImage, String imageName)
        {
            try
            {
                String facepayImagePath = Modules.SysCurrentModule.GetCurrentSettings().FacepayImagePath;

                if (Directory.Exists(facepayImagePath) == false)
                {
                    Directory.CreateDirectory(facepayImagePath);
                }

                facepayCapturedImage.Save(facepayImagePath + "\\" + imageName + ".jpeg", ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            captured = true;
        }

        public void GetCameraDevicesList()
        {
            try
            {
                if (videoDevices.Count != 0)
                {
                    foreach (FilterInfo device in videoDevices)
                    {
                        comboBoxCameraDevices.Items.Add(device.Name);
                    }
                }
                else
                {
                    comboBoxCameraDevices.Items.Add("No camera devices found");
                }

                comboBoxCameraDevices.SelectedIndex = 0;

                OpenCamera();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OpenCamera()
        {
            try
            {
                String cameraDevices = comboBoxCameraDevices.SelectedIndex.ToString();
                videoDevice = new VideoCaptureDevice(videoDevices[Convert.ToInt32(cameraDevices)].MonikerString);

                StartVideoSourcePlayer(videoDevice);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void StartVideoSourcePlayer(IVideoSource source)
        {
            try
            {
                videoSourcePlayerCamera.VideoSource = source;
                videoSourcePlayerCamera.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void StopVideoSourcePlayer()
        {
            try
            {
                if (videoSourcePlayerCamera.VideoSource != null)
                {
                    videoSourcePlayerCamera.SignalToStop();

                    if (videoSourcePlayerCamera.IsRunning)
                    {
                        videoSourcePlayerCamera.VideoSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CloseCamera()
        {
            try
            {
                StopVideoSourcePlayer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public delegate void CaptureImage(Bitmap image);
        public void UpdatePictureBoxOnCaptureImage(Bitmap image)
        {
            try
            {
                captured = false;
                Pay(image);
                CloseCamera();

                Close();

                trnSalesDetailTenderForm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void videoSourcePlayerCamera_NewFrame(object sender, ref Bitmap image)
        {
            try
            {
                if (captured == true)
                {
                    Invoke(new CaptureImage(UpdatePictureBoxOnCaptureImage), image);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TrnSalesDetailTenderFacepayCameraForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseCamera();
        }

        private void textBoxTappedCardNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                captured = true;
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            StopVideoSourcePlayer();

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
            }

            OpenCamera();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F2:
                    {
                        if (buttonOpen.Enabled == true)
                        {
                            buttonOpen.PerformClick();
                            Close();
                        }

                        break;
                    }
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
