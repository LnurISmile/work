using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace work.mvc.Identity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string CitizenShip { get; set; }  //  vətəndaşlıq
        public DateTime DoB { get; set; }
        public string SerialNumber { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime PeriodOfValidity { get; set; }  // etibarlılıq müddəti
        public string BloodGroup { get; set; }
        public string ARAddress { get; set; }  // faktiki yaşayış yeri

        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string MaritalStatus { get; set; }
        public string Spouse { get; set; }    // həyat yoldaşı

        public bool IsApproved { get; set; }
        public string ImgUrl { get; set; }
        public string PDFUrl { get; set; }

        public double PercentID { get; set; }  // ID faiz
        public double PercentF { get; set; }  // Family faiz
        public double PercentBD { get; set; }  // Body D. faiz
        public double PercentDl { get; set; }  // Driving L. faiz
        public double PercentS { get; set; }  // School faiz



    }
}
