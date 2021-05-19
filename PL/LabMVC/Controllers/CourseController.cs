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
    public class CourseController : Controller
    {
        private readonly ALDIFA_SOFT_MVC_IF4101Context _context;
        CourseDAO courseDAO;

        public CourseController(ALDIFA_SOFT_MVC_IF4101Context context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetExplicitCourse()
        {
            courseDAO = new CourseDAO(_context);
            return Ok(courseDAO.GetExplicitCourse());
        }

        public ActionResult GetCourses()
        {
            courseDAO = new CourseDAO(_context);
            return Ok(courseDAO.GetCourses());
        }

        public ActionResult GetCourseById(string id)
        {
            courseDAO = new CourseDAO(_context);
            return Ok(courseDAO.GetCourseById(id));
        }

        public IActionResult AddCourse([FromBody] Course course)
        {
            courseDAO = new CourseDAO(_context);
            return Ok(courseDAO.AddCourse(course));
        }

        public ActionResult EditCourse([FromBody] Course course)
        {
            courseDAO = new CourseDAO(_context);
            var oldUser = courseDAO.GetCourseById(course.Initials);
            courseDAO.RemoveCourse(oldUser);
            int resultToReturn = courseDAO.EditCourse(course);
            return Ok(resultToReturn);

        }

        public IActionResult RemoveCourse(string id)
        {
            courseDAO = new CourseDAO(_context);
            var courseSearch = courseDAO.GetCourseById(id);
            return Ok(courseDAO.RemoveCourse(courseSearch));
        }

        public ActionResult GetCoursesBySemester()
        {
            courseDAO = new CourseDAO(_context);
            return Ok(courseDAO.GetCoursesBySemester());
    }
}
}
