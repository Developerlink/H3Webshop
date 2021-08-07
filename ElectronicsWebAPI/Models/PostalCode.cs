using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsWebAPI.Models
{
    public class PostalCode
    {
        public int PostalCodeId { get; set; }
        public string AreaName { get; set; }


        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
