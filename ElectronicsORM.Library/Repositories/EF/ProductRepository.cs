using ElectronicsModel.Library.Dtos;
using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsORM.Library.Repositories.EF
{
    public class ProductRepository : IProductRepository
    {
        public bool CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProductsByProductType(int productTypeId)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Product GetProductFromOrderLine(int productId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> GetProductsFromProductType(int productTypeId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> GetProductsFromStore(int storeId)
        {
            throw new NotImplementedException();
        }

        public bool ProductExists(int productId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
