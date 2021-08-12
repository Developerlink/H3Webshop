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
            string query = "INSERT INTO [dbo].[StoreProduct] ([StoreId],[ProductId],[Quantity]) " +
            "VALUES (@StoreId, @ProductId, @Quantity) ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@StoreId", storeProduct.StoreId));
            cmd.Parameters.Add(new SqlParameter("@ProductId", storeProduct.ProductId));
            cmd.Parameters.Add(new SqlParameter("@Quantity", storeProduct.Quantity));

            if (_dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    // open database connection
                    _dbConn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            _dbConn.Close();

            return false;
        }

        public bool DeleteStoreProduct(int storeId, int productId)
        {
            string query = "DELETE FROM StoreProduct WHERE StoreId=@StoreId AND ProductId=@ProductId ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@StoreId", storeId));
            cmd.Parameters.Add(new SqlParameter("@ProductId", productId));


            if (_dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    // open database connection
                    _dbConn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            _dbConn.Close();

            return false;
        }

        public bool DeleteStoreProductByProduct(int productId)
        {
            string query = "DELETE FROM StoreProduct WHERE ProductId=@ProductId ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@ProductId", productId));


            if (_dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    // open database connection
                    _dbConn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            _dbConn.Close();

            return false;
        }

        public bool DeleteStoreProductsByStore(int storeId)
        {
            string query = "DELETE FROM StoreProduct WHERE StoreId=@StoreId ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@StoreId", storeId));


            if (_dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    // open database connection
                    _dbConn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            _dbConn.Close();

            return false;
        }

        public StoreProduct GetStoreProduct(int storeId, int productId)
        {
            StoreProduct storeProduct = null;

            string query = "SELECT [StoreId],[ProductId],[Quantity] FROM[dbo].[storeProduct] WHERE StoreId=@StoreId AND ProductId=@ProductId ";
            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@StoreId", storeId));
            cmd.Parameters.Add(new SqlParameter("@ProductId", productId));

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

                while (reader.Read())
                {
                    storeProduct = new StoreProduct()
                    {
                        StoreId = storeId,
                        ProductId = productId,
                        Quantity = reader.GetInt16(2)
                    };
                }
                reader.Close();
            }
            return storeProduct;
        }

        public ICollection<StoreProduct> GetStoreProducts()
        {
            var storeProducts = new List<StoreProduct>();

            string query = "SELECT [StoreId],[ProductId],[Quantity] FROM[dbo].[storeProduct] ";
            SqlCommand cmd = new SqlCommand(query, _dbConn);

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

                while (reader.Read())
                {
                    var storeProduct = new StoreProduct()
                    {
                        StoreId = reader.GetInt32(0),
                        ProductId = reader.GetInt32(1),
                        Quantity = reader.GetInt16(2)
                    };
                }
                reader.Close();
            }
            return storeProducts;
        }

        public ICollection<StoreProduct> GetStoreProductsFromProduct(int productId)
        {
            var storeProducts = new List<StoreProduct>();

            string query = "SELECT [StoreId],[ProductId],[Quantity] FROM[dbo].[storeProduct] WHERE ProductId=@ProductId ";
            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@ProductId", productId));

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

                while (reader.Read())
                {
                    var storeProduct = new StoreProduct()
                    {
                        StoreId = reader.GetInt32(0),
                        ProductId = reader.GetInt32(1),
                        Quantity = reader.GetInt16(2)
                    };
                }
                reader.Close();
            }
            return storeProducts;
        }

        public ICollection<StoreProduct> GetStoreProductsFromStore(int storeId)
        {
            var storeProducts = new List<StoreProduct>();

            string query = "SELECT [StoreId],[ProductId],[Quantity] FROM[dbo].[storeProduct] WHERE StoreId=@StoreId ";
            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@StoreId", storeId));

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

                while (reader.Read())
                {
                    var storeProduct = new StoreProduct()
                    {
                        StoreId = reader.GetInt32(0),
                        ProductId = reader.GetInt32(1),
                        Quantity = reader.GetInt16(2)
                    };
                }
                reader.Close();
            }
            return storeProducts;
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
            string query = "UPDATE [dbo].[StoreProduct]SET" +
                "[Quantity] = @Quantity" +
                 "WHERE StoreId=@StoreId AND ProductId=@ProductId ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@StoreId", storeProduct.StoreId));
            cmd.Parameters.Add(new SqlParameter("@ProductId", storeProduct.ProductId));
            cmd.Parameters.Add(new SqlParameter("@Quantity", storeProduct.Quantity));

            if (_dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    // open database connection
                    _dbConn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            _dbConn.Close();

            return false;
        }
    }
}
