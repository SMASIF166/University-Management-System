using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCuniversityManagementApp.Gateway;
using MVCuniversityManagementApp.Models;

namespace MVCuniversityManagementApp.Manager
{
    public class CourseAssignManager
    {
        private CourseAssignGateway aCourseAssignGateway = new CourseAssignGateway();
        public List<CourseAssign> GetAllDepartments()
        {
            return aCourseAssignGateway.GetAllDepartments();
        }
        public List<CourseAssign> GetAllCourses()
        {
            return aCourseAssignGateway.GetAllCourses();
        }

        public List<CourseAssign> GetAllTeachers()
        {
            return aCourseAssignGateway.GetAllTeachers();
        }

        public string AssignCourse(CourseAssign aCourseAssign)
        {
            if (aCourseAssignGateway.IsCourseNotAssigned(aCourseAssign))
            {
                if (aCourseAssignGateway.AssignCourse(aCourseAssign))
                {
                    return "Course assign saved";
                }
                return "Course assign save failed";
            }
            //int rowAffected = aTeacherGateway.SaveTeacher(aTeacher);
            else
            {
                return "Course is already assigned";
            }            
        }
    }
}
