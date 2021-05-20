using LabMVC.Models.Domain;
using LabMVC.Models.Entities;
using LabMVC15_04_2021.Models.DomainD;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LabMVC.Models.Data
{
    public class ProfessorDAO
    {
        private readonly IConfiguration _configuration;
        private readonly ALDIFA_SOFT_MVC_IF4101Context _context;
        string connectionString;
        public ProfessorDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public ProfessorDAO()
        {
        }

        /// <param name="context"></param>
        public ProfessorDAO(ALDIFA_SOFT_MVC_IF4101Context context)
        {
            _context = context;
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

         public IEnumerable<Entities.User> GetProfessor()
        {
            var users = (from user in _context.Users where user.Rol == "Profesor" select user);
            return users.ToList();
        }

        public Entities.User GetProfessorById(String identification)
        {
            var users = (from user in _context.Users where user.IdCard == identification select user);
            return users.FirstOrDefault();
        }

        public int AddProfessor(Entities.User professor)
        {
            int resultToReturn;
            try
            {
                _context.Add(professor);
                resultToReturn = _context.SaveChangesAsync().Result;
            }
            catch (DbUpdateException)
            {
                throw;
            }
            return resultToReturn;
        }

        public int RemoveProfessor(Entities.User professor)
        {
            int resultToReturn;
            var studentToRemove = _context.Users.Find(professor.Id);
            _context.Users.Remove(studentToRemove);
            resultToReturn = _context.SaveChangesAsync().Result;
            return resultToReturn;
        }

        public int EditProfessor(Entities.User professor)
        {
            int resultToReturn = 0;

            try
            {
                if (!ProfessorExists(professor.Id))
                {

                    _context.Update(professor);
                    resultToReturn = _context.SaveChangesAsync().Result;
                }

            }
            catch (DbUpdateException)
            {

                throw;

            }

            return resultToReturn;

        }

        public List<Entities.User> GetExplicitProfessor()
        {
            List<Entities.User> professors = null;

            using (var context = new ALDIFA_SOFT_MVC_IF4101Context())
            {
                professors = context.Users.Select(professorItem => new Entities.User()
                {
                    Id = professorItem.Id,
                    Name = professorItem.Name,
                    Email = professorItem.Email,
                    Password = professorItem.Password

                }).ToList<Entities.User>();
            }

            return professors;

        }

        private bool ProfessorExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
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


    }
}
