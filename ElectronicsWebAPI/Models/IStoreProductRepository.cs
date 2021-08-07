using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsWebAPI.Models
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
        bool DeleteStoreProduct(StoreProduct storeProduct);
        bool Save();
    }
}
