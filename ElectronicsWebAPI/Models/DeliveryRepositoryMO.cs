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

        public bool DeleteDeliveriesByCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDeliveriesByPostalCode(int postalCodeId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDeliveryBySalesOrder(int salesOrderId)
        {
            throw new NotImplementedException();
        }

        public bool DeliveryExists(int salesOrderId, int customerId, int postalCodeId)
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
