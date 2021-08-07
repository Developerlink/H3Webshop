using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsWebAPI.Models
{
    public interface ICustomerRepository
    {        
        ICollection<Customer> GetCustomers();
        bool CustomerExists(int customerId);
        Customer GetCustomer(int customerId);
        Customer GetCustomerFromDelivery(int deliveryId);
        ICollection<Customer> GetCustomersFromPostalCode(int postalCodeId);


        bool CreateCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(int customerId);
        bool Save();
    }
}
