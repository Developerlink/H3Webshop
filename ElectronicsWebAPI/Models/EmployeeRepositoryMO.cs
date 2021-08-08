using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsWebAPI.Models
{
    public class EmployeeRepositoryMO : IOrderLineRepository
    {
        public bool CreateOrderLine(OrderLine orderLine)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrderLine(int salesOrderId, int productId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrderLinesByProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrderLinesBySalesOrder(int salesOrderId)
        {
            throw new NotImplementedException();
        }

        public OrderLine GetOrderLine(int salesOrderId, int productId)
        {
            throw new NotImplementedException();
        }

        public ICollection<OrderLine> GetOrderLines()
        {
            throw new NotImplementedException();
        }

        public ICollection<OrderLine> GetOrderLinesFromProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public ICollection<OrderLine> GetOrderLinesFromSalesOrder(int salesOrderId)
        {
            throw new NotImplementedException();
        }

        public bool OrderLineExists(int salesOrderId, int productId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrderLine(OrderLine orderLine)
        {
            throw new NotImplementedException();
        }
    }
}
