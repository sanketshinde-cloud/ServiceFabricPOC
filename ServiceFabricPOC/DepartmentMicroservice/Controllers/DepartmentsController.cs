using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DepartmentMicroservice.Models;
using DepartmentMicroservice.Domain;
using Newtonsoft.Json;

namespace DepartmentMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private IDepartmentService _departmentService = null;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/Departments
        [HttpGet]
        public string GetDepartments()
        {

            List<DepartmentsDomain> departments = _departmentService.GetDepartments();

            List<DepartmentsDTO> departmentsDTO = DomainToDTOMapper(departments);

            RootObject rootObject = new RootObject();
            rootObject.Department = departmentsDTO;

            return JsonConvert.SerializeObject(rootObject);

        }

        List<DepartmentsDTO> DomainToDTOMapper(List<DepartmentsDomain> departmentsDomain)
        {
            var departmentsDTO = new List<DepartmentsDTO>();

            foreach (var department in departmentsDomain)
            {
                var departmentDTO = new DepartmentsDTO();
                departmentDTO.DeptId = department.DeptId;
                departmentDTO.DeptName = department.DeptName;
                departmentDTO.DeptDescription = department.DeptDescription;
                departmentDTO.EmployeeCount = department.EmployeeCount;
                departmentDTO.ShiftTime = department.ShiftTime;
                departmentsDTO.Add(departmentDTO);
            }
            return departmentsDTO;
        }


        // GET: api/Departments
        [HttpGet("{id}")]
        public string GetDepartmentsById(int Id)
        {
            DepartmentsDomain department = _departmentService.GetDepartmentById(Id);

            DepartmentsDTO departmentsDTO = DomainToDTOMapper(department);

            return JsonConvert.SerializeObject(departmentsDTO);
        }

        DepartmentsDTO DomainToDTOMapper(DepartmentsDomain department)
        {
            var departmentDTO = new DepartmentsDTO();
            departmentDTO.DeptId = department.DeptId;
            departmentDTO.DeptName = department.DeptName;
            departmentDTO.DeptDescription = department.DeptDescription;
            departmentDTO.EmployeeCount = department.EmployeeCount;
            departmentDTO.ShiftTime = department.ShiftTime;

            return departmentDTO;
        }


        // GET: api/Departments
        [HttpDelete("{id}")]
        public string DeleteDepartmentById(int Id)
        {

            List<DepartmentsDomain> departments = _departmentService.DeleteDepartmentById(Id);

            List<DepartmentsDTO> departmentsDTO = DomainToDTOMapper(departments);

            RootObject rootObject = new RootObject();

            rootObject.Department = departmentsDTO;

            return JsonConvert.SerializeObject(rootObject);
        }


        // GET: api/Departments
        [HttpPost]
        public string SaveDepartment([Bind("DeptName,DeptDescription,EmployeeCount,ShiftTime")] Departments department)
        {

            List<DepartmentsDomain> departments = _departmentService.SaveDepartment(department);

            List<DepartmentsDTO> departmentsDTO = DomainToDTOMapper(departments);

            RootObject rootObject = new RootObject();

            rootObject.Department = departmentsDTO;

            return JsonConvert.SerializeObject(rootObject);

        }


        // GET: api/Departments
        [HttpPut("{id}")]
        public string UpdateDepartment(int id, [FromBody]Departments department)
        {
            department.DeptId = id;

            List<DepartmentsDomain> departments = _departmentService.UpdateDepartment(department);

            List<DepartmentsDTO> departmentsDTO = DomainToDTOMapper(departments);

            RootObject rootObject = new RootObject();

            rootObject.Department = departmentsDTO;

            return JsonConvert.SerializeObject(rootObject);
        }
    }
}
