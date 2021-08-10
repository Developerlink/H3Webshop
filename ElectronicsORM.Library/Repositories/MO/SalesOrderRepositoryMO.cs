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
            throw new NotImplementedException();
        }

        public bool DeleteSalesOrder(int salesOrderId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSalesOrdersByOrderStatus(int orderStatusId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSalesOrdersByStore(int storeId)
        {
            throw new NotImplementedException();
        }

        public SalesOrder GetSalesOrder(int salesOrderId)
        {
            throw new NotImplementedException();
        }

        public SalesOrder GetSalesOrderFromDelivery(int deliveryId)
        {
            throw new NotImplementedException();
        }

        public ICollection<SalesOrder> GetSalesOrders()
        {
            throw new NotImplementedException();
        }

        public ICollection<SalesOrder> GetSalesOrdersFromOrderStatus(int orderStatusId)
        {
            throw new NotImplementedException();
        }

        public ICollection<SalesOrder> GetSalesOrdersFromProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public ICollection<SalesOrder> GetSalesOrdersFromStore(int storeId)
        {
            throw new NotImplementedException();
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

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateSalesOrder(SalesOrder salesOrder)
        {
            throw new NotImplementedException();
        }
    }
}
