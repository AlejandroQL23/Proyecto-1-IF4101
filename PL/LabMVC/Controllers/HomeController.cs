using LabMVC.Models;
using LabMVC.Models.Data;
using LabMVC.Models.Domain;
using LabMVC15_04_2021.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace LabMVC.Controllers
{
   

    public class HomeController : Controller
    {
        StudentDAO studentDAO;
        MajorDAO majorDAO;
        NationalityDAO nationalityDAO;
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

        public IActionResult GetMajors()
        {
            majorDAO = new MajorDAO(_configuration);
            List<Major> majors = new List<Major>();
            majors = majorDAO.Get();
            return Json(majors);
        }

        public IActionResult GetNationality()
        {
            nationalityDAO = new NationalityDAO(_configuration);
            List<Nationality> nationality = new List<Nationality>();
            nationality = nationalityDAO.Get();
            return Json(nationality);
        }


        public IActionResult Insert([FromBody] Student student)
        {
            try
            {
                //llamada viene de la vista, este es el intermediario
                //este metodo llama al modelo (BD)

                //regla de negocio, simulemos que ya existe e@e.com
                studentDAO = new StudentDAO(_configuration);

                if (studentDAO.VerifyEmail(student.Email))
                {
                    return Error();
                }
                else
                {
                    int resultToReturn = studentDAO.Insert(student);
                    // aca guardamos un 1 o un 0 dependiendo de si se inserto  el estudiante o no

                    return Ok(resultToReturn);// return Ok(resultToReturn);//retornamos el 1 o el 0 a la vista
                }

            }
            catch (Exception ex)
            {
                studentDAO.ExceptionMethod(ex);
            }
            return Ok();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
