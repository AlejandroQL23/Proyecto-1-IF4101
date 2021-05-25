using System;
using System.Collections.Generic;

#nullable disable

namespace LabMVC.Models.Entities
{
    public partial class News
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string TextContent { get; set; }
        public string Category { get; set; }
        public byte[] ExtraFile { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
