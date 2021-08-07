using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsWebAPI.Models
{
    public class SalesOrderRepositoryMO : ISalesOrderRepository
    {
        public bool CreateSalesOrder(SalesOrder salesOrder)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSalesOrder(int salesOrderId)
        {
            throw new NotImplementedException();
        }

        public SalesOrder GetSalesOrder(int salesOrderId)
        {
            throw new NotImplementedException();
        }

        public SalesOrder GetSalesOrderFromDelivery(int deliveryId)
        {
            throw new NotImplementedException();
        }

        public SalesOrder GetSalesOrderFromOrderLine(int orderLineId)
        {
            throw new NotImplementedException();
        }

        public ICollection<SalesOrder> GetSalesOrders()
        {
            throw new NotImplementedException();
        }

        public ICollection<SalesOrder> GetSalesOrdersFromOrderStatus(int orderStatusId)
        {
            throw new NotImplementedException();
        }

        public ICollection<SalesOrder> GetSalesOrdersFromStore(int storeId)
        {
            throw new NotImplementedException();
        }

        public bool SalesOrderExists(int salesOrderId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateSalesOrder(SalesOrder salesOrder)
        {
            throw new NotImplementedException();
        }
    }
}
