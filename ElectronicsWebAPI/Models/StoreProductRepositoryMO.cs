using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsWebAPI.Models
{
    public class StoreProductRepositoryMO : IStoreProductRepository
    {
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

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool StoreProductExists(int storeId, int productId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStoreProduct(StoreProduct storeProduct)
        {
            throw new NotImplementedException();
        }
    }
}
