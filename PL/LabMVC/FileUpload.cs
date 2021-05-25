using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabMVC.Models.Entities
{
    public class FileUpload
    {
        public IFormFile file { get; set; }
        public string identityUser { get; set; }

    }
}
