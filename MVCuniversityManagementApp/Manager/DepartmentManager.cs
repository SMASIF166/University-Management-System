using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCuniversityManagementApp.Gateway;
using MVCuniversityManagementApp.Models;

namespace MVCuniversityManagementApp.Manager
{
    public class DepartmentManager
    {
        private DepartmentGateway aDepartmentGateway = new DepartmentGateway();

        public string SaveDepartment(Department aDeparment)
        {
            if (aDepartmentGateway.IsDepartmentExist(aDeparment))
            {
                return "Department Name and Code must be unique";
            }
            int rowAffected = aDepartmentGateway.SaveDepartment(aDeparment);
            if (rowAffected > 0)
            {
                return "Department saved";
            }
            return "Department save failed";
        }

        public List<Department> GetAllDepartment()
        {
            return aDepartmentGateway.GetAllDepartment();
        }
    }
}
