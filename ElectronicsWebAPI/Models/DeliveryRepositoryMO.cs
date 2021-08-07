using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsWebAPI.Models
{
    public class DeliveryRepositoryMO : IDeliveryRepository
    {
        public bool CreateDelivery(Delivery delivery)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDelivery(Delivery delivery)
        {
            throw new NotImplementedException();
        }

        public bool DeliveryExists(int deliveryId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Delivery> GetDeliveries()
        {
            throw new NotImplementedException();
        }

        public ICollection<Delivery> GetDeliveriesFromCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Delivery> GetDeliveriesFromPostalCode(int postalCodeId)
        {
            throw new NotImplementedException();
        }

        public Delivery GetDelivery(int deliveryId)
        {
            throw new NotImplementedException();
        }

        public Delivery GetDeliveryFromSalesOrder(int salesOrderId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateDelivery(Delivery delivery)
        {
            throw new NotImplementedException();
        }
    }
}
