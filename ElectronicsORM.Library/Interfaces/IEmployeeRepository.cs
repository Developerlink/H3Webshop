using ElectronicsModel.Library.Dtos;
using ElectronicsModel.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsORM.Library.Interfaces
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetEmployees();
        ICollection<Employee> GetEmployeesFromDepartment(int departmentId);
        ICollection<Employee> GetEmployeesFromPostalCode(int postalCodeId);
        Employee GetEmployee(int employeeId);
        bool EmployeeExists(int employeeId);


        bool CreateEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int employeeId);
        bool DeleteEmployeesByDepartment(int departmentId);
        bool DeleteEmployeesByPostalCode(int postalCodeId);
    }
}
