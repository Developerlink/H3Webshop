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
    public class OrderLineRepositoryMO : IOrderLineRepository
    {
        private readonly SqlConnection _dbConn;

        public OrderLineRepositoryMO()
        {
            _dbConn = new SqlConnection(MsSql.GetConnectionString());
        }

        public bool CreateOrderLine(OrderLine orderLine)
        {
            string query = "INSERT INTO [dbo].[OrderLine] ([SalesOrderId],[ProductId],[Price],[Quantity]) " +
            "VALUES (@SalesOrderId, @ProductId, @Price, @Quantity) ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@SalesOrderId", orderLine.SalesOrderId));
            cmd.Parameters.Add(new SqlParameter("@ProductId", orderLine.ProductId));
            cmd.Parameters.Add(new SqlParameter("@Price", orderLine.Price));
            cmd.Parameters.Add(new SqlParameter("@Quantity", orderLine.Quantity));

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

        public bool DeleteOrderLine(int salesOrderId, int productId)
        {
            string query = "DELETE FROM OrderLine WHERE SalesOrderId=@SalesOrderId AND ProductId=@ProductId ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@SalesOrderId", salesOrderId));
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

        public bool DeleteOrderLinesByProduct(int productId)
        {
            string query = "DELETE FROM OrderLine WHERE ProductId=@ProductId ";

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

        public bool DeleteOrderLinesBySalesOrder(int salesOrderId)
        {
            string query = "DELETE FROM OrderLine WHERE SalesOrderId=@SalesOrderId ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@SalesOrderId", salesOrderId));

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

        public OrderLine GetOrderLine(int salesOrderId, int productId)
        {
            OrderLine orderLine = null;

            string query = "SELECT [SalesOrderId],[ProductId],[Price],[Quantity] FROM[dbo].[OrderLine] WHERE SalesOrderId=@SalesOrderId AND ProductId=@ProductId ";
            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@SalesOrderId", salesOrderId));
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
                    orderLine = new OrderLine()
                    {
                        SalesOrderId = salesOrderId,
                        ProductId = productId,
                        Price = reader.GetDecimal(2),
                        Quantity = reader.GetInt16(3)
                    };
                }
                reader.Close();
            }
            _dbConn.Close();

            return orderLine;
        }

        public ICollection<OrderLine> GetOrderLines()
        {
            var orderLines = new List<OrderLine>();

            string query = "SELECT [SalesOrderId],[ProductId],[Price],[Quantity] FROM[dbo].[OrderLine] ";
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
                    var orderLine = new OrderLine()
                    {
                        SalesOrderId = reader.GetInt32(0),
                        ProductId = reader.GetInt32(1),
                        Price = reader.GetDecimal(2),
                        Quantity = reader.GetInt16(3)
                    };
                    orderLines.Add(orderLine);
                }
                reader.Close();
            }
            _dbConn.Close();

            return orderLines;
        }

        public ICollection<OrderLine> GetOrderLinesFromProduct(int productId)
        {
            var orderLines = new List<OrderLine>();

            string query = "SELECT [SalesOrderId],[ProductId],[Price],[Quantity] FROM[dbo].[OrderLine] WHERE ProductId=@ProductId ";
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
                    var orderLine = new OrderLine()
                    {
                        SalesOrderId = reader.GetInt32(0),
                        ProductId = reader.GetInt32(1),
                        Price = reader.GetDecimal(2),
                        Quantity = reader.GetInt16(3)
                    };
                    orderLines.Add(orderLine);
                }
                reader.Close();
            }
            _dbConn.Close();

            return orderLines;
        }

        public ICollection<OrderLine> GetOrderLinesFromSalesOrder(int salesOrderId)
        {
            var orderLines = new List<OrderLine>();

            string query = "SELECT [SalesOrderId],[ProductId],[Price],[Quantity] FROM[dbo].[OrderLine] WHERE SalesOrderId=@SalesOrderId ";
            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@SalesOrderId", salesOrderId));

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
                    var orderLine = new OrderLine()
                    {
                        SalesOrderId = reader.GetInt32(0),
                        ProductId = reader.GetInt32(1),
                        Price = reader.GetDecimal(2),
                        Quantity = reader.GetInt16(3)
                    };
                    orderLines.Add(orderLine);
                }
                reader.Close();
            }
            _dbConn.Close();

            return orderLines;
        }

        public bool OrderLineExists(int salesOrderId, int productId)
        {
            bool result = false;

            string query = "SELECT COUNT(1) FROM OrderLine WHERE OrderLine.SalesOrderId=@salesOrderId AND OrderLine.ProductId=@productId ";
            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.AddWithValue("@salesOrderId", salesOrderId);
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

                int count = (int)cmd.ExecuteScalar();

                if (count == 1)
                {
                    result = true;
                }
            }
            _dbConn.Close();

            return result;
        }

        public bool UpdateOrderLine(OrderLine orderLine)
        {
            string query = "UPDATE [dbo].[OrderLine]SET" +
                "[Price] = @Price" +
                ",[Quantity] = @Quantity " +
                 "WHERE SalesOrderId=@SalesOrderId AND ProductId=@ProductId ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@SalesOrderId", orderLine.SalesOrderId));
            cmd.Parameters.Add(new SqlParameter("@ProductId", orderLine.ProductId));
            cmd.Parameters.Add(new SqlParameter("@Price", orderLine.Price));
            cmd.Parameters.Add(new SqlParameter("@Quantity", orderLine.Quantity));

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
