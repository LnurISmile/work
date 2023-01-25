using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work.entity
{
    public class Archive
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime SalaryDate { get; set; }
        public double Salary { get; set; }
        public bool Type { get; set; }
        public string Description { get; set; }
    }
}
