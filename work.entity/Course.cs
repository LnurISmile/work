using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work.entity
{
    public class Course
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CourseName { get; set; }
        public string CourseOnWhat { get; set; }
        public DateTime Course_StartDate { get; set; }
        public DateTime Course_UCompletionDate { get; set; }
        public string ImgUrl { get; set; }
        public string PDFUrl { get; set; }
    }
}
