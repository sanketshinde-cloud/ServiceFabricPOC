using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentMicroservice.Models;

namespace DepartmentMicroservice.Repository
{
    public interface IDepartmentRepository
    {
        List<Departments> GetDepartments();

        Departments GetDepartmentById(int Id);

        List<Departments> DeleteDepartmentById(int Id);

        List<Departments> SaveDepartment(Departments departments);

        List<Departments> UpdateDepartment(Departments departments);
    }
}
