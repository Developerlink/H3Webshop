using ElectronicsModel.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsModel.Library.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ProductDto(Product product)
        {
            Id = product.Id;
            ProductTypeId = product.ProductTypeId;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
        }

        public ProductDto()
        {

        }
    }
}
