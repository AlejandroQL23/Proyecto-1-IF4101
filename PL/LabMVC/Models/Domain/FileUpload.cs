using Microsoft.AspNetCore.Http;

namespace LabMVC.Models.Entities
{
    public class FileUpload
    {
        public IFormFile File { get; set; }
        public string IdentityUser { get; set; }

    }
}
