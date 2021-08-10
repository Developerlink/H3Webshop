using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ElectronicsORM.Library.DataAccess;

namespace ElectronicsORM.Library.Repositories.MO
{
    public class CustomerRepositoryMO : ICustomerRepository
    {
        readonly SqlConnection _dbConn;

        public CustomerRepositoryMO()
        {
            _dbConn = new SqlConnection(MsSql.GetConnectionString());
        }

        public bool CreateCustomer(Customer customer)
        {
            string query = "INSERT INTO [dbo].[Customer] ([PostalCodeId], [FirstName], [LastName], [EmailAddress], [PhoneNumber], [Address]) " +
                "OUTPUT INSERTED.ID " +
                "VALUES (@PostalCodeId, @FirstName, @LastName, @EmailAddress, @PhoneNumber, @Address) ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.AddWithValue("@PostalCodeId", customer.PostalCodeId);
            cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", customer.LastName);
            cmd.Parameters.AddWithValue("@EmailAddress", customer.EmailAddress);
            cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
            cmd.Parameters.AddWithValue("@Address", customer.Address);

            if (_dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    // open database connection
                    _dbConn.Open();
                    customer.Id = (int)cmd.ExecuteScalar();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return false;
        }

        public bool CustomerExists(int customerId)
        {
            bool result = false;

            string query = "SELECT COUNT(1) FROM Customer WHERE Customer.Id=@Id ";
            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.AddWithValue("@Id", customerId);

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
                reader.Close();

                if (count == 1)
                {
                    result = true;
                }
            }
            return result;
        }

        public bool DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomersByPostalCode(int postalCodeID)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int customerId)
        {
            Customer customer = null;

            string query = "SELECT PostalCodeId, FirstName, LastName, EmailAddress, PhoneNumber, Address FROM Customer WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.AddWithValue("@Id", customerId);

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
                    customer = new Customer()
                    {
                        Id = customerId,
                        PostalCodeId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        EmailAddress = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        Address = reader.GetString(5)
                    };
                    i++;
                }
                reader.Close();
                if (i != 1) return null;
            }

            return customer;
        }

        public Customer GetCustomerFromSalesOrder(int salesOrderId)
        {
            Customer customer = null;

            string query = "SELECT Customer.PostalCodeId, FirstName, LastName, EmailAddress, PhoneNumber, Customer.Address, Customer.Id " +
                "FROM Customer INNER JOIN Delivery ON Delivery.CustomerId = Customer.Id " +
                "INNER JOIN SalesOrder On SalesOrder.Id = Delivery.SalesOrderId " +
                "WHERE SalesOrder.Id = @Id";


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
                int i = 0;
                while (reader.Read())
                {
                    customer = new Customer()
                    {
                        PostalCodeId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        EmailAddress = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        Address = reader.GetString(5),
                        Id = reader.GetInt32(6)
                    };
                    i++;
                }
                reader.Close();

                if (i != 1) return null;
            }
            return customer;
        }

        public ICollection<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public ICollection<Customer> GetCustomersFromPostalCode(int postalCodeId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
