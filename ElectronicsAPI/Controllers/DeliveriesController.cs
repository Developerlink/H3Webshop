using ElectronicsModel.Library.Dtos;
using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ElectronicsAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeliveriesController : ControllerBase
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly ISalesOrderRepository _salesOrderRepository;
        private readonly IPostalCodeRepository _postalCodeRepository;
        private readonly ICustomerRepository _customerRepository;

        public DeliveriesController(IDeliveryRepository deliveryRepository, ISalesOrderRepository salesOrderRepository, IPostalCodeRepository postalCodeRepository, ICustomerRepository customerRepository)
        {
            _deliveryRepository = deliveryRepository;
            _salesOrderRepository = salesOrderRepository;
            _postalCodeRepository = postalCodeRepository;
            _customerRepository = customerRepository;
        }

        // GET: <DeliveriesController>
        [HttpGet]
        public ActionResult<IEnumerable<DeliveryDto>> GetDeliveries()
        {
            var deliveries = _deliveryRepository.GetDeliveries();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deliveryDtos = new List<DeliveryDto>();
            foreach (var Delivery in deliveries)
            {
                var deliveryDto = new DeliveryDto(Delivery);
                deliveryDtos.Add(deliveryDto);
            }

            return Ok(deliveryDtos);
        }

        // GET <DeliveriesController>/5
        [HttpGet("{salesOrderId}")]
        public ActionResult<DeliveryDto> GetDelivery(int salesOrderId)
        {
            if (!_deliveryRepository.DeliveryExists(salesOrderId))
            {
                return NotFound();
            }

            var delivery = _deliveryRepository.GetDeliveryFromSalesOrder(salesOrderId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deliveryDto = new DeliveryDto(delivery);

            return Ok(deliveryDto);
        }

        // POST <DeliveriesController>
        [HttpPost]
        public ActionResult PostDelivery([FromBody] Delivery delivery)
        {
            if (delivery == null)
            {
                return BadRequest(ModelState);
            }

            if (!_salesOrderRepository.SalesOrderExists(delivery.SalesOrderId))
            {
                return NotFound("SalesOrder was not found!");
            }

            if (!_customerRepository.CustomerExists(delivery.CustomerId))
            {
                return NotFound("Customer was not found!");
            }

            if (!_postalCodeRepository.PostalCodeExists(delivery.PostalCodeId))
            {
                return NotFound("Postal Code was not found!");
            }

            if(_deliveryRepository.DeliveryExists(delivery.SalesOrderId))
            {
                return BadRequest($"A delivery with SalesOrderId '{delivery.SalesOrderId}' already exists!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_deliveryRepository.CreateDelivery(delivery))
            {
                ModelState.AddModelError("", $"Something went wrong saving the Delivery");
                return StatusCode(500, ModelState);
            }

            var deliveryDto = new DeliveryDto(delivery);

            return CreatedAtAction("GetDelivery", new { salesOrderId = deliveryDto.SalesOrderId} ,deliveryDto);
        }

        // PUT <DeliveriesController>/5
        [HttpPut("{salesOrderId}")]
        public IActionResult UpdateDelivery(int salesOrderId, [FromBody] Delivery delivery)
        {
            if (delivery == null)
            {
                return BadRequest(ModelState);
            }

            if (salesOrderId != delivery.SalesOrderId)
            {
                ModelState.AddModelError("", $"The URL SalesOrderId '{salesOrderId}' does not match the Delivery object's SalesOrderId '{delivery.SalesOrderId}'");
                return BadRequest(ModelState);
            }

            if (!_salesOrderRepository.SalesOrderExists(salesOrderId))
            {
                ModelState.AddModelError("", $"SalesOrder does not exist with id'{salesOrderId}'!");
            }

            if (!_customerRepository.CustomerExists(delivery.CustomerId))
            {
                ModelState.AddModelError("", $"Customer does not exist with id'{delivery.CustomerId}'!");
            }

            if (!_postalCodeRepository.PostalCodeExists(delivery.PostalCodeId))
            {
                ModelState.AddModelError("", $"Postal Code does not exist with id'{delivery.PostalCodeId}'!");
            }

            if (!_deliveryRepository.DeliveryExists(salesOrderId))
            {
                ModelState.AddModelError("", $"Delivery does not exist with id'{salesOrderId}'!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_deliveryRepository.UpdateDelivery(delivery))
            {
                ModelState.AddModelError("", $"Something went wrong updating Delivery with SalesOrderID '{ salesOrderId }' ");
                return StatusCode(500, ModelState);
            }

            // Usually nothing is returned when updating. 
            return NoContent();
        }

        // DELETE <DeliveriesController>/5
        [HttpDelete("{salesOrderId}")]
        public IActionResult DeleteDelivery(int salesOrderId)
        {
            if (!_deliveryRepository.DeliveryExists(salesOrderId))
            {
                return NotFound();
            }            

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_deliveryRepository.DeleteDeliveryBySalesOrder(salesOrderId))
            {
                ModelState.AddModelError("", $"Something went wrong deleting Delivery with SalesOrderId { salesOrderId }");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
