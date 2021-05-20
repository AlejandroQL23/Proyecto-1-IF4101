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
    public class ForumCommentController : Controller
    {
        private readonly ALDIFA_SOFT_MVC_IF4101Context _context;
        ForumDAO forumCommentDAO;

        public ForumCommentController(ALDIFA_SOFT_MVC_IF4101Context context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetForum()
        {
            forumCommentDAO = new ForumDAO(_context);
            return Ok(forumCommentDAO.GetForumComments());
        }

        public ActionResult GetForumById(int id)
        {
            forumCommentDAO = new ForumDAO(_context);
            return Ok(forumCommentDAO.GetForumCommentById(id));
        }

        public IActionResult AddForumComment([FromBody] ForumComment forumComment)
        {
            forumCommentDAO = new ForumDAO(_context);
            return Ok(forumCommentDAO.AddForumComment(forumComment));
        }

    }
}
