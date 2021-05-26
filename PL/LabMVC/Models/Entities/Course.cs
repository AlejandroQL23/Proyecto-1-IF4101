using System;
using System.Collections.Generic;

#nullable disable

namespace ALDIFASOFT_MVC.Models.Entities
{
    public partial class Course
    {
        public int Id { get; set; }
        public string Initials { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public string Semester { get; set; }
        public string ScheduleId { get; set; }
        public bool? Activity { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }
    }
}
