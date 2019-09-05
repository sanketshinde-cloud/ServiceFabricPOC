using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentMicroservice.Controllers
{
    public class DepartmentsDTO
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptDescription { get; set; }
        public int? EmployeeCount { get; set; }
        public string ShiftTime { get; set; }
    }
}
