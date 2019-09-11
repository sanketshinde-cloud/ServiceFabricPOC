using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMicroservice.Domain;
using EmployeeMicroservice.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService = null;


        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/employee
        [HttpGet]
        public string GetEmployees()
        {
            List<EmployeeDomain> employees = _employeeService.GetEmployees();

            List<EmployeeDTO> employeeDTOs = DomainToDTOMapper(employees);

            EmployeeObject employeeObject = new EmployeeObject();

            employeeObject.Employees = employeeDTOs;

            return JsonConvert.SerializeObject(employeeObject);
        }

        // GET: api/employee
        [HttpGet("{id}")]
        public string GetEmployeeById(int Id)
        {
            EmployeeDomain employee = _employeeService.GetEmployeeById(Id);

            EmployeeDTO employeeDTO = DomainToDTOMapper(employee);

            return JsonConvert.SerializeObject(employeeDTO);
        }

        EmployeeDTO DomainToDTOMapper(EmployeeDomain employee)
        {
            var employeeDTO = new EmployeeDTO();
            employeeDTO.EmpId = employee.EmpId;
            employeeDTO.EmpName = employee.EmpName;
            employeeDTO.EmpAge = employee.EmpAge;
            employeeDTO.EmpEmail = employee.EmpEmail;
            employeeDTO.EmpSalary = employee.EmpSalary;

            return employeeDTO;
        }


        // GET: api/employee
        [HttpDelete("{id}")]
        public string DeleteEmployeeById(int Id)
        {

            List<EmployeeDomain> employees = _employeeService.DeleteEmployeeById(Id);

            List<EmployeeDTO> employeeDTOs = DomainToDTOMapper(employees);

            EmployeeObject employeeObject = new EmployeeObject();

            employeeObject.Employees = employeeDTOs;

            return JsonConvert.SerializeObject(employeeObject);

        }


        // GET: api/employee
        [HttpPost]
        public string SaveEmployee([Bind("EmpName,EmpAge,EmpSalary,EmpEmail")] Employee employee)
        {

            List<EmployeeDomain> employees = _employeeService.SaveEmployee(employee);

            List<EmployeeDTO> employeeDTOs = DomainToDTOMapper(employees);

            EmployeeObject employeeObject = new EmployeeObject();

            employeeObject.Employees = employeeDTOs;

            return JsonConvert.SerializeObject(employeeObject);

        }


        // GET: api/employee
        [HttpPut("{id}")]
        public string UpdateEmployee(int id, [FromBody]Employee employee)
        {
            employee.EmpId = id;

            List<EmployeeDomain> employees = _employeeService.UpdateEmployee(employee);

            List<EmployeeDTO> employeeDTOs = DomainToDTOMapper(employees);

            EmployeeObject employeeObject = new EmployeeObject();

            employeeObject.Employees = employeeDTOs;

            return JsonConvert.SerializeObject(employeeObject);

        }

        List<EmployeeDTO> DomainToDTOMapper(List<EmployeeDomain> employeeDomains)
        {
            var employeesDTO = new List<EmployeeDTO>();

            foreach (var department in employeeDomains)
            {
                var employeeDTO = new EmployeeDTO();
                employeeDTO.EmpId = department.EmpId;
                employeeDTO.EmpName = department.EmpName;
                employeeDTO.EmpAge = department.EmpAge;
                employeeDTO.EmpEmail = department.EmpEmail;
                employeeDTO.EmpSalary = department.EmpSalary;
                employeesDTO.Add(employeeDTO);
            }
            return employeesDTO;
        }

    }
}