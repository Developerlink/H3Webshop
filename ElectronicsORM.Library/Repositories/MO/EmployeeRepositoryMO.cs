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
    public class EmployeeRepositoryMO : IEmployeeRepository
    {
        readonly SqlConnection _dbConn;

        public EmployeeRepositoryMO()
        {
            _dbConn = new SqlConnection(MsSql.GetConnectionString());
        }

        public bool CreateEmployee(Employee employee)
        {
            string query = "INSERT INTO [dbo].[Employee] ([PostalCodeId],[FirstName],[LastName],[EmailAddress],[PhoneNumber],[WorkStartDate],[WorkEndDate],[IsActive],[Address],[DepartmentId]) " +
                "OUTPUT INSERTED.ID " +
                "VALUES (@PostalCodeId, @FirstName, @LastName, @EmailAddress, @PhoneNumber, @WorkStartDate, @WorkEndDate, @IsActive, @Address, @DepartmentId) ";
            
            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@PostalCodeId", employee.PostalCodeId));
            cmd.Parameters.Add(new SqlParameter("@FirstName", employee.FirstName));
            cmd.Parameters.Add(new SqlParameter("@LastName", employee.LastName));
            cmd.Parameters.Add(new SqlParameter("@EmailAddress", employee.EmailAddress));
            cmd.Parameters.Add(new SqlParameter("@PhoneNumber", employee.PhoneNumber));
            cmd.Parameters.Add(new SqlParameter("@WorkStartDate", employee.WorkStartDate));
            cmd.Parameters.Add(new SqlParameter("@WorkEndDate", employee.WorkEndDate));
            cmd.Parameters.Add(new SqlParameter("@IsActive", employee.IsActive));
            cmd.Parameters.Add(new SqlParameter("@Address", employee.Address));
            cmd.Parameters.Add(new SqlParameter("@DepartmentId", employee.DepartmentId));

            if (_dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    // open database connection
                    _dbConn.Open();
                    employee.Id = (int)cmd.ExecuteScalar();
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

        public bool DeleteEmployee(int employeeId)
        {
            string query = "DELETE FROM Employee WHERE Employee.Id=@Id ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@Id", employeeId));

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

        public bool DeleteEmployeesByDepartment(int departmentId)
        {
            string query = "DELETE FROM Employee WHERE DepartmentId=@Id ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@Id", departmentId));

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

        public bool DeleteEmployeesByPostalCode(int postalCodeId)
        {
            string query = "DELETE FROM Employee WHERE PostalCodeId=@Id ";

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

        public bool EmployeeExists(int employeeId)
        {
            bool result = false;

            string query = "SELECT COUNT(1) FROM Employee WHERE Employee.Id=@Id ";
            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.AddWithValue("@Id", employeeId);

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

        public Employee GetEmployee(int employeeId)
        {
            Employee employee = null;

            string query = "SELECT [PostalCodeId],[FirstName],[LastName],[EmailAddress],[PhoneNumber],[WorkStartDate],[WorkEndDate],[IsActive],[Address],[DepartmentId]" +
                "FROM[dbo].[Employee] " +
                "WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@Id", employeeId));

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
                    employee = new Employee()
                    {
                        Id = employeeId,
                        PostalCodeId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        EmailAddress = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        WorkStartDate = reader.GetDateTime(5),
                        WorkEndDate = reader.GetDateTime(6),
                        IsActive = reader.GetBoolean(7),
                        Address = reader.GetString(8),
                        DepartmentId = reader.GetInt32(9)
                    };
                    i++;
                }
                reader.Close();
                if (i != 1) return null;
            }
            return employee;
        }

        public ICollection<Employee> GetEmployees()
        {
            var employees = new List<Employee>();

            string query = "SELECT [PostalCodeId],[FirstName],[LastName],[EmailAddress],[PhoneNumber],[WorkStartDate],[WorkEndDate],[IsActive],[Address],[DepartmentId],[Id]" +
                "FROM[dbo].[Employee] ";

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
                    var employee = new Employee()
                    {
                        PostalCodeId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        EmailAddress = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        WorkStartDate = reader.GetDateTime(5),
                        WorkEndDate = reader.GetDateTime(6),
                        IsActive = reader.GetBoolean(7),
                        Address = reader.GetString(8),
                        DepartmentId = reader.GetInt32(9),
                        Id = reader.GetInt32(10)
                    };
                    employees.Add(employee);
                }
                reader.Close();
            }
            return employees;
        }

        public ICollection<Employee> GetEmployeesFromDepartment(int departmentId)
        {
            var employees = new List<Employee>();

            string query = "SELECT [PostalCodeId],[FirstName],[LastName],[EmailAddress],[PhoneNumber],[WorkStartDate],[WorkEndDate],[IsActive],[Address],[DepartmentId],[Id]" +
                "FROM[dbo].[Employee] " +
                "WHERE DepartmentId=@Id ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("Id", departmentId));

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
                    var employee = new Employee()
                    {
                        PostalCodeId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        EmailAddress = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        WorkStartDate = reader.GetDateTime(5),
                        WorkEndDate = reader.GetDateTime(6),
                        IsActive = reader.GetBoolean(7),
                        Address = reader.GetString(8),
                        DepartmentId = reader.GetInt32(9),
                        Id = reader.GetInt32(10)
                    };
                    employees.Add(employee);
                }
                reader.Close();
            }
            return employees;
        }

        public ICollection<Employee> GetEmployeesFromPostalCode(int postalCodeID)
        {
            var employees = new List<Employee>();

            string query = "SELECT [PostalCodeId],[FirstName],[LastName],[EmailAddress],[PhoneNumber],[WorkStartDate],[WorkEndDate],[IsActive],[Address],[DepartmentId],[Id]" +
                "FROM[dbo].[Employee] " +
                "WHERE PostalCodeId=@Id ";

            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("Id", postalCodeID));

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
                    var employee = new Employee()
                    {
                        PostalCodeId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        EmailAddress = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        WorkStartDate = reader.GetDateTime(5),
                        WorkEndDate = reader.GetDateTime(6),
                        IsActive = reader.GetBoolean(7),
                        Address = reader.GetString(8),
                        DepartmentId = reader.GetInt32(9),
                        Id = reader.GetInt32(10)
                    };
                    employees.Add(employee);
                }
                reader.Close();
            }
            return employees;
        }
        

        public bool UpdateEmployee(Employee employee)
        {
            string query = "UPDATE Customer SET " +
                "[PostalCodeId] = @PostalCodeId, " +
                "[FirstName] = @FirstName, " +
                ",[LastName] = @LastName, " +
                ",[EmailAddress] = @EmailAddress, " +
                ",[PhoneNumber] = @PhoneNumber, " +
                ",[WorkStartDate] = @WorkStartDate, " +
                ",[WorkEndDate] = @WorkEndDate, " +
                ",[IsActive] = @IsActive, " +
                ",[Address] = @Address, " +
                ",[DepartmentId] = @DepartmentId, " +
                "WHERE Id=@Id";

             SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@PostalCodeId", employee.PostalCodeId));
            cmd.Parameters.Add(new SqlParameter("@FirstName", employee.FirstName));
            cmd.Parameters.Add(new SqlParameter("@LastName", employee.LastName));
            cmd.Parameters.Add(new SqlParameter("@EmailAddress", employee.EmailAddress));
            cmd.Parameters.Add(new SqlParameter("@PhoneNumber", employee.PhoneNumber));
            cmd.Parameters.Add(new SqlParameter("@WorkStartDate", employee.WorkStartDate));
            cmd.Parameters.Add(new SqlParameter("@WorkEndDate", employee.WorkEndDate));
            cmd.Parameters.Add(new SqlParameter("@IsActive", employee.IsActive));
            cmd.Parameters.Add(new SqlParameter("@Address", employee.Address));
            cmd.Parameters.Add(new SqlParameter("@DepartmentId", employee.DepartmentId));
            cmd.Parameters.Add(new SqlParameter("@Id", employee.Id));

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
