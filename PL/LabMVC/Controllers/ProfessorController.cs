using LabMVC.Models.Data;
using LabMVC.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabMVC.Controllers
{
    public class ProfessorController : Controller
    {

        private readonly ALDIFA_SOFT_MVC_IF4101Context _context;
        ProfessorDAO professorDAO;


        public ProfessorController(ALDIFA_SOFT_MVC_IF4101Context context)
        {
            _context = context;
        }

        // GET: ProfessorController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetExplicitProfessor()
        {
            professorDAO = new ProfessorDAO(_context);
            return Ok(professorDAO.GetExplicitProfessor());
        }

        public ActionResult GetProfessor()
        {
            professorDAO = new ProfessorDAO(_context);
            return Ok(professorDAO.GetProfessor());
        }

        public ActionResult GetProfessorById(string id)
        {
            professorDAO = new ProfessorDAO(_context);
            return Ok(professorDAO.GetProfessorById(id));
        }

        public IActionResult AddProfessor([FromBody] User user)
        {
            professorDAO = new ProfessorDAO(_context);
            professorDAO.SendEmail(user.Email, "❁→❝Trámites de Inscripción Listo❞❁",
                           "<html><body ><h1>Estimado/a " + user.Name + "</h1><br/>" +
                           "<br/><h3>Sede: Atlántico<br/>" +
                           "<br/>Queremos informarle que el proceso de su inscripción al entorno oficial de Informática Empresarial para la Sede del Atlántico ha sido procesada y terminada con éxito, le hemos asignado una identificación oficial la cual es: " + user.IdCard + ", el cual necesitará para autenticarse en nuestros sitios oficiales con sesión de Profesor.  <br/>" +
                           "<br/>Le solicitamos atentamente que revise esta y más de su infomación oficial en el entorno de E-Matrícula(https://ematricula.ucr.ac.cr/ematricula/), así mismo, revisar en días posteriores al proceso de matrícula estudiantil si su respectivo entorno está habilitado en Mediación Virtual(https://mv1.mediacionvirtual.ucr.ac.cr/login/index.php)<br/>" +
                           "<br/>- Oficina de Orientación y Registro.</h3></body></html>");
            return Ok(professorDAO.AddProfessor(user));

        }

        public ActionResult UpdateProfessor([FromBody] User user)
        {
            professorDAO = new ProfessorDAO(_context);
            var oldUser = professorDAO.GetProfessorById(user.IdCard);
            professorDAO.RemoveProfessor(oldUser);
            int resultToReturn = professorDAO.EditProfessor(user);
            return Ok(resultToReturn);
        }

       
    }
}
