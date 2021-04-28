﻿using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using LabMVC15_04_2021.Models.DomainD;
using System.Data;

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

        public int Insert(Student student)
        {

            int resultToReturn;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand("CreateStudent", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id_Card", student.IdCard);
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@Last_Name", student.LastName);
                command.Parameters.AddWithValue("@Email", student.Email);
                command.Parameters.AddWithValue("@Password", student.Password);
                command.Parameters.AddWithValue("@Phone", student.Phone);
                command.Parameters.AddWithValue("@Address", student.Address);

                resultToReturn = command.ExecuteNonQuery();
                connection.Close();

            }

            return resultToReturn;


        }

        public Boolean VerifyEmail(string studentEmail)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); //abre conexión
                SqlCommand command = new SqlCommand("VerifyEmail", connection);//conexión con sql
                command.CommandType = System.Data.CommandType.StoredProcedure;//SP
                command.Parameters.AddWithValue("Email", studentEmail);//Parametros agregados

                var returnParameter = command.Parameters.Add("@Exists", System.Data.SqlDbType.Int); //parametro exist
                returnParameter.Direction = ParameterDirection.ReturnValue; //return
                command.ExecuteNonQuery();//ejecuta

                int result = (int)returnParameter.Value; //captura resultado 
                connection.Close();//cierra conexión 

                if (result == 1) //valida el resultado para el return 
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

