using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebAPIProject.Models.Entities
{
    public partial class NewsComment
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string TextContent { get; set; }
        public int? NewsId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
    }
}
