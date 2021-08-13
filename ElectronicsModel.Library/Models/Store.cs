using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsModel.Library.Models
{
    public class Store
    {
        public int Id { get; set; }
        public int PostalCodeId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }


        public virtual PostalCode PostalCode { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<StoreProduct> StoreProducts { get; set; }
        public virtual ICollection<SalesOrder> SalesOrders { get; set; }

        public Store()
        {
            PostalCode = new PostalCode();
        }
    }
}
