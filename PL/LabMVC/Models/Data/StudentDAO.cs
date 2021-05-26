using System;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Collections.Generic;
using LabMVC.Models.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ALDIFASOFT_MVC.Models.Entities;

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

        public StudentDAO(ALDIFA_SOFT_MVC_IF4101Context context)
        {
            _context = context;
        }

        public int AddStudent(User student)
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

        public IEnumerable<User> GetWaitingStudents()
        {
            var students = (from student in _context.Users where student.Approval == "En Espera" select student);
            return students.ToList();
        }

        public User GetStudentById(String identification)
        {
            var students = (from student in _context.Users where student.IdCard == identification select student);
            return students.FirstOrDefault();
        }

        public int EditStudent(User student)
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

        public int RemoveStudent(User student)
        {
            _context.Users.Remove(_context.Users.Find(student.Id));
            return _context.SaveChangesAsync().Result;
        }

        public int AddProfessorConsultation(ProfessorConsultation consultation)
        {
            int resultToReturn;
            try
            {
                _context.Add(consultation);
                resultToReturn = _context.SaveChangesAsync().Result;
            }
            catch (DbUpdateException)
            {
                throw;
            }
            return resultToReturn;
        }

        public User SaveStudentPhoto(User student)
        {
            _context.Users.Update(student);
            _context.SaveChanges();
            return student;
        }

        public User GetSavedStudentPhoto(string ID)
        {
            var students = (from student in _context.Users where student.IdCard == ID select student);
            return students.FirstOrDefault();
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

    }
}
