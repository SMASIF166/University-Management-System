using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCuniversityManagementApp.Models
{
    public class CourseAssign
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int TeacherCredit { get; set; }
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int CourseCredit { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentCode { get; set; }
        public int AssignedCredit { get; set; }
        public int RemainCredit { get; set; }
        public string CourseStatus { get; set; }
        public string SemesterName { get; set; }
    }
}
