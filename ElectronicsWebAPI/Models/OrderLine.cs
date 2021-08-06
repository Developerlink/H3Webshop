using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsWebAPI.Models
{
    public class OrderLine
    {
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }


        public virtual SalesOrder SalesOrder { get; set; }
        public virtual Product Product { get; set; }
    }
}
