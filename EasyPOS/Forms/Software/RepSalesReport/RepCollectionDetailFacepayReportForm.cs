using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace EasyPOS.Forms.Software.RepSalesReport
{
    public partial class RepCollectionDetailFacepayReportForm : Form
    {
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        public DateTime startDate;
        public DateTime endDate;
        public Int32 terminalId;
        public String printPath;

        public RepCollectionDetailFacepayReportForm(DateTime filterStartDate, DateTime filterEndDate, Int32 filterTerminalId, String filterPrintPath)
        {
            InitializeComponent();

            startDate = filterStartDate;
            endDate = filterEndDate;
            terminalId = filterTerminalId;
            printPath = filterPrintPath;

            GeneratePDFPurchaseOrderDetail();
        }

        private void GeneratePDFPurchaseOrderDetail()
        {
            try
            {
                var fileName = printPath + "\\CollectionDetailReport_Facepay_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                var currentUser = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;

                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));

                document.Open();

                iTextSharp.text.Font fontArial08 = FontFactory.GetFont("Arial", 08);
                iTextSharp.text.Font fontArial08Italic = FontFactory.GetFont("Arial", 08, iTextSharp.text.Font.ITALIC);
                iTextSharp.text.Font fontArial09 = FontFactory.GetFont("Arial", 9);
                iTextSharp.text.Font fontArial09Bold = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fontArial13Bold = FontFactory.GetFont("Arial", 13, iTextSharp.text.Font.BOLD);

                Paragraph headerLine = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(2F, 100.0F, BaseColor.BLACK, Element.ALIGN_MIDDLE, 5F)));
                Paragraph footerLine = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0F, 100.0F, BaseColor.BLACK, Element.ALIGN_MIDDLE, 5F)));

                var companyName = Modules.SysCurrentModule.GetCurrentSettings().CompanyName;
                var branch = "";
                var companyAddress = "";
                var companyContactNumber = "";
                var companyTaxNumber = "";

                PdfPTable tableHeader = new PdfPTable(2);
                tableHeader.SetWidths(new float[] { 70f, 30f });
                tableHeader.WidthPercentage = 100;
                tableHeader.AddCell(new PdfPCell(new Phrase(companyName, fontArial13Bold)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase("Collection Detail Report", fontArial13Bold)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyAddress, fontArial08)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(branch, fontArial08)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Rowspan = 3 });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyContactNumber, fontArial08)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(companyTaxNumber, fontArial08)) { Border = 0 });
                tableHeader.AddCell(new PdfPCell(new Phrase(headerLine)) { Border = 0, Colspan = 2 });
                document.Add(tableHeader);

                var collectionLines = from d in db.TrnCollectionLines
                                      where d.TrnCollection.CollectionDate >= startDate
                                      && d.TrnCollection.CollectionDate <= endDate
                                      && d.TrnCollection.TerminalId == terminalId
                                      && d.TrnCollection.IsLocked == true
                                      && d.TrnCollection.IsCancelled == false
                                      && d.MstPayType.PayTypeCode == "FACEPAY"
                                      select d;

                if (collectionLines.Any())
                {
                    String facepayPath = Modules.SysCurrentModule.GetCurrentSettings().FacepayImagePath;

                    PdfPTable tableCollectionLines = new PdfPTable(7);
                    tableCollectionLines.SetWidths(new float[] { 100f, 120f, 120f, 200f, 120f, 100f, 150f });
                    tableCollectionLines.WidthPercentage = 100;
                    tableCollectionLines.AddCell(new PdfPCell(new Phrase("Date", fontArial09Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                    tableCollectionLines.AddCell(new PdfPCell(new Phrase("Tx No.", fontArial09Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                    tableCollectionLines.AddCell(new PdfPCell(new Phrase("Code", fontArial09Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                    tableCollectionLines.AddCell(new PdfPCell(new Phrase("Customer", fontArial09Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                    tableCollectionLines.AddCell(new PdfPCell(new Phrase("Paytype", fontArial09Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                    tableCollectionLines.AddCell(new PdfPCell(new Phrase("Amount", fontArial09Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });
                    tableCollectionLines.AddCell(new PdfPCell(new Phrase("Picture", fontArial09Bold)) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 7f });

                    Decimal totalAmount = 0;

                    foreach (var collectionLine in collectionLines)
                    {
                        String collectioDate = collectionLine.TrnCollection.CollectionDate.ToShortDateString();
                        String collectionNumber = collectionLine.TrnCollection.CollectionNumber;
                        String customerCode = collectionLine.TrnCollection.MstCustomer.CustomerCode;
                        String customer = collectionLine.TrnCollection.MstCustomer.Customer;
                        String payType = collectionLine.MstPayType.PayType;
                        String amount = collectionLine.Amount.ToString("#,##0.00");

                        iTextSharp.text.Image picture = null;
                        if (File.Exists(facepayPath + "\\" + collectionNumber + ".jpeg"))
                        {
                            picture = iTextSharp.text.Image.GetInstance(facepayPath + "\\" + collectionNumber + ".jpeg");
                        }

                        tableCollectionLines.AddCell(new PdfPCell(new Phrase(collectioDate, fontArial09)) { HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = 6f, PaddingLeft = 5f, PaddingRight = 5f });
                        tableCollectionLines.AddCell(new PdfPCell(new Phrase(collectionNumber, fontArial09)) { HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = 6f, PaddingLeft = 5f, PaddingRight = 5f });
                        tableCollectionLines.AddCell(new PdfPCell(new Phrase(customerCode, fontArial09)) { HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = 6f, PaddingLeft = 5f, PaddingRight = 5f });
                        tableCollectionLines.AddCell(new PdfPCell(new Phrase(customer, fontArial09)) { HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = 6f, PaddingLeft = 5f, PaddingRight = 5f });
                        tableCollectionLines.AddCell(new PdfPCell(new Phrase(payType, fontArial09)) { HorizontalAlignment = 0, PaddingTop = 3f, PaddingBottom = 6f, PaddingLeft = 5f, PaddingRight = 5f });
                        tableCollectionLines.AddCell(new PdfPCell(new Phrase(amount, fontArial09)) { HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 6f, PaddingLeft = 5f, PaddingRight = 5f });
                        tableCollectionLines.AddCell(new PdfPCell(picture, true) { HorizontalAlignment = 1, PaddingTop = 3f, PaddingBottom = 6f, PaddingLeft = 5f, PaddingRight = 5f });

                        totalAmount += collectionLine.Amount;
                    }

                    tableCollectionLines.AddCell(new PdfPCell(new Phrase("Total", fontArial09Bold)) { Colspan = 5, HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableCollectionLines.AddCell(new PdfPCell(new Phrase(totalAmount.ToString("#,##0.00"), fontArial09Bold)) { HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });
                    tableCollectionLines.AddCell(new PdfPCell(new Phrase("", fontArial09Bold)) { HorizontalAlignment = 2, PaddingTop = 3f, PaddingBottom = 7f, PaddingLeft = 5f, PaddingRight = 5f });

                    document.Add(tableCollectionLines);
                }

                document.Close();

                MessageBox.Show("Generate CSV Successful!", "Generate CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
