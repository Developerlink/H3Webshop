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
            cmd.Parameters.Add(new SqlParameter("@PostalCodeId", customer.PostalCodeId));
            cmd.Parameters.Add(new SqlParameter("@FirstName", customer.FirstName));
            cmd.Parameters.Add(new SqlParameter("@LastName", customer.LastName));
            cmd.Parameters.Add(new SqlParameter("@EmailAddress", customer.EmailAddress));
            cmd.Parameters.Add(new SqlParameter("@PhoneNumber", customer.PhoneNumber));
            cmd.Parameters.Add(new SqlParameter("@Address", customer.Address));

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
            _dbConn.Close();

            return false;
        }

        public bool CustomerExists(int customerId)
        {
            bool result = false;

            string query = "SELECT COUNT(1) FROM Customer WHERE Customer.Id=@Id ";
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
            string query = "DELETE FROM Customer WHERE Customer.Id=@Id ";

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

        public bool DeleteCustomersByPostalCode(int postalCodeID)
        {
            string query = "DELETE FROM Customer WHERE Customer.PostalCodeId=@PostalCodeId ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@PostalCodeId", postalCodeID));

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

        public Customer GetCustomer(int customerId)
        {
            Customer customer = null;

            string query = "SELECT PostalCodeId, FirstName, LastName, EmailAddress, PhoneNumber, Address FROM Customer WHERE Id = @Id";
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
            var customers = new List<Customer>();

            string query = "SELECT PostalCodeId, FirstName, LastName, EmailAddress, PhoneNumber, Address, Id FROM Customer ";
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
                    var customer = new Customer()
                    {
                        PostalCodeId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        EmailAddress = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        Address = reader.GetString(5),
                        Id = reader.GetInt32(6)
                    };
                    customers.Add(customer);
                }
                reader.Close();
            }

            return customers;
        }

        public ICollection<Customer> GetCustomersFromPostalCode(int postalCodeId)
        {
            var customers = new List<Customer>();

            string query = "SELECT Id, FirstName, LastName, EmailAddress, PhoneNumber, Address FROM Customer WHERE PostalCodeId=@PostalCodeId ";
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
                    var customer = new Customer()
                    {
                        PostalCodeId = postalCodeId,
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        EmailAddress = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        Address = reader.GetString(5),
                    };
                    customers.Add(customer);
                }
                reader.Close();
            }

            return customers;
        }

        public bool UpdateCustomer(Customer customer)
        {
            string query = "UPDATE Customer SET " +
                "PostalCodeId = @PostalCodeId " +
                ",FirstName = @FirstName " +
                ",LastName = @LastName " +
                ",EmailAddress = @EmailAddress " +
                ",PhoneNumber = @PhoneNumber" +
                ",Address = @Address " +
                "WHERE Id=@Id ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@PostalCodeId", customer.PostalCodeId));
            cmd.Parameters.Add(new SqlParameter("@FirstName", customer.FirstName));
            cmd.Parameters.Add(new SqlParameter("@LastName", customer.LastName));
            cmd.Parameters.Add(new SqlParameter("@EmailAddress", customer.EmailAddress));
            cmd.Parameters.Add(new SqlParameter("@PhoneNumber", customer.PhoneNumber));
            cmd.Parameters.Add(new SqlParameter("@Address", customer.Address));
            cmd.Parameters.Add(new SqlParameter("@Id", customer.Id));

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
