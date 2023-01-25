using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work.entity;
using work.mvc.Identity;

namespace work.mvc.Models
{
    public class SalaryListViewModel
    {
        public List<User> Users { get; set; }
        public List<TimeZones> TimeZones { get; set; }
        public List<Salary> Salaries { get; set; }
    }
}
