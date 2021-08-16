using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsORM.Library.Repositories.EF
{
    public class StoreProductRepository : IStoreProductRepository
    {
        private ElectronicsDbContext _electronicsDbContext;

        public StoreProductRepository(ElectronicsDbContext electronicsDbContext)
        {
            _electronicsDbContext = electronicsDbContext;
        }
        public bool CreateStoreProduct(StoreProduct storeProduct)
        {
            throw new NotImplementedException();
        }

        public bool DeleteStoreProduct(int storeId, int productId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteStoreProductByProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteStoreProductsByStore(int storeId)
        {
            throw new NotImplementedException();
        }

        public StoreProduct GetStoreProduct(int storeId, int productId)
        {
            throw new NotImplementedException();
        }

        public ICollection<StoreProduct> GetStoreProducts()
        {
            throw new NotImplementedException();
        }

        public ICollection<StoreProduct> GetStoreProductsFromProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public ICollection<StoreProduct> GetStoreProductsFromStore(int storeId)
        {
            throw new NotImplementedException();
        }

        public bool StoreProductExists(int storeId, int productId)
        {
            return _electronicsDbContext.StoreProduct.Any(s => s.StoreId == storeId && s.ProductId == productId);
        }

        public bool UpdateStoreProduct(StoreProduct storeProduct)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var rowsChanged = _electronicsDbContext.SaveChanges();
            return rowsChanged >= 0;
        }
    }
}
