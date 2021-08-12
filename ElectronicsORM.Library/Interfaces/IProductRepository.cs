using ElectronicsModel.Library.Dtos;
using ElectronicsModel.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsORM.Library.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        ICollection<Product> GetProductsFromStore(int storeId);
        ICollection<Product> GetProductsFromSalesOrder(int salesOrderId);
        ICollection<Product> GetProductsFromProductType(int productTypeId);
        Product GetProduct(int productId);
        bool ProductExists(int productId);


        bool CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int productId);
        bool DeleteProductsByProductType(int productTypeId);
    }
}
