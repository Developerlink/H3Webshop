using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsModel.Library.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public virtual ICollection<Product> Products { get; set; } 
    }
}
