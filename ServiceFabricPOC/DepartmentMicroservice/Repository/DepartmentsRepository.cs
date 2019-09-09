using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentMicroservice.Models;
using Microsoft.EntityFrameworkCore;

namespace DepartmentMicroservice.Repository
{

    public class DepartmentsRepository : IDepartmentRepository
    {
        private readonly DepartmentContext _context;

        public DepartmentsRepository(DepartmentContext context)
        {
            _context = context;
        }
        public List<Departments> GetDepartments()
        {
            return _context.Departments.ToList();
        }

        public Departments GetDepartmentById(int Id)
        {
            return _context.Departments.ToList().Where(x => x.DeptId == Id).FirstOrDefault();
        }

        public List<Departments> DeleteDepartmentById(int Id)
        {
            _context.Departments.Remove(_context.Departments.Where(x => x.DeptId == Id).FirstOrDefault());
            _context.SaveChanges();
            return _context.Departments.ToList();
        }

        public List<Departments> SaveDepartment(Departments departments)
        {
            _context.Departments.Add(departments);
            _context.SaveChanges();
            return _context.Departments.ToList();
        }

        public List<Departments> UpdateDepartment(Departments departments)
        {
            //_context.Entry<Departments>(departments).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            //_context.Departments.AsNoTracking().ToList();
            _context.Departments.Update(departments);
            _context.SaveChanges();
            

            return _context.Departments.ToList();
        }
    }
}
