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
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.TrnPOS
{
    public partial class TrnSalesDetailTenderFacepayCameraForm : Form
    {
        public FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        public VideoCaptureDevice videoDevice;
        public Boolean captured = false;
        public String facepayImagePath = Modules.SysCurrentModule.GetCurrentSettings().FacepayImagePath;

        public Entities.SysCurrentEntity systemCurrent = Modules.SysCurrentModule.GetCurrentSettings();
        public TrnSalesDetailTenderForm trnSalesDetailTenderForm;
        public DataGridView mstDataGridViewTenderPayType;

        public TrnSalesDetailTenderFacepayCameraForm(TrnSalesDetailTenderForm salesDetailTenderForm, DataGridView dataGridViewTenderPayType, Decimal totalSalesAmount)
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
        }

        private void buttonCapture_Click(object sender, EventArgs e)
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

                OpenVideoSource(videoDevice);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OpenVideoSource(IVideoSource source)
        {
            try
            {
                if (videoSourcePlayerCamera.VideoSource != null)
                {
                    videoSourcePlayerCamera.SignalToStop();

                    while (true)
                    {
                        if (!videoSourcePlayerCamera.IsRunning)
                        {
                            break;
                        }

                        System.Threading.Thread.Sleep(500);
                    }

                    if (videoSourcePlayerCamera.IsRunning)
                    {
                        videoSourcePlayerCamera.Stop();
                    }

                    videoSourcePlayerCamera.VideoSource = null;
                }

                videoSourcePlayerCamera.VideoSource = source;
                videoSourcePlayerCamera.Start();
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

                pictureBoxCapturedPhoto.Image = image;
                pictureBoxCapturedPhoto.Update();

                String imageName = "\\ORNUMBER_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";

                if (Directory.Exists(facepayImagePath))
                {
                    pictureBoxCapturedPhoto.Image.Save(facepayImagePath + imageName, ImageFormat.Png);
                }
                else
                {
                    Directory.CreateDirectory(facepayImagePath);
                    pictureBoxCapturedPhoto.Image.Save(facepayImagePath + imageName, ImageFormat.Png);
                }
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

        public void CloseCamera()
        {
            try
            {
                videoDevice = null;
                OpenVideoSource(videoDevice);
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

        private void videoSourcePlayerCamera_PlayingFinished(object sender, ReasonToFinishPlaying reason)
        {

        }

        private void comboBoxCameraDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpenCamera();
        }
    }
}
