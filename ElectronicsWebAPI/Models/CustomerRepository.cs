using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsWebAPI.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool CustomerExists(int customerId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerFromDelivery(int deliveryId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public ICollection<Customer> GetCustomersFromPostalCode(int postalCodeId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
