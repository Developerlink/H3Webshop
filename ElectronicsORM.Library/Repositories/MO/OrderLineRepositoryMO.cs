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
            throw new NotImplementedException();
        }

        public bool DeleteOrderLine(int salesOrderId, int productId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrderLinesByProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrderLinesBySalesOrder(int salesOrderId)
        {
            throw new NotImplementedException();
        }

        public OrderLine GetOrderLine(int salesOrderId, int productId)
        {
            throw new NotImplementedException();
        }

        public ICollection<OrderLine> GetOrderLines()
        {
            throw new NotImplementedException();
        }

        public ICollection<OrderLine> GetOrderLinesFromProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public ICollection<OrderLine> GetOrderLinesFromSalesOrder(int salesOrderId)
        {
            throw new NotImplementedException();
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

        public bool UpdateOrderLine(OrderLine orderLine)
        {
            throw new NotImplementedException();
        }
    }
}
