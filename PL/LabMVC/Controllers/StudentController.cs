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

        public ActionResult GetExplicitStudent()
        {
            studentDAO = new StudentDAO(_context);
            return Ok(studentDAO.GetExplicitStudent());
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

        public ActionResult UpdateApprovalAcceptDenyStudent([FromBody] User user)
        {
            studentDAO = new StudentDAO(_context);
            var oldUser = studentDAO.GetStudentById(user.IdCard);
            user.Password = oldUser.Password;
            user.Phone = oldUser.Phone;
            user.Address = oldUser.Address;
           // user.Presidency = oldUser.Presidency;
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
            //tofo
            studentDAO.RemoveStudent(oldUser);
            int resultToReturn = studentDAO.EditStudent(user);
            return Ok(resultToReturn);
        }

    }
}
