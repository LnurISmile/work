using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work.mvc.Identity;

namespace work.mvc.Models
{
    public class DrivingLWIDDetailsModel
    {
        public string UserId { get; set; }
        public string IssuingAuthority { get; set; }
        public string DL_SerialNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Categories { get; set; }
        public string ImgUrl { get; set; }
        public string PDFUrl { get; set; }

        public List<User> Users { get; set; }
    }
}
