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
    public class SalesOrdersController : ControllerBase
    {
        private readonly ISalesOrderRepository _SalesOrderRepository;
        private readonly IOrderLineRepository _orderLineRepository;
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IStoreRepository _storeRepository;

        public SalesOrdersController(ISalesOrderRepository salesOrderRepository, IOrderLineRepository orderLineRepository, IDeliveryRepository deliveryRepository, IStoreRepository storeRepository)
        {
            _SalesOrderRepository = salesOrderRepository;
            _orderLineRepository = orderLineRepository;
            _deliveryRepository = deliveryRepository;
            _storeRepository = storeRepository;
        }

        // GET: <SalesOrdersController>
        [HttpGet]
        public ActionResult<IEnumerable<SalesOrderDto>> GetSalesOrders()
        {
            var salesOrders = _SalesOrderRepository.GetSalesOrders();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var SalesOrderDtos = new List<SalesOrderDto>();
            foreach (var SalesOrder in salesOrders)
            {
                var SalesOrderDto = new SalesOrderDto(SalesOrder);
                SalesOrderDtos.Add(SalesOrderDto);
            }

            return Ok(SalesOrderDtos);
        }

        // GET <SalesOrdersController>/5
        [HttpGet("{id}")]
        public ActionResult<SalesOrderDto> GetSalesOrder(int id)
        {
            if (!_SalesOrderRepository.SalesOrderExists(id))
            {
                return NotFound();
            }

            var salesOrder = _SalesOrderRepository.GetSalesOrder(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var salesOrderDto = new SalesOrderDto(salesOrder);

            return Ok(salesOrderDto);
        }

        // POST <SalesOrdersController>
        [HttpPost]
        public ActionResult PostSalesOrder([FromBody] SalesOrder salesOrder)
        {
            if (salesOrder == null)
            {
                return BadRequest(ModelState);
            }

            if (!_storeRepository.StoreExists(salesOrder.StoreId))
            {
                return NotFound("Store was not found!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_SalesOrderRepository.CreateSalesOrder(salesOrder))
            {
                ModelState.AddModelError("", $"Something went wrong saving the SalesOrder");
                return StatusCode(500, ModelState);
            }

            var salesOrderDto = new SalesOrderDto(salesOrder);

            return CreatedAtAction("GetSalesOrder", new { id = salesOrderDto.Id }, salesOrderDto);
        }

        // PUT <SalesOrdersController>/5
        [HttpPut("{salesOrderId}")]
        public IActionResult UpdateSalesOrder(int salesOrderId, [FromBody] SalesOrder salesOrder)
        {
            if (salesOrder == null)
            {
                return BadRequest(ModelState);
            }

            if (salesOrderId != salesOrder.Id)
            {
                ModelState.AddModelError("", $"The URL SalesOrderId '{salesOrderId}' does not match the SalesOrderobjects Id '{salesOrder.Id}'");
                return BadRequest(ModelState);
            }

            if (!_SalesOrderRepository.SalesOrderExists(salesOrder.Id))
            {
                ModelState.AddModelError("", "SalesOrder does not exist!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_SalesOrderRepository.UpdateSalesOrder(salesOrder))
            {
                ModelState.AddModelError("", $"Something went wrong updating SalesOrder with Id({salesOrder.Id}");
                return StatusCode(500, ModelState);
            }

            // Usually nothing is returned when updating. 
            return NoContent();
        }

        // DELETE <SalesOrdersController>/5
        [HttpDelete("{SalesOrderId}")]
        public IActionResult DeleteSalesOrder(int salesOrderId)
        {
            if (!_SalesOrderRepository.SalesOrderExists(salesOrderId))
            {
                return NotFound();
            }

            if (_deliveryRepository.GetDeliveryFromSalesOrder(salesOrderId) != null)
            {
                ModelState.AddModelError("", $"SalesOrder with Id({salesOrderId}) cannot be deleted because it is associated with a delivery");
                return StatusCode(409, ModelState);
            }

            var orderLinesToDelete = _orderLineRepository.GetOrderLinesFromSalesOrder(salesOrderId);
            var deliveryToDelete = _deliveryRepository.GetDeliveryFromSalesOrder(salesOrderId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (orderLinesToDelete.Count > 0)
            {
                if(!_orderLineRepository.DeleteOrderLinesBySalesOrder(salesOrderId))
                {
                    ModelState.AddModelError("", $"Something went wrong deleting orderlines with SalesOrder Id({ salesOrderId }) ");
                    return StatusCode(500, ModelState);
                }
            }

            if (deliveryToDelete != null)
            {
                if (!_deliveryRepository.DeleteDeliveryBySalesOrder(salesOrderId))
                {
                    ModelState.AddModelError("", $"Something went wrong deleting delivery with SalesOrder Id({ salesOrderId }) ");
                    return StatusCode(500, ModelState);
                }
            }

            if (!_SalesOrderRepository.DeleteSalesOrder(salesOrderId))
            {
                ModelState.AddModelError("", $"Something went wrong deleting SalesOrder with Id { salesOrderId }");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
