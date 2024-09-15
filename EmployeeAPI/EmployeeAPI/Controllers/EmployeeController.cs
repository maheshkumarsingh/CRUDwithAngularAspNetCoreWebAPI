using EmployeeAPI.Data;
using EmployeeAPI.Models.Domain;
using EmployeeAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeRequestDTO employee)
        {
            Employee employeeModel = null;
            if (employee!=null)
            {
                employeeModel = new Employee
                {
                    EmployeeName = employee.EmployeeName,
                    DateOfBirth = employee.DateOfBirth,
                    Gender = employee.Gender,
                    Department = employee.Department,
                    Designation = employee.Designation,
                    BasicSalary = employee.BasicSalary
                };
                await _context.Employees.AddAsync(employeeModel);
                await _context.SaveChangesAsync();
            }
                return Ok(employeeModel);
        }
        //[HttpPut]

        //public async Task<IActionResult> UpdateEmployee(AddEmployeeRequestDTO employee)
        //{
        //    var employeeModel = await _context.Employees.FindAsync(employee.EmployeeCode);
        //    if (employeeModel is not null)
        //    {
        //        employeeModel.EmployeeName = employee.EmployeeName;
        //        employeeModel.DateOfBirth = employee.DateOfBirth;
        //    }
        //}
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if(employee is not null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

    }
}
