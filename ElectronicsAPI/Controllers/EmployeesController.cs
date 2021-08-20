using ElectronicsModel.Library.Dtos;
using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IPostalCodeRepository _postalCodeRepository;

        public EmployeesController(IEmployeeRepository EmployeeRepository, IPostalCodeRepository postalCodeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
            _postalCodeRepository = postalCodeRepository;
        }

        // GET: <EmployeesController>
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDto>> GetEmployees()
        {
            var employees = _EmployeeRepository.GetEmployees();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeDtos = new List<EmployeeDto>();
            foreach (var employee in employees)
            {
                var EmployeeDto = new EmployeeDto(employee);
                employeeDtos.Add(EmployeeDto);
            }

            return Ok(employeeDtos);
        }

        // GET <EmployeesController>/5
        [HttpGet("{id}")]
        public ActionResult<EmployeeDto> GetEmployee(int id)
        {
            if (!_EmployeeRepository.EmployeeExists(id))
            {
                return NotFound();
            }

            var employee = _EmployeeRepository.GetEmployee(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeDto = new EmployeeDto(employee);

            return Ok(employeeDto);
        }

        // POST <EmployeesController>
        [HttpPost]
        public ActionResult PostEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest(ModelState);
            }

            if (!_postalCodeRepository.PostalCodeExists(employee.PostalCodeId))
            {
                return NotFound("Postal Code was not found!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_EmployeeRepository.CreateEmployee(employee))
            {
                ModelState.AddModelError("", $"Something went wrong saving the Employee");
                return StatusCode(500, ModelState);
            }

            var employeeDto = new EmployeeDto(employee);

            return CreatedAtAction("GetEmployee", new { id = employeeDto.Id }, employeeDto);
        }

        // PUT <EmployeesController>/5
        [HttpPut("{employeeId}")]
        public IActionResult UpdateEmployee(int employeeId, [FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest(ModelState);
            }

            if (employeeId != employee.Id)
            {
                ModelState.AddModelError("", $"The URL EmployeeId '{employeeId}' does not match the Employeeobjects Id '{employee.Id}'");
                return BadRequest(ModelState);
            }

            if (!_EmployeeRepository.EmployeeExists(employee.Id))
            {
                ModelState.AddModelError("", "Employee does not exist!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_EmployeeRepository.UpdateEmployee(employee))
            {
                ModelState.AddModelError("", $"Something went wrong updating Employee {employee.FirstName} {employee.LastName}");
                return StatusCode(500, ModelState);
            }

            // Usually nothing is returned when updating. 
            return NoContent();
        }

        // DELETE <EmployeesController>/5
        [HttpDelete("{employeeId}")]
        public IActionResult DeleteEmployee(int employeeId)
        {
            if (!_EmployeeRepository.EmployeeExists(employeeId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_EmployeeRepository.DeleteEmployee(employeeId))
            {
                ModelState.AddModelError("", $"Something went wrong deleting Employee with Id { employeeId }");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}

