using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work.entity;
using work.mvc.Identity;

namespace work.mvc.Models
{
    public class PenaltyDetailsModel
    {
        public string UserId { get; set; }
        public double PenaltyAmount { get; set; }
        public string Description { get; set; }
        public DateTime FinishDate { get; set; }
        public List<User> Users { get; set; }
        public List<PenaltyReady> PenaltyReadies { get; set; }
        public int PenaltyId { get; set; }
    }
}
