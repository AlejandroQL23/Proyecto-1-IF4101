using LabMVC.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        /// <param name="context"></param>
        public ForumDAO(ALDIFA_SOFT_MVC_IF4101Context context)
        {
            _context = context;
        }

        public IEnumerable<Entities.ForumComment> GetForumComments()
        {
            var forum = (from forumComment in _context.ForumComments select forumComment);
            return forum.ToList();
        }

        public Entities.ForumComment GetForumCommentById(int identification) //INT STRING .ID
        {
            var forum = (from forumComment in _context.ForumComments where forumComment.Id == identification select forumComment);
            return forum.FirstOrDefault();
        }

        public int AddForumComment(Entities.ForumComment forums)
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

    }
}
