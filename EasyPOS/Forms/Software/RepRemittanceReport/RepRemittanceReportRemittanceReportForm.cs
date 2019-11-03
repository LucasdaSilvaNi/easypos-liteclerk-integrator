using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.RepRemittanceReport
{
    public partial class RepRemittanceReportRemittanceReportForm : Form
    {
        public RepRemittanceReportForm repRemittanceReportForm;
        public Int32 filterTerminalId;
        public DateTime filterDate;
        public Int32 filterUserId;
        public String filterRemittanceNumber;
        public Entities.RepRemitanceReportEntity remitanceReportEntity;

        public RepRemittanceReportRemittanceReportForm(RepRemittanceReportForm remittanceReportForm, DateTime date, Int32 terminalId, Int32 userId, String remittanceNumber)
        {
            InitializeComponent();

            repRemittanceReportForm = remittanceReportForm;

            filterDate = date;
            filterTerminalId = terminalId;
            filterUserId = userId;
            filterRemittanceNumber = remittanceNumber;
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            DialogResult printerDialogResult = printDialogRemittanceReport.ShowDialog();
            if (printerDialogResult == DialogResult.OK)
            {
                PrintReport();
                Close();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void PrintReport()
        {
            printDocumentRemittanceReport.Print();
        }

        public void GetRemittanceReportDataSource()
        {
            Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

            Entities.RepRemitanceReportEntity repRemitanceReportEntity = new Entities.RepRemitanceReportEntity()
            {
                RemittanceNumber = "",
                RemittanceDate = "",
                Terminal = "",
                PreparedBy = "",
                Remarks = "",
                Amount1000 = 0,
                Amount500 = 0,
                Amount200 = 0,
                Amount100 = 0,
                Amount50 = 0,
                Amount20 = 0,
                Amount10 = 0,
                Amount5 = 0,
                Amount1 = 0,
                Amount025 = 0,
                Amount010 = 0,
                Amount005 = 0,
                Amount001 = 0,
                Total = 0,
                CollectionLines = new List<Entities.TrnCollectionLineEntity>()
            };

            repRemitanceReportEntity.RemittanceDate = filterDate.ToShortDateString();

            var remittance = from d in db.TrnDisbursements
                             where d.DisbursementDate == filterDate
                             && d.TerminalId == filterTerminalId
                             && d.PreparedBy == filterUserId
                             && d.DisbursementNumber == filterRemittanceNumber
                             select d;

            var currentCollections = from d in db.TrnCollections
                                     where d.TerminalId == filterTerminalId
                                     && d.CollectionDate == filterDate
                                     && d.PreparedBy == filterUserId
                                     && d.IsLocked == true
                                     && d.IsCancelled == false
                                     select d;

            var currentCollectionLines = from d in db.TrnCollectionLines
                                         where d.TrnCollection.TerminalId == filterTerminalId
                                         && d.TrnCollection.CollectionDate == filterDate
                                         && d.TrnCollection.PreparedBy == filterUserId
                                         && d.TrnCollection.IsLocked == true
                                         && d.TrnCollection.IsCancelled == false
                                         group d by new
                                         {
                                             d.MstPayType.PayType,
                                         } into g
                                         select new
                                         {
                                             g.Key.PayType,
                                             TotalAmount = g.Sum(s => s.Amount),
                                             TotalChangeAmount = g.Sum(s => s.TrnCollection.ChangeAmount)
                                         };

            if (remittance.Any() && currentCollectionLines.Any())
            {
                repRemitanceReportEntity.RemittanceNumber = remittance.FirstOrDefault().DisbursementNumber;
                repRemitanceReportEntity.RemittanceDate = remittance.FirstOrDefault().DisbursementDate.ToShortDateString();
                var terminal = from d in db.MstTerminals
                               where d.Id == filterTerminalId
                               select d;
                if (terminal.Any())
                {
                    repRemitanceReportEntity.Terminal = terminal.FirstOrDefault().Terminal;
                }

                var preparedBy = from d in db.MstUsers
                                 where d.Id == filterUserId
                                 select d;
                if (preparedBy.Any())
                {
                    repRemitanceReportEntity.PreparedBy = preparedBy.FirstOrDefault().UserName;
                }

                repRemitanceReportEntity.Remarks = remittance.FirstOrDefault().Remarks;
                repRemitanceReportEntity.Amount1000 = remittance.FirstOrDefault().Amount1000 != null ? remittance.FirstOrDefault().Amount1000 : 0;
                repRemitanceReportEntity.Amount500 = remittance.FirstOrDefault().Amount500 != null ? remittance.FirstOrDefault().Amount500 : 0;
                repRemitanceReportEntity.Amount200 = remittance.FirstOrDefault().Amount200 != null ? remittance.FirstOrDefault().Amount200 : 0;
                repRemitanceReportEntity.Amount100 = remittance.FirstOrDefault().Amount100 != null ? remittance.FirstOrDefault().Amount100 : 0;
                repRemitanceReportEntity.Amount50 = remittance.FirstOrDefault().Amount50 != null ? remittance.FirstOrDefault().Amount50 : 0;
                repRemitanceReportEntity.Amount20 = remittance.FirstOrDefault().Amount20 != null ? remittance.FirstOrDefault().Amount20 : 0;
                repRemitanceReportEntity.Amount10 = remittance.FirstOrDefault().Amount10 != null ? remittance.FirstOrDefault().Amount10 : 0;
                repRemitanceReportEntity.Amount5 = remittance.FirstOrDefault().Amount5 != null ? remittance.FirstOrDefault().Amount5 : 0;
                repRemitanceReportEntity.Amount1 = remittance.FirstOrDefault().Amount1 != null ? remittance.FirstOrDefault().Amount1 : 0;
                repRemitanceReportEntity.Amount025 = remittance.FirstOrDefault().Amount025 != null ? remittance.FirstOrDefault().Amount025 : 0;
                repRemitanceReportEntity.Amount010 = remittance.FirstOrDefault().Amount010 != null ? remittance.FirstOrDefault().Amount010 : 0;
                repRemitanceReportEntity.Amount005 = remittance.FirstOrDefault().Amount005 != null ? remittance.FirstOrDefault().Amount005 : 0;
                repRemitanceReportEntity.Amount001 = remittance.FirstOrDefault().Amount001 != null ? remittance.FirstOrDefault().Amount001 : 0;



                IEnumerable remittanceObject = repRemitanceReportEntity as IEnumerable;
                Decimal totalRemittanceAmount = 0;
                foreach (object remittanceElement in remittanceObject)
                {
                    Decimal remittanceAmount = 0;
                    if (remittanceElement.GetType() == typeof(Decimal))
                    {
                        remittanceAmount = Convert.ToDecimal(remittanceElement);
                    }
                    totalRemittanceAmount += remittanceAmount;
                }

                repRemitanceReportEntity.Total = totalRemittanceAmount;

                foreach (var collectionLine in currentCollectionLines)
                {
                    Decimal amount = collectionLine.TotalAmount;
                    if (collectionLine.PayType.Equals("Cash"))
                    {
                        amount = collectionLine.TotalAmount - collectionLine.TotalChangeAmount;
                    }

                    repRemitanceReportEntity.CollectionLines.Add(new Entities.TrnCollectionLineEntity()
                    {
                        PayType = collectionLine.PayType,
                        Amount = amount
                    });
                }
                repRemitanceReportEntity.TotalCollection = currentCollections.Sum(d => d.Amount);

                remitanceReportEntity = repRemitanceReportEntity;
            }

        }

        private void printDocumentRemittanceReport_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var dataSource = remitanceReportEntity;

            // =============
            // Font Settings
            // =============
            Font fontArial12Bold = new Font("Arial", 12, FontStyle.Bold);
            Font fontArial12Regular = new Font("Arial", 12, FontStyle.Regular);
            Font fontArial11Bold = new Font("Arial", 11, FontStyle.Bold);
            Font fontArial11Regular = new Font("Arial", 11, FontStyle.Regular);
            Font fontArial8Bold = new Font("Arial", 8, FontStyle.Bold);
            Font fontArial8Regular = new Font("Arial", 8, FontStyle.Regular);

            // ==================
            // Alignment Settings
            // ==================
            StringFormat drawFormatCenter = new StringFormat { Alignment = StringAlignment.Center };
            StringFormat drawFormatLeft = new StringFormat { Alignment = StringAlignment.Near };
            StringFormat drawFormatRight = new StringFormat { Alignment = StringAlignment.Far };

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

            // ==============
            // System Current
            // ==============
            var systemCurrent = Modules.SysCurrentModule.GetCurrentSettings();

            // ============
            // Company Name
            // ============
            String companyName = systemCurrent.CompanyName;
            graphics.DrawString(companyName, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(companyName, fontArial8Regular).Height;

            // ===============
            // Company Address
            // ===============
            String companyAddress = systemCurrent.Address;
            graphics.DrawString(companyAddress, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(companyAddress, fontArial8Regular).Height;

            // ======================
            // Z Reading Report Title
            // ======================
            String zReadingReportTitle = "Remittance Report";
            graphics.DrawString(zReadingReportTitle, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(zReadingReportTitle, fontArial8Regular).Height;

            // ====
            // Date 
            // ====
            String collectionDateText = DateTime.Today.ToString("MM-dd-yyyy", CultureInfo.InvariantCulture);
            graphics.DrawString(collectionDateText, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(collectionDateText, fontArial8Regular).Height;

            // ========
            // 1st Line
            // ========
            Point firstLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
            Point firstLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
            graphics.DrawLine(blackPen, firstLineFirstPoint, firstLineSecondPoint);

            String rimittanceDate = dataSource.RemittanceDate;
            String remittanceNumber = dataSource.RemittanceNumber;
            String terminal = dataSource.Terminal;
            String preparedBy = dataSource.PreparedBy;
            String remarks = dataSource.Remarks;
            Decimal amount1000 = Convert.ToDecimal(dataSource.Amount1000);
            Decimal amount500 = Convert.ToDecimal(dataSource.Amount500);
            Decimal amount200 = Convert.ToDecimal(dataSource.Amount200);
            Decimal amount100 = Convert.ToDecimal(dataSource.Amount100);
            Decimal amount50 = Convert.ToDecimal(dataSource.Amount50);
            Decimal amount20 = Convert.ToDecimal(dataSource.Amount20);
            Decimal amount10 = Convert.ToDecimal(dataSource.Amount10);
            Decimal amount1 = Convert.ToDecimal(dataSource.Amount1);
            Decimal amount025 = Convert.ToDecimal(dataSource.Amount025);
            Decimal amount010 = Convert.ToDecimal(dataSource.Amount010);
            Decimal amount005 = Convert.ToDecimal(dataSource.Amount005);
            Decimal amount001 = Convert.ToDecimal(dataSource.Amount001);
            Decimal totalAmount = Convert.ToDecimal(dataSource.Total);

            // ===============
            // Remittance Date
            // ===============
            String remittanceDateLabel = "\nDate";
            String remittanceDateData = "\n" + rimittanceDate;
            graphics.DrawString(remittanceDateLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(remittanceDateData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(remittanceDateData, fontArial8Regular).Height;

            // =================
            // Remittance Number
            // =================
            String remittanceNumberLabel = "\nDate";
            String remittanceNumberData = "\n" + remittanceNumber;
            graphics.DrawString(remittanceNumberLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(remittanceNumberData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(remittanceNumberData, fontArial8Regular).Height;

            // =================
            // Remittance Number
            // =================
            String terminalLabel = "\nTerminal";
            String terminalData = "\n" + terminal;
            graphics.DrawString(terminalLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(terminalData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(terminalData, fontArial8Regular).Height;

            // =================
            // Remittance Number
            // =================
            String preparedByLabel = "\nPrepared By";
            String preparedByData = "\n" + preparedBy;
            graphics.DrawString(preparedByLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(preparedByData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(preparedByData, fontArial8Regular).Height;

            // =======
            // Remarks
            // =======
            String remarksLabel = "\nRemarks";
            String remarksData = "\n" + remarks;
            graphics.DrawString(remarksLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(remarksData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(remarksData, fontArial8Regular).Height;

            // =======
            // 
            // =======
            String amount1000Label = "\nAmount 1000";
            String amount1000Data = "\n" + amount1000;
            graphics.DrawString(amount1000Label, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(amount1000Data, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(amount1000Data, fontArial8Regular).Height;

            // =======
            // 
            // =======
            String amount500Label = "\nAmount 500";
            String amount500Data = "\n" + amount500;
            graphics.DrawString(amount500Label, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(amount500Data, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(amount500Data, fontArial8Regular).Height;

            // =======
            // 
            // =======
            String amount200Label = "\nAmount 200";
            String amount200Data = "\n" + amount200;
            graphics.DrawString(amount200Label, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(amount200Data, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(amount200Data, fontArial8Regular).Height;

            // =======
            // 
            // =======
            String amount100Label = "\nAmount 100";
            String amount100Data = "\n" + amount100;
            graphics.DrawString(amount100Label, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(amount100Data, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(amount100Data, fontArial8Regular).Height;

            // =======
            // 
            // =======
            String amount50Label = "\nAmount 50";
            String amount50Data = "\n" + amount50;
            graphics.DrawString(amount50Label, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(amount50Data, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(amount50Data, fontArial8Regular).Height;

            // =======
            // 
            // =======
            String amount20Label = "\nAmount 20";
            String amount20Data = "\n" + amount20;
            graphics.DrawString(amount20Label, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(amount20Data, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(amount20Data, fontArial8Regular).Height;

            // =======
            // 
            // =======
            String amount10Label = "\nAmount 10";
            String amount10Data = "\n" + amount10;
            graphics.DrawString(amount10Label, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(amount10Data, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(amount10Data, fontArial8Regular).Height;

            // =======
            // 
            // =======
            String amount1Label = "\nAmount 1";
            String amount1Data = "\n" + amount1;
            graphics.DrawString(amount1Label, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(amount1Data, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(amount1Data, fontArial8Regular).Height;

            // =======
            // 
            // =======
            String amount025Label = "\nAmount 1";
            String amount025Data = "\n" + amount1;
            graphics.DrawString(amount025Label, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(amount025Data, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(amount025Data, fontArial8Regular).Height;

            // =======
            // 
            // =======
            String amount010Label = "\nAmount 010";
            String amount010Data = "\n" + amount010;
            graphics.DrawString(amount010Label, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(amount010Data, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(amount010Data, fontArial8Regular).Height;

            // =======
            // 
            // =======
            String amount005Label = "\nAmount 005";
            String amount005Data = "\n" + amount005;
            graphics.DrawString(amount005Label, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(amount005Data, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(amount005Data, fontArial8Regular).Height;

            // =======
            // 
            // =======
            String amount001Label = "\nAmount 001";
            String amount001Data = "\n" + amount001;
            graphics.DrawString(amount001Label, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(amount001Data, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(amount001Data, fontArial8Regular).Height;

            // =======
            // 
            // =======
            String totalAmountLabel = "\nAmount 001";
            String totalAmountData = "\n" + totalAmount;
            graphics.DrawString(totalAmountLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalAmountData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalAmountData, fontArial8Regular).Height;

            // ========
            // 2nd Line
            // ========
            Point secondLineFirstPoint = new Point(0, Convert.ToInt32(y) - 7);
            Point secondLineSecondPoint = new Point(500, Convert.ToInt32(y) - 7);
            graphics.DrawLine(blackPen, secondLineFirstPoint, secondLineSecondPoint);

            if (dataSource.CollectionLines.Any())
            {
                foreach (var collectionLine in dataSource.CollectionLines)
                {
                    // ================
                    // Collection Lines
                    // ================
                    String collectionLineLabel = collectionLine.PayType;
                    String collectionLineData = collectionLine.Amount.ToString("#,##0.00");
                    graphics.DrawString(collectionLineLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                    graphics.DrawString(collectionLineData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                    y += graphics.MeasureString(collectionLineData, fontArial8Regular).Height;
                }

                // ========
                // 3rd Line
                // ========
                Point thirdLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
                Point thirdLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
                graphics.DrawLine(blackPen, thirdLineFirstPoint, thirdLineSecondPoint);
            }

            Decimal totalCollection = dataSource.TotalCollection;

            // ================
            // Total Collection
            // ================
            if (dataSource.CollectionLines.Any())
            {
                String totalCollectionLabel = "\nTotal Collection";
                String totalCollectionData = "\n" + totalCollection.ToString("#,##0.00");
                graphics.DrawString(totalCollectionLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                graphics.DrawString(totalCollectionData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(totalCollectionData, fontArial8Regular).Height;
            }
            else
            {
                String totalCollectionLabel = "Total Collection";
                String totalCollectionData = totalCollection.ToString("#,##0.00");
                graphics.DrawString(totalCollectionLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                graphics.DrawString(totalCollectionData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(totalCollectionData, fontArial8Regular).Height;
            }

            // ========
            // 4th Line
            // ========
            Point forthLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
            Point forthLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
            graphics.DrawLine(blackPen, forthLineFirstPoint, forthLineSecondPoint);
        }
    }
}
