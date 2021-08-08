using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsWebAPI.Models
{
    interface ISalesOrderRepository
    {
        ICollection<SalesOrder> GetSalesOrders();
        ICollection<SalesOrder> GetSalesOrdersFromOrderStatus(int orderStatusId);
        ICollection<SalesOrder> GetSalesOrdersFromStore(int storeId);
        ICollection<SalesOrder> GetSalesOrdersFromProduct(int productId);
        bool SalesOrderExists(int salesOrderId);
        SalesOrder GetSalesOrder(int salesOrderId);
        SalesOrder GetSalesOrderFromDelivery(int deliveryId);


        bool CreateSalesOrder(SalesOrder salesOrder);
        bool UpdateSalesOrder(SalesOrder salesOrder);
        bool DeleteSalesOrdersByOrderStatus(int orderStatusId);
        bool DeleteSalesOrdersByStore(int storeId);
        bool DeleteSalesOrder(int salesOrderId);
        bool Save();
    }
}
