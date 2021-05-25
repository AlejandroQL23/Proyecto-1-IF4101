using LabMVC.Models;
using LabMVC.Models.Data;
using LabMVC.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LabMVC.Controllers
{
    public class LoginController : Controller
    {

        private readonly ALDIFA_SOFT_MVC_IF4101Context _context;
        StudentDAO studentDAO;

        public LoginController(ALDIFA_SOFT_MVC_IF4101Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

       // [HttpPost]
        public IActionResult Validate([FromBody] Models.Entities.User user)
        {

            studentDAO = new StudentDAO(_context);
            var localUser = studentDAO.GetStudentById(user.IdCard);
            if (studentDAO.StudentExistsUserName(user.IdCard) == true && studentDAO.StudentExistsPassword(user.Password) == true && localUser.Approval == "Aceptado")
            {
                HttpContext.Session.SetString("rol", localUser.Rol);

                //aqui poner lo demas datos
                //   return RedirectToAction("Index", "Student");
                return Ok(localUser);
            }
            else
            {
                return Error();
            }


            // return View();



        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




    }
}
