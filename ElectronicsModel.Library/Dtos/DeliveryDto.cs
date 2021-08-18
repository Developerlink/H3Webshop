using ElectronicsModel.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsModel.Library.Dtos
{
    public class DeliveryDto
    {
        public int SalesOrderId { get; set; }
        public int CustomerId { get; set; }
        public int PostalCodeId { get; set; }
        public string Address { get; set; }
        public DateTime SendDate { get; set; }

        public DeliveryDto()
        {

        }

        public DeliveryDto(Delivery delivery)
        {
            SalesOrderId = delivery.SalesOrderId;
            PostalCodeId = delivery.PostalCodeId;
            CustomerId = delivery.CustomerId;
            Address = delivery.Address;
            SendDate = delivery.SendDate;
        }
    }
}
