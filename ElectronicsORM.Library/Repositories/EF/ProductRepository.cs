using ElectronicsModel.Library.Dtos;
using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsORM.Library.Repositories.EF
{
    public class ProductRepository : IProductRepository
    {
        private readonly ElectronicsDbContext _electronicsDbContext;

        public ProductRepository(ElectronicsDbContext electronicsDbContext)
        {
            _electronicsDbContext = electronicsDbContext;
        }

        public bool CreateProduct(Product product)
        {
            // Alternatively:
            //product.ProductType = null;
            _electronicsDbContext.Add(product);
            _electronicsDbContext.Entry(product.ProductType).State = EntityState.Unchanged;

            return Save();
        }

        public bool DeleteProduct(int productId)
        {
            var productToDelete = _electronicsDbContext.Product.Find(productId);
            _electronicsDbContext.Remove(productToDelete);
            return Save();
        }

        public bool DeleteProductsByProductType(int productTypeId)
        {
            var productsToDelete = _electronicsDbContext.Product.Where(p => p.ProductTypeId == productTypeId);
            _electronicsDbContext.RemoveRange(productsToDelete);
            return Save();
        }

        public Product GetProduct(int productId)
        {
            var product = _electronicsDbContext.Product.Find(productId);
            product.ProductType = _electronicsDbContext.ProductType.Find(product.ProductTypeId);
            return product;
        }

        public ICollection<Product> GetProducts()
        {
            var products = _electronicsDbContext.Product.Include(p => p.ProductType).OrderByDescending(p => p.Id).ToList();
            return products;
        }

        public ICollection<Product> GetProductsFromProductType(int productTypeId)
        {
            var products = _electronicsDbContext.Product.Include(p => p.ProductType).Where(p => p.ProductTypeId == productTypeId).ToList();
            return products;
        }

        public ICollection<Product> GetProductsFromSalesOrder(int salesOrderId)
        {
            var products = _electronicsDbContext.OrderLine.Where(o => o.SalesOrderId == salesOrderId).Select(o => o.Product).Include(p => p.ProductType).ToList();
            return products;
        }

        public ICollection<Product> GetProductsFromStore(int storeId)
        {
            var products = _electronicsDbContext.StoreProduct.Where(s => s.StoreId == storeId).Select(s => s.Product).Include(p => p.ProductType).ToList();
            return products;
        }

        public bool ProductExists(int productId)
        {
            return _electronicsDbContext.Product.Any(p => p.Id == productId);
        }

        public bool UpdateProduct(Product product)
        {
            _electronicsDbContext.Update(product);
            return Save();
        }

        public bool Save()
        {
            var rowsChanged = _electronicsDbContext.SaveChanges();
            return rowsChanged >= 0;
        }
    }
}
