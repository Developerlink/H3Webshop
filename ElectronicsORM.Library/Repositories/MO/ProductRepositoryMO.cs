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
            string query = "INSERT INTO [dbo].[Product] ([ProductTypeId],[Name],[Description],[Price])" +
                "OUTPUT INSERTED.ID " +
                "VALUES (@ProductTypeId, @Name, @Description, @Price) ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@ProductTypeId", product.ProductTypeId));
            cmd.Parameters.Add(new SqlParameter("@Name", product.Name));
            cmd.Parameters.Add(new SqlParameter("@Description", product.Description));
            cmd.Parameters.Add(new SqlParameter("@Price", product.Price));

            if (_dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    // open database connection
                    _dbConn.Open();
                    product.Id = (int)cmd.ExecuteScalar();
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

        public bool DeleteProduct(int productId)
        {
            string query = "DELETE FROM Product WHERE Product.Id=@Id ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@Id", productId));

            if (_dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    // open database connection
                    _dbConn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            _dbConn.Close();

            return false;
        }

        public bool DeleteProductsByProductType(int productTypeId)
        {
            string query = "DELETE FROM Product WHERE ProductTypeId=@Id ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@Id", productTypeId));

            if (_dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    // open database connection
                    _dbConn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            _dbConn.Close();

            return false;
        }

        public Product GetProduct(int productId)
        {
            Product product = null;

            string query = "SELECT [ProductTypeId],[Name],[Description],[Price] FROM[dbo].[Product] WHERE Id=@Id";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@Id", productId));

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
                int i = 0;
                while (reader.Read())
                {
                    product = new Product()
                    {
                        Id = productId,
                        ProductTypeId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        Price = reader.GetDecimal(3),
                    };
                    i++;
                }
                reader.Close();
                if (i != 1) return null;
            }
            _dbConn.Close();

            return product;
        }

        public ICollection<Product> GetProducts()
        {
            var products = new List<Product>();

            string query = "SELECT [ProductTypeId],[Name],[Description],[Price],[Id] FROM[dbo].[Product] ";

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
                    var product = new Product()
                    {
                        ProductTypeId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        Price = reader.GetDecimal(3),
                        Id = reader.GetInt32(4)
                    };
                    products.Add(product);
                }
                reader.Close();
            }
            _dbConn.Close();

            return products;
        }

        public ICollection<Product> GetProductsFromProductType(int productTypeId)
        {
            var products = new List<Product>();

            string query = "SELECT [ProductTypeId],[Name],[Description],[Price],[Id] FROM[dbo].[Product] WHERE ProductTypeId=@Id ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@Id", productTypeId));

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
                    var product = new Product()
                    {
                        ProductTypeId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        Price = reader.GetDecimal(3),
                        Id = reader.GetInt32(4)
                    };
                    products.Add(product);
                }
                reader.Close();
            }
            _dbConn.Close();

            return products;
        }

        public ICollection<Product> GetProductsFromSalesOrder(int salesOrderId)
        {
            var products = new List<Product>();

            string query = "SELECT [ProductTypeId],[Name],[Description],[Price],[Id] FROM[dbo].[Product] " +
                "INNER JOIN OrderLine ON OrderLine.ProductId=Id " +
                "WHERE OrderLine.SalesOrderId=@Id ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@Id", salesOrderId));

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
                    var product = new Product()
                    {
                        ProductTypeId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        Price = reader.GetDecimal(3),
                        Id = reader.GetInt32(4)
                    };
                    products.Add(product);
                }
                reader.Close();
            }
            _dbConn.Close();

            return products;
        }

        public ICollection<Product> GetProductsFromStore(int storeId)
        {
            var products = new List<Product>();

            string query = "SELECT [ProductTypeId],[Name],[Description],[Price],[Id] FROM[dbo].[Product] WHERE StoreId=@Id ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@Id", storeId));

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
                    var product = new Product()
                    {
                        ProductTypeId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        Price = reader.GetDecimal(3),
                        Id = reader.GetInt32(4)
                    };
                    products.Add(product);
                }
                reader.Close();
            }
            _dbConn.Close();

            return products;
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

                int count = (int)cmd.ExecuteScalar();

                if (count == 1)
                {
                    result = true;
                }
            }
            _dbConn.Close();

            return result;
        }

        public bool UpdateProduct(Product product)
        {
            string query = "UPDATE [dbo].[Product] SET " +
                "[ProductTypeId] = @ProductTypeId , " +
                "[Name] = @Name, " +
                "[Description] = @Description, " +
                "[Price] = @Price " +
                "WHERE Id=@Id";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@ProductTypeId", product.ProductTypeId));
            cmd.Parameters.Add(new SqlParameter("@Name", product.Name));
            cmd.Parameters.Add(new SqlParameter("@Description", product.Description));
            cmd.Parameters.Add(new SqlParameter("@Price", product.Price));
            cmd.Parameters.Add(new SqlParameter("@Id", product.Id));

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
