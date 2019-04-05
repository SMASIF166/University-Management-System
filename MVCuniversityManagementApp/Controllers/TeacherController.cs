using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCuniversityManagementApp.Models;
using MVCuniversityManagementApp.Manager;

namespace MVCuniversityManagementApp.Controllers
{
    public class TeacherController : Controller
    {
        private TeacherManager aTeacherManager = new TeacherManager();
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveTeacher()
        {
            ViewBag.Departments = aTeacherManager.GetAllDepartments();
            ViewBag.Semesters = aTeacherManager.GetAllDesignations();
            return View();
        }

        [HttpPost]
        public ActionResult SaveTeacher(Teacher aTeacher)
        {
            ViewBag.Departments = aTeacherManager.GetAllDepartments();
            ViewBag.Semesters = aTeacherManager.GetAllDesignations();
            ViewBag.Message = aTeacherManager.SaveTeacher(aTeacher);
            return View();
        }
    }
}