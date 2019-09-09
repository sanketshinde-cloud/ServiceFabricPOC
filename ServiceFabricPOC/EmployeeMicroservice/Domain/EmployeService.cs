using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMicroservice.Models;
using EmployeeMicroservice.Repository;

namespace EmployeeMicroservice.Domain
{
    public class EmployeService : IEmployeeService
    {

        private IEmployeeRepository _employeeRepository = null;

        public EmployeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<EmployeeDomain> GetEmployees()
        {
            List<Employee> employee = _employeeRepository.GetEmployees();

            List<EmployeeDomain> employeesDomains = RepositoryToDomainMapper(employee);

            return employeesDomains;
        }

        public EmployeeDomain GetEmployeeById(int Id)
        {
            Employee employee = _employeeRepository.GetEmployeeById(Id);

            EmployeeDomain employeeDomain = RepositoryToDomainMapper(employee);

            return employeeDomain;
        }

        public List<EmployeeDomain> DeleteEmployeeById(int Id)
        {
            List<Employee> employees = _employeeRepository.DeleteEmployeeById(Id);

            List<EmployeeDomain> EmployeeDomains = RepositoryToDomainMapper(employees);

            return EmployeeDomains;
        }

        public List<EmployeeDomain> SaveEmployee(Employee employee)
        {
            List<Employee> employees = _employeeRepository.SaveEmployee(employee);

            List<EmployeeDomain> EmployeeDomains = RepositoryToDomainMapper(employees);

            return EmployeeDomains;
        }

        public List<EmployeeDomain> UpdateEmployee(Employee employee)
        {
            List<Employee> employees = _employeeRepository.UpdateEmployee(employee);

            List<EmployeeDomain> EmployeeDomains = RepositoryToDomainMapper(employees);

            return EmployeeDomains;
        }


        private List<EmployeeDomain> RepositoryToDomainMapper(List<Employee> employees)
        {
            var employeesDomain = new List<EmployeeDomain>();
            foreach (var employee in employees)
            {
                var employeeDomain = new EmployeeDomain();
                employeeDomain.EmpId = employee.EmpId;
                employeeDomain.EmpName = employee.EmpName;
                employeeDomain.EmpAge = employee.EmpAge;
                employeeDomain.EmpEmail = employee.EmpEmail;
                employeeDomain.EmpSalary = employee.EmpSalary;
                employeesDomain.Add(employeeDomain);
            }
            return employeesDomain;
        }

        private EmployeeDomain RepositoryToDomainMapper(Employee employee)
        {
            var employeeDomain = new EmployeeDomain();
            employeeDomain.EmpId = employee.EmpId;
            employeeDomain.EmpName = employee.EmpName;
            employeeDomain.EmpAge = employee.EmpAge;
            employeeDomain.EmpEmail = employee.EmpEmail;
            employeeDomain.EmpSalary = employee.EmpSalary;

            return employeeDomain;
        }
    }
}
