using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MVCuniversityManagementApp.Models;

namespace MVCuniversityManagementApp.Gateway
{
    class DepartmentGateway:Gateway
    {
        public int SaveDepartment(Department aDepartment)
        {
            Query = "INSERT INTO t_department (dept_code, dept_name) VALUES (@dept_code, @dept_name)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            //Command.Parameters.Add("name", SqlDbType.VarChar);
            //Command.Parameters["name"].Value = item.Name;

            Command.Parameters.AddWithValue("dept_code", aDepartment.DepartmentCode);
            Command.Parameters.AddWithValue("dept_name", aDepartment.DepartmentName);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsDepartmentExist(Department aDepartment)
        {
            Command = new SqlCommand();
            Command.CommandText = "SELECT * FROM t_department WHERE dept_code= '" + aDepartment.DepartmentCode + "' OR dept_name= '" + aDepartment.DepartmentName + "' ";
            Command.Connection = Connection;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                return true;
            }
            Reader.Close();
            Connection.Close();
            return false;
        }

        public List<Department> GetAllDepartment()
        {
            Query = "SELECT * FROM t_department";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Department> DepartmentList = new List<Department>();
            while (Reader.Read())
            {
                Department aDepartment = new Department
                {
                    DepartmentId = (int)Reader["dept_id"],
                    DepartmentCode = Reader["dept_code"].ToString(),
                    DepartmentName = Reader["dept_name"].ToString(),
                };
                DepartmentList.Add(aDepartment);
            }
            Reader.Close();
            Connection.Close();
            return DepartmentList;
        }
    }
}
