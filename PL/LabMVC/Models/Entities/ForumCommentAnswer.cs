using System;
using System.Collections.Generic;

#nullable disable

namespace LabMVC.Models.Entities
{
    public partial class ForumCommentAnswer
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public int? IdComment { get; set; }
        public string TextContent { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
    }
}
