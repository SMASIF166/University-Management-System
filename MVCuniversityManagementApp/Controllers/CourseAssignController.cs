using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCuniversityManagementApp.Models;
using MVCuniversityManagementApp.Manager;


namespace MVCuniversityManagementApp.Controllers
{
    public class CourseAssignController : Controller
    {
        private CourseAssignManager aCourseAssignManager = new CourseAssignManager();
        private DepartmentManager aDepartmentManager = new DepartmentManager();
        // GET: CourseAssign
        public ActionResult Index()
        {
            return View();
        }

   
        public ActionResult CourseAssign()
        {
            ViewBag.Departments = aCourseAssignManager.GetAllDepartments();
            ViewBag.Teachers= aCourseAssignManager.GetAllTeachers();
            return View(); 
        }

        [HttpPost]
        public ActionResult CourseAssign(CourseAssign aCourseAssign)
        {
            ViewBag.Departments = aCourseAssignManager.GetAllDepartments();
            ViewBag.Teachers = aCourseAssignManager.GetAllTeachers();
            ViewBag.Message = aCourseAssignManager.AssignCourse(aCourseAssign);
            return View();
        }

        public JsonResult GetCourseByDepartmentId(CourseAssign aCourseAssign)
        {
            var Course = aCourseAssignManager.GetAllCourses();
            var CourseList = Course.Where(a => a.DepartmentId == aCourseAssign.DepartmentId).ToList();
            return Json(CourseList);
        }

        public JsonResult GetTeacherByDepartmentId(CourseAssign aCourseAssign)
        {
            var Teachers = aCourseAssignManager.GetAllTeachers();
            var TeacherList = Teachers.Where(m => m.DepartmentId == aCourseAssign.DepartmentId).ToList();
            return Json(TeacherList);
        }
        public JsonResult GetTeacherCreditByDepartmentId(CourseAssign aCourseAssign)
        {
            var Teachers = aCourseAssignManager.GetAllTeachers();
            var TeacherList = Teachers.FirstOrDefault(m => m.TeacherId == aCourseAssign.TeacherId);
            return Json(TeacherList);
        }

        public JsonResult GetCourseNameByCourseId(CourseAssign aCourseAssign)
        {
            var Course = aCourseAssignManager.GetAllCourses();
            var CourseList = Course.FirstOrDefault(a => a.CourseId == aCourseAssign.CourseId);
            return Json(CourseList);
        }

        public JsonResult GetCourseCreditByCourseId(CourseAssign aCourseAssign)
        {
            var Course = aCourseAssignManager.GetAllCourses();
            var CourseList = Course.FirstOrDefault(a => a.CourseId == aCourseAssign.CourseId);
            return Json(CourseList);
        }

        public JsonResult GetRemainCreditByTeacherId(CourseAssign aCourseAssign)
        {
            var Course = aCourseAssignManager.GetAllTeachers();
            var CourseList = Course.FirstOrDefault(a => a.TeacherId == aCourseAssign.TeacherId);
            return Json(CourseList);
        }

        public ActionResult ViewCourseStatics()
        {
            ViewBag.Departments = aCourseAssignManager.GetAllDepartments();
            return View();
        }

        //[HttpPost]
        //public ActionResult ViewCourseStatics(CourseAssign aCourseAssign)
        //{
        //    ViewBag.Departments = aCourseAssignManager.GetAllDepartments();
        //    return View();
        //}

        public JsonResult GetCourseStaticsByDepartmentId(CourseAssign aCourseAssign)
        {
            var Course = aCourseAssignManager.GetAllCourses();
            var CourseList = Course.Where(a => a.DepartmentId == aCourseAssign.DepartmentId).ToList();
            return Json(CourseList);
        }
    }
}