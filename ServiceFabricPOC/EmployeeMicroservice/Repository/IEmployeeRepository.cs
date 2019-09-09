using EmployeeMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMicroservice.Repository
{
    public interface IEmployeeRepository
    {

        List<Employee> GetEmployees();

        Employee GetEmployeeById(int Id);

        List<Employee> DeleteEmployeeById(int Id);

        List<Employee> SaveEmployee(Employee employee);

        List<Employee> UpdateEmployee(Employee employee);
    }
}
