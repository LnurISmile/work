using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using work.entity;

namespace work.data.Concrete.EfCore
{
    public class WorkContext : DbContext
    {
        public WorkContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<BodyDimensions> bodyds { get; set; }
        public DbSet<Children> children { get; set; }
        public DbSet<College> colleges { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<DrivingLicense> dls { get; set; }
        public DbSet<Email> emails { get; set; }
        public DbSet<MobilePhone> mphones { get; set; }
        public DbSet<School> schools { get; set; }
        public DbSet<SocialNetwork> snetworks { get; set; }
        public DbSet<University> unis { get; set; }
        public DbSet<WorkEXP> exps { get; set; }
        public DbSet<Salary> salary { get; set; }
        public DbSet<OtherSkills> oskills { get; set; }
        public DbSet<SocialNSList> socialnslist { get; set; }
        public DbSet<Archive> archives { get; set; }
        public DbSet<Penalty> penalties { get; set; }
        public DbSet<PenaltyReady> penaltyready { get; set; }
        public DbSet<TimeZones> timeZones { get; set; }
        public DbSet<Bonus> bonus { get; set; }
        public DbSet<BonusReady> bonusreadies { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Seed();
        //}
    }
}
