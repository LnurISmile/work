using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work.entity;
using work.mvc.Identity;

namespace work.mvc.Models
{
    public class WorkListViewModel
    {
        public List<User> Users { get; set; }
        public List<WorkEXP> Wexp { get; set; }
        public List<OtherSkills> Oskills { get; set; }
    }
}
