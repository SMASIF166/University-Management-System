using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCuniversityManagementApp.Models;
using System.Data.SqlClient;
using System.Web;

namespace MVCuniversityManagementApp.Gateway
{
    public class StudentGateway:Gateway
    {
        public List<Student> GetAllDepartments()
        {
            Query = "SELECT * FROM t_department";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Student> DepartmentList = new List<Student>();
            while (Reader.Read())
            {
                Student aStudent = new Student
                {
                    DepartmentId = (int)Reader["dept_id"],
                    DepartmentCode = Reader["dept_code"].ToString(),
                };
                DepartmentList.Add(aStudent);
            }
            Reader.Close();
            Connection.Close();
            return DepartmentList;
        }

        public bool RegisterStudent(Student aStudent)
        {
            string studentDate = aStudent.StudentDate.Substring(0, 4);
            string Query2 = "SELECT DISTINCT RIGHT('00' + CONVERT(VARCHAR, (SELECT COUNT(id)+1 AS Total FROM t_student WHERE dept_id = '"+aStudent.DepartmentId + "' AND date = '" + studentDate + "')), 3) FROM t_student";
            Command = new SqlCommand(Query2, Connection);
            Command.Connection = Connection;
            Connection.Open();
            string Totalstudent = "001";
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Totalstudent = Reader[0].ToString();
            }
            Reader.Close();
            Connection.Close();



            string Query1 = "INSERT INTO t_student (name,email,contact_no,date,address,dept_id) VALUES (@name,@email,@contact_no,@date,@address,@dept_id)";
            Command = new SqlCommand(Query1, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("name", aStudent.StudentName);
            Command.Parameters.AddWithValue("email", aStudent.StudentEmail);
            Command.Parameters.AddWithValue("contact_no", aStudent.StudentContactNo);
            Command.Parameters.AddWithValue("date", studentDate);
            Command.Parameters.AddWithValue("address", aStudent.StudentAddress);
            Command.Parameters.AddWithValue("dept_id", aStudent.DepartmentId);

            Connection.Open();
            int rowAffected1 = Command.ExecuteNonQuery();
            Connection.Close();



            string Query3 = "select Distinct (D.dept_code) from t_student T inner join t_department D on T.dept_id=D.dept_id  WHERE T.email = '" + aStudent.StudentEmail + "'";
            Command = new SqlCommand(Query3, Connection);
            Command.Connection = Connection;
            Connection.Open();
            string StudentDept=null;
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                StudentDept = Reader[0].ToString();
            }
            Reader.Close();
            Connection.Close();


            string Query4 = "SELECT SUBSTRING(date,0,5) FROM t_student WHERE email = '" + aStudent.StudentEmail + "'";
            Command = new SqlCommand(Query4, Connection);
            Command.Connection = Connection;
            Connection.Open();
            string StudentDateString=null;
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                StudentDateString = Reader[0].ToString();
            }
            Reader.Close();
            Connection.Close();



            string Query5 = "UPDATE t_student SET reg_no = '" + StudentDept + "' +'-'+'" + StudentDateString + "'+'-'+'" + Totalstudent + "' WHERE email = '" + aStudent.StudentEmail + "'";
            Command = new SqlCommand(Query5, Connection);

            Connection.Open();
            int rowAffected2 = Command.ExecuteNonQuery();
            Connection.Close();


            if (rowAffected1 > 0 && rowAffected2 > 0)
            {
                return true;
            }
            return false;
        }

        public List<Student> GetStudentRecord()
        {
            //Query = "SELECT S.id,S.name,S.email,S.contact_no,S.date,S.address,S.dept_id,D.dept_code,S.reg_no FROM (t_student S INNER JOIN t_department D ON S.dept_id = D.dept_id) WHERE S.email = '"+ aStudent.StudentEmail +"'";
            Query = "SELECT S.id,S.name,S.email,S.contact_no,S.date,S.address,S.dept_id,D.dept_code,S.reg_no FROM (t_student S INNER JOIN t_department D ON S.dept_id = D.dept_id)";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Student> StudentRecordList = new List<Student>();
            while (Reader.Read())
            {
                Student aaStudent = new Student
                {
                    DepartmentId = (int)Reader["dept_id"],
                    StudentName = Reader["name"].ToString(),
                    StudentEmail = Reader["email"].ToString(),
                    StudentContactNo = Reader["contact_no"].ToString(),
                    StudentAddress = Reader["address"].ToString(),
                    DepartmentCode = Reader["dept_code"].ToString(),
                    RegistrationNumber = Reader["reg_no"].ToString(),
                    StudentDate = Reader["date"].ToString(),
                };
                StudentRecordList.Add(aaStudent);
            }
            Reader.Close();
            Connection.Close();
            return StudentRecordList;
        }

        public bool IsEmailExist(Student aStudent)
        {
            Command = new SqlCommand();
            Command.CommandText = "SELECT * FROM t_student WHERE email= '" + aStudent.StudentEmail + "'";
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
