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
    public class SalesOrderRepositoryMO : ISalesOrderRepository
    {
        readonly SqlConnection _dbConn;

        public SalesOrderRepositoryMO()
        {
            _dbConn = new SqlConnection(MsSql.GetConnectionString());
        }

        public bool CreateSalesOrder(SalesOrder salesOrder)
        {
            string query = "INSERT INTO [dbo].[SalesOrder] ([OrderStatusId],[OrderDate],[StoreId]) " +
                "OUTPUT INSERTED.ID " +
                "VALUES (@OrderStatusId, @OrderDate, @StoreId) ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@OrderStatusId", salesOrder.OrderStatusId));
            cmd.Parameters.Add(new SqlParameter("@OrderDate", salesOrder.OrderDate));
            cmd.Parameters.Add(new SqlParameter("@StoreId", salesOrder.StoreId));

            if (_dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    // open database connection
                    _dbConn.Open();
                    salesOrder.Id = (int)cmd.ExecuteScalar();
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

        public bool DeleteSalesOrder(int salesOrderId)
        {
            string query = "DELETE FROM SalesOrder WHERE SalesOrder.Id=@Id ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@Id", salesOrderId));

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

        public bool DeleteSalesOrdersByOrderStatus(int orderStatusId)
        {
            string query = "DELETE FROM SalesOrder WHERE OrderStatusId=@Id ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@Id", orderStatusId));

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

        public bool DeleteSalesOrdersByStore(int storeId)
        {
            string query = "DELETE FROM SalesOrder WHERE StoreId=@Id ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@Id", storeId));

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

        public SalesOrder GetSalesOrder(int salesOrderId)
        {
            SalesOrder salesOrder = null;

            string query = "SELECT [OrderStatusId],[OrderDate],[StoreId] FROM SalesOrder WHERE Id = @Id";
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
                int i = 0;
                while (reader.Read())
                {
                    salesOrder = new SalesOrder()
                    {
                        Id = salesOrderId,
                        OrderStatusId = reader.GetInt32(0),
                        OrderDate = reader.GetDateTime(1),
                        StoreId = reader.GetInt32(2)
                    };
                    i++;
                }
                reader.Close();
                if (i != 1) return null;
            }
            return salesOrder;
        }

        public ICollection<SalesOrder> GetSalesOrders()
        {
            var salesOrders = new List<SalesOrder>();

            string query = "SELECT [OrderStatusId],[OrderDate],[StoreId],[Id] FROM SalesOrder ";
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
                    var salesOrder = new SalesOrder()
                    {
                        OrderStatusId = reader.GetInt32(0),
                        OrderDate = reader.GetDateTime(1),
                        StoreId = reader.GetInt32(2),
                        Id = reader.GetInt32(3)
                    };
                    salesOrders.Add(salesOrder);
                }
                reader.Close();
            }
            return salesOrders;
        }

        public ICollection<SalesOrder> GetSalesOrdersFromOrderStatus(int orderStatusId)
        {
            var salesOrders = new List<SalesOrder>();

            string query = "SELECT [OrderStatusId],[OrderDate],[StoreId],[Id] FROM SalesOrder WHERE OrderStatusId=@Id ";
            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@Id", orderStatusId));

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
                    var salesOrder = new SalesOrder()
                    {
                        OrderStatusId = reader.GetInt32(0),
                        OrderDate = reader.GetDateTime(1),
                        StoreId = reader.GetInt32(2),
                        Id = reader.GetInt32(3)
                    };
                    salesOrders.Add(salesOrder);
                }
                reader.Close();
            }
            return salesOrders;
        }

        public ICollection<SalesOrder> GetSalesOrdersFromProduct(int productId)
        {
            var salesOrders = new List<SalesOrder>();

            string query = "SELECT [OrderStatusId],[OrderDate],[StoreId],[Id] FROM SalesOrder " +
                "INNER JOIN OrderLine ON OrderLine.SalesOrderId=Id " +
                "WHERE OrderLine.ProductId=@Id ";
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
                while (reader.Read())
                {
                    var salesOrder = new SalesOrder()
                    {
                        OrderStatusId = reader.GetInt32(0),
                        OrderDate = reader.GetDateTime(1),
                        StoreId = reader.GetInt32(2),
                        Id = reader.GetInt32(3)
                    };
                    salesOrders.Add(salesOrder);
                }
                reader.Close();
            }
            return salesOrders;
        }

        public ICollection<SalesOrder> GetSalesOrdersFromStore(int storeId)
        {
            var salesOrders = new List<SalesOrder>();

            string query = "SELECT [OrderStatusId],[OrderDate],[StoreId],[Id] FROM SalesOrder " +
                "WHERE StoreIdd=@Id ";
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
                    var salesOrder = new SalesOrder()
                    {
                        OrderStatusId = reader.GetInt32(0),
                        OrderDate = reader.GetDateTime(1),
                        StoreId = reader.GetInt32(2),
                        Id = reader.GetInt32(3)
                    };
                    salesOrders.Add(salesOrder);
                }
                reader.Close();
            }
            return salesOrders;
        }

        public bool SalesOrderExists(int salesOrderId)
        {
            bool result = false;

            string query = "SELECT COUNT(1) FROM SalesOrder WHERE SalesOrder.Id=@Id ";
            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.AddWithValue("@Id", salesOrderId);

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

        public bool UpdateSalesOrder(SalesOrder salesOrder)
        {
            string query = "UPDATE [dbo].[SalesOrder] SET " +
                "[OrderStatusId] = @OrderStatusId" +
                ",[OrderDate] = @OrderDate" +
                ",[StoreId] = @StoreId " +
                "WHERE Id=@Id ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@OrderStatusId", salesOrder.OrderStatusId));
            cmd.Parameters.Add(new SqlParameter("@OrderDate", salesOrder.OrderDate));
            cmd.Parameters.Add(new SqlParameter("@StoreId", salesOrder.StoreId));
            cmd.Parameters.Add(new SqlParameter("@Id", salesOrder.Id));

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
