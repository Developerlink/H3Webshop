using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsORM.Library.Repositories.EF
{
    public class CustomerRepository : ICustomerRepository
    {
        private ElectronicsDbContext _electronicsDbContext;

        public CustomerRepository(ElectronicsDbContext electronicsDbContext)
        {
            _electronicsDbContext = electronicsDbContext;
        }

        public bool CreateCustomer(Customer customer)
        {
            _electronicsDbContext.Add(customer);
            return Save();
        }

        public bool CustomerExists(int customerId)
        {
            return _electronicsDbContext.Customer.Any(c => c.Id == customerId);
        }

        public bool DeleteCustomer(int customerId)
        {
            var customerToDelete = _electronicsDbContext.Customer.Find(customerId);
            _electronicsDbContext.Remove(customerToDelete);
            return Save();
        }

        public bool DeleteCustomersByPostalCode(int postalCodeID)
        {
            var customersToDelete = _electronicsDbContext.Customer.Where(c => c.PostalCodeId == postalCodeID);
            _electronicsDbContext.RemoveRange(customersToDelete);
            return Save();
        }

        public Customer GetCustomer(int customerId)
        {
            var customer = _electronicsDbContext.Customer.Find(customerId);
            return customer;
        }

        public Customer GetCustomerFromSalesOrder(int salesOrderId)
        {
            var customer = _electronicsDbContext.Delivery.Where(d => d.SalesOrderId == salesOrderId).Select(d => d.Customer).FirstOrDefault();
            return customer;
        }

        public ICollection<Customer> GetCustomers()
        {
            var customers = _electronicsDbContext.Customer.OrderBy(c => c.FirstName).ToList();
            return customers;
        }

        public ICollection<Customer> GetCustomersFromPostalCode(int postalCodeId)
        {
            var customers = _electronicsDbContext.Customer.Where(c => c.PostalCodeId == postalCodeId).ToList();
            return customers;
        }

        public bool UpdateCustomer(Customer customer)
        {
            _electronicsDbContext.Update(customer);
            return Save();
        }

        public bool Save()
        {
            var rowsChanged = _electronicsDbContext.SaveChanges();
            return rowsChanged >= 0;
        }
    }
}
