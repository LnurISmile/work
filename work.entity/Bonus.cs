using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work.entity
{
    public class Bonus
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public double BonusAmount { get; set; }
        public double BonusPercent { get; set; }
        public string Description { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
