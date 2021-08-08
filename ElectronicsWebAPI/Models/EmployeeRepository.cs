using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsWebAPI.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public bool CreateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployeesByDepartment(int departmentId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployeesByPostalCode(int postalCodeId)
        {
            throw new NotImplementedException();
        }

        public bool EmployeeExists(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public ICollection<Employee> GetEmployeesFromDepartment(int departmentId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Employee> GetEmployeesFromPostalCode(int postalCodeID)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
