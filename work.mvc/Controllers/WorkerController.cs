using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work.data.Abstract;
using work.entity;
using work.mvc.Extensions;
using work.mvc.Identity;
using work.mvc.Models;

namespace work.mvc.Controllers
{
    [RequestSizeLimit(1000000000)]
    public class WorkerController : Controller
    {
        private IBodyDRepository _bdRepository;
        private IChildrenRepository _childrepository;
        private ICollegeRepository _collegeRepository;
        private ICourseRepository _courseRepository;
        private IDrivingLRepository _dlRepository;
        private IEmailRepository _emailRepository;
        private IMPhoneRepository _mphoneRepository;
        private ISchoolRepository _schoolRepository;
        private ISocialNRepository _socialNRepository;
        private IUniversityRepository _universityRepository;
        private IWorkEXPRepository _workEXPRepository;
        private ISocialNSListRepository _snslRepository;
        private ISalaryRepository _salaryRepository;
        private IOtherSkillsRepository _oskillsRepository;
        private IPenaltyRepository _penaltyRepository;
        private IPenaltyReadyRepository _penaltyreadyRepository;
        private ITimeZonesRepository _timeZonesRepository;
        private IArchiveRepository _archiveRepository;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        public WorkerController(IBodyDRepository bdRepository, IChildrenRepository childrepository, ICollegeRepository collegeRepository, ICourseRepository courseRepository,
                               IDrivingLRepository dlRepository, IEmailRepository emailRepository, IMPhoneRepository mphoneRepository, ISchoolRepository schoolRepository,
                               ISocialNRepository socialNRepository, IUniversityRepository universityRepository, IWorkEXPRepository workEXPRepository, ISalaryRepository salaryRepository,
                               ISocialNSListRepository snslRepository, IOtherSkillsRepository oskillsRepository, IPenaltyRepository penaltyRepository, ITimeZonesRepository timeZonesRepository,
                               IArchiveRepository archiveRepository, IPenaltyReadyRepository penaltyreadyRepository, RoleManager<IdentityRole> roleManager, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _bdRepository = bdRepository;
            _childrepository = childrepository;
            _collegeRepository = collegeRepository;
            _courseRepository = courseRepository;
            _dlRepository = dlRepository;
            _emailRepository = emailRepository;
            _mphoneRepository = mphoneRepository;
            _schoolRepository = schoolRepository;
            _socialNRepository = socialNRepository;
            _universityRepository = universityRepository;
            _workEXPRepository = workEXPRepository;
            _snslRepository = snslRepository;
            _salaryRepository = salaryRepository;
            _oskillsRepository = oskillsRepository;
            _penaltyRepository = penaltyRepository;
            _timeZonesRepository = timeZonesRepository;
            _archiveRepository = archiveRepository;
            _penaltyreadyRepository = penaltyreadyRepository;
        }

