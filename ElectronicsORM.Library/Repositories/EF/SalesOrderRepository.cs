using ElectronicsModel.Library.Dtos;
using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsORM.Library.Repositories.EF
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        private readonly ElectronicsDbContext _electronicsDbContext;

        public SalesOrderRepository(ElectronicsDbContext electronicsDbContext)
        {
            _electronicsDbContext = electronicsDbContext;
        }

        public bool CreateSalesOrder(SalesOrder salesOrder)
        {
            _electronicsDbContext.Add(salesOrder);
            return Save();
        }

        public bool DeleteSalesOrder(int salesOrderId)
        {
            var salesOrderToDelete = _electronicsDbContext.SalesOrder.Find(salesOrderId);
            _electronicsDbContext.Remove(salesOrderToDelete);
            return Save();
        }

        public bool DeleteSalesOrdersByOrderStatus(int orderStatusId)
        {
            var salesOrdersToDelete = _electronicsDbContext.SalesOrder.Where(s => s.OrderStatusId == orderStatusId);
            _electronicsDbContext.RemoveRange(salesOrdersToDelete);
            return Save();
        }

        public bool DeleteSalesOrdersByStore(int storeId)
        {
            var salesOrdersToDelete = _electronicsDbContext.SalesOrder.Where(s => s.StoreId == storeId);
            _electronicsDbContext.RemoveRange(salesOrdersToDelete);
            return Save();
        }

        public SalesOrder GetSalesOrder(int salesOrderId)
        {
            var salesOrder = _electronicsDbContext.SalesOrder.Find(salesOrderId);
            return salesOrder;
        }

        public ICollection<SalesOrder> GetSalesOrders()
        {
            var salesOrders = _electronicsDbContext.SalesOrder.OrderByDescending(s => s.Id).ToList();
            return salesOrders;
        }

        public ICollection<SalesOrder> GetSalesOrdersFromOrderStatus(int orderStatusId)
        {
            var salesOrders = _electronicsDbContext.SalesOrder.Where(s => s.OrderStatusId == orderStatusId).ToList();
            return salesOrders;
        }

        public ICollection<SalesOrder> GetSalesOrdersFromProduct(int productId)
        {
            var salesOrders = _electronicsDbContext.OrderLine.Where(o => o.ProductId == productId).Select(o => o.SalesOrder).ToList();
            return salesOrders;

        }

        public ICollection<SalesOrder> GetSalesOrdersFromStore(int storeId)
        {
            var salesOrders = _electronicsDbContext.SalesOrder.Where(s => s.StoreId == storeId).ToList();
            return salesOrders;
        }

        public bool SalesOrderExists(int salesOrderId)
        {
            return _electronicsDbContext.SalesOrder.Any(s => s.Id == salesOrderId);

        }

        public bool UpdateSalesOrder(SalesOrder salesOrder)
        {
            _electronicsDbContext.Update(salesOrder);
            return Save();
        }

        public bool Save()
        {
            var rowsChanged = _electronicsDbContext.SaveChanges();
            return rowsChanged >= 0;
        }
    }
}
