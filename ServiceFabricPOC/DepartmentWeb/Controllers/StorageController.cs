using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DepartmentWeb.Models;
using CommonLibrary.Utility;
using Microsoft.AspNetCore.Http;

namespace DepartmentWeb.Controllers
{
    public class StorageController : Controller
    {

        private IUtility _utility;

        public StorageController(IUtility utility)
        {
            _utility = utility;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StorageAcc(StorageModel storageModel)
        {

            if (_utility.UploadFileBlob(storageModel.FileName))
            { ViewData["blobdata"] = "Sucessfully uploaded to blob"; }
            else
            { ViewData["blobdata"] = "Error while uploading to blob"; }
            return View();
        }
        public ActionResult StorageAcc()
        {
            return View();
        }
    }
}