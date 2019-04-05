using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCuniversityManagementApp.Models
{
    public class Student
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentDate { get; set; }
        public string StudentAddress { get; set; }
        public string StudentContactNo { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentCode { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
