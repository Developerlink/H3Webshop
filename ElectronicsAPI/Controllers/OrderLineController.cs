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
    public class OrderLinesController : ControllerBase
    {
        private readonly IOrderLineRepository _orderLineRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISalesOrderRepository _salesOrderRepository;

        public OrderLinesController(IOrderLineRepository orderLineRepository, IProductRepository productRepository, ISalesOrderRepository salesOrderRepository)
        {
            _orderLineRepository = orderLineRepository;
            _productRepository = productRepository;
            _salesOrderRepository = salesOrderRepository;
        }

        // GET: <OrderLinesController>
        [HttpGet]
        public ActionResult<IEnumerable<OrderLineDto>> GetOrderLines()
        {
            var orderLines = _orderLineRepository.GetOrderLines();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderLineDtos = new List<OrderLineDto>();
            foreach (var OrderLine in orderLines)
            {
                var OrderLineDto = new OrderLineDto(OrderLine);
                orderLineDtos.Add(OrderLineDto);
            }

            return Ok(orderLineDtos);
        }

        // POST <OrderLinesController>
        [HttpPost]
        public ActionResult PostOrderLine([FromBody] OrderLine orderLine)
        {
            if (orderLine == null)
            {
                return BadRequest(ModelState);
            }

            if (!_salesOrderRepository.SalesOrderExists(orderLine.SalesOrderId))
            {
                return NotFound($"Sales Order was not found with id '{orderLine.SalesOrderId}'!");
            }

            if (!_productRepository.ProductExists(orderLine.ProductId))
            {
                return NotFound($"Product was not found with id '{orderLine.ProductId}'!");
            }

            if (_orderLineRepository.OrderLineExists(orderLine))
            {
                return BadRequest($"That orderline already exists. Use put instead!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_orderLineRepository.CreateOrderLine(orderLine))
            {
                ModelState.AddModelError("", $"Something went wrong saving the OrderLine");
                return StatusCode(500, ModelState);
            }

            var orderLineDto = new OrderLineDto(orderLine);

            return Ok(orderLineDto);
        }

        // PUT <OrderLinesController>/5
        [HttpPut]
        public IActionResult UpdateOrderLine([FromBody] OrderLine orderLine)
        {
            if (orderLine == null)
            {
                return BadRequest(ModelState);
            }

            if (!_orderLineRepository.OrderLineExists(orderLine))
            {
                ModelState.AddModelError("", "OrderLine does not exist!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_orderLineRepository.UpdateOrderLine(orderLine))
            {
                ModelState.AddModelError("", $"Something went wrong updating OrderLine with orderLine.SalesOrder Id {orderLine.SalesOrderId} Product Id {orderLine.ProductId}");
                return StatusCode(500, ModelState);
            }

            // Usually nothing is returned when updating. 
            return NoContent();
        }

        // DELETE <OrderLinesController>/5
        [HttpDelete]
        public IActionResult DeletesalesOrderId([FromBody] OrderLine orderLine)
        {
            if (!_orderLineRepository.OrderLineExists(orderLine))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_orderLineRepository.DeleteOrderLine(orderLine))
            {
                ModelState.AddModelError("", $"Something went wrong deleting salesOrderId with SalesOrder Id { orderLine.SalesOrderId } Product Id { orderLine.ProductId }");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}