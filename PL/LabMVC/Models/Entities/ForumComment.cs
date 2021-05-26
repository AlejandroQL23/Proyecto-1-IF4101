using System;
using System.Collections.Generic;

#nullable disable

namespace LabMVC.Models.Entities
{
    public partial class ForumComment
    {
        public int Id { get; set; }
        public string CourseInitials { get; set; }
        public string Author { get; set; }
        public string TextContent { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
    }
}
