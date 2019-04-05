using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCuniversityManagementApp.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int CourseCredit { get; set; }
        public string CourseDescription { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentCode { get; set; }
        public int SemesterId { get; set; }
        public string SemesterName { get; set; }
        public string CourseStatus { get; set; }
        //public int TeacherId { get; set; }
    }
}
