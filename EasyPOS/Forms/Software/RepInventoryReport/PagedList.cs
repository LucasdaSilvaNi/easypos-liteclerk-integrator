using EasyPOS.Entities;
using System.Collections.Generic;

namespace EasyPOS.Forms.Software.RepInventoryReport
{
    internal class PagedList<T>
    {
        private List<DgvRepInventoryInventoryReportListEntity> inventoryReportList;
        private int pageNumber;
        private int pageSize;

        public PagedList(List<DgvRepInventoryInventoryReportListEntity> inventoryReportList, int pageNumber, int pageSize)
        {
            this.inventoryReportList = inventoryReportList;
            this.pageNumber = pageNumber;
            this.pageSize = pageSize;
        }
    }
}