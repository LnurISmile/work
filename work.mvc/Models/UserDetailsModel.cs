using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work.entity;
using work.mvc.Identity;

namespace work.mvc.Models
{
    public class UserDetailsModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }
        public bool EmailConfirmed { get; set; }

        public string CitizenShip { get; set; }  //  vətəndaşlıq
        public DateTime DoB { get; set; }
        public string SerialNumber { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime PeriodOfValidity { get; set; }  // etibarlılıq müddəti
        public string BloodGroup { get; set; }
        public string ARAddress { get; set; }  // faktiki yaşayış yeri
        public string OtherSkills { get; set; }

        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string MaritalStatus { get; set; }
        public string Spouse { get; set; }  // həyat yoldaşı

        public bool IsApproved { get; set; }
        public string ImgUrl { get; set; }
        public string PDFUrl { get; set; }

        public IEnumerable<string> SelectedRoles { get; set; }

        public FamilyDetailsModel fdm { get; set; }
        public List<Children> Family { get; set; }
        public List<College> College { get; set; }//
        public List<University> Uni { get; set; }//
        public List<Course> Course { get; set; }//
        public List<WorkEXP> WorkEXP { get; set; }//
        public List<MobilePhone> MobilePhone { get; set; }//
        public List<Email> Emails { get; set; }//
        public List<BodyDimensions> BodyD { get; set; }
        public List<Salary> Salary { get; set; }
        public List<User> Users { get; set; }

        public double Percent { get; set; }
        
        public double PercentID { get; set; }  // ID faiz
        public double PercentF { get; set; }  // Family faiz
        public double PercentBD { get; set; }  // Body D. faiz
        public double PercentDl { get; set; }  // Driving L. faiz
        public double PercentS { get; set; }  // School faiz
        public double P { get; set; }
    }
}
