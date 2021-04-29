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


    }
}
