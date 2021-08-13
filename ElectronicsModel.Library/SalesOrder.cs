using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsModel.Library
{
    public partial class SalesOrder
    {
        public int Id { get; set; }
        public int? OrderStatusId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int StoreId { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }
        public virtual Store Store { get; set; }
    }
}
