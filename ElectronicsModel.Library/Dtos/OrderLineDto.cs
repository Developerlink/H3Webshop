using ElectronicsModel.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsModel.Library.Dtos
{
    public class OrderLineDto
    {
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public OrderLineDto(OrderLine orderLine)
        {
            SalesOrderId = orderLine.SalesOrderId;
            ProductId = orderLine.ProductId;
            Price = orderLine.Price;
            Quantity = orderLine.Quantity;
        }

        public OrderLineDto()
        {

        }
    }
}
