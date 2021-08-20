using ElectronicsModel.Library.Dtos;
using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ElectronicsAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPostalCodeRepository _postalCodeRepository;
        private readonly IDeliveryRepository _deliveryRepository;

        public CustomersController(ICustomerRepository customerRepository, IPostalCodeRepository postalCodeRepository, IDeliveryRepository deliveryRepository)
        {
            _customerRepository = customerRepository;
            _postalCodeRepository = postalCodeRepository;
            _deliveryRepository = deliveryRepository;
        }

        // GET: <CustomersController>
        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> GetCustomers()
        {
            var customers = _customerRepository.GetCustomers();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerDtos = new List<CustomerDto>();
            foreach(var customer in customers)
            {
                var customerDto = new CustomerDto(customer);
                customerDtos.Add(customerDto);
            }

            return Ok(customerDtos);
        }

        // GET <CustomersController>/5
        [HttpGet("{id}")]
        public ActionResult<CustomerDto> GetCustomer(int id)
        {
            if(!_customerRepository.CustomerExists(id))
            {
                return NotFound();
            }

            var customer = _customerRepository.GetCustomer(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerDto = new CustomerDto(customer);

            return Ok(customerDto);
        }

        // POST <CustomersController>
        [HttpPost]
        public ActionResult PostCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest(ModelState);
            }

            if (!_postalCodeRepository.PostalCodeExists(customer.PostalCodeId))
            {
                return NotFound("Postal Code was not found!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // This does not work in this project but it works in others!?
            //customer.PostalCode = _postalCodeRepository.GetPostalCode(customer.PostalCodeId);

            if (!_customerRepository.CreateCustomer(customer))
            {
                ModelState.AddModelError("", $"Something went wrong saving the Customer");
                return StatusCode(500, ModelState);
            }

            var customerDto = new CustomerDto(customer);

            return CreatedAtAction("GetCustomer", new { id = customerDto.Id }, customerDto);
        }

        // PUT <CustomersController>/5
        [HttpPut("{customerId}")]
        public IActionResult UpdateCustomer(int customerId, [FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest(ModelState);
            }

            if (customerId != customer.Id)
            {
                ModelState.AddModelError("", $"The URL CustomerId '{customerId}' does not match the Customerobjects Id '{customer.Id}'");
                return BadRequest(ModelState);
            }

            if (!_customerRepository.CustomerExists(customer.Id))
            {
                ModelState.AddModelError("", "Customer does not exist!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_customerRepository.UpdateCustomer(customer))
            {
                ModelState.AddModelError("", $"Something went wrong updating Customer {customer.FirstName} {customer.LastName}");
                return StatusCode(500, ModelState);
            }

            // Usually nothing is returned when updating. 
            return NoContent();
        }

        // DELETE <CustomersController>/5
        [HttpDelete("{customerId}")]
        public IActionResult DeleteCustomer(int customerId)
        {
            if (!_customerRepository.CustomerExists(customerId))
            {
                return NotFound();
            }

            if (_deliveryRepository.GetDeliveriesFromCustomer(customerId).Count() > 0)
            {
                ModelState.AddModelError("", $"Customer with Id({customerId}) cannot be deleted because it is associated with at least one delivery");
                return StatusCode(409, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_customerRepository.DeleteCustomer(customerId))
            {
                ModelState.AddModelError("", $"Something went wrong deleting Customer with Id { customerId }");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }        
    }
}
