﻿using System;
using System.Collections.Generic;

#nullable disable

namespace LabMVC.Models.Entities
{
    public partial class User
    {
        public User()
        {
            ForumComments = new HashSet<ForumComment>();
        }

        public int Id { get; set; }
        public string IdCard { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool? Activity { get; set; }
        public string Approval { get; set; }
        public bool? Presidency { get; set; }
        public string PersonalFormation { get; set; }
        public string DateTime { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreationUser { get; set; }
        public string UpdateUser { get; set; }
        public byte[] Photo { get; set; }
        public string Picture { get; set; }

        public virtual ICollection<ForumComment> ForumComments { get; set; }
    }
}
