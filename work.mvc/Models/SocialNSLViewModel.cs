using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work.entity;

namespace work.mvc.Models
{
    public class SocialNSLViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public List<SocialNSList> Snsl { get; set; }
    }
}
