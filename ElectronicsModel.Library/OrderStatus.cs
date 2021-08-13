using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsModel.Library
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            SalesOrder = new HashSet<SalesOrder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SalesOrder> SalesOrder { get; set; }
    }
}
