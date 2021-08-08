using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsWebAPI.Models
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        bool ProductExists(int productId);
        Product GetProduct(int productId);
        Product GetProductFromOrderLine(int productId);
        ICollection<Product> GetProductsFromStore(int storeId);
        ICollection<Product> GetProductsFromProductType(int productTypeId);


        bool CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int productId);
        bool DeleteProductsByProductType(int productTypeId);
        bool Save();
    }
}
