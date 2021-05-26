using System;
using System.Collections.Generic;

namespace WebAPIProject.Models.Entities
{
    public partial class NewsComment
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string TextContent { get; set; }
        public int? NewsId { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
