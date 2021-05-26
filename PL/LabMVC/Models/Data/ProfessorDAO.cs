using ALDIFASOFT_MVC.Models.Entities;
using LabMVC.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

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

        public ProfessorDAO(ALDIFA_SOFT_MVC_IF4101Context context)
        {
            _context = context;
        }

        public int AddProfessor(User professor)
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

        public IEnumerable<User> GetProfessor()
        {
            var professors = (from professor in _context.Users where professor.Rol == "Profesor" select professor);
            return professors.ToList();
        }

        public User GetProfessorById(String identification)
        {
            var professors = (from professor in _context.Users where professor.IdCard == identification select professor);
            return professors.FirstOrDefault();
        }

        public int EditProfessor(User professor)
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

        public int RemoveProfessor(User professor)
        {
            int resultToReturn;
            var studentToRemove = _context.Users.Find(professor.Id);
            _context.Users.Remove(studentToRemove);
            resultToReturn = _context.SaveChangesAsync().Result;
            return resultToReturn;
        }

        public IEnumerable<ProfessorConsultation> GetProfessorConsultations(String idCardProffesor)
        {
            var consultations = (from consultation in _context.ProfessorConsultations where consultation.IdCardProffesor == idCardProffesor select consultation);
            return consultations.ToList();
        }

        public ProfessorConsultation GetProfessorConsult(int identification)
        {
            var professors = (from professor in _context.ProfessorConsultations where professor.Id == identification select professor);
            return professors.FirstOrDefault();
        }

        public int RemoveConsult(ProfessorConsultation consultation)
        {
            int resultToReturn;
            var consultToRemove = _context.ProfessorConsultations.Find(consultation.Id);
            _context.ProfessorConsultations.Remove(consultToRemove);
            resultToReturn = _context.SaveChangesAsync().Result;
            return resultToReturn;
        }

        public User SaveProfessorPhoto(User professor)
        {

            _context.Users.Update(professor);
            _context.SaveChanges();
            return professor;
        }

        public User GetSavedProfessorPhoto(string ID)
        {
            var professors = (from professor in _context.Users where professor.IdCard == ID select professor);
            return professors.FirstOrDefault();
        }

        private bool ProfessorExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
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
