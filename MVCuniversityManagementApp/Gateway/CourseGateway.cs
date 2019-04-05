using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MVCuniversityManagementApp.Models;

namespace MVCuniversityManagementApp.Gateway
{
    class CourseGateway:Gateway
    {
        public List<Course> GetAllSemesters()
        {
            Query = "SELECT * FROM t_semester";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> Semesters = new List<Course>();
            while (Reader.Read())
            {
                Course aCourse = new Course()
                {
                    SemesterId = (int)Reader["semester_id"],
                    SemesterName = Reader["semester_name"].ToString(),
                };
                Semesters.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();
            return Semesters;
        }
        public List<Course> GetAllDepartment()
        {
            Query = "SELECT * FROM t_department";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> DepartmentList = new List<Course>();
            while (Reader.Read())
            {
                Course aCourse = new Course
                {
                    DepartmentId = (int)Reader["dept_id"],
                    DepartmentCode = Reader["dept_code"].ToString(),
                };
                DepartmentList.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();
            return DepartmentList;
        }
        public bool IsCourseExist(Course aCourse)
        {
            Command = new SqlCommand();
            Command.CommandText = "SELECT * FROM t_course WHERE course_code= '" + aCourse.CourseCode + "' OR course_name= '" + aCourse.CourseName + "' ";
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
        public int SaveCourse(Course aCourse)
        {
            Query = "INSERT INTO t_course (course_code,course_name,course_credit,course_description,dept_id,semester_id,course_status,teacher_id) VALUES (@course_code,@course_name,@course_credit,@course_description,@dept_id,@semester_id,'Not Assigned Yet',999)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            //Command.Parameters.Add("name", SqlDbType.VarChar);
            //Command.Parameters["name"].Value = item.Name;

            Command.Parameters.AddWithValue("course_code", aCourse.CourseCode);
            Command.Parameters.AddWithValue("course_name", aCourse.CourseName);
            Command.Parameters.AddWithValue("course_credit", aCourse.CourseCredit);
            Command.Parameters.AddWithValue("course_description", aCourse.CourseDescription);
            Command.Parameters.AddWithValue("dept_id", aCourse.DepartmentId);
            Command.Parameters.AddWithValue("semester_id", aCourse.SemesterId);
            //Command.Parameters.AddWithValue("teacher_id", aCourse.TeacherId);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}
