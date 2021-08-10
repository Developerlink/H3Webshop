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
            var customer = customerRepository.GetCustomer(6);

            return $"The api server is running..." +
                $"\nGetting data:" +
                $"\nId: {customer.Id} Name: {customer.FirstName} {customer.LastName}";
        }
    }
}
