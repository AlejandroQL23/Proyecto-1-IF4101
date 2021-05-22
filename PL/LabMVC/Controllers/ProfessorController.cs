using LabMVC.Models.Data;
using LabMVC.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LabMVC.Controllers
{
    public class ProfessorController : Controller
    {

        private readonly ALDIFA_SOFT_MVC_IF4101Context _context;
        ProfessorDAO professorDAO;
        StudentDAO studentDAO;

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
            user.LastName = oldUser.LastName;
            user.Password = oldUser.Password;
            user.Rol = oldUser.Rol;
            user.Address = oldUser.Address;
            user.Activity = oldUser.Activity;
            user.DateTime = oldUser.DateTime;
            user.Approval = oldUser.Approval;
            user.Photo = oldUser.Photo;
            professorDAO.RemoveProfessor(oldUser);
            int resultToReturn = professorDAO.EditProfessor(user);
            return Ok(resultToReturn);
        }

        public ActionResult AddDateTimeProfessor([FromBody] User user)
        {
            professorDAO = new ProfessorDAO(_context);
            var oldUser = professorDAO.GetProfessorById(user.IdCard);
            user.Name = oldUser.Name;
            user.LastName = oldUser.LastName;
            user.Email = oldUser.Email;
            user.Password = oldUser.Password;
            user.Rol = oldUser.Rol;
            user.Phone = oldUser.Phone;
            user.Address = oldUser.Address;
            user.Activity = oldUser.Activity;
            user.Approval = oldUser.Approval;
            user.Presidency = oldUser.Presidency;
            user.PersonalFormation = oldUser.PersonalFormation;
            user.Instagram = oldUser.Instagram;
            user.Facebook = oldUser.Facebook;
            user.Photo = oldUser.Photo;
            professorDAO.RemoveProfessor(oldUser);
            int resultToReturn = professorDAO.EditProfessor(user);
            return Ok(resultToReturn);
        }


        [HttpPost]
        public string SaveFile(FileUpload fileObj)
        { 
            Models.Entities.User identityUserObject = JsonConvert.DeserializeObject<Models.Entities.User>(fileObj.identityUser);
            if (fileObj.file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {

                    fileObj.file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    identityUserObject.Photo = fileBytes;
                    professorDAO = new ProfessorDAO(_context);
                    var newUser = professorDAO.GetProfessorById(identityUserObject.IdCard);
                    newUser.Photo = identityUserObject.Photo;
                    newUser = professorDAO.Save(newUser);
                    if (newUser.Id > 0)
                    {
                        return "Saved";

                    }

                }

            }
            return "Failed";

        }



        [HttpGet]
        public JsonResult GetSavedUser(string ID)
        { 
            professorDAO = new ProfessorDAO(_context);
            var user = professorDAO.GetSavedUser(ID);
            user.Photo = this.GetImage(Convert.ToBase64String(user.Photo));
            return Json(user);
        }

        public byte[] GetImage(string sBase64String)
        {
            byte[] bytes = null;
            if (!string.IsNullOrEmpty(sBase64String))
            {
                bytes = Convert.FromBase64String(sBase64String);
            }
            return bytes;

        }


        public ActionResult GetProfessorConsultations(string id)
        {
            professorDAO = new ProfessorDAO(_context);
            return Ok(professorDAO.GetProfessorConsultations(id));
        }
        public ActionResult AcceptConsult(int id)
        {

            professorDAO = new ProfessorDAO(_context);
            studentDAO = new StudentDAO(_context);
            var professorConsultation = professorDAO.GetProfessorConsult(id);
            var professor = professorDAO.GetProfessorById(professorConsultation.IdCardProffesor);
            var student = studentDAO.GetStudentById(professorConsultation.IdCardStudent);
            professorDAO.SendEmail(student.Email, "❁→❝Respuesta a su solicitud de consulta❞❁",
                          "<html><body ><h1>Estimado/a " + student.Name + " " + student.LastName + "</h1><br/>" +
                          "<br/><h3>El profesor " + professor.Name + " " + professor.LastName + " ha ACEPTADO su solicitud de consulta<br/></h3></body></html>");
            return Ok(professorDAO.RemoveConsult(professorConsultation));
        }

        public ActionResult DenyConsult(int id)
        {
            professorDAO = new ProfessorDAO(_context);
            studentDAO = new StudentDAO(_context);
            var professorConsultation = professorDAO.GetProfessorConsult(id);
            var professor = professorDAO.GetProfessorById(professorConsultation.IdCardProffesor);
            var student = studentDAO.GetStudentById(professorConsultation.IdCardStudent);
            professorDAO.SendEmail(student.Email, "❁→❝Respuesta a su solicitud de consulta❞❁",
                          "<html><body ><h1>Estimado/a " + student.Name + " " + student.LastName + "</h1><br/>" +
                          "<br/><h3>El profesor " + professor.Name + " " + professor.LastName + " ha RECHAZADO su solicitud de consulta<br/></h3></body></html>");
            return Ok(professorDAO.RemoveConsult(professorConsultation));
        }


    }
}
