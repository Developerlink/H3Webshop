using ElectronicsModel.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsModel.Library.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int PostalCodeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? WorkStartDate { get; set; }
        public DateTime? WorkEndDate { get; set; }
        public bool IsActive { get; set; }
        public string Address { get; set; }

        public EmployeeDto(Employee employee)
        {
            Id = employee.Id;
            DepartmentId = employee.DepartmentId;
            PostalCodeId = employee.PostalCodeId;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            EmailAddress = employee.EmailAddress;
            PhoneNumber = employee.PhoneNumber;
            WorkStartDate = employee.WorkStartDate;
            WorkEndDate = employee.WorkEndDate;
            IsActive = employee.IsActive;
            Address = employee.Address;
        }

        public EmployeeDto()
        {

        }
    }

}
