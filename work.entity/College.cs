using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work.entity
{
    public class College
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CollegeName { get; set; }
        public string CollegeSpecialty { get; set; }
        public DateTime College_StartDate { get; set; }
        public DateTime College_CompletionDate { get; set; }
        public string ImgUrl { get; set; }
        public string PDFUrl { get; set; }
    }
}
