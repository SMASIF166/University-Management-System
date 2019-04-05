using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCuniversityManagementApp.Gateway;
using MVCuniversityManagementApp.Models;

namespace MVCuniversityManagementApp.Manager
{
    public class TeacherManager
    {
        private TeacherGateway aTeacherGateway = new TeacherGateway();

        public List<Teacher> GetAllDepartments()
        {
            return aTeacherGateway.GetAllDepartment();
        }

        public List<Teacher> GetAllDesignations()
        {
            return aTeacherGateway.GetAllDesignation();
        }

        public string SaveTeacher(Teacher aTeacher)
        {
            if (aTeacherGateway.IsEmailExist(aTeacher))
            {
                return "Email must be unique";
            }
            int rowAffected = aTeacherGateway.SaveTeacher(aTeacher);
            if (rowAffected > 0)
            {
                return "Teacher saved";
            }
            return "Teacher save failed";
        }
    }
}
