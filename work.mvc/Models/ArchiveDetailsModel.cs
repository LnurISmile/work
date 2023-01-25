using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work.entity;
using work.mvc.Identity;

namespace work.mvc.Models
{
    public class ArchiveDetailsModel
    {
        public string UserId { get; set; }
        public DateTime SalaryDate { get; set; }
        public double Salary { get; set; }
        public bool Type { get; set; }
        public string Description { get; set; }
        public List<User> Users { get; set; }
        public List<Salary> Salaries { get; set; }
        public List<Penalty> Penalties { get; set; }
        public List<TimeZones> TimeZones { get; set; }
        public List<Archive> Archives { get; set; }
    }
}
