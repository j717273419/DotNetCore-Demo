using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_005_employee_api.Services.Models;

namespace WebApplication_005_employee_api.Services.IServices
{
    public interface IEmployee
    {
        public Employee Add(Employee employee);
        public bool Delete(string EmployeeNo);
        public IEnumerable<Employee> All();
    }
}
