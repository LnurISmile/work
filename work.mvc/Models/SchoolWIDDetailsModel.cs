using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work.mvc.Identity;

namespace work.mvc.Models
{
    public class SchoolWIDDetailsModel
    {
        public string UserId { get; set; }
        public string SchoolName { get; set; }
        public DateTime School_StartDate { get; set; }
        public DateTime School_CompletionDate { get; set; }
        public string ImgUrl { get; set; }
        public string PDFUrl { get; set; }
        public List<User> Users { get; set; }
    }
}
