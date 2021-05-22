using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using LabMVC15_04_2021.Models.DomainD;
using System.Data;
using System.Collections.Generic;
using LabMVC.Models.Domain;
using LabMVC.Models.Entities;
using User = LabMVC.Models.Domain.User;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LabMVC.Models.Data
{
    public class StudentDAO
    {
        private readonly IConfiguration _configuration;
        private readonly ALDIFA_SOFT_MVC_IF4101Context _context;
        string connectionString;

        public StudentDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public StudentDAO()
        {
        }

        /// <param name="context"></param>
        public StudentDAO(ALDIFA_SOFT_MVC_IF4101Context context)
        {
            _context = context;
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
            MailAddress mailaddress = new MailAddress(addressee);
            MailMessage mailMessage = new MailMessage("aldifasoft0@gmail.com", addressee, title, message);
            mailMessage.IsBodyHtml = true;
            smtpClient.Send(mailMessage);
        }

        public IEnumerable<Entities.User> GetWaitingStudents()
        {
            var users = (from user in _context.Users where user.Approval == "En Espera" select user);
            return users.ToList();
        }

        public Entities.User GetStudentById(String identification)
        {
            var users = (from user in _context.Users where user.IdCard == identification select user);
            return users.FirstOrDefault();
        }

        public int AddStudent(Entities.User student)
        {
            int resultToReturn;
            try
            {
                _context.Add(student);
                resultToReturn = _context.SaveChangesAsync().Result;
            }
            catch (DbUpdateException)
            {
                throw;
            }
            return resultToReturn;
        }

        public int RemoveStudent(Entities.User student)
        {
            _context.Users.Remove(_context.Users.Find(student.Id));
            return _context.SaveChangesAsync().Result;
        }

        public int EditStudent(Entities.User student)
        {
            int resultToReturn = 0;
            try
            {
                if (!StudentExists(student.Id))
                {
                    _context.Update(student);
                    resultToReturn = _context.SaveChangesAsync().Result;
                }
            }
            catch (DbUpdateException)
            {
                throw;
            }
            return resultToReturn;
        }

        public List<Entities.User> GetExplicitStudent()
        {
            List<Entities.User> students = null;
            using (var context = new ALDIFA_SOFT_MVC_IF4101Context())
            {
                students = context.Users.Select(studentItem => new Entities.User()
                {
                    Id = studentItem.Id,
                    Name = studentItem.Name,
                    Email = studentItem.Email,
                    Password = studentItem.Password

                }).ToList<Entities.User>();
            }
            return students;
        }

        private bool StudentExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
        public bool StudentExistsUserName(string username)
        {
            return _context.Users.Any(e => e.IdCard == username);
        }
        public bool StudentExistsPassword(string password)
        {
            return _context.Users.Any(e => e.Password == password);
        }

        public Entities.User Save(Entities.User user)
        {

            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public Entities.User GetSavedUser(string ID)
        {
            var users = (from user in _context.Users where user.IdCard == ID select user);
            return users.FirstOrDefault();
        }

        public int AddProfessorConsultation(ProfessorConsultation professorConsultation)
        {
            int resultToReturn;
            try
            {
                _context.Add(professorConsultation);
                resultToReturn = _context.SaveChangesAsync().Result;
            }
            catch (DbUpdateException)
            {
                throw;
            }
            return resultToReturn;
        }

    }
}
