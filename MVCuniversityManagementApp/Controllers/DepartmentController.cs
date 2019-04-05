using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCuniversityManagementApp.Models;
using MVCuniversityManagementApp.Manager;

namespace MVCuniversityManagementApp.Controllers
{
    public class DepartmentController : Controller
    {
        private DepartmentManager aDepartmentManager = new DepartmentManager();
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }

        //public string SaveDepartment(Department aDepartment)
        //{
        //    return aDepartmentManager.SaveDepartment(aDepartment);
        //}

        //private List<Department> GetAllDepartments()
        //{
        //    return aDepartmentManager.GetAllDepartment();
        //}


        [HttpGet]
        public ActionResult SaveDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveDepartment(Department aDepartment)
        {
            ViewBag.Message = aDepartmentManager.SaveDepartment(aDepartment);
            return View();
        }

        public ActionResult ShowAllDepartment()
        {
            List<Department> DepartmentList = aDepartmentManager.GetAllDepartment();
            ViewBag.Departments = DepartmentList;
            return View(DepartmentList);
        }

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    ViewBag.Categories = categoryManager.GetAllCategories();
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(Item item)
        //{
        //    ViewBag.Message = itemManager.Save(item);
        //    ViewBag.Categories = categoryManager.GetAllCategories();
        //    return View();
        //}
    }
}