using ElectronicsModel.Library.Dtos;
using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsORM.Library.Repositories.EF
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private ElectronicsDbContext _electronicsDbContext;

        public DeliveryRepository(ElectronicsDbContext electronicsDbContext)
        {
            _electronicsDbContext = electronicsDbContext;
        }

        public bool CreateDelivery(Delivery delivery)
        {
            _electronicsDbContext.Add(delivery);
            return Save();
        }

        public bool DeleteDeliveriesByCustomer(int customerId)
        {
            var deliveriesToDelete = _electronicsDbContext.Delivery.Where(d => d.CustomerId == customerId);
            _electronicsDbContext.RemoveRange(deliveriesToDelete);
            return Save();
        }

        public bool DeleteDeliveriesByPostalCode(int postalCodeId)
        {
            var deliveriesToDelete = _electronicsDbContext.Delivery.Where(d => d.PostalCodeId == postalCodeId);
            _electronicsDbContext.RemoveRange(deliveriesToDelete);
            return Save();
        }

        public bool DeleteDeliveryBySalesOrder(int salesOrderId)
        {
            var deliveryToDelete = _electronicsDbContext.Delivery.Where(d => d.SalesOrderId == salesOrderId);
            _electronicsDbContext.Remove(deliveryToDelete);
            return Save();
        }

        public bool DeliveryExists(int salesOrderId)
        {
            return _electronicsDbContext.Delivery.Any(d => d.SalesOrderId  == salesOrderId);

        }

        public ICollection<Delivery> GetDeliveries()
        {
            var deliveries = _electronicsDbContext.Delivery.OrderBy(d => d.CustomerId).OrderBy(d => d.SalesOrder.OrderDate).ToList();
            return deliveries;
        }

        public ICollection<Delivery> GetDeliveriesFromCustomer(int customerId)
        {
            var deliveries = _electronicsDbContext.Delivery.Where(d => d.CustomerId == customerId).OrderBy(d => d.SalesOrder.OrderDate).ToList();
            return deliveries;
        }

        public ICollection<Delivery> GetDeliveriesFromPostalCode(int postalCodeId)
        {
            var deliveries = _electronicsDbContext.Delivery.Where(d => d.PostalCodeId == postalCodeId).OrderBy(d => d.SalesOrder.OrderDate).ToList();
            return deliveries;
        }

        public Delivery GetDeliveryFromSalesOrder(int salesOrderId)
        {
            var delivery = _electronicsDbContext.Delivery.Where(d => d.SalesOrderId == salesOrderId).OrderBy(d => d.SalesOrder.OrderDate).FirstOrDefault();
            return delivery;
        }

        public bool UpdateDelivery(Delivery delivery)
        {
            _electronicsDbContext.Update(delivery);
            return Save();
        }

        public bool Save()
        {
            var rowsChanged = _electronicsDbContext.SaveChanges();
            return rowsChanged >= 0;
        }
    }
}
