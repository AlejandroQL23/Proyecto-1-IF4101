using LabMVC.Models.Data;
using LabMVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;

namespace LabMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly ALDIFA_SOFT_MVC_IF4101Context _context;
        StudentDAO studentDAO;

        public StudentController(ALDIFA_SOFT_MVC_IF4101Context context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult AddStudent([FromBody] User user)
        {
            studentDAO = new StudentDAO(_context);
            studentDAO.SendEmail(user.Email, "❁→❝Solicitud de inscripción En Espera❞❁",
                          "<html><body ><h1>Estimado/a " + user.Name + "</h1><br/>" +
                          "<br/><h3>Sede: Atlántico<br/>" +
                          "<br/>Queremos informarle que su solicitud de inscripción a la carrera de Informática Empresarial se encuentra en estado de espera hasta que uno de nuestros administradores revise su solicitud...<br/>" +
                          "<br/>En caso de que su solicitud sea rechazada y tenga alguna consulta con el resultado del registro, puede contactarse con el servicio de atención en la página oficial de Orientación y Registro(https://ori.ucr.ac.cr/), o bien, con el coordinador de la carrera mediante correo institucional(alvaro.mena@ucr.ac.cr)<br/>" +
                          "<br/>- Oficina de Orientación y Registro.</h3></body></html>");
            return Ok(studentDAO.AddStudent(user));
        }

        public ActionResult GetWaitingStudents()
        {
            studentDAO = new StudentDAO(_context);
            return Ok(studentDAO.GetWaitingStudents());
        }

        public ActionResult GetStudentById(string id)
        {
            studentDAO = new StudentDAO(_context);
            return Ok(studentDAO.GetStudentById(id));
        }

        public ActionResult UpdateApprovalAcceptDenyStudent([FromBody] User user)
        {
            studentDAO = new StudentDAO(_context);
            var oldUser = studentDAO.GetStudentById(user.IdCard);
            user.Password = oldUser.Password;
            user.Phone = oldUser.Phone;
            user.Address = oldUser.Address;
            studentDAO.RemoveStudent(oldUser);
            if (user.Approval == "Aceptado")
            {
                user.Activity = true;
                int resultToReturn = studentDAO.EditStudent(user);
                studentDAO.SendEmail(user.Email, "❁→❝Solicitud de inscripción Aceptada❞❁",
               "<html><body ><h1>Estimado/a " + user.Name + "</h1><br/>" +
               "<br/><h3>Sede: Atlántico<br/>" +
               "<br/>Queremos informarle que su solicitud de inscripción a la carrera de Informática ha sido aceptada con éxito, por este medio le recordamos de igual manera que su carné estudiantil es " + user.IdCard + ", el cuál será de suma importancia para los trámites oficiales dentro de la Universidad <br/>" +
               "<br/>Le pedimos porfavor que verifique la carrera en el sitio oficial de E-Matrícula(https://ematricula.ucr.ac.cr/ematricula/) con motivo del cercano proceos de matrícula. Así mismo registrarse en el sitio oficial de la universidad para el manejo de cada curso, Mediación Virtual(https://mv1.mediacionvirtual.ucr.ac.cr/login/index.php)<br/>" +
               "<br/>- Oficina de Orientación y Registro.</h3></body></html>");
                return Ok(resultToReturn);
            }
            else
            {
                user.Activity = false;
                int resultToReturn = studentDAO.EditStudent(user);
                studentDAO.SendEmail(user.Email, "❁→❝Solicitud de inscripción Rechazada❞❁",
                               "<html><body ><h1>Estimado/a " + user.Name + "</h1><br/>" +
                               "<br/><h3>Sede: Atlántico<br/>" +
                               "<br/>Queremos informarle que su solicitud de inscripción a la carrera de Informática ha sido rechazada, por lo tanto su actividad dentro de la carrera estará automaticamente inactivo dentro de los registros de la carrera <br/>" +
                               "<br/>En caso de tener una consulta con respecto al resultado de su solicitud, porfavor consultar con la Oficina de Orientación y Registros(https://ori.ucr.ac.cr/) o bien al coordinador de la carrera(alvaro.mena@ucr.ac.cr)<br/>" +
                               "<br/>- Oficina de Orientación y Registro.</h3></body></html>");
                return Ok(resultToReturn);
            }
        }

        public ActionResult UpdateStudent([FromBody] User user)
        {
            studentDAO = new StudentDAO(_context);
            var oldUser = studentDAO.GetStudentById(user.IdCard);
            user.LastName = oldUser.LastName;
            user.Password = oldUser.Password;
            user.Rol = oldUser.Rol;
            user.Address = oldUser.Address;
            user.Activity = oldUser.Activity;
            user.DateTime = oldUser.DateTime;
            user.Approval = oldUser.Approval;
            user.Photo = oldUser.Photo;
            studentDAO.RemoveStudent(oldUser);
            int resultToReturn = studentDAO.EditStudent(user);
            return Ok(resultToReturn);
        }

        public ActionResult UpdateActivityStudent([FromBody] User user)
        {
            studentDAO = new StudentDAO(_context);
            var oldUser = studentDAO.GetStudentById(user.IdCard);
            user.LastName = oldUser.LastName;
            user.Password = oldUser.Password;
            user.Rol = oldUser.Rol;
            user.Address = oldUser.Address;
            user.DateTime = oldUser.DateTime;
            user.Approval = oldUser.Approval;
            user.Presidency = oldUser.Presidency;
            user.Photo = oldUser.Photo;
            if (user.Activity == true)
            {
                user.Activity = false;
            }
            else
            {
                user.Activity = true;
            }
            studentDAO.RemoveStudent(oldUser);
            int resultToReturn = studentDAO.EditStudent(user);
            return Ok(resultToReturn);
        }

        public ActionResult DeleteStudent([FromBody] User user)
        {
            studentDAO = new StudentDAO(_context);
            var newUser = studentDAO.GetStudentById(user.IdCard);
            return Ok(studentDAO.RemoveStudent(newUser));
        }

        public ActionResult SendConsult([FromBody] ProfessorConsultation professorConsultation)
        {
            studentDAO = new StudentDAO(_context);
            var professor = studentDAO.GetStudentById(professorConsultation.IdCardProffesor);
            studentDAO.SendEmail(professor.Email, "❁→❝Solicitud de consulta❞❁",
                          "<html><body ><h1>Estimado/a " + professor.Name + " " + professor.LastName + "</h1><br/>" +
                          "<br/><h3>El estudiante " + professorConsultation.IdCardStudent + " - " + professorConsultation.StudentName + " le solicita lo siguiente:<br/>" +
                          "<br/>" + professorConsultation.ConsultationText + "<br/>" +
                          "<br/>Usted debe aceptar o rechazar esta consulta desde la página.</h3></body></html>");
            return Ok(studentDAO.AddProfessorConsultation(professorConsultation));
        }

        [HttpPost]
        public string SaveStudentPhoto(FileUpload fileObj)
        {
            User identityUserObject = JsonConvert.DeserializeObject<User>(fileObj.IdentityUser);
            if (fileObj.File.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    fileObj.File.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    identityUserObject.Photo = fileBytes;
                    studentDAO = new StudentDAO(_context);
                    var newUser = studentDAO.GetStudentById(identityUserObject.IdCard);
                    newUser.Photo = identityUserObject.Photo;
                    newUser = studentDAO.SaveStudentPhoto(newUser);
                    if (newUser.Id > 0)
                    {
                        return "Saved";
                    }
                }
            }
            return "Failed";
        }

        [HttpGet]
        public JsonResult GetSavedStudentPhoto(string ID)
        {
            studentDAO = new StudentDAO(_context);
            var user = studentDAO.GetSavedStudentPhoto(ID);
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

    }
}
