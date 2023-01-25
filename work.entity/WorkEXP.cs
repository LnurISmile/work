using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work.entity
{
    public class WorkEXP
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Company { get; set; }
        public string Employer { get; set; }
        public DateTime Start { get; set; }
        public DateTime Resignation { get; set; }
        public string CVPDF { get; set; }
    }
}
