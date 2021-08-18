using ElectronicsModel.Library.Dtos;
using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsORM.Library.Repositories.EF
{
    public class OrderLineRepository : IOrderLineRepository
    {
        private readonly ElectronicsDbContext _electronicsDbContext;

        public OrderLineRepository(ElectronicsDbContext electronicsDbContext)
        {
            _electronicsDbContext = electronicsDbContext;
        }

        public bool CreateOrderLine(OrderLine orderLine)
        {
            _electronicsDbContext.Add(orderLine);
            return Save();
        }

        public bool DeleteOrderLine(OrderLine orderLine)
        {
            _electronicsDbContext.Remove(orderLine);
            return Save();
        }

        public bool DeleteOrderLinesByProduct(int productId)
        {
            var orderLinesToDelete = _electronicsDbContext.OrderLine.Where(o => o.ProductId == productId).ToList();
            _electronicsDbContext.RemoveRange(orderLinesToDelete);
            return Save();
        }

        public bool DeleteOrderLinesBySalesOrder(int salesOrderId)
        {
            var orderLinesToDelete = _electronicsDbContext.OrderLine.Where(o => o.SalesOrderId == salesOrderId).ToList();
            _electronicsDbContext.RemoveRange(orderLinesToDelete);
            return Save();
        }

        public ICollection<OrderLine> GetOrderLines()
        {
            var orderLines = _electronicsDbContext.OrderLine.ToList();
            return orderLines;
        }

        public ICollection<OrderLine> GetOrderLinesFromProduct(int productId)
        {
            var orderLines = _electronicsDbContext.OrderLine.Where(o => o.ProductId == productId).OrderBy(o => o.SalesOrderId).ToList();
            return orderLines;
        }

        public ICollection<OrderLine> GetOrderLinesFromSalesOrder(int salesOrderId)
        {
            var orderLines = _electronicsDbContext.OrderLine.Where(o => o.SalesOrderId == salesOrderId).OrderBy(o => o.SalesOrderId).ToList();
            return orderLines;
        }

        public bool OrderLineExists(OrderLine orderLine)
        {
            return _electronicsDbContext.OrderLine.Any(o => o.SalesOrderId == orderLine.SalesOrderId && o.ProductId == orderLine.ProductId);
        }

        public bool UpdateOrderLine(OrderLine orderLine)
        {
            _electronicsDbContext.Update(orderLine);
            return Save();
        }

        public bool Save()
        {
            var rowsChanged = _electronicsDbContext.SaveChanges();
            return rowsChanged >= 0;
        }
    }
}
