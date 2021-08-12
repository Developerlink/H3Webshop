using ElectronicsModel.Library.Dtos;
using ElectronicsModel.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsORM.Library.Interfaces
{
    public interface ISalesOrderRepository
    {
        ICollection<SalesOrder> GetSalesOrders();
        ICollection<SalesOrder> GetSalesOrdersFromOrderStatus(int orderStatusId);
        ICollection<SalesOrder> GetSalesOrdersFromStore(int storeId);
        ICollection<SalesOrder> GetSalesOrdersFromProduct(int productId);
        SalesOrder GetSalesOrder(int salesOrderId);
        bool SalesOrderExists(int salesOrderId);


        bool CreateSalesOrder(SalesOrder salesOrder);
        bool UpdateSalesOrder(SalesOrder salesOrder);
        bool DeleteSalesOrdersByOrderStatus(int orderStatusId);
        bool DeleteSalesOrdersByStore(int storeId);
        bool DeleteSalesOrder(int salesOrderId);
    }
}
