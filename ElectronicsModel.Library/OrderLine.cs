using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsModel.Library
{
    public partial class OrderLine
    {
        public int? SalesOrderId { get; set; }
        public int? ProductId { get; set; }
        public decimal? Price { get; set; }
        public short? Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }
    }
}
