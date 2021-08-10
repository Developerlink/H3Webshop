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
    public class StoreProductRepositoryMO : IStoreProductRepository
    {
        private readonly SqlConnection _dbConn;

        public StoreProductRepositoryMO()
        {
            _dbConn = new SqlConnection(MsSql.GetConnectionString());
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

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool StoreProductExists(int storeId, int productId)
        {
            bool result = false;

            string query = "SELECT COUNT(1) FROM StoreProduct WHERE StoreProduct.StoreId=@storeId AND StoreProduct.ProductId=@productId ";
            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.AddWithValue("@storeId", storeId);
            cmd.Parameters.AddWithValue("@productId", productId);

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

        public bool UpdateStoreProduct(StoreProduct storeProduct)
        {
            throw new NotImplementedException();
        }
    }
}
