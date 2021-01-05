using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.RepSalesReport
{
    public partial class RepUnsoldItemReportForm : Form
    {
        public List<Entities.DgvRepUnsoldItemEntity> salesDetailList;
        public BindingSource dataUnsoldItemSource = new BindingSource();
        public PagedList<Entities.DgvRepUnsoldItemEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        public DateTime dateStart;
        public DateTime dateEnd;
        public RepUnsoldItemReportForm(DateTime startDate, DateTime endDate)
        {
            dateStart = startDate;
            dateEnd = endDate;
            InitializeComponent();
        }
        //public List<Entities.DgvRepUnsoldItemEntity> GetUnsoldItemListData(DateTime startDate, DateTime endDate)
        //{
        //    List<Entities.DgvRepUnsoldItemEntity> rowList = new List<Entities.DgvRepUnsoldItemEntity>();

        //    Controllers.RepSalesReportController repUnsoldItemsReportController = new Controllers.RepSalesReportController();

        //    var salesDetailList = repUnsoldItemsReportController.UnsoldItemsReport(startDate, endDate);
        //    if (salesDetailList.Any())
        //    {
        //        List<Entities.DgvRepUnsoldItemEntity> newUnsoldItemsReportList = new List<Entities.DgvRepUnsoldItemEntity>();
        //        foreach (var unsoldItemsReport in salesDetailList)
        //        {
        //            newUnsoldItemsReportList.Add(new Entities.DgvRepUnsoldItemEntity()
        //            {
        //                ColumnBarCode = unsoldItemsReport.BarCode,
        //                ColumnItemDescription = unsoldItemsReport.ItemDescription,
        //                ColumnItemCategory = unsoldItemsReport.ItemCategory,
        //                ColumnUnit = unsoldItemsReport.Unit,
        //                ColumnPrice = unsoldItemsReport.Price.ToString("#,##0.00"),
        //                ColumnQuantity = unsoldItemsReport.Quantity.ToString("#,##0.00"),
        //                ColumnAmount = unsoldItemsReport.Amount.ToString("#,##0.00")
        //            });

        //        }

        //        rowList = newUnsoldItemsReportList.ToList();
        //    }

        //    return rowList;
        //}
        
            private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
