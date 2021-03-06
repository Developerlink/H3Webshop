using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicsORM.Library.Repositories.EF
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ElectronicsDbContext _electronicsDbContext;

        public ProductTypeRepository(ElectronicsDbContext electronicsDbContext)
        {
            _electronicsDbContext = electronicsDbContext;
        }

        public ProductType GetProductType(int productTypeId)
        {
            return _electronicsDbContext.ProductType.Find(productTypeId);
        }

        public ICollection<ProductType> GetProductTypes()
        {
            return _electronicsDbContext.ProductType.ToList();
        }

        public bool ProductTypeExists(int productTypeId)
        {
            return _electronicsDbContext.ProductType.Any(p => p.Id == productTypeId);
        }
    }
}
