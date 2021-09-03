using ElectronicsModel.Library.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsModel.Library.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


        public virtual ProductType ProductType { get; set; }
        public virtual ICollection<StoreProduct> StoreProducts { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }

        public Product(ProductDto productDto)
        {
            Id = productDto.Id;
            ProductTypeId = productDto.ProductType.Id;
            Name = productDto.Name;
            Description = productDto.Description;
            Price = productDto.Price;
            ProductType = null;
        }

        public Product()
        {

        }
    }
}
