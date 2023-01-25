using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work.entity
{
    public class DrivingLicense
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string IssuingAuthority { get; set; }
        public string DL_SerialNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Categories { get; set; }
        public string ImgUrl { get; set; }
        public string PDFUrl { get; set; }
        public double PercentDL { get; set; }
    }
}
