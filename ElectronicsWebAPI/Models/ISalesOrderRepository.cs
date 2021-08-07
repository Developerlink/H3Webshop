using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsWebAPI.Models
{
    interface ISalesOrderRepository
    {
        ICollection<SalesOrder> GetSalesOrders();
        bool SalesOrderExists(int salesOrderId);
        SalesOrder GetSalesOrder(int salesOrderId);
        SalesOrder GetSalesOrderFromOrderLine(int orderLineId);
        SalesOrder GetSalesOrderFromDelivery(int deliveryId);
        ICollection<SalesOrder> GetSalesOrdersFromOrderStatus(int orderStatusId);
        ICollection<SalesOrder> GetSalesOrdersFromStore(int storeId);


        bool CreateSalesOrder(SalesOrder salesOrder);
        bool UpdateSalesOrder(SalesOrder salesOrder);
        bool DeleteSalesOrder(int salesOrderId);
        bool Save();
    }
}
