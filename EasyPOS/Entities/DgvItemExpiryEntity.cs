using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvItemExpiryEntity
    {
        public String ColumnItemListCode { get; set; }
        public String ColumnItemListBarcode { get; set; }
        public String ColumnItem { get; set; }
        public String ColumnOnHandQuantity { get; set; }
        public String ColumnUnit { get; set; }
        public String ColumnCost { get; set; }
        public String ColumnPrice { get; set; }
        public String ColumnExpiryDate { get; set; }

    }
}
