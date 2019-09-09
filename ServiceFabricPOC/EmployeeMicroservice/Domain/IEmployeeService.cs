using EmployeeMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMicroservice.Domain
{
    public interface IEmployeeService
    {

        List<EmployeeDomain> GetEmployees();

        EmployeeDomain GetEmployeeById(int Id);

        List<EmployeeDomain> DeleteEmployeeById(int Id);

        List<EmployeeDomain> SaveEmployee(Employee employee);

        List<EmployeeDomain> UpdateEmployee(Employee employee);
    }
}
