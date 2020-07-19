using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebApplication_005_employee_api.Services.IServices;
using WebApplication_005_employee_api.Services.Models;

namespace WebApplication_005_employee_api.Services
{
    public class EmployeeService : IEmployee
    {
        public static IList<Employee> employees;

        public IList<Employee> GetEmployees()
        {
            if (employees != null)
            {
                return employees;
            }
            else
            {
                var list = new List<Employee>();
                var json = JsonSerializer.Serialize(list);
                //HttpContext.se.SetString("employees", json);
                return new List<Employee>();
            }
        }
        public Employee Add(Employee employee)
        {
            employee.EmployeeNo = Guid.NewGuid().ToString();
            GetEmployees().Add(employee);
            return employee;
        }

        public IEnumerable<Employee> All()
        {
            return GetEmployees();
        }

        public bool Delete(string EmployeeNo)
        {
            var list = GetEmployees();
            if (list.Any(p=>p.EmployeeNo == EmployeeNo))
            {
                var employee = list.First(p => p.EmployeeNo == EmployeeNo);
                list.Remove(employee);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
