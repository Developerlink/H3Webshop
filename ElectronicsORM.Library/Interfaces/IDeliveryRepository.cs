using ElectronicsModel.Library.Dtos;
using ElectronicsModel.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsORM.Library.Interfaces
{
    public interface IDeliveryRepository
    {
        ICollection<Delivery> GetDeliveries();
        ICollection<Delivery> GetDeliveriesFromCustomer(int customerId);
        ICollection<Delivery> GetDeliveriesFromPostalCode(int postalCodeId);
        Delivery GetDeliveryFromSalesOrder(int salesOrderId);
        bool DeliveryExists(int salesOrderId);


        bool CreateDelivery(Delivery delivery);
        bool UpdateDelivery(Delivery delivery);
        bool DeleteDeliveriesByCustomer(int customerId);
        bool DeleteDeliveriesByPostalCode(int postalCodeId);
        bool DeleteDeliveryBySalesOrder(int salesOrderId);
    }
}
