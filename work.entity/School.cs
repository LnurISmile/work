using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work.entity
{
    public class School
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string SchoolName { get; set; }
        public DateTime School_StartDate { get; set; }
        public DateTime School_CompletionDate { get; set; }
        public string ImgUrl { get; set; }
        public string PDFUrl { get; set; }
        public double PercentSch { get; set; }

    }
}
