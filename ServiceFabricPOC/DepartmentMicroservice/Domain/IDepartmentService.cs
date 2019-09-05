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
    }
}
