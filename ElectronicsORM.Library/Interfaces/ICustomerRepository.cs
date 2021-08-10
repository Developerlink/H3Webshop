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
        bool CustomerExists(int customerId);
        Customer GetCustomer(int customerId);
        Customer GetCustomerFromSalesOrderDelivery(int salesOrderId);
        ICollection<Customer> GetCustomersFromPostalCode(int postalCodeId);


        bool CreateCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(int customerId);
        bool DeleteCustomersByPostalCode(int postalCodeID);
        bool Save();
    }
}
