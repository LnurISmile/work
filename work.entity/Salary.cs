using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work.entity
{
    public class Salary
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int TimeZoneId { get; set; }
        public double Full_Salary { get; set; }
        public double Hourly_Salary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
