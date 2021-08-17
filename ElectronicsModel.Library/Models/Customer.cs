using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsModel.Library.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public int PostalCodeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual PostalCode PostalCode { get; set; }
    }
}
