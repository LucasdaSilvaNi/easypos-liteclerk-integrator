using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zen.Barcode;

namespace EasyPOS.Forms.Software.SysUtilities
{
    public partial class SysUtilitiesBarcodePrintingQuantity : Form
    {
        public Int32 itemId;
        public Entities.MstItemEntity itemEntity;

        public SysUtilitiesBarcodePrintingQuantity(Int32 itemIdFilter)
        {
            InitializeComponent();
            itemId = itemIdFilter;

            textBoxPrintQuantity.Text = "0";
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Controllers.MstItemController mstItemController = new Controllers.MstItemController();
                if (mstItemController.DetailItem(itemId) != null)
                {
                    itemEntity = mstItemController.DetailItem(itemId);

                    DialogResult printDialogBarcodePrintingDialogResult = printDialogBarcodePrinting.ShowDialog();
                    if (printDialogBarcodePrintingDialogResult == DialogResult.OK)
                    {
                        printDocumentBarcodePrinting.PrinterSettings.PrinterName = printDialogBarcodePrinting.PrinterSettings.PrinterName;
                        printDocumentBarcodePrinting.Print();
                    }
                }
                else
                {
                    MessageBox.Show("Item not found.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxPrintQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxPrintQuantity_Leave(object sender, EventArgs e)
        {
            try
            {
                textBoxPrintQuantity.Text = Convert.ToDecimal(textBoxPrintQuantity.Text).ToString("#,##0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxPrintQuantity_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxPrintQuantity.Text))
            {
                textBoxPrintQuantity.Text = "0";
            }
        }

        private void printDocumentBarcodePrinting_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // =====
            // Sizes
            // =====
            float x = 5, y = 5;
            float width = 245.0F, height = 0F;

            // ==============
            // Tools Settings
            // ==============
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            Pen blackPen = new Pen(Color.Black, 1);
            Pen whitePen = new Pen(Color.White, 1);

            // ========
            // Graphics
            // ========
            Graphics graphics = e.Graphics;

            // =============
            // Font Settings
            // =============
            Font fontArial15Bold = new Font("Arial", 15, FontStyle.Bold);
            Font fontArial15Regular = new Font("Arial", 15, FontStyle.Regular);
            Font fontArial14Bold = new Font("Arial", 14, FontStyle.Bold);
            Font fontArial14Regular = new Font("Arial", 14, FontStyle.Regular);
            Font fontArial13Bold = new Font("Arial", 13, FontStyle.Bold);
            Font fontArial13Regular = new Font("Arial", 13, FontStyle.Regular);
            Font fontArial12Bold = new Font("Arial", 12, FontStyle.Bold);
            Font fontArial12Regular = new Font("Arial", 12, FontStyle.Regular);
            Font fontArial11Bold = new Font("Arial", 11, FontStyle.Bold);
            Font fontArial11Regular = new Font("Arial", 11, FontStyle.Regular);
            Font fontArial11Italic = new Font("Arial", 11, FontStyle.Italic);
            Font fontArial10Bold = new Font("Arial", 10, FontStyle.Bold);
            Font fontArial10Regular = new Font("Arial", 10, FontStyle.Regular);
            Font fontArial10Italic = new Font("Arial", 10, FontStyle.Italic);
            Font fontArial8Bold = new Font("Arial", 8, FontStyle.Bold);
            Font fontArial8Regular = new Font("Arial", 8, FontStyle.Regular);

            // ==================
            // Alignment Settings
            // ==================
            StringFormat drawFormatCenter = new StringFormat { Alignment = StringAlignment.Center };
            StringFormat drawFormatLeft = new StringFormat { Alignment = StringAlignment.Near };
            StringFormat drawFormatRight = new StringFormat { Alignment = StringAlignment.Far };

            String itemAlias = itemEntity.Alias;
            graphics.DrawString(itemAlias, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(itemAlias, fontArial8Regular).Height;

            Code128BarcodeDraw barcode = BarcodeDrawFactory.Code128WithChecksum;
            Image image = barcode.Draw(itemEntity.BarCode, 50);
            graphics.DrawImage(image, new RectangleF(x, y, width, 55));
            y += image.Height + 7;

            String itemPrice = itemEntity.Price.ToString("#,##0.00");
            graphics.DrawString(itemPrice, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(itemPrice, fontArial8Regular).Height;
        }
    }
}
