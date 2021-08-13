using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsModel.Library
{
    public partial class PostalCode
    {
        public PostalCode()
        {
            Customer = new HashSet<Customer>();
            Employee = new HashSet<Employee>();
            Store = new HashSet<Store>();
        }

        public int PostalCodeId { get; set; }
        public string AreaName { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Store> Store { get; set; }
    }
}
