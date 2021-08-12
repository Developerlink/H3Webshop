using ElectronicsModel.Library.Dtos;
using ElectronicsModel.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsORM.Library.Interfaces
{
    public interface IOrderLineRepository
    {
        ICollection<OrderLine> GetOrderLines();
        ICollection<OrderLine> GetOrderLinesFromSalesOrder(int salesOrderId);
        ICollection<OrderLine> GetOrderLinesFromProduct(int productId);
        OrderLine GetOrderLine(int salesOrderId, int productId);
        bool OrderLineExists(int salesOrderId, int productId);


        bool CreateOrderLine(OrderLine orderLine);
        bool UpdateOrderLine(OrderLine orderLine);
        bool DeleteOrderLinesBySalesOrder(int salesOrderId);
        bool DeleteOrderLinesByProduct(int productId);
        bool DeleteOrderLine(int salesOrderId, int productId);
    }
}
