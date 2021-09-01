using ElectronicsModel.Library.Models;

namespace ElectronicsModel.Library.Dtos
{
    public class ProductTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ProductTypeDto(ProductType productType)
        {
            Id = productType.Id;
            Name = productType.Name;
        }

        public ProductTypeDto()
        {

        }
    }

}
