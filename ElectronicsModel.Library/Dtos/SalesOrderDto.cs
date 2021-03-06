using ElectronicsModel.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsModel.Library.Dtos
{
    public class SalesOrderDto
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime OrderDate { get; set; }

        public SalesOrderDto(SalesOrder salesOrder)
        {
            Id = salesOrder.Id;
            StoreId = salesOrder.StoreId;
            OrderStatusId = salesOrder.OrderStatusId;
            OrderDate = salesOrder.OrderDate;
        }

        public SalesOrderDto()
        {

        }
    }
}
