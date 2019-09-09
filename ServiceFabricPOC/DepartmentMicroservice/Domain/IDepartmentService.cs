using DepartmentMicroservice.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentMicroservice.Domain
{
    public interface IDepartmentService
    {
        List<DepartmentsDomain> GetDepartments();

        DepartmentsDomain GetDepartmentById(int Id);

        List<DepartmentsDomain> DeleteDepartmentById(int Id);

        List<DepartmentsDomain> SaveDepartment(Departments departments);

        List<DepartmentsDomain> UpdateDepartment(Departments departments);
    }
}
