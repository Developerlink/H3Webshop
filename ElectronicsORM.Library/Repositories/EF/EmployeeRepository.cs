using ElectronicsModel.Library.Dtos;
using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsORM.Library.Repositories.EF
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ElectronicsDbContext _electronicsDbContext;

        public EmployeeRepository(ElectronicsDbContext electronicsDbContext)
        {
            _electronicsDbContext = electronicsDbContext;
        }

        public bool CreateEmployee(Employee employee)
        {
            _electronicsDbContext.Add(employee);
            return Save();
        }

        public bool DeleteEmployee(int employeeId)
        {
            var employeeToDelete = _electronicsDbContext.Employee.Find(employeeId);
            _electronicsDbContext.Remove(employeeToDelete);
            return Save();
        }

        public bool DeleteEmployeesByDepartment(int departmentId)
        {
            var employeesToDelete = _electronicsDbContext.Employee.Where(e => e.DepartmentId == departmentId);
            _electronicsDbContext.RemoveRange(employeesToDelete);
            return Save();
        }

        public bool DeleteEmployeesByPostalCode(int postalCodeId)
        {
            var employeesToDelete = _electronicsDbContext.Employee.Where(e => e.PostalCodeId == postalCodeId);
            _electronicsDbContext.RemoveRange(employeesToDelete);
            return Save();
        }

        public bool EmployeeExists(int employeeId)
        {
            return _electronicsDbContext.Employee.Any(e=> e.Id == employeeId);
        }

        public Employee GetEmployee(int employeeId)
        {
            var employee = _electronicsDbContext.Employee.Find(employeeId);
            return employee;
        }

        public ICollection<Employee> GetEmployees()
        {
            var employees = _electronicsDbContext.Employee.OrderByDescending(e => e.Id).ToList();
            return employees;
        }

        public ICollection<Employee> GetEmployeesFromDepartment(int departmentId)
        {
            var employees = _electronicsDbContext.Employee.Where(e => e.DepartmentId == departmentId).OrderBy(e => e.FirstName).OrderBy(e => e.LastName).ToList();
            return employees;
        }

        public ICollection<Employee> GetEmployeesFromPostalCode(int postalCodeID)
        {
            var employees = _electronicsDbContext.Employee.Where(e => e.PostalCodeId == postalCodeID).OrderBy(e => e.FirstName).OrderBy(e => e.LastName).ToList();
            return employees;
        }

        public bool UpdateEmployee(Employee employee)
        {
            _electronicsDbContext.Update(employee);
            return Save();
        }

        public bool Save()
        {
            var rowsChanged = _electronicsDbContext.SaveChanges();
            return rowsChanged >= 0;
        }
    }
}
