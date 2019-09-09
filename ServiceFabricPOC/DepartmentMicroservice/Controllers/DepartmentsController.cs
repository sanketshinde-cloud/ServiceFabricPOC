using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DepartmentMicroservice.Models;
using DepartmentMicroservice.Domain;
using Newtonsoft.Json;

namespace DepartmentMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private IDepartmentService _departmentService = null;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/Departments
        [HttpGet]
        public string GetDepartments()
        {

            List<DepartmentsDomain> departments = _departmentService.GetDepartments();

            List<DepartmentsDTO> departmentsDTO = DomainToDTOMapper(departments);

            return JsonConvert.SerializeObject(departmentsDTO);

        }

        List<DepartmentsDTO> DomainToDTOMapper(List<DepartmentsDomain> departmentsDomain)
        {
            var departmentsDTO = new List<DepartmentsDTO>();

            foreach (var department in departmentsDomain)
            {
                var departmentDTO = new DepartmentsDTO();
                departmentDTO.DeptId = department.DeptId;
                departmentDTO.DeptName = department.DeptName;
                departmentDTO.DeptDescription = department.DeptDescription;
                departmentDTO.EmployeeCount = department.EmployeeCount;
                departmentDTO.ShiftTime = department.ShiftTime;
                departmentsDTO.Add(departmentDTO);
            }
            return departmentsDTO;
        }


        // GET: api/Departments
        [HttpGet("{id}")]
        public string GetDepartmentsById(int Id)
        {
            DepartmentsDomain department = _departmentService.GetDepartmentById(Id);

            DepartmentsDTO departmentsDTO = DomainToDTOMapper(department);

            return JsonConvert.SerializeObject(departmentsDTO);
        }

        DepartmentsDTO DomainToDTOMapper(DepartmentsDomain department)
        {
            var departmentDTO = new DepartmentsDTO();
            departmentDTO.DeptId = department.DeptId;
            departmentDTO.DeptName = department.DeptName;
            departmentDTO.DeptDescription = department.DeptDescription;
            departmentDTO.EmployeeCount = department.EmployeeCount;
            departmentDTO.ShiftTime = department.ShiftTime;

            return departmentDTO;
        }


        // GET: api/Departments
        [HttpDelete("{id}")]
        public string DeleteDepartmentById(int Id)
        {

            List<DepartmentsDomain> departments = _departmentService.DeleteDepartmentById(Id);

            List<DepartmentsDTO> departmentsDTO = DomainToDTOMapper(departments);

            return JsonConvert.SerializeObject(departmentsDTO);

        }


        // GET: api/Departments
        [HttpPost]
        public string SaveDepartment([Bind("DeptName,DeptDescription,EmployeeCount,ShiftTime")] Departments department)
        {

            List<DepartmentsDomain> departments = _departmentService.SaveDepartment(department);

            List<DepartmentsDTO> departmentsDTO = DomainToDTOMapper(departments);

            return JsonConvert.SerializeObject(departmentsDTO);

        }


        // GET: api/Departments
        [HttpPut("{id}")]
        public string UpdateDepartment(int id, [FromBody]Departments department)
        {
            department.DeptId = id;

            List<DepartmentsDomain> departments = _departmentService.UpdateDepartment(department);

            List<DepartmentsDTO> departmentsDTO = DomainToDTOMapper(departments);

            return JsonConvert.SerializeObject(departmentsDTO);

        }


        //private readonly DepartmentContext _context;

        //public DepartmentsController(DepartmentContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/Departments
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Departments>>> GetDepartments()
        //{
        //    return await _context.Departments.ToListAsync();
        //}

        // GET: api/Departments/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Departments>> GetDepartments(int id)
        //{
        //    var departments = await _context.Departments.FindAsync(id);

        //    if (departments == null)
        //    {
        //        return NotFound();
        //    }

        //    return departments;
        //}

        //// PUT: api/Departments/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDepartments(int id, Departments departments)
        //{
        //    if (id != departments.DeptId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(departments).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DepartmentsExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Departments
        //[HttpPost]
        //public async Task<ActionResult<Departments>> PostDepartments(Departments departments)
        //{
        //    _context.Departments.Add(departments);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetDepartments", new { id = departments.DeptId }, departments);
        //}

        //// DELETE: api/Departments/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Departments>> DeleteDepartments(int id)
        //{
        //    var departments = await _context.Departments.FindAsync(id);
        //    if (departments == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Departments.Remove(departments);
        //    await _context.SaveChangesAsync();

        //    return departments;
        //}

        //private bool DepartmentsExists(int id)
        //{
        //    return _context.Departments.Any(e => e.DeptId == id);
        //}
    }
}
