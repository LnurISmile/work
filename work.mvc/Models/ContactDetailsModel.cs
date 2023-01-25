using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work.entity;

namespace work.mvc.Models
{
    public class ContactDetailsModel
    {
        public string UserId { get; set; }
        public string Emails { get; set; }
        public string MobileNumber { get; set; }
        public string SocialNetworkName { get; set; }
        public string Link { get; set; }
        public List<MobilePhone> Mp { get; set; }
        public List<Email> Em { get; set; }
        public List<SocialNetwork> Sn { get; set; }
        public List<SocialNSList> Snsl { get; set; }

    }
}
