using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsModel.Library.Models
{
    public class OrderLine
    {
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public Int16 Quantity { get; set; }


        public virtual SalesOrder SalesOrder { get; set; }
        public virtual Product Product { get; set; }
    }
}
