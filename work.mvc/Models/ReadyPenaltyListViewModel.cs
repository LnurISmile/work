using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work.entity;
using work.mvc.Identity;

namespace work.mvc.Models
{
    public class ReadyPenaltyListViewModel
    {
        public List<PenaltyReady> PenaltyReadies { get; set; }
        public string PenaltyName { get; set; }
        public double PenaltyAmount { get; set; }
    }
}
