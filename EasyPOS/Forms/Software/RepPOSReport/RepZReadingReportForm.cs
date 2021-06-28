using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.RepPOSReport
{
    public partial class RepZReadingReportForm : Form
    {
        private Modules.SysUserRightsModule sysUserRights;

        public Forms.Software.RepPOSReport.RepPOSReportForm repPOSReportForm;
        public Int32 filterTerminalId;
        public String filterTerminal = "";
        public DateTime filterDate;
        public Entities.RepPOSReportZReadingReportEntity zReadingReportEntity;

        public RepZReadingReportForm(Forms.Software.RepPOSReport.RepPOSReportForm POSReportForm, Int32 terminalId, DateTime date)
        {
            InitializeComponent();

            sysUserRights = new Modules.SysUserRightsModule("RepPOS (Z Reading)");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (sysUserRights.GetUserRights().CanPrint == false)
                {
                    buttonPrint.Enabled = false;
                }
            }

            repPOSReportForm = POSReportForm;
            filterTerminalId = terminalId;
            filterDate = date;
            if (Modules.SysCurrentModule.GetCurrentSettings().PrinterType == "Dot Matrix Printer")
            {
                printDocumentZReadingReport.DefaultPageSettings.PaperSize = new PaperSize("Z Reading Report", 255, 1000);
                ZReadingDataSource();
            }
            else
            {
                printDocumentZReadingReport.DefaultPageSettings.PaperSize = new PaperSize("Z Reading Report", 270, 1000);
                ZReadingDataSource();
            }

        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            DialogResult printerDialogResult = printDialogZReadingReport.ShowDialog();
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
            printDocumentZReadingReport.Print();
        }

        public void ZReadingDataSource()
        {
            Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

            Entities.RepPOSReportZReadingReportEntity repZReadingReportEntity = new Entities.RepPOSReportZReadingReportEntity()
            {
                Terminal = "",
                Date = "",
                TotalGrossSales = 0,
                TotalRegularDiscount = 0,
                TotalSeniorDiscount = 0,
                TotalPWDDiscount = 0,
                TotalSalesReturn = 0,
                TotalNetSales = 0,
                CollectionLines = new List<Entities.TrnCollectionLineEntity>(),
                TotalRefund = 0,
                TotalCollection = 0,
                TotalVATSales = 0,
                TotalVATAmount = 0,
                TotalNonVAT = 0,
                TotalVATExclusive = 0,
                TotalVATExempt = 0,
                TotalVATZeroRated = 0,
                CounterIdStart = "0000000000",
                CounterIdEnd = "0000000000",
                TotalCancelledTrnsactionCount = 0,
                TotalCancelledAmount = 0,
                TotalNumberOfTransactions = 0,
                TotalNumberOfSKU = 0,
                TotalQuantity = 0,
                GrossSalesTotalPreviousReading = 0,
                GrossSalesRunningTotal = 0,
                NetSalesTotalPreviousReading = 0,
                NetSalesRunningTotal = 0,
                ZReadingCounter = "0"
            };

            repZReadingReportEntity.Date = filterDate.ToShortDateString();

            var terminal = from d in db.MstTerminals
                           where d.Id == filterTerminalId
                           select d;

            if (terminal.Any())
            {
                filterTerminal = terminal.FirstOrDefault().Terminal;
            }

            var currentCollections = from d in db.TrnCollections
                                     where d.TerminalId == filterTerminalId
                                     && d.CollectionDate == filterDate
                                     && d.IsLocked == true
                                     && d.IsCancelled == false
                                     && d.SalesId != null
                                     && d.TrnSale.IsLocked == true
                                     && d.TrnSale.IsCancelled == false
                                     && d.TrnSale.IsReturned == false
                                     select d;

            if (currentCollections.Any())
            {
                Decimal totalGrossSales = 0;
                Decimal totalRegularDiscount = 0;
                Decimal totalSeniorCitizenDiscount = 0;
                Decimal totalPWDDiscount = 0;
                Decimal totalSalesReturn = 0;

                Decimal totalVATSales = 0;
                Decimal totalVATAmount = 0;
                Decimal totalNonVATSales = 0;
                Decimal totalVATExemptSales = 0;
                Decimal totalVATZeroRatedSales = 0;

                Decimal totalNoOfSKUs = 0;
                Decimal totalQUantity = 0;

                for (Int32 i = 0; i < currentCollections.Count(); i++)
                {
                    var currentCollection = currentCollections.ToArray()[i];

                    Decimal salesLineTotalGrossSales = 0;
                    Decimal salesLineTotalRegularDiscount = 0;
                    Decimal salesLineTotalSeniorCitizenDiscount = 0;
                    Decimal salesLineTotalPWDDiscount = 0;

                    Decimal salesLineTotalVATSales = 0;
                    Decimal salesLineTotalVATAmount = 0;
                    Decimal salesLineTotalNonVATSales = 0;
                    Decimal salesLineTotalVATExemptSales = 0;
                    Decimal salesLineTotalVATZeroRatedSales = 0;

                    var salesLines = from d in currentCollection.TrnSale.TrnSalesLines
                                     where d.Quantity > 0
                                     select d;

                    if (salesLines.Any())
                    {
                        totalNoOfSKUs += salesLines.Count();
                        totalQUantity += salesLines.Sum(d => d.Quantity);

                        for (Int32 j = 0; j < salesLines.Count(); j++)
                        {
                            var salesLine = salesLines.ToArray()[j];

                            if (salesLine.MstTax.Code == "EXEMPTVAT")
                            {
                                if (salesLine.MstItem.MstTax1.Rate > 0)
                                {
                                    salesLineTotalGrossSales += (salesLine.Price * salesLine.Quantity) - ((salesLine.Price * salesLine.Quantity) / (1 + (salesLine.MstItem.MstTax1.Rate / 100)) * (salesLine.MstItem.MstTax1.Rate / 100));
                                }
                                else
                                {
                                    salesLineTotalGrossSales += salesLine.Price * salesLine.Quantity;
                                }
                            }
                            else
                            {
                                if (salesLine.MstTax.Rate > 0)
                                {
                                    salesLineTotalGrossSales += (salesLine.Price * salesLine.Quantity) - salesLine.TaxAmount;
                                }
                                else
                                {
                                    salesLineTotalGrossSales += salesLine.Price * salesLine.Quantity;
                                }
                            }

                            if (salesLine.MstDiscount.Discount != "Senior Citizen Discount" && salesLine.MstDiscount.Discount != "PWD")
                            {
                                salesLineTotalRegularDiscount += salesLine.DiscountAmount * salesLine.Quantity;
                            }

                            if (salesLine.MstDiscount.Discount == "Senior Citizen Discount")
                            {
                                salesLineTotalSeniorCitizenDiscount += salesLine.DiscountAmount * salesLine.Quantity;
                            }

                            if (salesLine.MstDiscount.Discount == "PWD")
                            {
                                salesLineTotalPWDDiscount += salesLine.DiscountAmount * salesLine.Quantity;
                            }

                            if (salesLine.MstTax.Code.Equals("VAT"))
                            {
                                salesLineTotalVATSales += salesLine.Amount - (salesLine.Amount / (1 + (salesLine.MstTax.Rate / 100)) * (salesLine.MstTax.Rate / 100));
                            }

                            if (salesLine.MstTax.Code == "EXEMPTVAT")
                            {
                                salesLineTotalVATAmount += ((salesLine.Price * salesLine.Quantity) / (1 + (salesLine.MstItem.MstTax1.Rate / 100)) * (salesLine.MstItem.MstTax1.Rate / 100));
                            }
                            else
                            {
                                salesLineTotalVATAmount += salesLine.TaxAmount;
                            }

                            if (salesLine.MstTax.Code.Equals("NONVAT"))
                            {
                                salesLineTotalNonVATSales += salesLine.Amount;
                            }

                            if (salesLine.MstTax.Code.Equals("EXEMPTVAT"))
                            {
                                salesLineTotalVATExemptSales += ((salesLine.Price * salesLine.Quantity) - ((salesLine.Price * salesLine.Quantity) / (1 + (salesLine.MstItem.MstTax1.Rate / 100)) * (salesLine.MstItem.MstTax1.Rate / 100))) - salesLineTotalSeniorCitizenDiscount - salesLineTotalPWDDiscount;
                            }

                            if (salesLine.MstTax.Code.Equals("ZEROVAT"))
                            {
                                salesLineTotalVATZeroRatedSales += salesLine.Amount;
                            }
                        }
                    }

                    totalGrossSales += salesLineTotalGrossSales;
                    totalRegularDiscount += salesLineTotalRegularDiscount;
                    totalSeniorCitizenDiscount += salesLineTotalSeniorCitizenDiscount;
                    totalPWDDiscount += salesLineTotalPWDDiscount;

                    totalVATSales += salesLineTotalVATSales;
                    totalVATAmount += salesLineTotalVATAmount;
                    totalNonVATSales += salesLineTotalNonVATSales;
                    totalVATExemptSales += salesLineTotalVATExemptSales;
                    totalVATZeroRatedSales += salesLineTotalVATZeroRatedSales;
                }

                Decimal VATSalesReturn = 0;
                Decimal VATAmountSalesReturn = 0;

                Decimal VATExemptSalesReturn = 0;
                Decimal VATAmountExemptSalesReturn = 0;

                var salesReturnLines = from d in db.TrnSalesLines
                                       where d.Quantity < 0
                                       && d.TrnSale.SalesDate == filterDate
                                       && d.TrnSale.IsLocked == true
                                       && d.TrnSale.IsCancelled == false
                                       && d.TrnSale.IsReturned == true
                                       select d;

                if (salesReturnLines.Any())
                {
                    for (Int32 i = 0; i < salesReturnLines.Count(); i++)
                    {
                        var salesReturnLine = salesReturnLines.ToArray()[i];

                        if (salesReturnLine.MstTax.Code.Equals("VAT"))
                        {
                            VATSalesReturn += salesReturnLine.Amount;
                            VATAmountSalesReturn += salesReturnLine.TaxAmount * -1;
                        }

                        if (salesReturnLine.MstTax.Code.Equals("EXEMPTVAT"))
                        {
                            VATExemptSalesReturn += salesReturnLine.Amount;

                            if (salesReturnLine.MstTax.Code == "EXEMPTVAT")
                            {
                                VATAmountExemptSalesReturn += ((salesReturnLine.Price * (salesReturnLine.Quantity * -1)) / (1 + (salesReturnLine.MstItem.MstTax1.Rate / 100)) * (salesReturnLine.MstItem.MstTax1.Rate / 100)) * -1;
                            }
                            else
                            {
                                VATAmountExemptSalesReturn += salesReturnLine.TaxAmount;
                            }
                        }
                    }

                    totalSalesReturn += (VATSalesReturn + VATExemptSalesReturn);
                }

                repZReadingReportEntity.TotalGrossSales = totalGrossSales;
                repZReadingReportEntity.TotalRegularDiscount = totalRegularDiscount;
                repZReadingReportEntity.TotalSeniorDiscount = totalSeniorCitizenDiscount;
                repZReadingReportEntity.TotalPWDDiscount = totalPWDDiscount;
                repZReadingReportEntity.TotalSalesReturn = totalSalesReturn;
                repZReadingReportEntity.TotalNetSales = totalGrossSales -
                                                        totalRegularDiscount -
                                                        totalSeniorCitizenDiscount -
                                                        totalPWDDiscount -
                                                        (totalSalesReturn * -1);

                repZReadingReportEntity.TotalVATSales = totalVATSales - (VATSalesReturn * -1);
                repZReadingReportEntity.TotalVATAmount = totalVATAmount - VATAmountSalesReturn - VATAmountExemptSalesReturn;
                repZReadingReportEntity.TotalNonVAT = totalNonVATSales;
                repZReadingReportEntity.TotalVATExempt = totalVATExemptSales - (VATExemptSalesReturn * -1);
                repZReadingReportEntity.TotalVATZeroRated = totalVATZeroRatedSales;

                repZReadingReportEntity.TotalNumberOfSKU = totalNoOfSKUs;
                repZReadingReportEntity.TotalQuantity = totalQUantity;
            }

            var disbursmenet = from d in db.TrnDisbursements
                               where d.TerminalId == filterTerminalId
                               && d.DisbursementDate == filterDate
                               && d.IsLocked == true
                               && d.IsRefund == true
                               && d.RefundSalesId != null
                               select d;

            if (disbursmenet.Any())
            {
                repZReadingReportEntity.TotalRefund = disbursmenet.Sum(d => d.Amount);
            }

            var currentCollectionLines = from d in db.TrnCollectionLines
                                         where d.TrnCollection.TerminalId == filterTerminalId
                                         && d.TrnCollection.CollectionDate == filterDate
                                         && d.TrnCollection.IsLocked == true
                                         && d.TrnCollection.IsCancelled == false
                                         && d.TrnCollection.TrnSale.IsReturned == false
                                         group d by new
                                         {
                                             d.MstPayType.PayTypeCode,
                                             d.MstPayType.PayType,
                                         } into g
                                         select new
                                         {
                                             g.Key.PayTypeCode,
                                             g.Key.PayType,
                                             TotalAmount = g.Sum(s => s.Amount),
                                             TotalChangeAmount = g.Sum(s => s.TrnCollection.ChangeAmount)
                                         };

            Decimal totalCollectionAmount = 0;

            if (currentCollectionLines.ToList().Any())
            {
                // =========================
                // COLLECTION LINE PAY TYPES
                // =========================

                // Compute the CASH
                Decimal changeAmount = 0;
                for (Int32 i = 0; i < currentCollectionLines.Count(); i++)
                {
                    var collectionLine = currentCollectionLines.ToArray()[i];

                    changeAmount += collectionLine.TotalChangeAmount;
                }

                for (Int32 i = 0; i < currentCollectionLines.Count(); i++)
                {
                    var collectionLine = currentCollectionLines.ToArray()[i];

                    Decimal amount = collectionLine.TotalAmount;
                    if (collectionLine.PayTypeCode.Equals("CASH") == true)
                    {
                        amount = collectionLine.TotalAmount - changeAmount;
                    }

                    repZReadingReportEntity.CollectionLines.Add(new Entities.TrnCollectionLineEntity()
                    {
                        PayType = collectionLine.PayType,
                        Amount = amount
                    });

                    totalCollectionAmount += amount;
                }
            }

            repZReadingReportEntity.TotalCollection = totalCollectionAmount - repZReadingReportEntity.TotalRefund;

            var counterCollections = from d in db.TrnCollections
                                     where d.TerminalId == filterTerminalId
                                     && d.CollectionDate == filterDate
                                     && d.IsLocked == true
                                     select d;

            if (counterCollections.Any())
            {
                repZReadingReportEntity.CounterIdStart = counterCollections.OrderBy(d => d.Id).FirstOrDefault().CollectionNumber;
                repZReadingReportEntity.CounterIdEnd = counterCollections.OrderByDescending(d => d.Id).FirstOrDefault().CollectionNumber;
                repZReadingReportEntity.TotalNumberOfTransactions = counterCollections.Count();
            }

            var currentCancelledCollections = from d in db.TrnCollections
                                              where d.TerminalId == filterTerminalId
                                              && d.CollectionDate == filterDate
                                              && d.IsLocked == true
                                              && d.IsCancelled == true
                                              select d;

            if (currentCancelledCollections.Any())
            {
                repZReadingReportEntity.TotalCancelledTrnsactionCount = currentCancelledCollections.Count();
                repZReadingReportEntity.TotalCancelledAmount = currentCancelledCollections.Sum(d => d.Amount);
            }

            Decimal currentDeclareRate = 0;

            var currentSysDeclareRate = from d in db.SysDeclareRates
                                        where d.Date == filterDate
                                        select d;

            if (currentSysDeclareRate.Any())
            {
                if (currentSysDeclareRate.FirstOrDefault().DeclareRate != null)
                {
                    currentDeclareRate = Convert.ToDecimal(currentSysDeclareRate.FirstOrDefault().DeclareRate);
                }
            }
            else
            {
                currentDeclareRate = Modules.SysCurrentModule.GetCurrentSettings().DeclareRate;
            }

            var previousDeclareRates = from d in db.SysDeclareRates
                                       where d.Date < filterDate
                                       select d;

            Decimal totalAccumulatedGrossSales = 0;
            Decimal totalAccumulatedRegularDiscount = 0;
            Decimal totalAccumulatedSeniorCitizenDiscount = 0;
            Decimal totalAccumulatedPWDDiscount = 0;
            Decimal totalAccumulatedSalesReturn = 0;

            var previousCollections = from d in db.TrnCollections
                                      where d.TerminalId == filterTerminalId
                                      && d.CollectionDate < filterDate
                                      && d.IsLocked == true
                                      && d.IsCancelled == false
                                      && d.SalesId != null
                                      && d.TrnSale.IsLocked == true
                                      && d.TrnSale.IsCancelled == false
                                      && d.TrnSale.IsReturned == false
                                      select d;

            if (previousCollections.Any())
            {
                for (Int32 i = 0; i < previousCollections.Count(); i++)
                {
                    var previousCollection = previousCollections.ToArray()[i];

                    Decimal salesLineTotalGrossSales = 0;
                    Decimal salesLineTotalRegularDiscount = 0;
                    Decimal salesLineTotalSeniorCitizenDiscount = 0;
                    Decimal salesLineTotalPWDDiscount = 0;

                    var salesLines = from d in previousCollection.TrnSale.TrnSalesLines
                                     where d.Quantity > 0
                                     select d;

                    if (salesLines.Any())
                    {
                        for (Int32 j = 0; j < salesLines.Count(); j++)
                        {
                            var salesLine = salesLines.ToArray()[j];

                            if (salesLine.MstTax.Code == "EXEMPTVAT")
                            {
                                if (salesLine.MstItem.MstTax1.Rate > 0)
                                {
                                    salesLineTotalGrossSales += (salesLine.Price * salesLine.Quantity) - ((salesLine.Price * salesLine.Quantity) / (1 + (salesLine.MstItem.MstTax1.Rate / 100)) * (salesLine.MstItem.MstTax1.Rate / 100));
                                }
                                else
                                {
                                    salesLineTotalGrossSales += salesLine.Price * salesLine.Quantity;
                                }
                            }
                            else
                            {
                                if (salesLine.MstTax.Rate > 0)
                                {
                                    salesLineTotalGrossSales += (salesLine.Price * salesLine.Quantity) - salesLine.TaxAmount;
                                }
                                else
                                {
                                    salesLineTotalGrossSales += salesLine.Price * salesLine.Quantity;
                                }
                            }

                            if (salesLine.MstDiscount.Discount != "Senior Citizen Discount" && salesLine.MstDiscount.Discount != "PWD")
                            {
                                salesLineTotalRegularDiscount += salesLine.DiscountAmount * salesLine.Quantity;
                            }

                            if (salesLine.MstDiscount.Discount == "Senior Citizen Discount")
                            {
                                salesLineTotalSeniorCitizenDiscount += salesLine.DiscountAmount * salesLine.Quantity;
                            }

                            if (salesLine.MstDiscount.Discount == "PWD")
                            {
                                salesLineTotalPWDDiscount += salesLine.DiscountAmount * salesLine.Quantity;
                            }
                        }
                    }

                    Decimal previousDeclareRate = 0;

                    if (previousDeclareRates.Any())
                    {
                        var previousSysDeclareRate = from d in previousDeclareRates
                                                     where d.Date == previousCollection.TrnSale.SalesDate
                                                     select d;

                        if (previousSysDeclareRate.Any())
                        {
                            if (previousSysDeclareRate.FirstOrDefault().DeclareRate != null)
                            {
                                previousDeclareRate = Convert.ToDecimal(previousSysDeclareRate.FirstOrDefault().DeclareRate);
                            }
                            else
                            {
                                previousDeclareRate = Modules.SysCurrentModule.GetCurrentSettings().DeclareRate;
                            }
                        }
                        else
                        {
                            previousDeclareRate = Modules.SysCurrentModule.GetCurrentSettings().DeclareRate;
                        }
                    }

                    totalAccumulatedGrossSales += salesLineTotalGrossSales * previousDeclareRate;
                    totalAccumulatedRegularDiscount += salesLineTotalRegularDiscount * previousDeclareRate;
                    totalAccumulatedSeniorCitizenDiscount += salesLineTotalSeniorCitizenDiscount * previousDeclareRate;
                    totalAccumulatedPWDDiscount += salesLineTotalPWDDiscount * previousDeclareRate;
                }

                Decimal VATSalesReturn = 0;
                Decimal VATAmountSalesReturn = 0;

                Decimal VATExemptSalesReturn = 0;
                Decimal VATAmountExemptSalesReturn = 0;

                var previousSalesReturnLines = from d in db.TrnSalesLines
                                               where d.Quantity < 0
                                               && d.TrnSale.SalesDate < filterDate
                                               && d.TrnSale.IsLocked == true
                                               && d.TrnSale.IsCancelled == false
                                               && d.TrnSale.IsReturned == true
                                               select d;

                if (previousSalesReturnLines.Any())
                {
                    for (Int32 i = 0; i < previousSalesReturnLines.Count(); i++)
                    {
                        var salesReturnLine = previousSalesReturnLines.ToArray()[i];

                        Decimal previousDeclareRate = 0;

                        if (previousDeclareRates.Any())
                        {
                            var previousSysDeclareRate = from d in previousDeclareRates
                                                         where d.Date == salesReturnLine.TrnSale.SalesDate
                                                         select d;

                            if (previousSysDeclareRate.Any())
                            {
                                if (previousSysDeclareRate.FirstOrDefault().DeclareRate != null)
                                {
                                    previousDeclareRate = Convert.ToDecimal(previousSysDeclareRate.FirstOrDefault().DeclareRate);
                                }
                                else
                                {
                                    previousDeclareRate = Modules.SysCurrentModule.GetCurrentSettings().DeclareRate;
                                }
                            }
                            else
                            {
                                previousDeclareRate = Modules.SysCurrentModule.GetCurrentSettings().DeclareRate;
                            }
                        }

                        if (salesReturnLine.MstTax.Code.Equals("VAT"))
                        {
                            VATSalesReturn += salesReturnLine.Amount * previousDeclareRate;
                            VATAmountSalesReturn += (salesReturnLine.TaxAmount * -1) * previousDeclareRate;
                        }

                        if (salesReturnLine.MstTax.Code.Equals("EXEMPTVAT"))
                        {
                            VATExemptSalesReturn += salesReturnLine.Amount * previousDeclareRate;

                            if (salesReturnLine.MstTax.Code == "EXEMPTVAT")
                            {
                                VATAmountExemptSalesReturn += (((salesReturnLine.Price * (salesReturnLine.Quantity * -1)) / (1 + (salesReturnLine.MstItem.MstTax1.Rate / 100)) * (salesReturnLine.MstItem.MstTax1.Rate / 100)) * -1) * previousDeclareRate;
                            }
                            else
                            {
                                VATAmountExemptSalesReturn += salesReturnLine.TaxAmount * previousDeclareRate;
                            }
                        }
                    }

                    totalAccumulatedSalesReturn += (VATSalesReturn + VATExemptSalesReturn);
                }
            }

            repZReadingReportEntity.GrossSalesTotalPreviousReading = totalAccumulatedGrossSales;
            repZReadingReportEntity.GrossSalesRunningTotal = (repZReadingReportEntity.TotalGrossSales * currentDeclareRate) + repZReadingReportEntity.GrossSalesTotalPreviousReading;
            repZReadingReportEntity.NetSalesTotalPreviousReading = repZReadingReportEntity.GrossSalesTotalPreviousReading - totalAccumulatedRegularDiscount - totalAccumulatedSeniorCitizenDiscount - totalAccumulatedPWDDiscount - (totalAccumulatedSalesReturn * -1);
            repZReadingReportEntity.NetSalesRunningTotal = (repZReadingReportEntity.TotalNetSales * currentDeclareRate) + repZReadingReportEntity.NetSalesTotalPreviousReading;

            var firstCollection = from d in db.TrnCollections
                                  where d.IsLocked == true
                                  select d;

            if (firstCollection.Any())
            {
                Double totalDays = (filterDate - firstCollection.FirstOrDefault().CollectionDate).TotalDays + 1;
                repZReadingReportEntity.ZReadingCounter = totalDays.ToString("#,##0");
            }

            zReadingReportEntity = repZReadingReportEntity;
        }

        private void printDocumentZReadingReport_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

            var dataSource = zReadingReportEntity;

            Decimal currentDeclareRate = 0;

            var currentSysDeclareRate = from d in db.SysDeclareRates
                                        where d.Date == filterDate
                                        select d;

            if (currentSysDeclareRate.Any())
            {
                if (currentSysDeclareRate.FirstOrDefault().DeclareRate != null)
                {
                    currentDeclareRate = Convert.ToDecimal(currentSysDeclareRate.FirstOrDefault().DeclareRate);
                }
            }
            else
            {
                currentDeclareRate = Modules.SysCurrentModule.GetCurrentSettings().DeclareRate;
            }

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

            float x, y;
            float width, height;
            if (Modules.SysCurrentModule.GetCurrentSettings().PrinterType == "Dot Matrix Printer")
            {
                x = 5; y = 5;
                width = 245.0F; height = 0F;
            }
            else
            {
                x = 5; y = 5;
                width = 260.0F; height = 0F;
            }
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
            float adjustStringName = 1;
            if (companyName.Length > 43)
            {
                adjustStringName = 3;
            }
            graphics.DrawString(companyName, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(companyName, fontArial8Regular).Height * adjustStringName;

            // ===============
            // Company Address
            // ===============
            String companyAddress = systemCurrent.Address;

            float adjuctHeight = 1;
            if (companyAddress.Length > 43)
            {
                adjuctHeight = 3;
            }

            graphics.DrawString(companyAddress, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += (graphics.MeasureString(companyAddress, fontArial8Regular).Height * adjuctHeight);

            // ==========
            // TIN Number
            // ==========
            String TINNumber = systemCurrent.TIN;
            graphics.DrawString("TIN: " + TINNumber, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(companyAddress, fontArial8Regular).Height;

            // =============
            // Serial Number
            // =============
            String serialNo = systemCurrent.SerialNo;
            graphics.DrawString("SN: " + serialNo, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(companyAddress, fontArial8Regular).Height;

            // ==============
            // Machine Number
            // ==============
            String machineNo = systemCurrent.MachineNo;
            graphics.DrawString("MIN: " + machineNo, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(companyAddress, fontArial8Regular).Height;

            // ===============
            // Terminal Number
            // ===============
            String terminal = filterTerminal;
            graphics.DrawString("Terminal: " + terminal, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(companyAddress, fontArial8Regular).Height;

            // ======================
            // Z Reading Report Title
            // ======================
            String zReadingReportTitle = "Z Reading Report";
            graphics.DrawString(zReadingReportTitle, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(zReadingReportTitle, fontArial8Regular).Height;

            // ====
            // Date 
            // ====
            String collectionDateText = filterDate.ToString("MM-dd-yyyy", CultureInfo.InvariantCulture);
            graphics.DrawString(collectionDateText, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(collectionDateText, fontArial8Regular).Height;

            // ========
            // 1st Line
            // ========
            Point firstLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
            Point firstLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
            graphics.DrawLine(blackPen, firstLineFirstPoint, firstLineSecondPoint);

            Decimal totalGrossSales = dataSource.TotalGrossSales * currentDeclareRate;
            Decimal totalRegularDiscount = dataSource.TotalRegularDiscount * currentDeclareRate;
            Decimal totalSeniorDiscount = dataSource.TotalSeniorDiscount * currentDeclareRate;
            Decimal totalPWDDiscount = dataSource.TotalPWDDiscount * currentDeclareRate;
            Decimal totalSalesReturn = dataSource.TotalSalesReturn * currentDeclareRate;
            Decimal totalNetSales = dataSource.TotalNetSales * currentDeclareRate;

            // ===========
            // Gross Sales
            // ===========
            String totalGrossSalesLabel = "\nGross Sales (Net of VAT)";
            String totalGrossSalesData = "\n" + totalGrossSales.ToString("#,##0.00");
            graphics.DrawString(totalGrossSalesLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalGrossSalesData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalGrossSalesData, fontArial8Regular).Height;

            // ================
            // Regular Discount
            // ================
            String totalRegularDiscountLabel = "Regular Discount";
            String totalRegularDiscountData = totalRegularDiscount.ToString("#,##0.00");
            graphics.DrawString(totalRegularDiscountLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalRegularDiscountData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalRegularDiscountData, fontArial8Regular).Height;

            // ===============
            // Senior Discount
            // ===============
            String totalSeniorDiscountLabel = "Senior Discount";
            String totalSeniorDiscountData = totalSeniorDiscount.ToString("#,##0.00");
            graphics.DrawString(totalSeniorDiscountLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalSeniorDiscountData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalSeniorDiscountData, fontArial8Regular).Height;

            // ============
            // PWD Discount
            // ============
            String totalPWDDiscountLabel = "PWD Discount";
            String totalPWDDiscountData = totalPWDDiscount.ToString("#,##0.00");
            graphics.DrawString(totalPWDDiscountLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalPWDDiscountData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalPWDDiscountData, fontArial8Regular).Height;

            // ============
            // Sales Return
            // ============
            String totalSalesReturnLabel = "Sales Return";
            String totalSalesReturnData = "(" + totalSalesReturn.ToString("#,##0.00") + ")";
            graphics.DrawString(totalSalesReturnLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalSalesReturnData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalSalesReturnData, fontArial8Regular).Height;

            // =========
            // Net Sales
            // =========
            String totalNetSalesLabel = "Net Sales \n\n";
            String totalNetSalesData = totalNetSales.ToString("#,##0.00") + "\n\n";
            graphics.DrawString(totalNetSalesLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalNetSalesData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalNetSalesData, fontArial8Regular).Height;

            // ========
            // 2nd Line
            // ========
            Point secondLineFirstPoint = new Point(0, Convert.ToInt32(y) - 7);
            Point secondLineSecondPoint = new Point(500, Convert.ToInt32(y) - 7);
            graphics.DrawLine(blackPen, secondLineFirstPoint, secondLineSecondPoint);

            if (dataSource.CollectionLines.Any())
            {
                for (Int32 i = 0; i < dataSource.CollectionLines.Count(); i++)
                {
                    var collectionLine = dataSource.CollectionLines.ToArray()[i];

                    // ================
                    // Collection Lines
                    // ================
                    String collectionLineLabel = collectionLine.PayType;
                    String collectionLineData = (collectionLine.Amount * currentDeclareRate).ToString("#,##0.00");
                    graphics.DrawString(collectionLineLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                    graphics.DrawString(collectionLineData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                    y += graphics.MeasureString(collectionLineData, fontArial8Regular).Height;
                }

                Decimal totalRefund = dataSource.TotalRefund * currentDeclareRate;

                String totalRefundLabel = "Refund";
                String totalRefundData = "(" + totalRefund.ToString("#,##0.00") + ")";
                graphics.DrawString(totalRefundLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                graphics.DrawString(totalRefundData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(totalRefundData, fontArial8Regular).Height;

                // ========
                // 3rd Line
                // ========
                Point thirdLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
                Point thirdLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
                graphics.DrawLine(blackPen, thirdLineFirstPoint, thirdLineSecondPoint);
            }

            // ========
            // 3rd Line
            // ========
            Point thirdLineFirstPoint2 = new Point(0, Convert.ToInt32(y) + 5);
            Point thirdLineSecondPoint2 = new Point(500, Convert.ToInt32(y) + 5);
            graphics.DrawLine(blackPen, thirdLineFirstPoint2, thirdLineSecondPoint2);

            Decimal totalCollection = dataSource.TotalCollection * currentDeclareRate;

            String totalCollectionLabel = "\nTotal Collection";
            String totalCollectionData = "\n" + totalCollection.ToString("#,##0.00");
            graphics.DrawString(totalCollectionLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalCollectionData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalCollectionData, fontArial8Regular).Height;

            // ========
            // 4th Line
            // ========
            Point forthLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
            Point forthLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
            graphics.DrawLine(blackPen, forthLineFirstPoint, forthLineSecondPoint);

            Decimal totalVATSales = dataSource.TotalVATSales * currentDeclareRate;
            Decimal totalVATAmount = dataSource.TotalVATAmount * currentDeclareRate;
            Decimal totalNonVAT = dataSource.TotalNonVAT * currentDeclareRate;
            Decimal totalVATExclusive = dataSource.TotalVATExclusive * currentDeclareRate;
            Decimal totalVATExempt = dataSource.TotalVATExempt * currentDeclareRate;
            Decimal totalVATZeroRated = dataSource.TotalVATZeroRated * currentDeclareRate;

            String vatSalesLabel = "\nVAT Sales";
            String totalVatSalesData = "\n" + totalVATSales.ToString("#,##0.00");
            graphics.DrawString(vatSalesLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalVatSalesData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalVatSalesData, fontArial8Regular).Height;

            String totalVATAmountLabel = "VAT Amount";
            String totalVATAmountData = totalVATAmount.ToString("#,##0.00");
            graphics.DrawString(totalVATAmountLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalVATAmountData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalVATAmountData, fontArial8Regular).Height;

            String totalNonVATLabel = "Non-VAT";
            String totalNonVATAmount = totalNonVAT.ToString("#,##0.00");
            graphics.DrawString(totalNonVATLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalNonVATAmount, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalNonVATAmount, fontArial8Regular).Height;

            String totalVATExemptLabel = "VAT Exempt";
            String totalVATExemptData = totalVATExempt.ToString("#,##0.00");
            graphics.DrawString(totalVATExemptLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalVATExemptData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalVATExemptData, fontArial8Regular).Height;

            String totalVATZeroRatedLabel = "VAT Zero Rated";
            String totalVatZeroRatedData = totalVATZeroRated.ToString("#,##0.00");
            graphics.DrawString(totalVATZeroRatedLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalVatZeroRatedData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalVatZeroRatedData, fontArial8Regular).Height;

            // ========
            // 5th Line
            // ========
            Point fifthLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
            Point fifthLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
            graphics.DrawLine(blackPen, fifthLineFirstPoint, fifthLineSecondPoint);

            String counterIdStart = dataSource.CounterIdStart;
            String counterIdEnd = dataSource.CounterIdEnd;

            String startCounterIdLabel = "\nCounter ID Start";
            String startCounterIdData = "\n" + counterIdStart;
            graphics.DrawString(startCounterIdLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(startCounterIdData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(startCounterIdData, fontArial8Regular).Height;

            String endCounterIdLabel = "Counter ID End";
            String endCounterIdData = counterIdEnd;
            graphics.DrawString(endCounterIdLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(endCounterIdData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(endCounterIdData, fontArial8Regular).Height;

            // ========
            // 6th Line
            // ========
            Point sixthLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
            Point sixthLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
            graphics.DrawLine(blackPen, sixthLineFirstPoint, sixthLineSecondPoint);

            Decimal totalCancelledTrnsactionCount = dataSource.TotalCancelledTrnsactionCount;
            Decimal totalCancelledAmount = dataSource.TotalCancelledAmount * currentDeclareRate;

            String totalCancelledTrnsactionCountLabel = "\nCancelled Tx.";
            String totalCancelledTrnsactionCountData = "\n" + totalCancelledTrnsactionCount.ToString("#,##0");
            graphics.DrawString(totalCancelledTrnsactionCountLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalCancelledTrnsactionCountData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalCancelledTrnsactionCountData, fontArial8Regular).Height;

            String totalCancelledAmountLabel = "Cancelled Amount";
            String totalCancelledAmountData = totalCancelledAmount.ToString("#,##0.00");
            graphics.DrawString(totalCancelledAmountLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalCancelledAmountData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalCancelledAmountData, fontArial8Regular).Height;

            // ========
            // 7th Line
            // ========
            Point seventhLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
            Point seventhLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
            graphics.DrawLine(blackPen, seventhLineFirstPoint, seventhLineSecondPoint);

            Decimal totalNumberOfTransactions = dataSource.TotalNumberOfTransactions;
            Decimal totalNumberOfSKU = dataSource.TotalNumberOfSKU;
            Decimal totalQuantity = dataSource.TotalQuantity;

            String totalNumberOfTransactionsLabel = "\nNo. of Transactions";
            String totalNumberOfTransactionsData = "\n" + totalNumberOfTransactions.ToString("#,##0");
            graphics.DrawString(totalNumberOfTransactionsLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalNumberOfTransactionsData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalNumberOfTransactionsData, fontArial8Regular).Height;

            String totalNumberOfSKULabel = "No. of SKU";
            String totalNumberOfSKUData = totalNumberOfSKU.ToString("#,##0");
            graphics.DrawString(totalNumberOfSKULabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalNumberOfSKUData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalNumberOfSKUData, fontArial8Regular).Height;

            String totalQuantityLabel = "Total Quantity";
            String totalQuantityData = totalQuantity.ToString("#,##0.00");
            graphics.DrawString(totalQuantityLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalQuantityData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalQuantityData, fontArial8Regular).Height;

            // ========
            // 8th Line
            // ========
            Point eightLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
            Point eightLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
            graphics.DrawLine(blackPen, eightLineFirstPoint, eightLineSecondPoint);

            graphics.DrawString("\nAccumulated Gross Sales (Net of VAT)", fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            y += graphics.MeasureString("\nAccumulated Gross Sales (Net of VAT)", fontArial8Regular).Height;

            Decimal grossSalesTotalPreviousReading = dataSource.GrossSalesTotalPreviousReading;
            Decimal grossSalesRunningTotal = dataSource.GrossSalesRunningTotal;

            String grossSalesTotalPreviousReadingLabel = "\nPrevious Reading";
            String grossSalesTotalPreviousReadingData = "\n" + grossSalesTotalPreviousReading.ToString("#,##0.00");
            graphics.DrawString(grossSalesTotalPreviousReadingLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(grossSalesTotalPreviousReadingData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(grossSalesTotalPreviousReadingData, fontArial8Regular).Height;

            graphics.DrawString("Gross Sales (Net of VAT)", fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalGrossSales.ToString("#,##0.00"), fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalGrossSales.ToString("#,##0.00"), fontArial8Regular).Height;

            String grossSalesRunningTotalLabel = "Accu. Gross Sales (Net of VAT)";
            String grossSalesRunningTotalData = grossSalesRunningTotal.ToString("#,##0.00");
            graphics.DrawString(grossSalesRunningTotalLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(grossSalesRunningTotalData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(grossSalesRunningTotalData, fontArial8Regular).Height;

            // ========
            // 9th Line
            // ========
            Point ninethLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
            Point ninethLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
            graphics.DrawLine(blackPen, ninethLineFirstPoint, ninethLineSecondPoint);

            graphics.DrawString("\nAccumulated Net Sales", fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            y += graphics.MeasureString("\nAccumulated Net Sales", fontArial8Regular).Height;

            Decimal netSalesTotalPreviousReading = dataSource.NetSalesTotalPreviousReading;
            Decimal netSalesRunningTotal = dataSource.NetSalesRunningTotal;

            String netSalesTotalPreviousReadingLabel = "\nPrevious Reading";
            String netSalesTotalPreviousReadingData = "\n" + netSalesTotalPreviousReading.ToString("#,##0.00");
            graphics.DrawString(netSalesTotalPreviousReadingLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(netSalesTotalPreviousReadingData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(netSalesTotalPreviousReadingData, fontArial8Regular).Height;

            graphics.DrawString("Net Sales", fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalNetSales.ToString("#,##0.00"), fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalNetSales.ToString("#,##0.00"), fontArial8Regular).Height;

            String netSalesRunningTotalLabel = "Accu. Net Sales";
            String netSalesRunningTotalData = netSalesRunningTotal.ToString("#,##0.00");
            graphics.DrawString(netSalesRunningTotalLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(netSalesRunningTotalData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(netSalesRunningTotalData, fontArial8Regular).Height;

            // =========
            // 10th Line
            // =========
            Point tenthLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
            Point tenthLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
            graphics.DrawLine(blackPen, tenthLineFirstPoint, tenthLineSecondPoint);

            String zReadingCounter = dataSource.ZReadingCounter;

            String zReadingCounterLabel = "\nZ-Reading Counter";
            String zReadingCounterData = "\n" + zReadingCounter;
            graphics.DrawString(zReadingCounterLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(zReadingCounterData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(zReadingCounterData, fontArial8Regular).Height;

            // =========
            // 11th Line
            // =========
            Point eleventhLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
            Point eleventhLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
            graphics.DrawLine(blackPen, eleventhLineFirstPoint, eleventhLineSecondPoint);

            String zReadingFooter = systemCurrent.ZReadingFooter;

            if (Modules.SysCurrentModule.GetCurrentSettings().PrinterType == "Dot Matrix Printer")
            {
                String zReadingEndLabel = "\n" + zReadingFooter + "\n \n\n\n\n\n\n\n.";
                graphics.DrawString(zReadingEndLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += graphics.MeasureString(zReadingEndLabel, fontArial8Regular).Height;
            }
            else
            {
                String zReadingEndLabel = "\n" + zReadingFooter + "\n \n\n\n.";
                graphics.DrawString(zReadingEndLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += graphics.MeasureString(zReadingEndLabel, fontArial8Regular).Height;
            }
        }
    }
}
