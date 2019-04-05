using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCuniversityManagementApp.Models;
using MVCuniversityManagementApp.Manager;

namespace MVCuniversityManagementApp.Controllers
{
    public class CourseController : Controller
    {
        private DepartmentManager aDepartmentManager = new DepartmentManager();
        private CourseManager aCourseManager = new CourseManager();
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveCourse()
        {
            ViewBag.Departments = aCourseManager.GetAllDepartment();
            ViewBag.Semesters = aCourseManager.GetAllSemesters();
            return View();
        }

        [HttpPost]
        public ActionResult SaveCourse(Course aCourse)
        {
            ViewBag.Departments = aCourseManager.GetAllDepartment();
            ViewBag.Semesters = aCourseManager.GetAllSemesters();
            ViewBag.Message = aCourseManager.SaveCourse(aCourse);
            return View();
        }
    }
}