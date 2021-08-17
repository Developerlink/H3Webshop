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
        private readonly ElectronicsDbContext _electronicsDbContext;

        public StoreProductRepository(ElectronicsDbContext electronicsDbContext)
        {
            _electronicsDbContext = electronicsDbContext;
        }
        public bool CreateStoreProduct(StoreProduct storeProduct)
        {
            _electronicsDbContext.Add(storeProduct);
            return Save();
        }

        public bool DeleteStoreProduct(int storeId, int productId)
        {
            var storeProductsToDelete = _electronicsDbContext.StoreProduct.Where(s => s.StoreId == storeId && s.ProductId == productId).ToList();
            _electronicsDbContext.RemoveRange(storeProductsToDelete);
            return Save();
        }

        public bool DeleteStoreProductByProduct(int productId)
        {
            var storeProductsToDelete = _electronicsDbContext.StoreProduct.Where(s => s.ProductId == productId).ToList();
            _electronicsDbContext.RemoveRange(storeProductsToDelete);
            return Save();
        }

        public bool DeleteStoreProductsByStore(int storeId)
        {
            var storeProductsToDelete = _electronicsDbContext.StoreProduct.Where(s => s.StoreId == storeId).ToList();
            _electronicsDbContext.RemoveRange(storeProductsToDelete);
            return Save();
        }

        public StoreProduct GetStoreProduct(int storeId, int productId)
        {
            var storeProduct = _electronicsDbContext.StoreProduct.Where(s => s.StoreId == storeId && s.ProductId == productId).FirstOrDefault(); ;
            return storeProduct;
        }

        public ICollection<StoreProduct> GetStoreProducts()
        {
            var storeProducts = _electronicsDbContext.StoreProduct.OrderBy(s => s.StoreId).ToList();
            return storeProducts;
        }

        public ICollection<StoreProduct> GetStoreProductsFromProduct(int productId)
        {
            var storeProducts = _electronicsDbContext.StoreProduct.Where(s => s.ProductId == productId).ToList();
            return storeProducts;
        }

        public ICollection<StoreProduct> GetStoreProductsFromStore(int storeId)
        {
            var storeProducts = _electronicsDbContext.StoreProduct.Where(s => s.StoreId == storeId).ToList();
            return storeProducts;
        }

        public bool StoreProductExists(int storeId, int productId)
        {
            return _electronicsDbContext.StoreProduct.Any(s => s.StoreId == storeId && s.ProductId == productId);
        }

        public bool UpdateStoreProduct(StoreProduct storeProduct)
        {
            _electronicsDbContext.Update(storeProduct);
            return Save();
        }

        public bool Save()
        {
            var rowsChanged = _electronicsDbContext.SaveChanges();
            return rowsChanged >= 0;
        }
    }
}
