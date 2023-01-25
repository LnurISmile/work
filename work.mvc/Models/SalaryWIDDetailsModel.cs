using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using work.entity;
using work.mvc.Identity;

namespace work.mvc.Models
{
    public class SalaryWIDDetailsModel
    {
        public string UserId { get; set; }
        public int TimeZoneId { get; set; }
        public double Full_Salary { get; set; }
        public double Hourly_Salary { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public List<User> Users { get; set; }
        public List<TimeZones> TimeZones { get; set; }
    }
}
