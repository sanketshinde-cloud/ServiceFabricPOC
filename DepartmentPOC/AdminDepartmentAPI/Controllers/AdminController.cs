using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Belgrade.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminDepartmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly IQueryPipe SqlPipe;
        private readonly ICommand SqlCommand;

        public AdminController(ICommand sqlCommand, IQueryPipe sqlPipe)
        {
            this.SqlCommand = sqlCommand;
            this.SqlPipe = sqlPipe;
        }

        // GET api/Admin
        [HttpGet]
        public async Task Get()
        {
            await SqlPipe.Stream("select * from Departments FOR JSON PATH", Response.Body, "[]");
        }

        // GET api/Admin/5
        [HttpGet("{id}")]
        public async Task Get(int id)
        {
            var cmd = new SqlCommand("select * from Departments where Id = @id FOR JSON PATH, WITHOUT_ARRAY_WRAPPER");
            cmd.Parameters.AddWithValue("id", id);
            await SqlPipe.Stream(cmd, Response.Body, "{}");
        }
    }
}
