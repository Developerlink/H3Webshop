using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsORM.Library.Repositories.EF
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ElectronicsDbContext _electronicsDbContext;

        public CustomerRepository(ElectronicsDbContext electronicsDbContext)
        {
            _electronicsDbContext = electronicsDbContext;
        }

        public bool CreateCustomer(Customer customer)
        {
            try
            {
                _electronicsDbContext.Add(customer);
                return Save();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool CustomerExists(int customerId)
        {
            return _electronicsDbContext.Customer.Any(c => c.Id == customerId);
        }

        public bool EmailExists(string email)
        {
            return _electronicsDbContext.Customer.Any(c => c.EmailAddress == email);
        }

        public bool DeleteCustomer(int customerId)
        {
            try
            {
                var customerToDelete = _electronicsDbContext.Customer.Find(customerId);
                _electronicsDbContext.Remove(customerToDelete);
                return Save();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeleteCustomersByPostalCode(int postalCodeID)
        {
            try
            {
                var customersToDelete = _electronicsDbContext.Customer.Where(c => c.PostalCodeId == postalCodeID);
                _electronicsDbContext.RemoveRange(customersToDelete);
                return Save();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public Customer GetCustomer(int customerId)
        {
            try
            {
                var customer = _electronicsDbContext.Customer.Find(customerId);
                return customer;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public Customer GetCustomerFromSalesOrder(int salesOrderId)
        {
            try
            {
                var customer = _electronicsDbContext.Delivery.Where(d => d.SalesOrderId == salesOrderId).Select(d => d.Customer).FirstOrDefault();
                return customer;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public ICollection<Customer> GetCustomers()
        {
            try
            {
                var customers = _electronicsDbContext.Customer.OrderByDescending(c => c.Id).ThenBy(c => c.LastName).ToList();
                return customers;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public ICollection<Customer> GetCustomersFromPostalCode(int postalCodeId)
        {
            try
            {
                var customers = _electronicsDbContext.Customer.Where(c => c.PostalCodeId == postalCodeId).OrderBy(c => c.FirstName).ThenBy(c => c.LastName).ToList();
                return customers;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                _electronicsDbContext.Update(customer);
                return Save();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Save()
        {
            try
            {
                var rowsChanged = _electronicsDbContext.SaveChanges();
                return rowsChanged >= 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
