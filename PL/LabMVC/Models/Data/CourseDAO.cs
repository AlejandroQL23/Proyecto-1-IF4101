using LabMVC15_04_2021.Models.DomainD;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LabMVC.Models.Data
{
    public class CourseDAO
    {
        private readonly IConfiguration _configuration;
        string connectionString;
        public CourseDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public CourseDAO()
        {
        }

        public int Insert(Course course)
        {
            int resultToReturn;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("CreateCourse", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Initials", course.Initials);
                command.Parameters.AddWithValue("@Name", course.Name);
                command.Parameters.AddWithValue("@Credits", course.Credits);
                command.Parameters.AddWithValue("@Semester", course.Semester);
                command.Parameters.AddWithValue("@Schedule_Id", course.ScheduleId);
                command.Parameters.AddWithValue("@Activity", course.Activity);
                resultToReturn = command.ExecuteNonQuery();
                connection.Close();
            }
            return resultToReturn;
        }

        public List<Course> Get()
        {
            List<Course> courses = new List<Course>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectCourseGeneral", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    courses.Add(new Course
                    {
                        Initials = sqlDataReader["Initials"].ToString(),
                        Name = sqlDataReader["Name"].ToString(),
                        Credits = Convert.ToInt32(sqlDataReader["Credits"]),
                        Semester = sqlDataReader["Semester"].ToString(),
                        Activity = Convert.ToInt32(sqlDataReader["Activity"])
                    });
                }
                connection.Close();
            }
            return courses;
        }

        public Course Get(string id)
        {
            Course course = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("ReadCourse", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Initials", id);
                SqlDataReader sqlDataReader = command.ExecuteReader();
                course = new Course();
                if (sqlDataReader.Read())
                {
                    course.Initials = sqlDataReader["Initials"].ToString();
                    course.Name = sqlDataReader["Name"].ToString();
                    course.Credits = Convert.ToInt32(sqlDataReader["Credits"]);
                    course.Semester = sqlDataReader["Semester"].ToString();
                    course.Activity = Convert.ToInt32(sqlDataReader["Activity"]);
                }
                connection.Close();
            }
            return course;
        }

        public int DeleteCourse(string initials)
        {
            int resultToReturn;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DeleteCourse", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Initials", initials);
                resultToReturn = command.ExecuteNonQuery();
                connection.Close();
            }
            return resultToReturn;
        }

        public int UpdateCourse(Course course)
        {
            int resultToReturn;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UpdateCourse", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Initials", course.Initials);
                command.Parameters.AddWithValue("@Name", course.Name);
                command.Parameters.AddWithValue("@Credits", course.Credits);
                command.Parameters.AddWithValue("@Semester", course.Semester);
                command.Parameters.AddWithValue("@Activity", course.Activity);
                resultToReturn = command.ExecuteNonQuery();
                connection.Close();
            }
            return resultToReturn;
        }
    }
}
