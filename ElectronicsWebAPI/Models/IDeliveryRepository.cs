using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsWebAPI.Models
{
    public interface IDeliveryRepository
    {
        ICollection<Delivery> GetDeliveries();
        bool DeliveryExists(int deliveryId);
        Delivery GetDelivery(int deliveryId);
        Delivery GetDeliveryFromSalesOrder(int salesOrderId);
        ICollection<Delivery> GetDeliveriesFromCustomer(int customerId);
        ICollection<Delivery> GetDeliveriesFromPostalCode(int postalCodeId);


        bool CreateDelivery(Delivery delivery);
        bool UpdateDelivery(Delivery delivery);
        bool DeleteDelivery(Delivery delivery);
        bool Save();
    }
}
