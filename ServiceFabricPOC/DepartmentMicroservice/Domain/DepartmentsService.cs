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
            foreach (var department in departments)
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

        public DepartmentsDomain GetDepartmentById(int Id)
        {

            Departments department = _departmentRepository.GetDepartmentById(Id);

            DepartmentsDomain departmentsDomain = RepositoryToDomainMapper(department);
            return departmentsDomain;
        }

        private DepartmentsDomain RepositoryToDomainMapper(Departments department)
        {
            var departmentDomain = new DepartmentsDomain();
            departmentDomain.DeptId = department.DeptId;
            departmentDomain.DeptName = department.DeptName;
            departmentDomain.DeptDescription = department.DeptDescription;
            departmentDomain.EmployeeCount = department.EmployeeCount;
            departmentDomain.ShiftTime = department.ShiftTime;

            return departmentDomain;
        }

        public List<DepartmentsDomain> DeleteDepartmentById(int Id)
        {
            List<Departments> departments = _departmentRepository.DeleteDepartmentById(Id);

            List<DepartmentsDomain> departmentsDomains = RepositoryToDomainMapper(departments);

            return departmentsDomains;
        }

        public List<DepartmentsDomain> SaveDepartment(Departments department)
        {
            List<Departments> departments = _departmentRepository.SaveDepartment(department);

            List<DepartmentsDomain> departmentsDomains = RepositoryToDomainMapper(departments);

            return departmentsDomains;
        }

        public List<DepartmentsDomain> UpdateDepartment(Departments department)
        {
            List<Departments> departments = _departmentRepository.UpdateDepartment(department);

            List<DepartmentsDomain> departmentsDomains = RepositoryToDomainMapper(departments);

            return departmentsDomains;
        }
    }
}
