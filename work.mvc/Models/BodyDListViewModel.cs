using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work.entity;
using work.mvc.Identity;

namespace work.mvc.Models
{
    public class BodyDListViewModel
    {
        public List<User> Users { get; set; }
        public List<BodyDimensions> BodyD { get; set; }
    }
}
