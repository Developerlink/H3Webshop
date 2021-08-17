using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsModel.Library.Models
{
    public class PostalCode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostalCodeId { get; set; }
        public string AreaName { get; set; }


        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
