using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCuniversityManagementApp.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherAddress { get; set; }
        public string TeacherEmail { get; set; }
        public string TeacherContactNo { get; set; }
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentCode { get; set; }
        public int TeacherCredit { get; set; }
        public int AssignedCredit { get; set; }
        public int RemainCredit { get; set; }
    }
}
