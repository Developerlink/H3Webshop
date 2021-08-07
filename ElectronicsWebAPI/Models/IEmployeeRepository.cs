using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsWebAPI.Models
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetEmployees();
        bool EmployeeExists(int employeeId);
        Employee GetEmployee(int employeeId);
        ICollection<Employee> GetEmployeesFromDepartment(int departmentId);
        ICollection<Employee> GetEmployeesFromPostalCode(int postalCodeID);


        bool CreateEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int employeeId);
        bool Save();
    }
}
