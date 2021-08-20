using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ElectronicsModel.Library.Models
{
    public class Customer
    {
        [JsonIgnore]

        public int Id { get; set; }
        public int PostalCodeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        [JsonIgnore]
        public virtual ICollection<Delivery> Deliveries { get; set; }
        [JsonIgnore]
        public virtual PostalCode PostalCode { get; set; }
    }
}