        /////////////////////////////////////////////////// UserDetails //
        public async Task<IActionResult> UserDetailList(string Id)
        {
            if (Id != null)
            {
                var user = await _userManager.FindByIdAsync(Id);
                if (user != null)
                {
                    return View(new UserDetailsModel()
                    {
                        UserId = user.Id,
                        Users = _userManager.Users.ToList()
                    });
                }

                TempData.Put("message", new AlertMessage()
                {
                    Title = "Xəta",
                    Message = $"Belə istifadıçi yoxdur",
                    AlertType = "warning"
                });
                return Redirect("/admin/users");
            }

            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = $"Hər hansı istifadəçi seçilməmişdir",
                AlertType = "warning"
            });
            return Redirect("/admin/users");
        }  // +
        public IActionResult UserIdCard(string Id)
        {
            if (Id == null)
            {
                return Redirect("/admin/list/idcard");
            }
            User user = _userManager.Users.Where(i=>i.Id == Id).FirstOrDefault();
            if (user == null)
            {
                return Redirect("/admin/list/idcard");
            }
            return View(new WorkerDetailModel
            {
                User = user
            });
        }  // +
        public IActionResult UserFamily(string Id)
        {
            if (Id == null)
            {
                return Redirect("/admin/list/idcard");
            }
            User user = _userManager.Users.Where(i => i.Id == Id).FirstOrDefault();
            var children = _childrepository.GetAll().Where(i => i.UserId == Id).ToList();
            if (user == null)
            {
                return Redirect("/admin/list/idcard");
            }
            return View(new WorkerDetailModel
            {
                User = user,
                ChildrenList = children
            });
        }  // +
        public IActionResult UserBodyD(string Id)
        {
            if (Id == null)
            {
                return Redirect("/admin/list/idcard");
            }
            User user = _userManager.Users.Where(i => i.Id == Id).FirstOrDefault();
            BodyDimensions body = _bdRepository.GetDetails(Id);
            //var bodys = _bdRepository.GetAll().Where(i => i.UserId == Id).ToList();
            if (user == null)
            {
                return Redirect("/admin/list/idcard");
            }
            return View(new WorkerDetailModel
            {
                User = user,
                BodyD = body,
                //BodyDList = bodys
            });
        }  // +
        public IActionResult UserStudy(string Id)
        {
            if (Id == null)
            {
                return Redirect("/admin/list/idcard");
            }
            User user = _userManager.Users.Where(i => i.Id == Id).FirstOrDefault();
            School sc = _schoolRepository.GetDetails(Id);
            //College col = _collegeRepository.GetDetails(Id);
            //University uni = _universityRepository.GetDetails(Id);
            //Course cou = _courseRepository.GetDetails(Id);
            //var scs = _schoolRepository.GetAll().Where(i => i.UserId == Id).ToList();
            var cols = _collegeRepository.GetAll().Where(i => i.UserId == Id).ToList();
            var unis = _universityRepository.GetAll().Where(i => i.UserId == Id).ToList();
            var cous = _courseRepository.GetAll().Where(i => i.UserId == Id).ToList();
            if (user == null)
            {
                return Redirect("/admin/list/idcard");
            }
            return View(new WorkerDetailModel
            {
                User = user,
                School = sc,
                //College = col,
                //University = uni,
                //Course = cou,
                //SchoolList = scs,
                CollegeList = cols,
                UniversityList = unis,
                CourseList = cous
            });
        }  // +
        public IActionResult UserWorkEXP(string Id)
        {
            if (Id == null)
            {
                return Redirect("/admin/list/idcard");
            }
            User user = _userManager.Users.Where(i => i.Id == Id).FirstOrDefault();
            //WorkEXP exp = _workEXPRepository.GetDetails(Id);
            //OtherSkills skill = _oskillsRepository.GetDetails(Id);
            var work = _workEXPRepository.GetAll().Where(i => i.UserId == Id).ToList();
            var skills = _oskillsRepository.GetAll().Where(i => i.UserId == Id).ToList();
            if (user == null)
            {
                return Redirect("/admin/list/idcard");
            }
            return View(new WorkerDetailModel
            {
                User = user,
                //WorkEXP = exp,
                //OtherSkills = skill,
                WorkList = work,
                OSkillsList = skills
            });
        }  // +
        public IActionResult UserDrivingL(string Id)
        {
            if (Id == null)
            {
                return Redirect("/admin/list/idcard");
            }
            User user = _userManager.Users.Where(i => i.Id == Id).FirstOrDefault();
            DrivingLicense dl = _dlRepository.GetDetails(Id);
            //var dls = _dlRepository.GetAll().Where(i => i.UserId == Id).ToList();
            if (user == null)
            {
                return Redirect("/admin/list/idcard");
            }
            return View(new WorkerDetailModel
            {
                User = user,
                DL = dl,
                //DLList = dls
            });
        }  // +
        public IActionResult UserContact(string Id)
        {
            if (Id == null)
            {
                return Redirect("/admin/list/idcard");
            }
            User user = _userManager.Users.Where(i => i.Id == Id).FirstOrDefault();
            //Email em = _emailRepository.GetDetails(Id);
            //MobilePhone mp = _mphoneRepository.GetDetails(Id);
            //SocialNetwork sn = _socialNRepository.GetDetails(Id);
            var ems = _emailRepository.GetAll().Where(i => i.UserId == Id).ToList();
            var mps = _mphoneRepository.GetAll().Where(i => i.UserId == Id).ToList();
            var sns = _socialNRepository.GetAll().Where(i => i.UserId == Id).ToList();
            var snsl = _snslRepository.GetAll();
            if (user == null)
            {
                return Redirect("/admin/list/idcard");
            }
            return View(new WorkerDetailModel
            {
                User = user,
                //Email = em,
                //MobilePhone = mp,
                //SocialNetwork = sn,
                EmailList = ems,
                MPhoneList = mps,
                SocialNList = sns,
                SNSLList = snsl
            });
        }  // +
        public IActionResult UserSalary(string Id)
        {
            if (Id == null)
            {
                return Redirect("/admin/list/idcard");
            }
            User user = _userManager.Users.Where(i => i.Id == Id).FirstOrDefault();
            //Salary s = _salaryRepository.GetDetails(Id);
            var ss = _salaryRepository.GetAll().Where(i => i.UserId == Id).ToList();
            foreach (var e in ss)
            {
                var tz = _timeZonesRepository.GetDetails(e.TimeZoneId);
                if (user == null)
                {
                    return Redirect("/admin/list/idcard");
                }
                return View(new WorkerDetailModel
                {
                    User = user,
                    //Salary = s,
                    SalaryList = ss,
                    TimeZone = tz
                });
            }
            return Redirect("/admin/list/idcard");
        }  // +


        /////////////////////////////////////////////////// Logout //
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData.Put("message", new AlertMessage()
            {
                Title = "Çıxış",
                Message = "Hesabdan çıxış edildi ,servisdən istifadə etmək üçün təkrar daxil olun",
                AlertType = "primary"
            });
            return Redirect("~/");
        }

        /////////////////////////////////////////////////// Login //
        public IActionResult Login(string ReturnUrl = null)
        {
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Bele bir hesab yaradılmamışdır");
                return View(model);
            }

            //if (!await _userManager.IsEmailConfirmedAsync(user))
            //{
            //    ModelState.AddModelError("", "Email hesabınıza gələn link ilə proflinizi təstiqləyin");
            //    return View(model);
            //}

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
            if (result.Succeeded)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Xoş Gəlmisiniz",
                    Message = "",
                    AlertType = "primary"
                });
                return Redirect(model.ReturnUrl ?? "~/");
            }

            ModelState.AddModelError("", "İstifadəçi adı və ya şifrə yanlışdır");
            return View(model);
        }


        /////////////////////////////////////////////////// Profile Manage //
        public async Task<IActionResult> UserManage()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            return Redirect($"/user/details/{user.Id}");
        }

        //[HttpPost]
        //public async Task<IActionResult> UserManage(UserManage model, IFormFile file, IFormFile file0)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    //    var user = await _userManager.FindByEmailAsync(User.Identity.Name);
        //    //    if (user != null && user.IsSalon)
        //    //    {
        //    //        user.UserName = model.UserName;
        //    //        user.Email = model.Email;
        //    //        user.FirstName = model.FirstName;
        //    //        user.LastName = model.LastName;
        //    //        user.SalonName = model.SalonName;
        //    //        user.Address = model.Address;
        //    //        user.MobileNumber2 = model.MobileNumber2;
        //    //        user.MobileNumber3 = model.MobileNumber3;
        //    //        user.MobileNumber4 = model.MobileNumber4;
        //    //        if (file != null)
        //    //        {
        //    //            var extention = Path.GetExtension(file.FileName);
        //    //            var randomName = string.Format($"salon_{model.SalonName}_{Guid.NewGuid()}{extention}");
        //    //            user.ImageUrl = randomName;
        //    //            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{model.Email}", randomName);
        //    //            using (var stream = new FileStream(path, FileMode.Create))
        //    //            {
        //    //                await file.CopyToAsync(stream);
        //    //            }
        //    //        }
        //    //        if (file0 != null)
        //    //        {
        //    //            var extention = Path.GetExtension(file0.FileName);
        //    //            var randomName = string.Format($"salon_logo_{model.SalonName}_{Guid.NewGuid()}{extention}");
        //    //            user.LogoUrl = randomName;
        //    //            var path1 = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{model.Email}", randomName);
        //    //            using (var stream = new FileStream(path1, FileMode.Create))
        //    //            {
        //    //                await file0.CopyToAsync(stream);
        //    //            }
        //    //        }

        //    //        var result = await _userManager.UpdateAsync(user);
        //    //        if (result.Succeeded)
        //    //        {
        //    //            TempData.Put("message", new AlertMessage()
        //    //            {
        //    //                Title = $"{model.FirstName} {model.LastName}",
        //    //                Message = "Profiliniz tənzimləndi",
        //    //                AlertType = "primary"
        //    //            });
        //    //            return Redirect("/account/usermanage");
        //    //        }
        //    //    }
        //    //    else if (user != null && user.IsSalon == false)
        //    //    {
        //    //        user.UserName = model.UserName;
        //    //        user.Email = model.Email;
        //    //        user.FirstName = model.FirstName;
        //    //        user.LastName = model.LastName;
        //    //        user.MobileNumber2 = model.MobileNumber2;
        //    //        user.SalonName = model.SalonName = "NoSalon";

        //    //        var result = await _userManager.UpdateAsync(user);
        //    //        if (result.Succeeded)
        //    //        {
        //    //            TempData.Put("message", new AlertMessage()
        //    //            {
        //    //                Title = $"{model.FirstName} {model.LastName}",
        //    //                Message = "Profiliniz tənzimləndi",
        //    //                AlertType = "primary"
        //    //            });
        //    //            return Redirect("/account/usermanage");
        //    //        }
        //    //    }
        //    //    return Redirect("/account/usermanage");
        //    //}
        //    return View(model);
        //}


    }
}
