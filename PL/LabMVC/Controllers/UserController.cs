using LabMVC.Models.Data;
using LabMVC.Models.Domain;
using LabMVC.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ALDIFA_SOFT_MVC_IF4101Context _context;
        StudentDAO studentDAO;


        public UserController(ALDIFA_SOFT_MVC_IF4101Context context)
        {
            _context = context;
        }
        // GET: UserController
        [HttpPost]
        public IActionResult Index([FromBody] Models.Domain.User user)
        {

            studentDAO = new StudentDAO(_context);
            var localUser = studentDAO.GetStudentById(user.IdCard);
            if (studentDAO.StudentExistsUserName(user.IdCard) == true && studentDAO.StudentExistsPassword(user.Password) == true)
            {
                HttpContext.Session.SetString("rol", localUser.Rol);
                return RedirectToAction("Index", "Student");
            }


            return View();



        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
