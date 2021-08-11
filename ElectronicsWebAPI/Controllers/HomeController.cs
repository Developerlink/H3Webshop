using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.Interfaces;
using ElectronicsORM.Library.Repositories.MO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsWebAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet]
        public string Get()
        {
            ICustomerRepository customerRepository = new CustomerRepositoryMO();
            int id = 6;

            int salesOrderId = 1;

            if (customerRepository.CustomerExists(id))
            {
                var customer = customerRepository.GetCustomer(id);
                var customer2 = customerRepository.GetCustomerFromSalesOrder(salesOrderId);
                var newCustomer = new Customer()
                {
                    FirstName = "Link",
                    LastName = "Kokiri",
                    PostalCodeId = 5000,
                    Address = "Forrest Road 11",
                    EmailAddress = "Link@mail7.com",
                    PhoneNumber = "12345678"
                };
                customerRepository.CreateCustomer(newCustomer);

                return $"The api server is running..." +
                    $"\nCustomer from looing up Id: " +
                    $"\nID: {customer.Id} Name: {customer.FirstName} {customer.LastName}" +
                    $"\nCustomer from looking up SalesOrderId: " + 
                    $"\nID: {customer2.Id} Name: {customer2.FirstName} {customer2.LastName}" +
                    $"\nInserted customer: " +
                    $"\nID: {newCustomer.Id} Name: {newCustomer.FirstName} {newCustomer.LastName}";
            }
            else
            {
                return $"The customer with ID: {id} does not exist";
            }
        }
    }
}
