using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work.entity;
using work.mvc.Identity;

namespace work.mvc.Models
{
    public class WorkWIDDetailsModel
    {
        public string UserId { get; set; }
        public string Company { get; set; }
        public string Employer { get; set; }
        public DateTime Start { get; set; }
        public DateTime Resignation { get; set; }
        public string CVPDF { get; set; }
        public List<User> Users { get; set; }
        public List<OtherSkills> OSkills { get; set; }
        public OtheSkillsDetailsModel os { get; set; }
    }
}
