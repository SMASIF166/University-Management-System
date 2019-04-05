using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCuniversityManagementApp.Gateway;
using MVCuniversityManagementApp.Models;

namespace MVCuniversityManagementApp.Manager
{
    public class CourseManager
    {
        DepartmentGateway aDepartmentGateway = new DepartmentGateway();
        CourseGateway aCourseGateway = new CourseGateway();
        public List<Department> GetAllDepartments()
        {
            return aDepartmentGateway.GetAllDepartment();
        }

        public List<Course> GetAllSemesters()
        {
            return aCourseGateway.GetAllSemesters();
        }

        public List<Course> GetAllDepartment()
        {
            return aCourseGateway.GetAllDepartment();
        }

        public string SaveCourse(Course aCourse)
        {
            if (aCourseGateway.IsCourseExist(aCourse))
            {
                return "Course Name and Code must be unique";
            }
            int rowAffected = aCourseGateway.SaveCourse(aCourse);
            if (rowAffected > 0)
            {
                return "Course saved";
            }
            return "Course save failed";
        }
    }
}
