using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.RepInventoryReport
{
    public partial class RepInventoryReportPDFForm : Form
    {
        public DateTime startDate;
        public DateTime endDate;
        public String category;
        public Int32 itemId;
        public String filter;

        public RepInventoryReportPDFForm(DateTime dateStart, DateTime dateEnd, String filterItemCategory, Int32 itemIds, String Filter)
        {
            InitializeComponent();
            startDate = dateStart;
            endDate = dateEnd;
            category = filterItemCategory;
            itemId = itemIds;
            filter = Filter;
        }

        public void PrintInventoryReportPDFForm()
        {
            try
            {
                Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

                iTextSharp.text.Font fontTimesNewRoman10 = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10);
                iTextSharp.text.Font fontTimesNewRoman10Italic = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10, iTextSharp.text.Font.ITALIC);
                iTextSharp.text.Font fontTimesNewRoman10Bold = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fontTimesNewRoman14Bold = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD);

                Paragraph line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.5F, 100.0F, BaseColor.DARK_GRAY, Element.ALIGN_MIDDLE, 10F)));

                var fileName = "Inventory Report PDF Form" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                var currentUser = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;

                var systemCurrent = Modules.SysCurrentModule.GetCurrentSettings();

                Document document = new Document(PageSize.LETTER.Rotate());
                document.SetMargins(30f, 30f, 100f, 30f);

                PdfWriter pdfWriter = PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
                pdfWriter.PageEvent = new InventoryReportHeaderFooter(startDate, endDate, category, itemId);

                document.Open();

                if (itemId == 0 && category == "ALL")
                {
                    List<Entities.RepInventoryReportEntity> newRepInventoryReportEntity = new List<Entities.RepInventoryReportEntity>();
                    var beginningInInventories = from d in db.TrnStockInLines
                                                 where d.TrnStockIn.IsLocked == true
                                                 && d.TrnStockIn.StockInDate < startDate.Date
                                                 && d.MstItem.IsInventory == true
                                                 && d.MstItem.IsLocked == true
                                                 select new Entities.RepInventoryReportEntity
                                                 {
                                                     Document = "Beg",
                                                     Id = "Beg-In-" + d.Id,
                                                     InventoryDate = d.TrnStockIn.StockInDate,
                                                     ItemCode = d.MstItem.ItemCode,
                                                     BarCode = d.MstItem.BarCode,
                                                     ItemDescription = d.MstItem.ItemDescription,
                                                     BeginningQuantity = d.Quantity,
                                                     InQuantity = 0,
                                                     OutQuantity = 0,
                                                     EndingQuantity = 0,
                                                     Unit = d.MstUnit.Unit,
                                                     Cost = d.MstItem.Cost,
                                                     Price = d.MstItem.Price,
                                                     Amount = 0
                                                 };

                    var beginningSoldInventories = from d in db.TrnSalesLines
                                                   where d.TrnSale.IsLocked == true
                                                   && d.TrnSale.IsCancelled == false
                                                   && d.TrnSale.SalesDate < startDate.Date
                                                   && d.MstItem.IsInventory == true
                                                   && d.MstItem.IsLocked == true
                                                   select new Entities.RepInventoryReportEntity
                                                   {
                                                       Document = "Beg",
                                                       Id = "Beg-Sold-" + d.Id,
                                                       InventoryDate = d.TrnSale.SalesDate,
                                                       ItemCode = d.MstItem.ItemCode,
                                                       BarCode = d.MstItem.BarCode,
                                                       ItemDescription = d.MstItem.ItemDescription,
                                                       BeginningQuantity = d.Quantity * -1,
                                                       InQuantity = 0,
                                                       OutQuantity = 0,
                                                       EndingQuantity = 0,
                                                       Unit = d.MstUnit.Unit,
                                                       Cost = d.MstItem.Cost,
                                                       Price = d.MstItem.Price,
                                                       Amount = 0
                                                   };

                    List<Entities.RepInventoryReportEntity> beginningSoldComponentInventories = new List<Entities.RepInventoryReportEntity>();

                    var beginningSoldComponents = from d in db.TrnSalesLines
                                                  where d.TrnSale.IsLocked == true
                                                  && d.TrnSale.IsCancelled == false
                                                  && d.TrnSale.SalesDate < startDate.Date
                                                  && d.MstItem.IsInventory == false
                                                  && d.MstItem.MstItemComponents.Any() == true
                                                  && d.MstItem.IsLocked == true
                                                  select d;

                    if (beginningSoldComponents.ToList().Any() == true)
                    {
                        foreach (var beginningSoldComponent in beginningSoldComponents.ToList())
                        {
                            var itemComponents = beginningSoldComponent.MstItem.MstItemComponents;
                            if (itemComponents.Any() == true)
                            {
                                foreach (var itemComponent in itemComponents.ToList())
                                {
                                    beginningSoldComponentInventories.Add(new Entities.RepInventoryReportEntity()
                                    {
                                        Document = "Beg",
                                        Id = "Beg-Sold-Component" + itemComponent.Id,
                                        InventoryDate = beginningSoldComponent.TrnSale.SalesDate,
                                        ItemCode = itemComponent.MstItem1.ItemCode,
                                        BarCode = itemComponent.MstItem1.BarCode,
                                        ItemDescription = itemComponent.MstItem1.ItemDescription,
                                        BeginningQuantity = (itemComponent.Quantity * beginningSoldComponent.Quantity) * -1,
                                        InQuantity = 0,
                                        OutQuantity = 0,
                                        EndingQuantity = 0,
                                        Unit = itemComponent.MstItem1.MstUnit.Unit,
                                        Cost = itemComponent.MstItem1.Cost,
                                        Price = itemComponent.MstItem1.Price,
                                        Amount = 0
                                    });
                                }
                            }
                        }
                    }

                    var beginningOutInventories = from d in db.TrnStockOutLines
                                                  where d.TrnStockOut.IsLocked == true
                                                  && d.TrnStockOut.StockOutDate < startDate.Date
                                                  && d.MstItem.IsInventory == true
                                                  && d.MstItem.IsLocked == true
                                                  select new Entities.RepInventoryReportEntity
                                                  {
                                                      Document = "Beg",
                                                      Id = "Beg-Out-" + d.Id,
                                                      InventoryDate = d.TrnStockOut.StockOutDate,
                                                      ItemCode = d.MstItem.ItemCode,
                                                      BarCode = d.MstItem.BarCode,
                                                      ItemDescription = d.MstItem.ItemDescription,
                                                      BeginningQuantity = d.Quantity * -1,
                                                      InQuantity = 0,
                                                      OutQuantity = 0,
                                                      EndingQuantity = 0,
                                                      Unit = d.MstUnit.Unit,
                                                      Cost = d.MstItem.Cost,
                                                      Price = d.MstItem.Price,
                                                      Amount = 0
                                                  };

                    var unionBeginningInventories = beginningInInventories.ToList().Union(beginningSoldInventories.ToList()).Union(beginningSoldComponentInventories.ToList()).Union(beginningOutInventories.ToList());

                    var currentInInventories = from d in db.TrnStockInLines
                                               where d.TrnStockIn.IsLocked == true
                                               && d.TrnStockIn.StockInDate >= startDate.Date
                                               && d.TrnStockIn.StockInDate <= endDate.Date
                                               && d.MstItem.IsInventory == true
                                               && d.MstItem.IsLocked == true
                                               select new Entities.RepInventoryReportEntity
                                               {
                                                   Document = "Cur",
                                                   Id = "Cur-In-" + d.Id,
                                                   InventoryDate = d.TrnStockIn.StockInDate,
                                                   ItemCode = d.MstItem.ItemCode,
                                                   BarCode = d.MstItem.BarCode,
                                                   ItemDescription = d.MstItem.ItemDescription,
                                                   BeginningQuantity = 0,
                                                   InQuantity = d.Quantity,
                                                   OutQuantity = 0,
                                                   EndingQuantity = 0,
                                                   Unit = d.MstUnit.Unit,
                                                   Cost = d.MstItem.Cost,
                                                   Price = d.MstItem.Price,
                                                   Amount = 0
                                               };

                    var currentSoldInventories = from d in db.TrnSalesLines
                                                 where d.TrnSale.IsLocked == true
                                                 && d.TrnSale.IsCancelled == false
                                                 && d.TrnSale.SalesDate >= startDate.Date
                                                 && d.TrnSale.SalesDate <= endDate.Date
                                                 && d.MstItem.IsInventory == true
                                                 && d.MstItem.IsLocked == true
                                                 select new Entities.RepInventoryReportEntity
                                                 {
                                                     Document = "Cur",
                                                     Id = "Cur-Sold-" + d.Id,
                                                     InventoryDate = d.TrnSale.SalesDate,
                                                     ItemCode = d.MstItem.ItemCode,
                                                     BarCode = d.MstItem.BarCode,
                                                     ItemDescription = d.MstItem.ItemDescription,
                                                     BeginningQuantity = 0,
                                                     InQuantity = 0,
                                                     OutQuantity = d.Quantity,
                                                     EndingQuantity = 0,
                                                     Unit = d.MstUnit.Unit,
                                                     Cost = d.MstItem.Cost,
                                                     Price = d.MstItem.Price,
                                                     Amount = 0
                                                 };

                    List<Entities.RepInventoryReportEntity> currentSoldComponentInventories = new List<Entities.RepInventoryReportEntity>();

                    var currentSoldComponents = from d in db.TrnSalesLines
                                                where d.TrnSale.IsLocked == true
                                                && d.TrnSale.IsCancelled == false
                                                && d.TrnSale.SalesDate >= startDate.Date
                                                && d.TrnSale.SalesDate <= endDate.Date
                                                && d.MstItem.IsInventory == false
                                                && d.MstItem.MstItemComponents.Any() == true
                                                && d.MstItem.IsLocked == true
                                                select d;

                    if (currentSoldComponents.ToList().Any() == true)
                    {
                        foreach (var currentSoldComponent in currentSoldComponents.ToList())
                        {
                            var itemComponents = currentSoldComponent.MstItem.MstItemComponents;
                            if (itemComponents.Any() == true)
                            {
                                foreach (var itemComponent in itemComponents.ToList())
                                {
                                    currentSoldComponentInventories.Add(new Entities.RepInventoryReportEntity()
                                    {
                                        Document = "Cur",
                                        Id = "Cur-Sold-Component" + itemComponent.Id,
                                        InventoryDate = currentSoldComponent.TrnSale.SalesDate,
                                        ItemCode = itemComponent.MstItem1.ItemCode,
                                        BarCode = itemComponent.MstItem1.BarCode,
                                        ItemDescription = itemComponent.MstItem1.ItemDescription,
                                        BeginningQuantity = 0,
                                        InQuantity = 0,
                                        OutQuantity = itemComponent.Quantity * currentSoldComponent.Quantity,
                                        EndingQuantity = 0,
                                        Unit = itemComponent.MstItem1.MstUnit.Unit,
                                        Cost = itemComponent.MstItem1.Cost,
                                        Price = itemComponent.MstItem1.Price,
                                        Amount = 0
                                    });
                                }
                            }
                        }
                    }

                    var currentOutInventories = from d in db.TrnStockOutLines
                                                where d.TrnStockOut.IsLocked == true
                                                && d.TrnStockOut.StockOutDate >= startDate.Date
                                                && d.TrnStockOut.StockOutDate <= endDate.Date
                                                && d.MstItem.IsInventory == true
                                                && d.MstItem.IsLocked == true
                                                select new Entities.RepInventoryReportEntity
                                                {
                                                    Document = "Cur",
                                                    Id = "Cur-Out-" + d.Id,
                                                    InventoryDate = d.TrnStockOut.StockOutDate,
                                                    ItemCode = d.MstItem.ItemCode,
                                                    BarCode = d.MstItem.BarCode,
                                                    ItemDescription = d.MstItem.ItemDescription,
                                                    BeginningQuantity = 0,
                                                    InQuantity = 0,
                                                    OutQuantity = d.Quantity,
                                                    EndingQuantity = 0,
                                                    Unit = d.MstUnit.Unit,
                                                    Cost = d.MstItem.Cost,
                                                    Price = d.MstItem.Price,
                                                    Amount = 0
                                                };

                    var unionCurrentInventories = currentInInventories.ToList().Union(currentSoldInventories.ToList()).Union(currentSoldComponentInventories.ToList()).Union(currentOutInventories.ToList());

                    var unionInventories = unionBeginningInventories.ToList().Union(unionCurrentInventories.ToList());
                    if (unionInventories.Any())
                    {
                        var inventories = from d in unionInventories
                                          group d by new
                                          {
                                              d.ItemCode,
                                              d.BarCode,
                                              d.ItemDescription,
                                              d.Unit,
                                              d.Cost,
                                              d.Price
                                          } into g
                                          select new Entities.RepInventoryReportEntity
                                          {
                                              ItemCode = g.Key.ItemCode,
                                              BarCode = g.Key.BarCode,
                                              ItemDescription = g.Key.ItemDescription,
                                              Unit = g.Key.Unit,
                                              BeginningQuantity = g.Sum(s => s.BeginningQuantity),
                                              InQuantity = g.Sum(s => s.InQuantity),
                                              OutQuantity = g.Sum(s => s.OutQuantity) * -1,
                                              EndingQuantity = g.Sum(s => (s.BeginningQuantity + s.InQuantity) - s.OutQuantity),
                                              CountQuantity = 0,
                                              Variance = g.Sum(s => (s.BeginningQuantity + s.InQuantity) - s.OutQuantity),
                                              Cost = g.Key.Cost,
                                              Price = g.Key.Price,
                                              Amount = g.Key.Cost * g.Sum(s => (s.BeginningQuantity + s.InQuantity) - s.OutQuantity),
                                          };

                        return inventories.Where(d => d.ItemDescription.ToUpper().Contains(filter.ToUpper()) == true || d.Unit.ToUpper().Contains(filter.ToUpper()) == true).OrderBy(d => d.ItemDescription).ToList();
                    }
                }
                else if (category != "ALL" && itemId != 0)
                {
                    List<Entities.RepInventoryReportEntity> newRepInventoryReportEntity = new List<Entities.RepInventoryReportEntity>();
                    var beginningInInventories = from d in db.TrnStockInLines
                                                 where d.TrnStockIn.IsLocked == true
                                                 && d.TrnStockIn.StockInDate < startDate.Date
                                                 && d.MstItem.Category == category
                                                 && d.MstItem.Id == itemId
                                                 && d.MstItem.IsInventory == true
                                                 && d.MstItem.IsLocked == true
                                                 select new Entities.RepInventoryReportEntity
                                                 {
                                                     Document = "Beg",
                                                     Id = "Beg-In-" + d.Id,
                                                     InventoryDate = d.TrnStockIn.StockInDate,
                                                     ItemCode = d.MstItem.ItemCode,
                                                     BarCode = d.MstItem.BarCode,
                                                     ItemDescription = d.MstItem.ItemDescription,
                                                     BeginningQuantity = d.Quantity,
                                                     InQuantity = 0,
                                                     OutQuantity = 0,
                                                     EndingQuantity = 0,
                                                     Unit = d.MstUnit.Unit,
                                                     Cost = d.MstItem.Cost,
                                                     Price = d.MstItem.Price,
                                                     Amount = 0
                                                 };

                    var beginningSoldInventories = from d in db.TrnSalesLines
                                                   where d.TrnSale.IsLocked == true
                                                   && d.TrnSale.IsCancelled == false
                                                   && d.TrnSale.SalesDate < startDate.Date
                                                   && d.MstItem.Category == category
                                                   && d.MstItem.Id == itemId
                                                   && d.MstItem.IsInventory == true
                                                   && d.MstItem.IsLocked == true
                                                   select new Entities.RepInventoryReportEntity
                                                   {
                                                       Document = "Beg",
                                                       Id = "Beg-Sold-" + d.Id,
                                                       InventoryDate = d.TrnSale.SalesDate,
                                                       ItemCode = d.MstItem.ItemCode,
                                                       BarCode = d.MstItem.BarCode,
                                                       ItemDescription = d.MstItem.ItemDescription,
                                                       BeginningQuantity = d.Quantity * -1,
                                                       InQuantity = 0,
                                                       OutQuantity = 0,
                                                       EndingQuantity = 0,
                                                       Unit = d.MstUnit.Unit,
                                                       Cost = d.MstItem.Cost,
                                                       Price = d.MstItem.Price,
                                                       Amount = 0
                                                   };

                    List<Entities.RepInventoryReportEntity> beginningSoldComponentInventories = new List<Entities.RepInventoryReportEntity>();

                    var beginningSoldComponents = from d in db.TrnSalesLines
                                                  where d.TrnSale.IsLocked == true
                                                  && d.TrnSale.IsCancelled == false
                                                  && d.TrnSale.SalesDate < startDate.Date
                                                  && d.MstItem.Category == category
                                                  && d.MstItem.Id == itemId
                                                  && d.MstItem.IsInventory == false
                                                  && d.MstItem.MstItemComponents.Any() == true
                                                  && d.MstItem.IsLocked == true
                                                  select d;

                    if (beginningSoldComponents.ToList().Any() == true)
                    {
                        foreach (var beginningSoldComponent in beginningSoldComponents.ToList())
                        {
                            var itemComponents = beginningSoldComponent.MstItem.MstItemComponents;
                            if (itemComponents.Any() == true)
                            {
                                foreach (var itemComponent in itemComponents.ToList())
                                {
                                    beginningSoldComponentInventories.Add(new Entities.RepInventoryReportEntity()
                                    {
                                        Document = "Beg",
                                        Id = "Beg-Sold-Component" + itemComponent.Id,
                                        InventoryDate = beginningSoldComponent.TrnSale.SalesDate,
                                        ItemCode = itemComponent.MstItem1.ItemCode,
                                        BarCode = itemComponent.MstItem1.BarCode,
                                        ItemDescription = itemComponent.MstItem1.ItemDescription,
                                        BeginningQuantity = (itemComponent.Quantity * beginningSoldComponent.Quantity) * -1,
                                        InQuantity = 0,
                                        OutQuantity = 0,
                                        EndingQuantity = 0,
                                        Unit = itemComponent.MstItem1.MstUnit.Unit,
                                        Cost = itemComponent.MstItem1.Cost,
                                        Price = itemComponent.MstItem1.Price,
                                        Amount = 0
                                    });
                                }
                            }
                        }
                    }

                    var beginningOutInventories = from d in db.TrnStockOutLines
                                                  where d.TrnStockOut.IsLocked == true
                                                  && d.TrnStockOut.StockOutDate < startDate.Date
                                                  && d.MstItem.Category == category
                                                  && d.MstItem.Id == itemId
                                                  && d.MstItem.IsInventory == true
                                                  && d.MstItem.IsLocked == true
                                                  select new Entities.RepInventoryReportEntity
                                                  {
                                                      Document = "Beg",
                                                      Id = "Beg-Out-" + d.Id,
                                                      InventoryDate = d.TrnStockOut.StockOutDate,
                                                      ItemCode = d.MstItem.ItemCode,
                                                      BarCode = d.MstItem.BarCode,
                                                      ItemDescription = d.MstItem.ItemDescription,
                                                      BeginningQuantity = d.Quantity * -1,
                                                      InQuantity = 0,
                                                      OutQuantity = 0,
                                                      EndingQuantity = 0,
                                                      Unit = d.MstUnit.Unit,
                                                      Cost = d.MstItem.Cost,
                                                      Price = d.MstItem.Price,
                                                      Amount = 0
                                                  };

                    var unionBeginningInventories = beginningInInventories.ToList().Union(beginningSoldInventories.ToList()).Union(beginningSoldComponentInventories.ToList()).Union(beginningOutInventories.ToList());

                    var currentInInventories = from d in db.TrnStockInLines
                                               where d.TrnStockIn.IsLocked == true
                                               && d.TrnStockIn.StockInDate >= startDate.Date
                                               && d.TrnStockIn.StockInDate <= endDate.Date
                                               && d.MstItem.Category == category
                                               && d.MstItem.Id == itemId
                                               && d.MstItem.IsInventory == true
                                               && d.MstItem.IsLocked == true
                                               select new Entities.RepInventoryReportEntity
                                               {
                                                   Document = "Cur",
                                                   Id = "Cur-In-" + d.Id,
                                                   InventoryDate = d.TrnStockIn.StockInDate,
                                                   ItemCode = d.MstItem.ItemCode,
                                                   BarCode = d.MstItem.BarCode,
                                                   ItemDescription = d.MstItem.ItemDescription,
                                                   BeginningQuantity = 0,
                                                   InQuantity = d.Quantity,
                                                   OutQuantity = 0,
                                                   EndingQuantity = 0,
                                                   Unit = d.MstUnit.Unit,
                                                   Cost = d.MstItem.Cost,
                                                   Price = d.MstItem.Price,
                                                   Amount = 0
                                               };

                    var currentSoldInventories = from d in db.TrnSalesLines
                                                 where d.TrnSale.IsLocked == true
                                                 && d.TrnSale.IsCancelled == false
                                                 && d.TrnSale.SalesDate >= startDate.Date
                                                 && d.TrnSale.SalesDate <= endDate.Date
                                                 && d.MstItem.Category == category
                                                 && d.MstItem.Id == itemId
                                                 && d.MstItem.IsInventory == true
                                                 && d.MstItem.IsLocked == true
                                                 select new Entities.RepInventoryReportEntity
                                                 {
                                                     Document = "Cur",
                                                     Id = "Cur-Sold-" + d.Id,
                                                     InventoryDate = d.TrnSale.SalesDate,
                                                     ItemCode = d.MstItem.ItemCode,
                                                     BarCode = d.MstItem.BarCode,
                                                     ItemDescription = d.MstItem.ItemDescription,
                                                     BeginningQuantity = 0,
                                                     InQuantity = 0,
                                                     OutQuantity = d.Quantity,
                                                     EndingQuantity = 0,
                                                     Unit = d.MstUnit.Unit,
                                                     Cost = d.MstItem.Cost,
                                                     Price = d.MstItem.Price,
                                                     Amount = 0
                                                 };

                    List<Entities.RepInventoryReportEntity> currentSoldComponentInventories = new List<Entities.RepInventoryReportEntity>();

                    var currentSoldComponents = from d in db.TrnSalesLines
                                                where d.TrnSale.IsLocked == true
                                                && d.TrnSale.IsCancelled == false
                                                && d.TrnSale.SalesDate >= startDate.Date
                                                && d.TrnSale.SalesDate <= endDate.Date
                                                && d.MstItem.Category == category
                                                && d.MstItem.Id == itemId
                                                && d.MstItem.IsInventory == false
                                                && d.MstItem.MstItemComponents.Any() == true
                                                && d.MstItem.IsLocked == true
                                                select d;

                    if (currentSoldComponents.ToList().Any() == true)
                    {
                        foreach (var currentSoldComponent in currentSoldComponents.ToList())
                        {
                            var itemComponents = currentSoldComponent.MstItem.MstItemComponents;
                            if (itemComponents.Any() == true)
                            {
                                foreach (var itemComponent in itemComponents.ToList())
                                {
                                    currentSoldComponentInventories.Add(new Entities.RepInventoryReportEntity()
                                    {
                                        Document = "Cur",
                                        Id = "Cur-Sold-Component" + itemComponent.Id,
                                        InventoryDate = currentSoldComponent.TrnSale.SalesDate,
                                        ItemCode = itemComponent.MstItem1.ItemCode,
                                        BarCode = itemComponent.MstItem1.BarCode,
                                        ItemDescription = itemComponent.MstItem1.ItemDescription,
                                        BeginningQuantity = 0,
                                        InQuantity = 0,
                                        OutQuantity = itemComponent.Quantity * currentSoldComponent.Quantity,
                                        EndingQuantity = 0,
                                        Unit = itemComponent.MstItem1.MstUnit.Unit,
                                        Cost = itemComponent.MstItem1.Cost,
                                        Price = itemComponent.MstItem1.Price,
                                        Amount = 0
                                    });
                                }
                            }
                        }
                    }

                    var currentOutInventories = from d in db.TrnStockOutLines
                                                where d.TrnStockOut.IsLocked == true
                                                && d.TrnStockOut.StockOutDate >= startDate.Date
                                                && d.TrnStockOut.StockOutDate <= endDate.Date
                                                && d.MstItem.Category == category
                                                && d.MstItem.Id == itemId
                                                && d.MstItem.IsInventory == true
                                                && d.MstItem.IsLocked == true
                                                select new Entities.RepInventoryReportEntity
                                                {
                                                    Document = "Cur",
                                                    Id = "Cur-Out-" + d.Id,
                                                    InventoryDate = d.TrnStockOut.StockOutDate,
                                                    ItemCode = d.MstItem.ItemCode,
                                                    BarCode = d.MstItem.BarCode,
                                                    ItemDescription = d.MstItem.ItemDescription,
                                                    BeginningQuantity = 0,
                                                    InQuantity = 0,
                                                    OutQuantity = d.Quantity,
                                                    EndingQuantity = 0,
                                                    Unit = d.MstUnit.Unit,
                                                    Cost = d.MstItem.Cost,
                                                    Price = d.MstItem.Price,
                                                    Amount = 0
                                                };

                    var unionCurrentInventories = currentInInventories.ToList().Union(currentSoldInventories.ToList()).Union(currentSoldComponentInventories.ToList()).Union(currentOutInventories.ToList());

                    var unionInventories = unionBeginningInventories.ToList().Union(unionCurrentInventories.ToList());
                    if (unionInventories.Any())
                    {
                        var inventories = from d in unionInventories
                                          group d by new
                                          {
                                              d.ItemCode,
                                              d.BarCode,
                                              d.ItemDescription,
                                              d.Unit,
                                              d.Cost,
                                              d.Price
                                          } into g
                                          select new Entities.RepInventoryReportEntity
                                          {
                                              ItemCode = g.Key.ItemCode,
                                              BarCode = g.Key.BarCode,
                                              ItemDescription = g.Key.ItemDescription,
                                              Unit = g.Key.Unit,
                                              BeginningQuantity = g.Sum(s => s.BeginningQuantity),
                                              InQuantity = g.Sum(s => s.InQuantity),
                                              OutQuantity = g.Sum(s => s.OutQuantity) * -1,
                                              EndingQuantity = g.Sum(s => (s.BeginningQuantity + s.InQuantity) - s.OutQuantity),
                                              CountQuantity = 0,
                                              Variance = g.Sum(s => (s.BeginningQuantity + s.InQuantity) - s.OutQuantity),
                                              Cost = g.Key.Cost,
                                              Price = g.Key.Price,
                                              Amount = g.Key.Cost * g.Sum(s => (s.BeginningQuantity + s.InQuantity) - s.OutQuantity),
                                          };

                        return inventories.Where(d => d.ItemDescription.ToUpper().Contains(filter.ToUpper()) == true || d.Unit.ToUpper().Contains(filter.ToUpper()) == true).OrderBy(d => d.ItemDescription).ToList();
                    }
                }
                else if (category == "ALL" && itemId != 0)
                {
                    List<Entities.RepInventoryReportEntity> newRepInventoryReportEntity = new List<Entities.RepInventoryReportEntity>();
                    var beginningInInventories = from d in db.TrnStockInLines
                                                 where d.TrnStockIn.IsLocked == true
                                                 && d.TrnStockIn.StockInDate < startDate.Date
                                                 && d.MstItem.Id == itemId
                                                 && d.MstItem.IsInventory == true
                                                 && d.MstItem.IsLocked == true
                                                 select new Entities.RepInventoryReportEntity
                                                 {
                                                     Document = "Beg",
                                                     Id = "Beg-In-" + d.Id,
                                                     InventoryDate = d.TrnStockIn.StockInDate,
                                                     ItemCode = d.MstItem.ItemCode,
                                                     BarCode = d.MstItem.BarCode,
                                                     ItemDescription = d.MstItem.ItemDescription,
                                                     BeginningQuantity = d.Quantity,
                                                     InQuantity = 0,
                                                     OutQuantity = 0,
                                                     EndingQuantity = 0,
                                                     Unit = d.MstUnit.Unit,
                                                     Cost = d.MstItem.Cost,
                                                     Price = d.MstItem.Price,
                                                     Amount = 0
                                                 };

                    var beginningSoldInventories = from d in db.TrnSalesLines
                                                   where d.TrnSale.IsLocked == true
                                                   && d.TrnSale.IsCancelled == false
                                                   && d.TrnSale.SalesDate < startDate.Date
                                                  && d.MstItem.Id == itemId
                                                   && d.MstItem.IsInventory == true
                                                   && d.MstItem.IsLocked == true
                                                   select new Entities.RepInventoryReportEntity
                                                   {
                                                       Document = "Beg",
                                                       Id = "Beg-Sold-" + d.Id,
                                                       InventoryDate = d.TrnSale.SalesDate,
                                                       ItemCode = d.MstItem.ItemCode,
                                                       BarCode = d.MstItem.BarCode,
                                                       ItemDescription = d.MstItem.ItemDescription,
                                                       BeginningQuantity = d.Quantity * -1,
                                                       InQuantity = 0,
                                                       OutQuantity = 0,
                                                       EndingQuantity = 0,
                                                       Unit = d.MstUnit.Unit,
                                                       Cost = d.MstItem.Cost,
                                                       Price = d.MstItem.Price,
                                                       Amount = 0
                                                   };

                    List<Entities.RepInventoryReportEntity> beginningSoldComponentInventories = new List<Entities.RepInventoryReportEntity>();

                    var beginningSoldComponents = from d in db.TrnSalesLines
                                                  where d.TrnSale.IsLocked == true
                                                  && d.TrnSale.IsCancelled == false
                                                  && d.TrnSale.SalesDate < startDate.Date
                                                  && d.MstItem.Id == itemId
                                                  && d.MstItem.IsInventory == false
                                                  && d.MstItem.MstItemComponents.Any() == true
                                                  && d.MstItem.IsLocked == true
                                                  select d;

                    if (beginningSoldComponents.ToList().Any() == true)
                    {
                        foreach (var beginningSoldComponent in beginningSoldComponents.ToList())
                        {
                            var itemComponents = beginningSoldComponent.MstItem.MstItemComponents;
                            if (itemComponents.Any() == true)
                            {
                                foreach (var itemComponent in itemComponents.ToList())
                                {
                                    beginningSoldComponentInventories.Add(new Entities.RepInventoryReportEntity()
                                    {
                                        Document = "Beg",
                                        Id = "Beg-Sold-Component" + itemComponent.Id,
                                        InventoryDate = beginningSoldComponent.TrnSale.SalesDate,
                                        ItemCode = itemComponent.MstItem1.ItemCode,
                                        BarCode = itemComponent.MstItem1.BarCode,
                                        ItemDescription = itemComponent.MstItem1.ItemDescription,
                                        BeginningQuantity = (itemComponent.Quantity * beginningSoldComponent.Quantity) * -1,
                                        InQuantity = 0,
                                        OutQuantity = 0,
                                        EndingQuantity = 0,
                                        Unit = itemComponent.MstItem1.MstUnit.Unit,
                                        Cost = itemComponent.MstItem1.Cost,
                                        Price = itemComponent.MstItem1.Price,
                                        Amount = 0
                                    });
                                }
                            }
                        }
                    }

                    var beginningOutInventories = from d in db.TrnStockOutLines
                                                  where d.TrnStockOut.IsLocked == true
                                                  && d.TrnStockOut.StockOutDate < startDate.Date
                                                  && d.MstItem.Id == itemId
                                                  && d.MstItem.IsInventory == true
                                                  && d.MstItem.IsLocked == true
                                                  select new Entities.RepInventoryReportEntity
                                                  {
                                                      Document = "Beg",
                                                      Id = "Beg-Out-" + d.Id,
                                                      InventoryDate = d.TrnStockOut.StockOutDate,
                                                      ItemCode = d.MstItem.ItemCode,
                                                      BarCode = d.MstItem.BarCode,
                                                      ItemDescription = d.MstItem.ItemDescription,
                                                      BeginningQuantity = d.Quantity * -1,
                                                      InQuantity = 0,
                                                      OutQuantity = 0,
                                                      EndingQuantity = 0,
                                                      Unit = d.MstUnit.Unit,
                                                      Cost = d.MstItem.Cost,
                                                      Price = d.MstItem.Price,
                                                      Amount = 0
                                                  };

                    var unionBeginningInventories = beginningInInventories.ToList().Union(beginningSoldInventories.ToList()).Union(beginningSoldComponentInventories.ToList()).Union(beginningOutInventories.ToList());

                    var currentInInventories = from d in db.TrnStockInLines
                                               where d.TrnStockIn.IsLocked == true
                                               && d.TrnStockIn.StockInDate >= startDate.Date
                                               && d.TrnStockIn.StockInDate <= endDate.Date
                                               && d.MstItem.Id == itemId
                                               && d.MstItem.IsInventory == true
                                               && d.MstItem.IsLocked == true
                                               select new Entities.RepInventoryReportEntity
                                               {
                                                   Document = "Cur",
                                                   Id = "Cur-In-" + d.Id,
                                                   InventoryDate = d.TrnStockIn.StockInDate,
                                                   ItemCode = d.MstItem.ItemCode,
                                                   BarCode = d.MstItem.BarCode,
                                                   ItemDescription = d.MstItem.ItemDescription,
                                                   BeginningQuantity = 0,
                                                   InQuantity = d.Quantity,
                                                   OutQuantity = 0,
                                                   EndingQuantity = 0,
                                                   Unit = d.MstUnit.Unit,
                                                   Cost = d.MstItem.Cost,
                                                   Price = d.MstItem.Price,
                                                   Amount = 0
                                               };

                    var currentSoldInventories = from d in db.TrnSalesLines
                                                 where d.TrnSale.IsLocked == true
                                                 && d.TrnSale.IsCancelled == false
                                                 && d.TrnSale.SalesDate >= startDate.Date
                                                 && d.TrnSale.SalesDate <= endDate.Date
                                                 && d.MstItem.Id == itemId
                                                 && d.MstItem.IsInventory == true
                                                 && d.MstItem.IsLocked == true
                                                 select new Entities.RepInventoryReportEntity
                                                 {
                                                     Document = "Cur",
                                                     Id = "Cur-Sold-" + d.Id,
                                                     InventoryDate = d.TrnSale.SalesDate,
                                                     ItemCode = d.MstItem.ItemCode,
                                                     BarCode = d.MstItem.BarCode,
                                                     ItemDescription = d.MstItem.ItemDescription,
                                                     BeginningQuantity = 0,
                                                     InQuantity = 0,
                                                     OutQuantity = d.Quantity,
                                                     EndingQuantity = 0,
                                                     Unit = d.MstUnit.Unit,
                                                     Cost = d.MstItem.Cost,
                                                     Price = d.MstItem.Price,
                                                     Amount = 0
                                                 };

                    List<Entities.RepInventoryReportEntity> currentSoldComponentInventories = new List<Entities.RepInventoryReportEntity>();

                    var currentSoldComponents = from d in db.TrnSalesLines
                                                where d.TrnSale.IsLocked == true
                                                && d.TrnSale.IsCancelled == false
                                                && d.TrnSale.SalesDate >= startDate.Date
                                                && d.TrnSale.SalesDate <= endDate.Date
                                                && d.MstItem.Id == itemId
                                                && d.MstItem.IsInventory == false
                                                && d.MstItem.MstItemComponents.Any() == true
                                                && d.MstItem.IsLocked == true
                                                select d;

                    if (currentSoldComponents.ToList().Any() == true)
                    {
                        foreach (var currentSoldComponent in currentSoldComponents.ToList())
                        {
                            var itemComponents = currentSoldComponent.MstItem.MstItemComponents;
                            if (itemComponents.Any() == true)
                            {
                                foreach (var itemComponent in itemComponents.ToList())
                                {
                                    currentSoldComponentInventories.Add(new Entities.RepInventoryReportEntity()
                                    {
                                        Document = "Cur",
                                        Id = "Cur-Sold-Component" + itemComponent.Id,
                                        InventoryDate = currentSoldComponent.TrnSale.SalesDate,
                                        ItemCode = itemComponent.MstItem1.ItemCode,
                                        BarCode = itemComponent.MstItem1.BarCode,
                                        ItemDescription = itemComponent.MstItem1.ItemDescription,
                                        BeginningQuantity = 0,
                                        InQuantity = 0,
                                        OutQuantity = itemComponent.Quantity * currentSoldComponent.Quantity,
                                        EndingQuantity = 0,
                                        Unit = itemComponent.MstItem1.MstUnit.Unit,
                                        Cost = itemComponent.MstItem1.Cost,
                                        Price = itemComponent.MstItem1.Price,
                                        Amount = 0
                                    });
                                }
                            }
                        }
                    }

                    var currentOutInventories = from d in db.TrnStockOutLines
                                                where d.TrnStockOut.IsLocked == true
                                                && d.TrnStockOut.StockOutDate >= startDate.Date
                                                && d.TrnStockOut.StockOutDate <= endDate.Date
                                                && d.MstItem.Id == itemId
                                                && d.MstItem.IsInventory == true
                                                && d.MstItem.IsLocked == true
                                                select new Entities.RepInventoryReportEntity
                                                {
                                                    Document = "Cur",
                                                    Id = "Cur-Out-" + d.Id,
                                                    InventoryDate = d.TrnStockOut.StockOutDate,
                                                    ItemCode = d.MstItem.ItemCode,
                                                    BarCode = d.MstItem.BarCode,
                                                    ItemDescription = d.MstItem.ItemDescription,
                                                    BeginningQuantity = 0,
                                                    InQuantity = 0,
                                                    OutQuantity = d.Quantity,
                                                    EndingQuantity = 0,
                                                    Unit = d.MstUnit.Unit,
                                                    Cost = d.MstItem.Cost,
                                                    Price = d.MstItem.Price,
                                                    Amount = 0
                                                };

                    var unionCurrentInventories = currentInInventories.ToList().Union(currentSoldInventories.ToList()).Union(currentSoldComponentInventories.ToList()).Union(currentOutInventories.ToList());

                    var unionInventories = unionBeginningInventories.ToList().Union(unionCurrentInventories.ToList());
                    if (unionInventories.Any())
                    {
                        var inventories = from d in unionInventories
                                          group d by new
                                          {
                                              d.ItemCode,
                                              d.BarCode,
                                              d.ItemDescription,
                                              d.Unit,
                                              d.Cost,
                                              d.Price
                                          } into g
                                          select new Entities.RepInventoryReportEntity
                                          {
                                              ItemCode = g.Key.ItemCode,
                                              BarCode = g.Key.BarCode,
                                              ItemDescription = g.Key.ItemDescription,
                                              Unit = g.Key.Unit,
                                              BeginningQuantity = g.Sum(s => s.BeginningQuantity),
                                              InQuantity = g.Sum(s => s.InQuantity),
                                              OutQuantity = g.Sum(s => s.OutQuantity) * -1,
                                              EndingQuantity = g.Sum(s => (s.BeginningQuantity + s.InQuantity) - s.OutQuantity),
                                              CountQuantity = 0,
                                              Variance = g.Sum(s => (s.BeginningQuantity + s.InQuantity) - s.OutQuantity),
                                              Cost = g.Key.Cost,
                                              Price = g.Key.Price,
                                              Amount = g.Key.Cost * g.Sum(s => (s.BeginningQuantity + s.InQuantity) - s.OutQuantity),
                                          };

                        return inventories.Where(d => d.ItemDescription.ToUpper().Contains(filter.ToUpper()) == true || d.Unit.ToUpper().Contains(filter.ToUpper()) == true).OrderBy(d => d.ItemDescription).ToList();
                    }
                }
                else if (category != "ALL" && itemId == 0)
                {
                    List<Entities.RepInventoryReportEntity> newRepInventoryReportEntity = new List<Entities.RepInventoryReportEntity>();
                    var beginningInInventories = from d in db.TrnStockInLines
                                                 where d.TrnStockIn.IsLocked == true
                                                 && d.TrnStockIn.StockInDate < startDate.Date
                                                 && d.MstItem.Category == category
                                                 && d.MstItem.IsInventory == true
                                                 && d.MstItem.IsLocked == true
                                                 select new Entities.RepInventoryReportEntity
                                                 {
                                                     Document = "Beg",
                                                     Id = "Beg-In-" + d.Id,
                                                     InventoryDate = d.TrnStockIn.StockInDate,
                                                     ItemCode = d.MstItem.ItemCode,
                                                     BarCode = d.MstItem.BarCode,
                                                     ItemDescription = d.MstItem.ItemDescription,
                                                     BeginningQuantity = d.Quantity,
                                                     InQuantity = 0,
                                                     OutQuantity = 0,
                                                     EndingQuantity = 0,
                                                     Unit = d.MstUnit.Unit,
                                                     Cost = d.MstItem.Cost,
                                                     Price = d.MstItem.Price,
                                                     Amount = 0
                                                 };

                    var beginningSoldInventories = from d in db.TrnSalesLines
                                                   where d.TrnSale.IsLocked == true
                                                   && d.TrnSale.IsCancelled == false
                                                   && d.TrnSale.SalesDate < startDate.Date
                                                   && d.MstItem.Category == category
                                                   && d.MstItem.IsInventory == true
                                                   && d.MstItem.IsLocked == true
                                                   select new Entities.RepInventoryReportEntity
                                                   {
                                                       Document = "Beg",
                                                       Id = "Beg-Sold-" + d.Id,
                                                       InventoryDate = d.TrnSale.SalesDate,
                                                       ItemCode = d.MstItem.ItemCode,
                                                       BarCode = d.MstItem.BarCode,
                                                       ItemDescription = d.MstItem.ItemDescription,
                                                       BeginningQuantity = d.Quantity * -1,
                                                       InQuantity = 0,
                                                       OutQuantity = 0,
                                                       EndingQuantity = 0,
                                                       Unit = d.MstUnit.Unit,
                                                       Cost = d.MstItem.Cost,
                                                       Price = d.MstItem.Price,
                                                       Amount = 0
                                                   };

                    List<Entities.RepInventoryReportEntity> beginningSoldComponentInventories = new List<Entities.RepInventoryReportEntity>();

                    var beginningSoldComponents = from d in db.TrnSalesLines
                                                  where d.TrnSale.IsLocked == true
                                                  && d.TrnSale.IsCancelled == false
                                                  && d.TrnSale.SalesDate < startDate.Date
                                                  && d.MstItem.Category == category
                                                  && d.MstItem.IsInventory == false
                                                  && d.MstItem.MstItemComponents.Any() == true
                                                  && d.MstItem.IsLocked == true
                                                  select d;

                    if (beginningSoldComponents.ToList().Any() == true)
                    {
                        foreach (var beginningSoldComponent in beginningSoldComponents.ToList())
                        {
                            var itemComponents = beginningSoldComponent.MstItem.MstItemComponents;
                            if (itemComponents.Any() == true)
                            {
                                foreach (var itemComponent in itemComponents.ToList())
                                {
                                    beginningSoldComponentInventories.Add(new Entities.RepInventoryReportEntity()
                                    {
                                        Document = "Beg",
                                        Id = "Beg-Sold-Component" + itemComponent.Id,
                                        InventoryDate = beginningSoldComponent.TrnSale.SalesDate,
                                        ItemCode = itemComponent.MstItem1.ItemCode,
                                        BarCode = itemComponent.MstItem1.BarCode,
                                        ItemDescription = itemComponent.MstItem1.ItemDescription,
                                        BeginningQuantity = (itemComponent.Quantity * beginningSoldComponent.Quantity) * -1,
                                        InQuantity = 0,
                                        OutQuantity = 0,
                                        EndingQuantity = 0,
                                        Unit = itemComponent.MstItem1.MstUnit.Unit,
                                        Cost = itemComponent.MstItem1.Cost,
                                        Price = itemComponent.MstItem1.Price,
                                        Amount = 0
                                    });
                                }
                            }
                        }
                    }

                    var beginningOutInventories = from d in db.TrnStockOutLines
                                                  where d.TrnStockOut.IsLocked == true
                                                  && d.TrnStockOut.StockOutDate < startDate.Date
                                                  && d.MstItem.Category == category
                                                  && d.MstItem.IsInventory == true
                                                  && d.MstItem.IsLocked == true
                                                  select new Entities.RepInventoryReportEntity
                                                  {
                                                      Document = "Beg",
                                                      Id = "Beg-Out-" + d.Id,
                                                      InventoryDate = d.TrnStockOut.StockOutDate,
                                                      ItemCode = d.MstItem.ItemCode,
                                                      BarCode = d.MstItem.BarCode,
                                                      ItemDescription = d.MstItem.ItemDescription,
                                                      BeginningQuantity = d.Quantity * -1,
                                                      InQuantity = 0,
                                                      OutQuantity = 0,
                                                      EndingQuantity = 0,
                                                      Unit = d.MstUnit.Unit,
                                                      Cost = d.MstItem.Cost,
                                                      Price = d.MstItem.Price,
                                                      Amount = 0
                                                  };

                    var unionBeginningInventories = beginningInInventories.ToList().Union(beginningSoldInventories.ToList()).Union(beginningSoldComponentInventories.ToList()).Union(beginningOutInventories.ToList());

                    var currentInInventories = from d in db.TrnStockInLines
                                               where d.TrnStockIn.IsLocked == true
                                               && d.TrnStockIn.StockInDate >= startDate.Date
                                               && d.TrnStockIn.StockInDate <= endDate.Date
                                               && d.MstItem.Category == category
                                               && d.MstItem.IsInventory == true
                                               && d.MstItem.IsLocked == true
                                               select new Entities.RepInventoryReportEntity
                                               {
                                                   Document = "Cur",
                                                   Id = "Cur-In-" + d.Id,
                                                   InventoryDate = d.TrnStockIn.StockInDate,
                                                   ItemCode = d.MstItem.ItemCode,
                                                   BarCode = d.MstItem.BarCode,
                                                   ItemDescription = d.MstItem.ItemDescription,
                                                   BeginningQuantity = 0,
                                                   InQuantity = d.Quantity,
                                                   OutQuantity = 0,
                                                   EndingQuantity = 0,
                                                   Unit = d.MstUnit.Unit,
                                                   Cost = d.MstItem.Cost,
                                                   Price = d.MstItem.Price,
                                                   Amount = 0
                                               };

                    var currentSoldInventories = from d in db.TrnSalesLines
                                                 where d.TrnSale.IsLocked == true
                                                 && d.TrnSale.IsCancelled == false
                                                 && d.TrnSale.SalesDate >= startDate.Date
                                                 && d.TrnSale.SalesDate <= endDate.Date
                                                 && d.MstItem.Category == category
                                                 && d.MstItem.IsInventory == true
                                                 && d.MstItem.IsLocked == true
                                                 select new Entities.RepInventoryReportEntity
                                                 {
                                                     Document = "Cur",
                                                     Id = "Cur-Sold-" + d.Id,
                                                     InventoryDate = d.TrnSale.SalesDate,
                                                     ItemCode = d.MstItem.ItemCode,
                                                     BarCode = d.MstItem.BarCode,
                                                     ItemDescription = d.MstItem.ItemDescription,
                                                     BeginningQuantity = 0,
                                                     InQuantity = 0,
                                                     OutQuantity = d.Quantity,
                                                     EndingQuantity = 0,
                                                     Unit = d.MstUnit.Unit,
                                                     Cost = d.MstItem.Cost,
                                                     Price = d.MstItem.Price,
                                                     Amount = 0
                                                 };

                    List<Entities.RepInventoryReportEntity> currentSoldComponentInventories = new List<Entities.RepInventoryReportEntity>();

                    var currentSoldComponents = from d in db.TrnSalesLines
                                                where d.TrnSale.IsLocked == true
                                                && d.TrnSale.IsCancelled == false
                                                && d.TrnSale.SalesDate >= startDate.Date
                                                && d.TrnSale.SalesDate <= endDate.Date
                                                && d.MstItem.Category == category
                                                && d.MstItem.IsInventory == false
                                                && d.MstItem.MstItemComponents.Any() == true
                                                && d.MstItem.IsLocked == true
                                                select d;

                    if (currentSoldComponents.ToList().Any() == true)
                    {
                        foreach (var currentSoldComponent in currentSoldComponents.ToList())
                        {
                            var itemComponents = currentSoldComponent.MstItem.MstItemComponents;
                            if (itemComponents.Any() == true)
                            {
                                foreach (var itemComponent in itemComponents.ToList())
                                {
                                    currentSoldComponentInventories.Add(new Entities.RepInventoryReportEntity()
                                    {
                                        Document = "Cur",
                                        Id = "Cur-Sold-Component" + itemComponent.Id,
                                        InventoryDate = currentSoldComponent.TrnSale.SalesDate,
                                        ItemCode = itemComponent.MstItem1.ItemCode,
                                        BarCode = itemComponent.MstItem1.BarCode,
                                        ItemDescription = itemComponent.MstItem1.ItemDescription,
                                        BeginningQuantity = 0,
                                        InQuantity = 0,
                                        OutQuantity = itemComponent.Quantity * currentSoldComponent.Quantity,
                                        EndingQuantity = 0,
                                        Unit = itemComponent.MstItem1.MstUnit.Unit,
                                        Cost = itemComponent.MstItem1.Cost,
                                        Price = itemComponent.MstItem1.Price,
                                        Amount = 0
                                    });
                                }
                            }
                        }
                    }

                    var currentOutInventories = from d in db.TrnStockOutLines
                                                where d.TrnStockOut.IsLocked == true
                                                && d.TrnStockOut.StockOutDate >= startDate.Date
                                                && d.TrnStockOut.StockOutDate <= endDate.Date
                                                && d.MstItem.Category == category
                                                && d.MstItem.IsInventory == true
                                                && d.MstItem.IsLocked == true
                                                select new Entities.RepInventoryReportEntity
                                                {
                                                    Document = "Cur",
                                                    Id = "Cur-Out-" + d.Id,
                                                    InventoryDate = d.TrnStockOut.StockOutDate,
                                                    ItemCode = d.MstItem.ItemCode,
                                                    BarCode = d.MstItem.BarCode,
                                                    ItemDescription = d.MstItem.ItemDescription,
                                                    BeginningQuantity = 0,
                                                    InQuantity = 0,
                                                    OutQuantity = d.Quantity,
                                                    EndingQuantity = 0,
                                                    Unit = d.MstUnit.Unit,
                                                    Cost = d.MstItem.Cost,
                                                    Price = d.MstItem.Price,
                                                    Amount = 0
                                                };

                    var unionCurrentInventories = currentInInventories.ToList().Union(currentSoldInventories.ToList()).Union(currentSoldComponentInventories.ToList()).Union(currentOutInventories.ToList());

                    var unionInventories = unionBeginningInventories.ToList().Union(unionCurrentInventories.ToList());
                    if (unionInventories.Any())
                    {
                        var inventories = from d in unionInventories
                                          group d by new
                                          {
                                              d.ItemCode,
                                              d.BarCode,
                                              d.ItemDescription,
                                              d.Unit,
                                              d.Cost,
                                              d.Price
                                          } into g
                                          select new Entities.RepInventoryReportEntity
                                          {
                                              ItemCode = g.Key.ItemCode,
                                              BarCode = g.Key.BarCode,
                                              ItemDescription = g.Key.ItemDescription,
                                              Unit = g.Key.Unit,
                                              BeginningQuantity = g.Sum(s => s.BeginningQuantity),
                                              InQuantity = g.Sum(s => s.InQuantity),
                                              OutQuantity = g.Sum(s => s.OutQuantity) * -1,
                                              EndingQuantity = g.Sum(s => (s.BeginningQuantity + s.InQuantity) - s.OutQuantity),
                                              CountQuantity = 0,
                                              Variance = g.Sum(s => (s.BeginningQuantity + s.InQuantity) - s.OutQuantity),
                                              Cost = g.Key.Cost,
                                              Price = g.Key.Price,
                                              Amount = g.Key.Cost * g.Sum(s => (s.BeginningQuantity + s.InQuantity) - s.OutQuantity),
                                          };

                        return inventories.Where(d => d.ItemDescription.ToUpper().Contains(filter.ToUpper()) == true || d.Unit.ToUpper().Contains(filter.ToUpper()) == true).OrderBy(d => d.ItemDescription).ToList();
                    }


                var accountReceivables = from d in newSales select d;
                if (accountReceivables.Any())
                {
                    PdfPTable tableLines = new PdfPTable(12);
                    tableLines.SetWidths(new float[] { 100f, 70f, 60f, 60f, 60f, 60f, 60f, 60f, 60f, 60f, 60f, 60f });
                    tableLines.WidthPercentage = 100;

                    Decimal sales_amount = 0;
                    Decimal payment_amount = 0;
                    Decimal balance_amount = 0;
                    Decimal current_amount = 0;
                    Decimal _30Days_amount = 0;
                    Decimal _60Days_amount = 0;
                    Decimal _90Days_amount = 0;
                    Decimal _120Days_amount = 0;

                    foreach (var accountReceivable in accountReceivables)
                    {
                        tableLines.AddCell(new PdfPCell(new Phrase(accountReceivable.ColumnCustomer, fontTimesNewRoman10)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                        tableLines.AddCell(new PdfPCell(new Phrase(accountReceivable.ColumnSalesNumber, fontTimesNewRoman10)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                        tableLines.AddCell(new PdfPCell(new Phrase(accountReceivable.ColumnSalesDate, fontTimesNewRoman10)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                        tableLines.AddCell(new PdfPCell(new Phrase(accountReceivable.ColumnSalesAmount, fontTimesNewRoman10)) { HorizontalAlignment = 2, Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                        tableLines.AddCell(new PdfPCell(new Phrase(accountReceivable.ColumnPaymentAmount, fontTimesNewRoman10)) { HorizontalAlignment = 2, Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                        tableLines.AddCell(new PdfPCell(new Phrase(accountReceivable.ColumnBalanceAmount, fontTimesNewRoman10)) { HorizontalAlignment = 2, Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                        tableLines.AddCell(new PdfPCell(new Phrase(accountReceivable.ColumnDueDate, fontTimesNewRoman10)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                        tableLines.AddCell(new PdfPCell(new Phrase(accountReceivable.ColumnCurrent, fontTimesNewRoman10)) { HorizontalAlignment = 2, Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                        tableLines.AddCell(new PdfPCell(new Phrase(accountReceivable.Column30Days, fontTimesNewRoman10)) { HorizontalAlignment = 2, Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                        tableLines.AddCell(new PdfPCell(new Phrase(accountReceivable.Column60Days, fontTimesNewRoman10)) { HorizontalAlignment = 2, Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                        tableLines.AddCell(new PdfPCell(new Phrase(accountReceivable.Column90Days, fontTimesNewRoman10)) { HorizontalAlignment = 2, Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                        tableLines.AddCell(new PdfPCell(new Phrase(accountReceivable.Column120Days, fontTimesNewRoman10)) { HorizontalAlignment = 2, Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });

                        sales_amount += Convert.ToDecimal(accountReceivable.ColumnSalesAmount);
                        payment_amount += Convert.ToDecimal(accountReceivable.ColumnPaymentAmount);
                        balance_amount += Convert.ToDecimal(accountReceivable.ColumnBalanceAmount);
                        current_amount += Convert.ToDecimal(accountReceivable.ColumnCurrent);
                        _30Days_amount += Convert.ToDecimal(accountReceivable.Column30Days);
                        _60Days_amount += Convert.ToDecimal(accountReceivable.Column60Days);
                        _90Days_amount += Convert.ToDecimal(accountReceivable.Column90Days);
                        _120Days_amount += Convert.ToDecimal(accountReceivable.Column120Days);
                    }

                    tableLines.AddCell(new PdfPCell(new Phrase(line)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = -5f, Colspan = 12 });
                    tableLines.AddCell(new PdfPCell(new Phrase("Total: ", fontTimesNewRoman10Bold)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 20f, Colspan = 3, HorizontalAlignment = 2 });
                    tableLines.AddCell(new PdfPCell(new Phrase(sales_amount.ToString("#,##0.00"), fontTimesNewRoman10Bold)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 20f, HorizontalAlignment = 2 });
                    tableLines.AddCell(new PdfPCell(new Phrase(payment_amount.ToString("#,##0.00"), fontTimesNewRoman10Bold)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 20f, HorizontalAlignment = 2 });
                    tableLines.AddCell(new PdfPCell(new Phrase(balance_amount.ToString("#,##0.00"), fontTimesNewRoman10Bold)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 20f, HorizontalAlignment = 2 });
                    tableLines.AddCell(new PdfPCell(new Phrase("", fontTimesNewRoman10Bold)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 20f, HorizontalAlignment = 2 });
                    tableLines.AddCell(new PdfPCell(new Phrase(current_amount.ToString("#,##0.00"), fontTimesNewRoman10Bold)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 20f, HorizontalAlignment = 2 });
                    tableLines.AddCell(new PdfPCell(new Phrase(_30Days_amount.ToString("#,##0.00"), fontTimesNewRoman10Bold)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 20f, HorizontalAlignment = 2 });
                    tableLines.AddCell(new PdfPCell(new Phrase(_60Days_amount.ToString("#,##0.00"), fontTimesNewRoman10Bold)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 20f, HorizontalAlignment = 2 });
                    tableLines.AddCell(new PdfPCell(new Phrase(_90Days_amount.ToString("#,##0.00"), fontTimesNewRoman10Bold)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 20f, HorizontalAlignment = 2 });
                    tableLines.AddCell(new PdfPCell(new Phrase(_120Days_amount.ToString("#,##0.00"), fontTimesNewRoman10Bold)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 20f, HorizontalAlignment = 2 });

                    document.Add(tableLines);
                    document.Close();

                    //ProcessStartInfo info = new ProcessStartInfo(fileName)
                    //{
                    //    Verb = "Print",
                    //    CreateNoWindow = true,
                    //    WindowStyle = ProcessWindowStyle.Hidden
                    //};

                    //Process printDwg = new Process
                    //{
                    //    StartInfo = info
                    //};

                    //printDwg.Start();
                    //printDwg.Close();


                    Process.Start(fileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
