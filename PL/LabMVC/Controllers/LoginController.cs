using ALDIFASOFT_MVC.Models.Entities;
using LabMVC.Models;
using LabMVC.Models.Data;
using LabMVC.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        public IActionResult ValidateLogin([FromBody] User user)
        {
            studentDAO = new StudentDAO(_context);
            var localUser = studentDAO.GetStudentById(user.IdCard);
            if (studentDAO.StudentExistsUserName(user.IdCard) == true && studentDAO.StudentExistsPassword(user.Password) == true && localUser.Approval == "Aceptado")
            {
                HttpContext.Session.SetString("rol", localUser.Rol);
                return Ok(localUser);
            }
            else
            {
                return Error();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
