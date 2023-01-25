using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work.entity;
using work.mvc.Identity;

namespace work.mvc.Models
{
    public class ContactListViewModel
    {
        public List<User> Users { get; set; }
        public List<Email> Emails { get; set; }
        public List<MobilePhone> MobilePhones { get; set; }
        public List<SocialNetwork> SocialNetworks { get; set; }

    }
}
