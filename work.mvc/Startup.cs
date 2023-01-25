//using work.business.Abstract;
//using work.business.Concrete;
using work.data.Abstract;
using work.data.Concrete.EfCore;
using work.mvc.EmailServices;
using work.mvc.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace work.mvc
{
    public class Startup
    {
        public IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(_configuration.GetConnectionString("MsSqlConnection")));
            services.AddDbContext<WorkContext>(options => options.UseSqlServer(_configuration.GetConnectionString("MsSqlConnection")));

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(365);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".Work.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBodyDRepository, EfCoreBodyDRepository>();
            services.AddScoped<IChildrenRepository, EfCoreChildrenRepository>();
            services.AddScoped<ICollegeRepository, EfCoreCollegeRepository>();
            services.AddScoped<ICourseRepository, EfCoreCourseRepository>();
            services.AddScoped<IDrivingLRepository, EfCoreDrivingLRepository>();
            services.AddScoped<IEmailRepository, EfCoreEmailRepository>();
            services.AddScoped<IMPhoneRepository, EfCoreMPhoneRepository>();
            services.AddScoped<ISchoolRepository, EfCoreSchoolRepository>();
            services.AddScoped<ISocialNRepository, EfCoreSocialNRepository>();
            services.AddScoped<IUniversityRepository, EfCoreUniversityRepository>();
            services.AddScoped<IWorkEXPRepository, EfCoreWorkEXPRepository>();
            services.AddScoped<ISocialNSListRepository, EfCoreSocialNSListRepository>();
            services.AddScoped<ISalaryRepository, EfCoreSalaryRepository>();
            services.AddScoped<IOtherSkillsRepository, EfCoreOtherSkillsRepository>();
            services.AddScoped<IPenaltyRepository, EfCorePenaltyRepository>();
            services.AddScoped<IPenaltyReadyRepository, EfCorePenaltyReadyRepository>();
            services.AddScoped<ITimeZonesRepository, EfCoreTimeZonesRepository>();
            services.AddScoped<IArchiveRepository, EfCoreArchiveRepository>();
            services.AddScoped<IBonusRepository, EfCoreBonusRepository>();
            services.AddScoped<IBonusReadyRepository, EfCoreBonusReadyRepository>();

            services.AddScoped<IEmailSender, SmtpEmailSender>(i =>
                        new SmtpEmailSender(
                            _configuration["EmailSender:Host"],
                            _configuration.GetValue<int>("EmailSender:Port"),
                            _configuration.GetValue<bool>("EmailSender:EnableSSL"),
                            _configuration["EmailSender:UserName"],
                            _configuration["EmailSender:Password"]
                            ));

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
                              IConfiguration configuration, UserManager<User> userManager,
                              RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                /////////////////////////////////////////////////// Admin //
                /////////////////////////////////////////////////// List //
                endpoints.MapControllerRoute(
                    name: "idcardlist",
                    pattern: "admin/list/idcard",
                    defaults: new { controller = "Admin", action = "IDCList" }
                    );

                endpoints.MapControllerRoute(
                     name: "idcardunapproved",
                     pattern: "admin/idcardlist/unapproved",
                     defaults: new { controller = "Admin", action = "IDCUnApproved" }
                     );

                endpoints.MapControllerRoute(
                    name: "familylist",
                    pattern: "admin/list/family",
                    defaults: new { controller = "Admin", action = "FamilyList" }
                    );

                endpoints.MapControllerRoute(
                    name: "bodydimensionslist",
                    pattern: "admin/list/bodydimensions",
                    defaults: new { controller = "Admin", action = "BodyDList" }
                    );

                endpoints.MapControllerRoute(
                    name: "studylist",
                    pattern: "admin/list/study",
                    defaults: new { controller = "Admin", action = "StudyList" }
                    );
                endpoints.MapControllerRoute(
                    name: "schoollist",
                    pattern: "admin/list/school",
                    defaults: new { controller = "Admin", action = "SchoolList" }
                    );
                endpoints.MapControllerRoute(
                    name: "collegelist",
                    pattern: "admin/list/college",
                    defaults: new { controller = "Admin", action = "CollegeList" }
                    );
                endpoints.MapControllerRoute(
                    name: "collegeeditlist",
                    pattern: "admin/college/list/{id?}",
                    defaults: new { controller = "Admin", action = "CollegeEditList" }
                    );
                endpoints.MapControllerRoute(
                    name: "unilist",
                    pattern: "admin/list/university",
                    defaults: new { controller = "Admin", action = "UniList" }
                    );
                endpoints.MapControllerRoute(
                    name: "unieditlist",
                    pattern: "admin/university/list/{id?}",
                    defaults: new { controller = "Admin", action = "UniEditList" }
                    );
                endpoints.MapControllerRoute(
                    name: "courselist",
                    pattern: "admin/list/course",
                    defaults: new { controller = "Admin", action = "CourseList" }
                    );
                endpoints.MapControllerRoute(
                    name: "courseeditlist",
                    pattern: "admin/course/list/{id?}",
                    defaults: new { controller = "Admin", action = "CourseEditList" }
                    );

                endpoints.MapControllerRoute(
                    name: "workexplist",
                    pattern: "admin/list/workexp",
                    defaults: new { controller = "Admin", action = "WorkEXPList" }
                    );

                endpoints.MapControllerRoute(
                    name: "dirivingcardlist",
                    pattern: "admin/list/dirivingcard",
                    defaults: new { controller = "Admin", action = "DCList" }
                    );

                endpoints.MapControllerRoute(
                    name: "contactlist",
                    pattern: "admin/list/contact",
                    defaults: new { controller = "Admin", action = "ContactList" }
                    );

                endpoints.MapControllerRoute(
                    name: "salarylist",
                    pattern: "admin/list/salary",
                    defaults: new { controller = "Admin", action = "SalaryList" }
                    );

                endpoints.MapControllerRoute(
                    name: "userscontact",
                    pattern: "admin/list/socialnetwork",
                    defaults: new { controller = "Admin", action = "SNList" }
                    );

                endpoints.MapControllerRoute(
                    name: "hr",
                    pattern: "admin/hr",
                    defaults: new { controller = "Admin", action = "HR" }
                    );

                endpoints.MapControllerRoute(
                    name: "users",
                    pattern: "admin/users",
                    defaults: new { controller = "Admin", action = "UserList" }
                    );

                endpoints.MapControllerRoute(
                    name: "timezones",
                    pattern: "admin/timezones",
                    defaults: new { controller = "Admin", action = "ListTimeZone" }
                    );

                endpoints.MapControllerRoute(
                   name: "penalties",
                   pattern: "admin/penalties",
                   defaults: new { controller = "Admin", action = "ListPenalty" }
                   );
                endpoints.MapControllerRoute(
                   name: "readypenalties",
                   pattern: "admin/penalties/ready",
                   defaults: new { controller = "Admin", action = "ListReadyPenalty" }
                   );

                endpoints.MapControllerRoute(
                   name: "archives",
                   pattern: "admin/archives",
                   defaults: new { controller = "Admin", action = "ListArchive" }
                   );

                endpoints.MapControllerRoute(
                   name: "bonus",
                   pattern: "admin/bonus",
                   defaults: new { controller = "Admin", action = "ListBonus" }
                   );
                endpoints.MapControllerRoute(
                   name: "readybonus",
                   pattern: "admin/bonus/ready",
                   defaults: new { controller = "Admin", action = "ListReadyBonus" }
                   );

                /////////////////////////////////////////////////// Edit //
                endpoints.MapControllerRoute(
                    name: "studyeditlist",
                    pattern: "admin/user/salaryedit/{id?}",
                    defaults: new { controller = "Admin", action = "EditSalaryUser" }
                    );

                endpoints.MapControllerRoute(
                    name: "studyeditlist",
                    pattern: "admin/user/studyeditlist/{id?}",
                    defaults: new { controller = "Admin", action = "EditStudyList" }
                    );
                endpoints.MapControllerRoute(
                    name: "schooledit",
                    pattern: "admin/user/schooledit/{id?}",
                    defaults: new { controller = "Admin", action = "EditScUser" }
                    );
                endpoints.MapControllerRoute(
                    name: "collegeedit",
                    pattern: "admin/user/collegeedit/{id?}",
                    defaults: new { controller = "Admin", action = "EditColUser" }
                    );
                endpoints.MapControllerRoute(
                    name: "universityedit",
                    pattern: "admin/user/universityedit/{id?}",
                    defaults: new { controller = "Admin", action = "EditUniUser" }
                    );
                endpoints.MapControllerRoute(
                    name: "courseedit",
                    pattern: "admin/user/courseedit/{id?}",
                    defaults: new { controller = "Admin", action = "EditCosUser" }
                    );

                endpoints.MapControllerRoute(
                    name: "contactedit",
                    pattern: "admin/user/contactedit/{id?}",
                    defaults: new { controller = "Admin", action = "EditCUser" }
                    );

                endpoints.MapControllerRoute(
                    name: "workexpedit",
                    pattern: "admin/user/workexpedit/{id?}",
                    defaults: new { controller = "Admin", action = "EditWEUser" }
                    );

                endpoints.MapControllerRoute(
                    name: "drivingledit",
                    pattern: "admin/user/drivingledit/{id?}",
                    defaults: new { controller = "Admin", action = "EditDLUser" }
                    );

                endpoints.MapControllerRoute(
                    name: "bodydedit",
                    pattern: "admin/user/bodydedit/{id?}",
                    defaults: new { controller = "Admin", action = "EditBDUser" }
                    );

                endpoints.MapControllerRoute(
                    name: "familyedit",
                    pattern: "admin/user/familyedit/{id?}",
                    defaults: new { controller = "Admin", action = "EditFUser" }
                    );

                endpoints.MapControllerRoute(
                    name: "idcedit",
                    pattern: "admin/user/idcedit/{id?}",
                    defaults: new { controller = "Admin", action = "EditIDCUser" }
                    );

                endpoints.MapControllerRoute(
                    name: "edittimezone",
                    pattern: "admin/edit/timezone/{id?}",
                    defaults: new { controller = "Admin", action = "EditTimezone" }
                    );

                endpoints.MapControllerRoute(
                    name: "edituser",
                    pattern: "admin/user/edit/{id?}",
                    defaults: new { controller = "Admin", action = "EditUser" }
                    );

                /////////////////////////////////////////////////// Create //
                endpoints.MapControllerRoute(
                    name: "createuser",
                    pattern: "admin/user/create",
                    defaults: new { controller = "Admin", action = "CreateUser" }
                    );

                endpoints.MapControllerRoute(
                    name: "createsalary",
                    pattern: "admin/salary/create",
                    defaults: new { controller = "Admin", action = "CreateSalary" }
                    );
                endpoints.MapControllerRoute(
                   name: "salarycreate",
                   pattern: "admin/create/salary/{id?}",
                   defaults: new { controller = "Admin", action = "CreateSalWithID" }
                   );

                endpoints.MapControllerRoute(
                    name: "createschool",
                    pattern: "admin/school/create",
                    defaults: new { controller = "Admin", action = "CreateSchool" }
                    );
                endpoints.MapControllerRoute(
                    name: "schoolcreate",
                    pattern: "admin/create/school/{id?}",
                    defaults: new { controller = "Admin", action = "CreateScWithID" }
                    );
                endpoints.MapControllerRoute(
                    name: "createcollege",
                    pattern: "admin/college/create",
                    defaults: new { controller = "Admin", action = "CreateCollege" }
                    );
                endpoints.MapControllerRoute(
                    name: "collegecreate",
                    pattern: "admin/create/college/{id?}",
                    defaults: new { controller = "Admin", action = "CreateColWithID" }
                    );
                endpoints.MapControllerRoute(
                    name: "createuni",
                    pattern: "admin/university/create",
                    defaults: new { controller = "Admin", action = "CreateUni" }
                    );
                endpoints.MapControllerRoute(
                    name: "unicreate",
                    pattern: "admin/create/university/{id?}",
                    defaults: new { controller = "Admin", action = "CreateUniWithID" }
                    );
                endpoints.MapControllerRoute(
                    name: "createcourse",
                    pattern: "admin/course/create",
                    defaults: new { controller = "Admin", action = "CreateCourse" }
                    );
                endpoints.MapControllerRoute(
                    name: "coursecreate",
                    pattern: "admin/create/course/{id?}",
                    defaults: new { controller = "Admin", action = "CreateCouWithID" }
                    );

                endpoints.MapControllerRoute(
                    name: "workexpcreate",
                    pattern: "admin/create/workexp/{id?}",
                    defaults: new { controller = "Admin", action = "CreateWEWithID" }
                    );

                endpoints.MapControllerRoute(
                    name: "createworkexp",
                    pattern: "admin/workexp/create",
                    defaults: new { controller = "Admin", action = "CreateWorkEXP" }
                    );

                endpoints.MapControllerRoute(
                    name: "drivinglcreate",
                    pattern: "admin/create/drivingl/{id?}",
                    defaults: new { controller = "Admin", action = "CreateDLWithID" }
                    );

                endpoints.MapControllerRoute(
                    name: "createdrivingl",
                    pattern: "admin/drivingl/create",
                    defaults: new { controller = "Admin", action = "CreateDrivingL" }
                    );

                endpoints.MapControllerRoute(
                    name: "bodydcreate",
                    pattern: "admin/create/bodyd/{id?}",
                    defaults: new { controller = "Admin", action = "CreateBDWithID" }
                    );

                endpoints.MapControllerRoute(
                    name: "createbodyd",
                    pattern: "admin/bodyd/create",
                    defaults: new { controller = "Admin", action = "CreateBodyD" }
                    );

                endpoints.MapControllerRoute(
                    name: "createtimezone",
                    pattern: "admin/create/timezone",
                    defaults: new { controller = "Admin", action = "CreateTimezone" }
                    );

                endpoints.MapControllerRoute(
                    name: "createpenalty",
                    pattern: "admin/create/penalty",
                    defaults: new { controller = "Admin", action = "CreatePenalty" }
                    );
                endpoints.MapControllerRoute(
                    name: "createpenalty",
                    pattern: "admin/create/penalty/{id?}",
                    defaults: new { controller = "Admin", action = "CreatePenaltyWID" }
                    );
                endpoints.MapControllerRoute(
                    name: "createpenaltyready",
                    pattern: "admin/create/penaltyready",
                    defaults: new { controller = "Admin", action = "CreatePenaltyReady" }
                    );

                endpoints.MapControllerRoute(
                    name: "createarchive",
                    pattern: "admin/create/archive",
                    defaults: new { controller = "Admin", action = "CreateArchive" }
                    );
                endpoints.MapControllerRoute(
                    name: "createarchive",
                    pattern: "admin/create/archive/{id?}",
                    defaults: new { controller = "Admin", action = "CreateArchiveWID" }
                    );

                endpoints.MapControllerRoute(
                    name: "createbonus",
                    pattern: "admin/create/bonus",
                    defaults: new { controller = "Admin", action = "CreateBonus" }
                    );
                endpoints.MapControllerRoute(
                    name: "createbonus",
                    pattern: "admin/create/bonus/{id?}",
                    defaults: new { controller = "Admin", action = "CreateBonusWID" }
                    );
                endpoints.MapControllerRoute(
                    name: "createbonusready",
                    pattern: "admin/create/bonusready",
                    defaults: new { controller = "Admin", action = "CreateBonusReady" }
                    );

                /////////////////////////////////////////////////// Role //
                endpoints.MapControllerRoute(
                    name: "editrole",
                    pattern: "admin/role/edit/{id?}",
                    defaults: new { controller = "Admin", action = "EditRole" }
                    );

                endpoints.MapControllerRoute(
                    name: "createrole",
                    pattern: "admin/role/create",
                    defaults: new { controller = "Admin", action = "CreateRole" }
                    );

                endpoints.MapControllerRoute(
                    name: "roles",
                    pattern: "admin/roles",
                    defaults: new { controller = "Admin", action = "RoleList" }
                    );

                /////////////////////////////////////////////////// Worker //
                endpoints.MapControllerRoute(
                    name: "usermanage",
                    pattern: "usermanage",
                    defaults: new { controller = "Worker", action = "UserManage" }
                    );

                endpoints.MapControllerRoute(
                    name: "login",
                    pattern: "login",
                    defaults: new { controller = "Worker", action = "Login" }
                    );
                ///////////////////////////// Details //
                endpoints.MapControllerRoute(
                    name: "detailsuser",
                    pattern: "user/details/{id?}",
                    defaults: new { controller = "Worker", action = "UserDetailList" }
                    );
                endpoints.MapControllerRoute(
                    name: "detailsuser",
                    pattern: "user/idcard/{id?}",
                    defaults: new { controller = "Worker", action = "UserIdCard" }
                    );
                endpoints.MapControllerRoute(
                    name: "detailsuser",
                    pattern: "user/family/{id?}",
                    defaults: new { controller = "Worker", action = "UserFamily" }
                    );
                endpoints.MapControllerRoute(
                    name: "detailsuser",
                    pattern: "user/bodydimensions/{id?}",
                    defaults: new { controller = "Worker", action = "UserBodyD" }
                    );
                endpoints.MapControllerRoute(
                    name: "detailsuser",
                    pattern: "user/study/{id?}",
                    defaults: new { controller = "Worker", action = "UserStudy" }
                    );
                endpoints.MapControllerRoute(
                    name: "detailsuser",
                    pattern: "user/workexp/{id?}",
                    defaults: new { controller = "Worker", action = "UserWorkEXP" }
                    );
                endpoints.MapControllerRoute(
                    name: "detailsuser",
                    pattern: "user/drivinglicense/{id?}",
                    defaults: new { controller = "Worker", action = "UserDrivingL" }
                    );
                endpoints.MapControllerRoute(
                    name: "detailsuser",
                    pattern: "user/contact/{id?}",
                    defaults: new { controller = "Worker", action = "UserContact" }
                    );
                endpoints.MapControllerRoute(
                    name: "detailsuser",
                    pattern: "user/salary/{id?}",
                    defaults: new { controller = "Worker", action = "UserSalary" }
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=index}/{id?}"
                    );
            });

            SeedIdentity.Seed(userManager, roleManager, configuration).Wait();
        }
    }
}
