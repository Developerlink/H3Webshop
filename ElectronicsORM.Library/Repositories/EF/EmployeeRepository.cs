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
        public bool CreateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool CreateOrderLine(OrderLine orderLine)
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

        public bool DeleteOrderLine(int salesOrderId, int productId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrderLinesByProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrderLinesBySalesOrder(int salesOrderId)
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

        public OrderLine GetOrderLine(int salesOrderId, int productId)
        {
            throw new NotImplementedException();
        }

        public ICollection<OrderLine> GetOrderLines()
        {
            throw new NotImplementedException();
        }

        public ICollection<OrderLine> GetOrderLinesFromProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public ICollection<OrderLine> GetOrderLinesFromSalesOrder(int salesOrderId)
        {
            throw new NotImplementedException();
        }

        public bool OrderLineExists(int salesOrderId, int productId)
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

        public bool UpdateOrderLine(OrderLine orderLine)
        {
            throw new NotImplementedException();
        }
    }
}
