using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work.entity;
using work.mvc.Identity;

namespace work.mvc.Models
{
    public class WorkerDetailModel
    {
        public User User { get; set; }
        public List<User> UserList { get; set; }
        public BodyDimensions BodyD { get; set; }
        public List<BodyDimensions> BodyDList { get; set; }
        public DrivingLicense DL { get; set; }
        public List<DrivingLicense> DLList { get; set; }

        public Children Children { get; set; }
        public List<Children> ChildrenList { get; set; }

        public School School { get; set; }
        public List<School> SchoolList { get; set; }
        public College College { get; set; }
        public List<College> CollegeList { get; set; }
        public Course Course { get; set; }
        public List<Course> CourseList { get; set; }
        public University University { get; set; }
        public List<University> UniversityList { get; set; }


        public Email Email { get; set; }
        public List<Email> EmailList { get; set; }
        public MobilePhone MobilePhone { get; set; }
        public List<MobilePhone> MPhoneList { get; set; }
        public SocialNetwork SocialNetwork { get; set; }
        public List<SocialNetwork> SocialNList{ get; set; }
        public List<SocialNSList> SNSLList{ get; set; }

        public Salary Salary { get; set; }
        public List<Salary> SalaryList { get; set; }
        public List<TimeZones> TimeZonesList { get; set; }
        public TimeZones TimeZone { get; set; }

        public WorkEXP WorkEXP { get; set; }
        public List<WorkEXP> WorkList { get; set; }
        public OtherSkills OtherSkills { get; set; }
        public List<OtherSkills> OSkillsList { get; set; }
    }
}
