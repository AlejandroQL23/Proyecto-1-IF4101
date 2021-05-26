using ALDIFASOFT_MVC.Models.Entities;
using LabMVC.Models.Data;
using LabMVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult AddForumComment([FromBody] ForumComment forumComment)
        {
            forumCommentDAO = new ForumDAO(_context);
            return Ok(forumCommentDAO.AddForumComment(forumComment));
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

        public IActionResult AddForumCommentAnswer([FromBody] ForumCommentAnswer forumCommentAnswer)
        {
            forumCommentDAO = new ForumDAO(_context);
            return Ok(forumCommentDAO.AddForumCommentAnswer(forumCommentAnswer));
        }

        public ActionResult GetForumAnswer(int Id)
        {
            forumCommentDAO = new ForumDAO(_context);
            return Ok(forumCommentDAO.GetForumCommentsAnswer(Id));
        }

    }
}
