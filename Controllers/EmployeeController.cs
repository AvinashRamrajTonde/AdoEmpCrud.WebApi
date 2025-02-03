using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoEmpCrud.WebApi.Data;
using AdoEmpCrud.WebApi.Data.Core;
using AdoEmpCrud.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdoEmpCrud.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        [HttpGet]
        public IActionResult GetEmployees()
        {
          
            var employees = _employeeRepository.GetEmployees();

            if (employees == null || employees.Count() == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(employees);
            }

        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {

            if(!ModelState.IsValid){
                return BadRequest("Data is Not Valid");
            }

            var status = _employeeRepository.AddEmployee(employee);

            if (status)
            {
                return Ok("Employee Added");
            }
            else
            {
                return BadRequest("Error..");
            }
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateEmployee(int Id, Employee employee)
        {         
            var status = _employeeRepository.UpdateEmployee(Id, employee);

            if (status)
            {
                return Ok("Employee Updated");
            }
            else
            {
                return BadRequest("Error..");
            }
        }

 

        [HttpDelete("{Id}")]

        public IActionResult DeleteEmployee(int Id)
        {

            var status = _employeeRepository.DeleteEmployee(Id);

            if (status)
            {
                return Ok("Employee Deleted.!");
            }
            else
            {
                return BadRequest("Error..");
            }
        }
    }
}