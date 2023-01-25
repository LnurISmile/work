using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work.entity;

namespace work.mvc.Models
{
    public class ReadyBonusListViewModel
    {
        public List<BonusReady> BonusReadies { get; set; }
        public string BonusName { get; set; }
        public double BonusAmount { get; set; }
        public double BonusPercent { get; set; }

        public double Hourly_Amount { get; set; }
        public int Work_Hour { get; set; }
        public int Work_Day { get; set; }
    }
}
