using ALDIFASOFT_MVC.Models.Entities;
using LabMVC.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace LabMVC.Models.Data
{
    public class ForumDAO
    {
        private readonly IConfiguration _configuration;
        private readonly ALDIFA_SOFT_MVC_IF4101Context _context;
        string connectionString;
        public ForumDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public ForumDAO()
        {
        }

        public ForumDAO(ALDIFA_SOFT_MVC_IF4101Context context)
        {
            _context = context;
        }

        public int AddForumComment(ForumComment forums)
        {
            int resultToReturn;
            try
            {
                _context.Add(forums);
                resultToReturn = _context.SaveChangesAsync().Result;
            }
            catch (DbUpdateException)
            {
                throw;
            }
            return resultToReturn;
        }

        public IEnumerable<ForumComment> GetForumComments()
        {
            var forum = (from forumComment in _context.ForumComments select forumComment);
            return forum.ToList();
        }

        public ForumComment GetForumCommentById(int identification)
        {
            var forum = (from forumComment in _context.ForumComments where forumComment.Id == identification select forumComment);
            return forum.FirstOrDefault();
        }

        public int AddForumCommentAnswer(ForumCommentAnswer forumAnswer)
        {
            int resultToReturn;
            try
            {
                _context.Add(forumAnswer);
                resultToReturn = _context.SaveChangesAsync().Result;
            }
            catch (DbUpdateException)
            {
                throw;
            }
            return resultToReturn;
        }

        public IEnumerable<ForumCommentAnswer> GetForumCommentsAnswer(int idComment)
        {
            var forum = (from forumCommentAnswer in _context.ForumCommentAnswers where forumCommentAnswer.IdComment == idComment select forumCommentAnswer);
            return forum.ToList();
        }

    }
}
