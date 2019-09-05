using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentMicroservice.Models;

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
    }
}
