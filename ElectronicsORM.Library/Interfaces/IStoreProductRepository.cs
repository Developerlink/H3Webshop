using ElectronicsModel.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsORM.Library.Interfaces
{
    public interface IStoreProductRepository
    {
        ICollection<StoreProduct> GetStoreProducts();
        ICollection<StoreProduct> GetStoreProductsFromProduct(int productId);
        ICollection<StoreProduct> GetStoreProductsFromStore(int storeId);
        bool StoreProductExists(int storeId, int productId);
        StoreProduct GetStoreProduct(int storeId, int productId);


        bool CreateStoreProduct(StoreProduct storeProduct);
        bool UpdateStoreProduct(StoreProduct storeProduct);
        bool DeleteStoreProductByProduct(int productId);
        bool DeleteStoreProductsByStore(int storeId);
        bool DeleteStoreProduct(int storeId, int productId);
        bool Save();
    }
}
