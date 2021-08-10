using ElectronicsModel.Library.Dtos;
using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.DataAccess;
using ElectronicsORM.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsORM.Library.Repositories.MO
{
    public class ProductRepositoryMO : IProductRepository
    {
        readonly SqlConnection _dbConn;

        public ProductRepositoryMO()
        {
            _dbConn = new SqlConnection(MsSql.GetConnectionString());
        }
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
            bool result = false;

            string query = "SELECT COUNT(1) FROM Product WHERE Product.Id=@Id ";
            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.AddWithValue("@Id", productId);

            if (_dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    // open database connection
                    _dbConn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int count = 0;
                while (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
                if (count == 1)
                {
                    result = true;
                }
            }
            return result;
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
