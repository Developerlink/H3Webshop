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
        public bool CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool CustomerExists(int customerId)
        {
            throw new NotImplementedException();
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
            SqlConnection dbConn = MsSql.GetSqlConnection();

            string query = "SELECT PostalCodeId, FirstName, LastName, EmailAddress, PhoneNumber, Address FROM Customer WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.AddWithValue("@Id", customerId);

            if (dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    // open database connection
                    dbConn.Open();
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
                if (i != 1) return null;
            }

            return customer;
        }

        public Customer GetCustomerFromDelivery(int deliveryId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerFromSalesOrderDelivery(int salesOrderId)
        {
            throw new NotImplementedException();
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
