using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work.entity
{
    public class University
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
    }
}
