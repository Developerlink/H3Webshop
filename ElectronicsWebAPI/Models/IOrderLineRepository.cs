using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsWebAPI.Models
{
    interface IOrderLineRepository
    {
        ICollection<OrderLine> GetOrderLines();
        ICollection<OrderLine> GetOrderLinesFromSalesOrder(int salesOrderId);
        ICollection<OrderLine> GetOrderLinesFromProduct(int productId);
        bool OrderLineExists(int salesOrderId, int productId);
        OrderLine GetOrderLine(int salesOrderId, int productId);


        bool CreateOrderLine(OrderLine orderLine);
        bool UpdateOrderLine(OrderLine orderLine);
        bool DeleteOrderLine(OrderLine orderLine);
        bool Save();
    }
}
