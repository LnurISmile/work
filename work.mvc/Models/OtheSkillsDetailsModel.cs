using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work.mvc.Identity;

namespace work.mvc.Models
{
    public class OtheSkillsDetailsModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Skill { get; set; }
        //public List<User> Users { get; set; }
    }
}
