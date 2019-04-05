using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCuniversityManagementApp.Models;
using MVCuniversityManagementApp.Manager;

namespace MVCuniversityManagementApp.Controllers
{
    public class StudentController : Controller
    {
        private StudentManager aStudentManager = new StudentManager();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RegisterStudent()
        {
            ViewBag.Departments = aStudentManager.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult RegisterStudent(Student aStudent)
        {
            ViewBag.Departments = aStudentManager.GetAllDepartments();
            ViewBag.Message = aStudentManager.RegisterStudent(aStudent);
            //ViewBag.StudentRecord = aStudentManager.GetStudentRecord();
            return View();
            //return RedirectToAction("ShowRegisteredStudents");
        }

        public ActionResult ShowRegisteredStudents()
        {
            ViewBag.StudentRecord = aStudentManager.GetStudentRecord();
            return View();
        }
    }
}