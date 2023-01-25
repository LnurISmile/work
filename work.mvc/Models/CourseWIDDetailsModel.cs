using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work.mvc.Identity;

namespace work.mvc.Models
{
    public class CourseWIDDetailsModel
    {
        public string UserId { get; set; }
        public string CourseName { get; set; }
        public string CourseOnWhat { get; set; }
        public DateTime Course_StartDate { get; set; }
        public DateTime Course_UCompletionDate { get; set; }
        public string ImgUrl { get; set; }
        public string PDFUrl { get; set; }
        public List<User> Users { get; set; }
    }
}
