using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentWeb.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

    }
}