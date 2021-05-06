using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabMVC.Models.Domain
{
    public class User
    {
        private int id;
        private string idCard;
        private string name;
        private string lastName;
        private string email;
        private string password;
        private string rol;
        private string phone;
        private string address;
        private int activity;
        private string approval;
        private int presidency;
        private string personalFormation;
        private string dateTime;
        private string instagram;
        private string facebook;      
        private string picture;


        
        public User(int id, string idCard, string name, string lastName, string email, string password, string rol, string phone, string address, int activity, string approval, int presidency, string personalFormation, string dateTime, string instagram, string facebook, string picture)
        {
            this.Id = id;
            this.IdCard = idCard;
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
            this.Rol = rol;
            this.Phone = phone;
            this.Address = address;
            this.Activity = activity;
            this.Approval = approval;
            this.Presidency = presidency;
            this.PersonalFormation = personalFormation;
            this.DateTime = dateTime;
            this.Instagram = instagram;
            this.Facebook = facebook;
            this.Picture = picture;
        }


        public User()
        {


        }
        public int Id { get => id; set => id = value; }
        public string IdCard { get => idCard; set => idCard = value; }
        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Rol { get => rol; set => rol = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public int Activity { get => activity; set => activity = value; }
        public string Approval { get => approval; set => approval = value; }
        public int Presidency { get => presidency; set => presidency = value; }
        public string PersonalFormation { get => personalFormation; set => personalFormation = value; }
        public string DateTime { get => dateTime; set => dateTime = value; }
        public string Instagram { get => instagram; set => instagram = value; }
        public string Facebook { get => facebook; set => facebook = value; }
        public string Picture { get => picture; set => picture = value; }
    }
}
