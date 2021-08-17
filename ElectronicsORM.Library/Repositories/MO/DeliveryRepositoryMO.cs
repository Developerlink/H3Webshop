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
            string query = "INSERT INTO [dbo].[Delivery] ([SalesOrderId],[PostalCodeId],[Address],[SendDate],[CustomerId]) " +
                "VALUES (@SalesOrderId,@PostalCodeId,@Address,@SendDate,@CustomerId) ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@SalesOrderId", delivery.SalesOrderId));
            cmd.Parameters.Add(new SqlParameter("@PostalCodeId", delivery.PostalCodeId));
            cmd.Parameters.Add(new SqlParameter("@Address", delivery.Address));
            cmd.Parameters.Add(new SqlParameter("@SendDate", delivery.SendDate));
            cmd.Parameters.Add(new SqlParameter("@CustomerId", delivery.CustomerId));

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

        public bool DeleteDeliveriesByCustomer(int customerId)
        {
            string query = "DELETE FROM Delivery WHERE CustomerId=@Id ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@Id", customerId));

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

        public bool DeleteDeliveriesByPostalCode(int postalCodeId)
        {
            string query = "DELETE FROM Delivery WHERE PostalCodeId=@Id ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@Id", postalCodeId));

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

        public bool DeleteDeliveryBySalesOrder(int salesOrderId)
        {
            string query = "DELETE FROM Delivery WHERE SalesOrderId=@Id ";

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

        public bool DeliveryExists(int salesOrderId)
        {
            bool result = false;

            string query = "SELECT COUNT(1) FROM Delivery WHERE Delivery.SalesOrderId=@salesOrderId ";
            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@salesOrderId", salesOrderId));

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

        public ICollection<Delivery> GetDeliveries()
        {
            var deliveries = new List<Delivery>();

            string query = "SELECT [SalesOrderId],[PostalCodeId],[Address],[SendDate],[CustomerId] FROM[dbo].[Delivery]";
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
                    var delivery = new Delivery()
                    {
                        SalesOrderId = reader.GetInt32(0),
                        PostalCodeId = reader.GetInt32(1),
                        Address = reader.GetString(2),
                        SendDate = reader.GetDateTime(3),
                        CustomerId = reader.GetInt32(4)
                    };
                    deliveries.Add(delivery);
                }
                reader.Close();
            }
            _dbConn.Close();

            return deliveries;
        }

        public ICollection<Delivery> GetDeliveriesFromCustomer(int customerId)
        {
            var deliveries = new List<Delivery>();

            string query = "SELECT [SalesOrderId],[PostalCodeId],[Address],[SendDate],[CustomerId] FROM[dbo].[Delivery] WHERE [CustomerId]=@Id ";
            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@Id", customerId));

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
                    var delivery = new Delivery()
                    {
                        SalesOrderId = reader.GetInt32(0),
                        PostalCodeId = reader.GetInt32(1),
                        Address = reader.GetString(2),
                        SendDate = reader.GetDateTime(3),
                        CustomerId = reader.GetInt32(4)
                    };
                    deliveries.Add(delivery);
                }
                reader.Close();
            }
            _dbConn.Close();

            return deliveries;
        }

        public ICollection<Delivery> GetDeliveriesFromPostalCode(int postalCodeId)
        {
            var deliveries = new List<Delivery>();

            string query = "SELECT [SalesOrderId],[PostalCodeId],[Address],[SendDate],[CustomerId] FROM[dbo].[Delivery] WHERE [PostalCodeId]=@Id ";
            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@Id", postalCodeId));

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
                    var delivery = new Delivery()
                    {
                        SalesOrderId = reader.GetInt32(0),
                        PostalCodeId = reader.GetInt32(1),
                        Address = reader.GetString(2),
                        SendDate = reader.GetDateTime(3),
                        CustomerId = reader.GetInt32(4)
                    };
                    deliveries.Add(delivery);
                }
                reader.Close();
            }
            _dbConn.Close();

            return deliveries;
        }

        public Delivery GetDeliveryFromSalesOrder(int salesOrderId)
        {
            Delivery delivery = null;

            string query = "SELECT [SalesOrderId],[PostalCodeId],[Address],[SendDate],[CustomerId] FROM[dbo].[Delivery] WHERE [SalesOrderId]=@Id ";
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
                    delivery = new Delivery()
                    {
                        SalesOrderId = salesOrderId,
                        PostalCodeId = reader.GetInt32(1),
                        Address = reader.GetString(2),
                        SendDate = reader.GetDateTime(3),
                        CustomerId = reader.GetInt32(4)
                    };
                }
                reader.Close();
            }
            _dbConn.Close();

            return delivery;
        }

        public bool UpdateDelivery(Delivery delivery)
        {
            string query = "UPDATE [dbo].[Delivery] SET " +
                ",[PostalCodeId] = @PostalCodeId" +
                ",[Address] = $Address" +
                ",[SendDate] = @SendDate" +
                ",[CustomerId] = @CustomerId" +
                "WHERE SalesOrderId=@SalesOrderId ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@PostalCodeId", delivery.PostalCodeId));
            cmd.Parameters.Add(new SqlParameter("@Address", delivery.Address));
            cmd.Parameters.Add(new SqlParameter("@SendDate", delivery.SendDate));
            cmd.Parameters.Add(new SqlParameter("@CustomerId", delivery.CustomerId));
            cmd.Parameters.Add(new SqlParameter("@SalesOrderId", delivery.SalesOrderId));

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
