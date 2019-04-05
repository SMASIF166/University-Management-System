using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MVCuniversityManagementApp.Models;

namespace MVCuniversityManagementApp.Gateway
{
    class TeacherGateway:Gateway
    {
        public List<Teacher> GetAllDepartment()
        {
            Query = "SELECT * FROM t_department";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Teacher> DepartmentList = new List<Teacher>();
            while (Reader.Read())
            {
                Teacher aTeacher = new Teacher
                {
                    DepartmentId = (int)Reader["dept_id"],
                    DepartmentCode = Reader["dept_code"].ToString(),
                };
                DepartmentList.Add(aTeacher);
            }
            Reader.Close();
            Connection.Close();
            return DepartmentList;
        }

        public List<Teacher> GetAllDesignation()
        {
            Query = "SELECT * FROM t_designation";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Teacher> Designations = new List<Teacher>();
            while (Reader.Read())
            {
                Teacher aTeacher = new Teacher()
                {
                    DesignationId = (int)Reader["designation_id"],
                    DesignationName = Reader["designation_name"].ToString(),
                };
                Designations.Add(aTeacher);
            }
            Reader.Close();
            Connection.Close();
            return Designations;
        }

        public int SaveTeacher(Teacher aTeacher)
        {
            Query = "INSERT INTO t_teacher (teacher_name,teacher_address,teacher_email,teacher_contactno,designation_id,teacher_credit,dept_id,assigned_credit,remain_credit) VALUES (@teacher_name,@teacher_address,@teacher_email,@teacher_contactno,@designation_id,@teacher_credit,@dept_id,0,@teacher_credit)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            //Command.Parameters.Add("name", SqlDbType.VarChar);
            //Command.Parameters["name"].Value = item.Name;

            Command.Parameters.AddWithValue("teacher_name", aTeacher.TeacherName);
            Command.Parameters.AddWithValue("teacher_address", aTeacher.TeacherAddress);
            Command.Parameters.AddWithValue("teacher_email", aTeacher.TeacherEmail);
            Command.Parameters.AddWithValue("teacher_contactno", aTeacher.TeacherContactNo);
            Command.Parameters.AddWithValue("designation_id", aTeacher.DesignationId);
            Command.Parameters.AddWithValue("teacher_credit", aTeacher.TeacherCredit);
            Command.Parameters.AddWithValue("dept_id", aTeacher.DepartmentId);
            Command.Parameters.AddWithValue("assigned_credit", aTeacher.AssignedCredit);
            Command.Parameters.AddWithValue("remain_credit", aTeacher.RemainCredit);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsEmailExist(Teacher aTeacher)
        {
            Command = new SqlCommand();
            Command.CommandText = "SELECT * FROM t_teacher WHERE teacher_email = '" + aTeacher.TeacherEmail + "'";
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
    }
}
