using ElectronicsModel.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsORM.Library.Interfaces
{
    public interface ICustomerRepository
    {
        ICollection<Customer> GetCustomers();
        ICollection<Customer> GetCustomersFromPostalCode(int postalCodeId);
        Customer GetCustomer(int customerId);
        Customer GetCustomerFromSalesOrder(int salesOrderId);
        bool CustomerExists(int customerId);
        bool EmailExists(string email);


        bool CreateCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(int customerId);
        bool DeleteCustomersByPostalCode(int postalCodeId);
    }
}
