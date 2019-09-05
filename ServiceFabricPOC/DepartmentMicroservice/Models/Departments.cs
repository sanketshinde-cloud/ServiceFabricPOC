using System;
using System.Collections.Generic;

namespace DepartmentMicroservice.Models
{
    public partial class Departments
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptDescription { get; set; }
        public int? EmployeeCount { get; set; }
        public string ShiftTime { get; set; }
    }
}
