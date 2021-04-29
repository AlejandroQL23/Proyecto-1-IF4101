using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabMVC.Models.Domain
{
    public class Nationality
    {
        private int id;
        private string name;

        public Nationality(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Nationality()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
