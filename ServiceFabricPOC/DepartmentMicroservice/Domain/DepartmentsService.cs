using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentMicroservice.Models;
using Microsoft.AspNetCore.Mvc;
using DepartmentMicroservice.Repository;

namespace DepartmentMicroservice.Domain
{
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRepository _departmentRepository = null;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public List<DepartmentsDomain> GetDepartments()
        {
            List<Departments> departments = _departmentRepository.GetDepartments();

            List<DepartmentsDomain> departmentsDomains = RepositoryToDomainMapper(departments);

            return departmentsDomains;
        }

        private List<DepartmentsDomain> RepositoryToDomainMapper(List<Departments> departments)
        {
            var departmentsDomain = new List<DepartmentsDomain>();
            foreach(var department in departments)
            {
                var departmentDomain = new DepartmentsDomain();
                departmentDomain.DeptId = department.DeptId;
                departmentDomain.DeptName = department.DeptName;
                departmentDomain.DeptDescription = department.DeptDescription;
                departmentDomain.EmployeeCount = department.EmployeeCount;
                departmentDomain.ShiftTime = department.ShiftTime;
                departmentsDomain.Add(departmentDomain);
            }
            return departmentsDomain;
        }
    }
}
