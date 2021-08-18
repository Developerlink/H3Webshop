using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsModel.Library.Models
{
    public class Delivery
    {        
        public int SalesOrderId { get; set; }
        public int CustomerId { get; set; }
        public int PostalCodeId { get; set; }
        public string Address { get; set; }
        public DateTime SendDate { get; set; }


        public virtual SalesOrder SalesOrder { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual PostalCode PostalCode { get; set; }

    }
}
