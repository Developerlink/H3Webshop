using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsModel.Library
{
    public partial class Delivery
    {
        public int? SalesOrderId { get; set; }
        public int? PostalCodeId { get; set; }
        public string Address { get; set; }
        public DateTime? SendDate { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual PostalCode PostalCode { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }
    }
}
