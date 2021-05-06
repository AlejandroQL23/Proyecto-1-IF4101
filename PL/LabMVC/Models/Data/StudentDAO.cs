using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using LabMVC15_04_2021.Models.DomainD;
using System.Data;
using System.Collections.Generic;
using LabMVC.Models.Domain;

namespace LabMVC.Models.Data
{
    public class StudentDAO
    {
        private readonly IConfiguration _configuration;
        string connectionString;

        public StudentDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");

        }
        public StudentDAO()
        {

        }

        public int Insert(User user)
        {

            int resultToReturn;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand("CreateStudent", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdCard", user.IdCard);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Phone", user.Phone);
                command.Parameters.AddWithValue("@Address", user.Address);

                resultToReturn = command.ExecuteNonQuery();
                connection.Close();

            }

            return resultToReturn;

        }

        public int UpdateApproval(User user)
        {

            int resultToReturn;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand("UpdateStudentApproval", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdCard", user.IdCard);
                command.Parameters.AddWithValue("@Approval", user.Approval);

                resultToReturn = command.ExecuteNonQuery();
                connection.Close();

            }

            return resultToReturn;

        }


        public List<User> Get()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand("ReadStudents", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    users.Add(new User
                    {
                        IdCard = sqlDataReader["IdCard"].ToString(),
                        Name = sqlDataReader["Name"].ToString(),
                        LastName = sqlDataReader["LastName"].ToString(),
                        Email = sqlDataReader["Email"].ToString(),
                        Phone = sqlDataReader["Phone"].ToString()
                    });
                }

                connection.Close();
            }
            return users;


        }


        public User Get(string id)
        {
           User user = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectStudentByID", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StudentId", id);

                SqlDataReader sqlDataReader = command.ExecuteReader();
                user = new User();
                if (sqlDataReader.Read())
                {
                    user.IdCard = sqlDataReader["IdCard"].ToString();
                    user.Name = sqlDataReader["Name"].ToString();
                    user.LastName = sqlDataReader["LastName"].ToString();
                    user.Email = sqlDataReader["Email"].ToString();

                }
                connection.Close();
            }
            return user;

        }

        public Boolean VerifyEmail(string studentEmail)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("VerifyEmail", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Email", studentEmail);

                var returnParameter = command.Parameters.Add("@Exists", System.Data.SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                command.ExecuteNonQuery();

                int result = (int)returnParameter.Value; 
                connection.Close();

                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

  

        public Boolean loginAuthentication(string userIdCard, string userPassword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("loginAuthentication", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("IdCard", userIdCard);
                command.Parameters.AddWithValue("Password", userPassword);

                var returnParameter = command.Parameters.Add("@Exists", System.Data.SqlDbType.Int); 
                returnParameter.Direction = ParameterDirection.ReturnValue;
                command.ExecuteNonQuery();

                int result = (int)returnParameter.Value; 
                connection.Close();

                if (result == 1) 
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }


        public void SendEmail(String addressee, String title, String message)
        {

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("aldifasoft0@gmail.com", "LPAC2021"),
                EnableSsl = true,
            };
            MailMessage mailMessage = new MailMessage("aldifasoft0@gmail.com", addressee, title, message);
            mailMessage.IsBodyHtml = true;
            smtpClient.Send(mailMessage);

        }
    }

}

