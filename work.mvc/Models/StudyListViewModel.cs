using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work.entity;
using work.mvc.Identity;

namespace work.mvc.Models
{
    public class StudyListViewModel
    {
        public List<User> Users { get; set; }
        public List<School> Schools { get; set; }
        public List<College> Colleges { get; set; }
        public List<University> Universities { get; set; }
        public List<Course> Courses { get; set; }
    }
}
