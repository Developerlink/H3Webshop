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
    public class DeliveryRepositoryMO : IDeliveryRepository
    {
        readonly SqlConnection _dbConn;

        public DeliveryRepositoryMO()
        {
            _dbConn = new SqlConnection(MsSql.GetConnectionString());
        }

        public bool CreateDelivery(Delivery delivery)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDeliveriesByCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDeliveriesByPostalCode(int postalCodeId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDeliveryBySalesOrder(int salesOrderId)
        {
            throw new NotImplementedException();
        }

        public bool DeliveryExists(int salesOrderId, int customerId, int postalCodeId)
        {
            bool result = false;

            string query = "SELECT COUNT(1) FROM Delivery WHERE Delivery.SalesOrderId=@salesOrderId AND Delivery.CustomerId=@customerId AND Delivery.PostalCodeId=@postalCodeId ";
            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.AddWithValue("@salesOrderId", salesOrderId);
            cmd.Parameters.AddWithValue("@customerId", customerId);
            cmd.Parameters.AddWithValue("@ostalCodeId", postalCodeId);

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

        public ICollection<Delivery> GetDeliveries()
        {
            throw new NotImplementedException();
        }

        public ICollection<Delivery> GetDeliveriesFromCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Delivery> GetDeliveriesFromPostalCode(int postalCodeId)
        {
            throw new NotImplementedException();
        }

        public Delivery GetDeliveryFromSalesOrder(int salesOrderId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateDelivery(Delivery delivery)
        {
            throw new NotImplementedException();
        }
    }
}
