using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabMVC.Models.Domain
{
    public class Major
    {

        private int id;
        private string code;
        private string name;

        public Major(int id, string code, string name)
        {
            this.Id = id;
            this.Code = code;
            this.Name = name;
        }
        public Major()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
    }
}
