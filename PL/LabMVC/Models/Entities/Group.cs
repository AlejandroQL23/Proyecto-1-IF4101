using System;
using System.Collections.Generic;

#nullable disable

namespace ALDIFASOFT_MVC.Models.Entities
{
    public partial class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public int? ScheduleId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }
    }
}
