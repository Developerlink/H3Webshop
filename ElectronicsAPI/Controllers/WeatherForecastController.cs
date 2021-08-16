using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.Interfaces;
using ElectronicsORM.Library.Repositories.MO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
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
                    EmailAddress = "Link@mail.com",
                    PhoneNumber = "12345678"
                };
                customerRepository.CreateCustomer(newCustomer);
                newCustomer.FirstName = "Zelda";
                newCustomer.EmailAddress = "zelda@mail.com";
                newCustomer.PhoneNumber = "99887766";
                customerRepository.UpdateCustomer(newCustomer);

                customerRepository.DeleteCustomer(newCustomer.Id);

                return $"The api server is running..." +
                    $"\nCustomer from looking up Id: " +
                    $"\nID: {customer.Id} Name: {customer.FirstName} {customer.LastName}" +
                    $"\nCustomer from looking up SalesOrderId: " +
                    $"\nID: {customer2.Id} Name: {customer2.FirstName} {customer2.LastName}" +
                    $"\nInserted customer: " +
                    $"\nID: {newCustomer.Id} Name: {newCustomer.FirstName} {newCustomer.LastName}" +
                    $"\nAttempting to delete customer with id: {newCustomer.Id} " +
                    $"\nWhen asking the db if the customer with id {newCustomer.Id} exists the answer is now: {customerRepository.CustomerExists(newCustomer.Id)} " +
                    $"";
            }
            else
            {
                return $"The customer with ID: {id} does not exist";
            }
        }
    }
}
