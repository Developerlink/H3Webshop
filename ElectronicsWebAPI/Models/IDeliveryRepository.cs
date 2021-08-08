﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsWebAPI.Models
{
    public interface IDeliveryRepository
    {
        ICollection<Delivery> GetDeliveries();
        ICollection<Delivery> GetDeliveriesFromCustomer(int customerId);
        ICollection<Delivery> GetDeliveriesFromPostalCode(int postalCodeId);
        bool DeliveryExists(int salesOrderId, int customerId, int postalCodeId);
        Delivery GetDeliveryFromSalesOrder(int salesOrderId);


        bool CreateDelivery(Delivery delivery);
        bool UpdateDelivery(Delivery delivery);
        bool DeleteDeliveriesByCustomer(int customerId);
        bool DeleteDeliveriesByPostalCode(int postalCodeId);
        bool DeleteDeliveryBySalesOrder(int salesOrderId);
        bool Save();
    }
}
