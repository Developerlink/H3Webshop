using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsModel.Library.Models
{
    public class SalesOrder
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime OrderDate { get; set; }


        public virtual Store Store { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }

        public SalesOrder()
        {
            Store = new Store();
            OrderStatus = new OrderStatus();
        }
    }
}
