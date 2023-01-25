using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work.entity;
using work.mvc.Identity;

namespace work.mvc.Models
{
    public class BonusDetailsModel
    {
        public string UserId { get; set; }
        public double BonusAmount { get; set; }
        public double BonusPercent { get; set; }
        public string Description { get; set; }
        public DateTime FinishDate { get; set; }
        public List<User> Users { get; set; }
        public List<BonusReady> BonusReadies { get; set; }
        public int BonusId { get; set; }
    }
}
