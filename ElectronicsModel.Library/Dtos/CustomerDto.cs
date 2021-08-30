using ElectronicsModel.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ElectronicsModel.Library.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public int PostalCodeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public CustomerDto()
        {

        }

        public CustomerDto(Customer customer)
        {
            Id = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Address = customer.Address;
            PostalCodeId = customer.PostalCodeId;
            PhoneNumber = customer.PhoneNumber;
            EmailAddress = customer.EmailAddress;
        }
    }

}
