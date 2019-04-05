using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MVCuniversityManagementApp.Models;

namespace MVCuniversityManagementApp.Gateway
{
    public class CourseAssignGateway:Gateway
    {
        public List<CourseAssign> GetAllDepartments()
        {
            Query = "SELECT * FROM t_department";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<CourseAssign> DepartmentList = new List<CourseAssign>();
            while (Reader.Read())
            {
                CourseAssign aCourseAssign = new CourseAssign
                {
                    DepartmentId = (int)Reader["dept_id"],
                    DepartmentCode = Reader["dept_code"].ToString(),
                };
                DepartmentList.Add(aCourseAssign);
            }
            Reader.Close();
            Connection.Close();
            return DepartmentList;
        }

        public List<CourseAssign> GetAllCourses()
        {
            Query = " SELECT * FROM (t_course AS C INNER JOIN t_semester AS S ON C.semester_id = S.semester_id)";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<CourseAssign> CourseList = new List<CourseAssign>();
            while (Reader.Read())
            {
                CourseAssign aCourseAssign = new CourseAssign
                {
                    CourseId = (int)Reader["course_id"],
                    CourseCode = Reader["course_code"].ToString(),
                    CourseName = Reader["course_name"].ToString(),
                    CourseCredit = (int)Reader["course_credit"],
                    DepartmentId = (int)Reader["dept_id"],
                    SemesterName = Reader["semester_name"].ToString(),
                    CourseStatus = Reader["course_status"].ToString(),
                };
                CourseList.Add(aCourseAssign);
            }
            Reader.Close();
            Connection.Close();
            return CourseList;
        }

        public List<CourseAssign> GetAllTeachers()
        {
            Query = "SELECT * FROM t_teacher";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<CourseAssign> TeacherList = new List<CourseAssign>();
            while (Reader.Read())
            {
                CourseAssign aCourseAssign = new CourseAssign
                {
                    DepartmentId = (int)Reader["dept_id"],
                    TeacherCredit = (int)Reader["teacher_credit"],
                    TeacherId = (int)Reader["teacher_id"],
                    TeacherName = Reader["teacher_name"].ToString(),
                    AssignedCredit = (int)Reader["assigned_credit"],
                    RemainCredit = (int)Reader["remain_credit"],
                };
                TeacherList.Add(aCourseAssign);
            }
            Reader.Close();
            Connection.Close();
            return TeacherList;
        }

        public List<CourseAssign> GetAllCourseStatics()
        {
            Query = "SELECT * FROM (t_teacher INNER JOIN t_course ON t_teacher.dept_id = t_course.dept_id) INNER JOIN t_semester ON t_course.semester_id = t_teacher.semester_id ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<CourseAssign> TeacherList = new List<CourseAssign>();
            while (Reader.Read())
            {
                CourseAssign aCourseAssign = new CourseAssign
                {
                    DepartmentId = (int)Reader["dept_id"],
                    TeacherCredit = (int)Reader["teacher_credit"],
                    TeacherId = (int)Reader["teacher_id"],
                    TeacherName = Reader["teacher_name"].ToString(),
                    AssignedCredit = (int)Reader["assigned_credit"],
                    RemainCredit = (int)Reader["remain_credit"],
                    CourseId = (int)Reader["course_id"],
                    CourseCode = Reader["course_code"].ToString(),
                    CourseName = Reader["course_name"].ToString(),
                    CourseCredit = (int)Reader["course_credit"],
                    SemesterName = Reader["semester_name"].ToString(),
                };
                TeacherList.Add(aCourseAssign);
            }
            Reader.Close();
            Connection.Close();
            return TeacherList;
        }

        public bool IsCourseNotAssigned(CourseAssign aCourseAssign)
        {
            Command = new SqlCommand();
            Command.CommandText = "SELECT * FROM t_course WHERE course_id = '" + aCourseAssign.CourseId + "' AND course_status = 'Not Assigned Yet' ";
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

        public bool AssignCourse(CourseAssign aCourseAssign)
        {
            string Query1 = "SELECT teacher_name FROM t_teacher WHERE teacher_id='"+ aCourseAssign.TeacherId +"'";
            Command = new SqlCommand(Query1, Connection);
            Command.Connection = Connection;
            Connection.Close();
            Connection.Open();
            string teacherName = null;
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                teacherName = Reader["teacher_name"].ToString();
            }
            Reader.Close();
            Connection.Close();



            string Query2 = "UPDATE t_course SET course_status = @course_status,teacher_id = @teacher_id WHERE course_id='" + aCourseAssign.CourseId+"' AND course_status = 'Not Assigned Yet'";
            Command = new SqlCommand(Query2, Connection);
            Command.Parameters.Clear();

            //Command.Parameters.Add("name", SqlDbType.VarChar);
            //Command.Parameters["name"].Value = item.Name;

            Command.Parameters.AddWithValue("teacher_id", aCourseAssign.TeacherId);
            Command.Parameters.AddWithValue("course_status", teacherName);

            //Connection.Close();
            Connection.Open();
            int rowAffected1 = Command.ExecuteNonQuery();
            Command.ExecuteNonQuery();
            Connection.Close();



            //string Query3 = "UPDATE t_teacher SET assigned_credit = @assigned_credit, remain_credit = @teacher_credit-@assigned_credit  WHERE teacher_id = '" + aCourseAssign.TeacherId + "'";
            string Query3 = "UPDATE t_teacher SET assigned_credit = @assigned_credit, remain_credit = @teacher_credit-@assigned_credit  WHERE teacher_id = '" + aCourseAssign.TeacherId + "'";

            Command = new SqlCommand(Query3, Connection);
            Command.Parameters.AddWithValue("assigned_credit", aCourseAssign.CourseCredit);
            Command.Parameters.AddWithValue("teacher_credit", aCourseAssign.TeacherCredit);
            Command.Parameters.AddWithValue("remain_credit", aCourseAssign.RemainCredit);

            Connection.Open();
            int rowAffected2 = Command.ExecuteNonQuery();
            //Command.ExecuteNonQuery();
            Connection.Close();

            if( rowAffected1 > 0 && rowAffected2 >0)
            {
                return true;
            }
            return false;
        }
    }
}
