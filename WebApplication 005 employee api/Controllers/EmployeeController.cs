using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_005_employee_api.Services.IServices;
using WebApplication_005_employee_api.Services.Models;

namespace WebApplication_005_employee_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee Employee;
        public EmployeeController(IEmployee employee)
        {
            Employee = employee;
        }

        [HttpGet]
        public IEnumerable<Employee> All()
        {
            return Employee.All();
        }

        [HttpPost]
        public Employee Add(Employee employee)
        {
            return Employee.Add(employee);
        }

        [HttpDelete]
        public bool Delete(string employeeNo)
        {
            return Employee.Delete(employeeNo);
        }
    }
}
