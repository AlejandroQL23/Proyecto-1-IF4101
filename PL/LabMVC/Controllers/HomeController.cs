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
        ProfessorDAO professorDAO;
        
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

        public IActionResult InsertProfessor([FromBody] Professor professor)
        {

            professorDAO = new ProfessorDAO(_configuration);

                int resultToReturn = professorDAO.Insert(professor);
                studentDAO.SendEmail(professor.Email, "Inscripción",
                   "<html><body ><h1>Bienvenido '" + professor.Name + "´' al sitio de inscripción de la Universidad de Costa Rica</h1><br/>" +
                   "<br/><h3>Sede: Atlántico<br/>" +
                   "<br/>Recinto de Paraíso<br/>" +
                   "<br/>Carrera: Informática Empresarial<br/>" +
                   "<br/>Professor ingresado.</h3></body></html>");
                return Ok(resultToReturn);
           
        }

        public IActionResult UpdateApprovalAccept([FromBody] Student student)
        {

            studentDAO = new StudentDAO(_configuration);

                int resultToReturn = studentDAO.UpdateApproval(student);
            studentDAO.SendEmail(student.Email, "❁→❝Solicitud de inscripción Aceptada❞❁",
           "<html><body ><h1>Estimado/a " + student.Name + "</h1><br/>" +
           "<br/><h3>Sede: Atlántico<br/>" +
           "<br/>Queremos informarle que su solicitud de inscripción a la carrera de Informática ha sido aceptada con éxito, por este medio le recordamos de igual manera que su carné estudiantil es " + student.IdCard + ", el cuál será de suma importancia para los trámites oficiales dentro de la Universidad <br/>" +
           "<br/>Le pedimos porfavor que verifique la carrera en el sitio oficial de E-Matrícula(https://ematricula.ucr.ac.cr/ematricula/) con motivo del cercano proceos de matrícula. Así mismo registrarse en el sitio oficial de la universidad para el manejo de cada curso, Mediación Virtual(https://mv1.mediacionvirtual.ucr.ac.cr/login/index.php)<br/>" +
           "<br/>- Oficina de Orientación y Registro.</h3></body></html>");
            return Ok(resultToReturn);

        }

        public IActionResult UpdateApprovalDeny([FromBody] Student student)
        {

            studentDAO = new StudentDAO(_configuration);

            int resultToReturn = studentDAO.UpdateApproval(student);
            studentDAO.SendEmail(student.Email, "❁→❝Solicitud de inscripción Rechazada❞❁",
                           "<html><body ><h1>Estimado/a " + student.Name + "</h1><br/>" +
                           "<br/><h3>Sede: Atlántico<br/>" +
                           "<br/>Queremos informarle que su solicitud de inscripción a la carrera de Informática ha sido rechazada, por lo tanto su actividad dentro de la carrera estará automaticamente inactivo dentro de los registros de la carrera <br/>" +
                           "<br/>En caso de tener una consulta con respecto al resultado de su solicitud, porfavor consultar con la Oficina de Orientación y Registros(https://ori.ucr.ac.cr/) o bien al coordinador de la carrera(alvaro.mena@ucr.ac.cr)<br/>" +
                           "<br/>- Oficina de Orientación y Registro.</h3></body></html>");
            return Ok(resultToReturn);

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
