using LabMVC.Models;
using LabMVC.Models.Data;
using LabMVC.Models.Domain;
using LabMVC15_04_2021.Models.DomainD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace LabMVC.Controllers
{
    public class HomeController : Controller
    {
        StudentDAO studentDAO;
        ProfessorDAO professorDAO;
        CourseDAO courseDAO;

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

        public IActionResult LoginAuthentication(User user)
        {
            if (studentDAO.loginAuthentication(user.IdCard, user.Password))
            {
                return Ok();
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
