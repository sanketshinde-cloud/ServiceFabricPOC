using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMicroservice.Models;

namespace EmployeeMicroservice.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly employeeContext _context;

        public EmployeeRepository(employeeContext context)
        {
            _context = context;
        }

        public List<Employee> GetEmployees()
        {
            return _context.Employee.ToList();
        }

        public Employee GetEmployeeById(int Id)
        {
            return _context.Employee.ToList().Where(x => x.EmpId == Id).FirstOrDefault();
        }

        public List<Employee> DeleteEmployeeById(int Id)
        {
            _context.Employee.Remove(_context.Employee.Where(x => x.EmpId == Id).FirstOrDefault());
            _context.SaveChanges();
            return _context.Employee.ToList();
        }

        public List<Employee> SaveEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
            return _context.Employee.ToList();
        }

        public List<Employee> UpdateEmployee(Employee employee)
        {
            _context.Employee.Update(employee);
            _context.SaveChanges();
            return _context.Employee.ToList();
        }
    }
}
