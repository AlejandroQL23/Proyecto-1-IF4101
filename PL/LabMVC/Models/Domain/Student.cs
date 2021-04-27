using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabMVC.Models.Domain
{
    public class Student
    {
        private int id;
        private string name;
        private string email;
        private string password;
        private string nationality;
        private string major;


        public Student() { 
       }

        public Student(int id, string name, string email, string password, string nationality, string major)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Nationality = nationality;
            this.Major = major;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Nationality { get => nationality; set => nationality = value; }
        public string Major { get => major; set => major = value; }
    }
}
