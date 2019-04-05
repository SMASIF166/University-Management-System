using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCuniversityManagementApp.Gateway;
using MVCuniversityManagementApp.Models;

namespace MVCuniversityManagementApp.Manager
{
    public class StudentManager
    {
        private StudentGateway aStudentGateway = new StudentGateway();
        public List<Student> GetAllDepartments()
        {
            return aStudentGateway.GetAllDepartments();
        }

        public List<Student> GetStudentRecord()
        {
            return aStudentGateway.GetStudentRecord();
        }

        public string RegisterStudent(Student aStudent)
        {
            if(aStudentGateway.IsEmailExist(aStudent))
            {
                return "Same email exist. Please use a unique email id.";
            }
            else
            {
                if (aStudentGateway.RegisterStudent(aStudent))
                {
                    return "Student saved";
                }
            }
            return "Student save failed";
        }
    }
}
