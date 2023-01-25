using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work.mvc.Identity;

namespace work.mvc.Models
{
    public class UniDetailsModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UniversityLevel { get; set; }
        public string UniversityName { get; set; }
        public string UniversitySpecialty { get; set; }
        public DateTime Uni_StartDate { get; set; }
        public DateTime Uni_CompletionDate { get; set; }
        public string ImgUrl { get; set; }
        public string PDFUrl { get; set; }
        public List<User> Users { get; set; }
    }
}
