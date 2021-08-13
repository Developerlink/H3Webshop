using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsModel.Library.Models
{
    public class StoreProduct
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }


        public virtual Store Store { get; set; }
        public virtual Product Product { get; set; }

        public StoreProduct()
        {
            Store = new Store();
            Product = new Product();
        }
    }
}
