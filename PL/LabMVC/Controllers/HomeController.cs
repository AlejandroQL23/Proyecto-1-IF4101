using LabMVC.Models;
using LabMVC.Models.Data;
using LabMVC15_04_2021.Models.DomainD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;


namespace LabMVC.Controllers
{


    public class HomeController : Controller
    {
        StudentDAO studentDAO;
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Insert([FromBody] Student student)
        {

            studentDAO = new StudentDAO(_configuration);

            if (studentDAO.VerifyEmail(student.Email))
            {
                return Error();
            }
            else
            {
                int resultToReturn = studentDAO.Insert(student);
            studentDAO.SendEmail(student.Email, "Inscripción",
               "<html><body ><h1>Bienvenido '" + student.Name + "´' al sitio de inscripción de la Universidad de Costa Rica</h1><br/>" +
               "<br/><h3>Sede: Atlántico<br/>" +
               "<br/>Recinto de Paraíso<br/>" +
               "<br/>Carrera: Informática Empresarial<br/>" +
               "<br/>Su solicitud está en espera de aprobación.</h3></body></html>");
            return Ok(resultToReturn);
            }
        }

        public IActionResult GetStudents()
        {
            //llamada al modelo para obtener las carreras
            studentDAO = new StudentDAO(_configuration);

            List<Student> students = new List<Student>();
            students = studentDAO.Get();

            return Json(students);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
