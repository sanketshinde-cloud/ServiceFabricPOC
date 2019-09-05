using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentMicroservice.Domain
{
    public class DepartmentsDomain
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptDescription { get; set; }
        public int? EmployeeCount { get; set; }
        public string ShiftTime { get; set; }
    }
}
