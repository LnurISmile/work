using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using work.data.Abstract;
using work.entity;
using work.mvc.EmailServices;
using work.mvc.Extensions;
using work.mvc.Identity;
using work.mvc.Models;

namespace work.mvc.Controllers
{
    [Authorize(Roles = "Admin")]
    [RequestSizeLimit(1000000000)]
    public class AdminController : Controller
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
        private IBonusRepository _bonusRepository;
        private IBonusReadyRepository _bonusreadyRepository;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IEmailSender _emailSender;
        public AdminController(IBodyDRepository bdRepository, IChildrenRepository childrepository, ICollegeRepository collegeRepository, ICourseRepository courseRepository,
                               IDrivingLRepository dlRepository, IEmailRepository emailRepository, IMPhoneRepository mphoneRepository, ISchoolRepository schoolRepository,
                               ISocialNRepository socialNRepository, IUniversityRepository universityRepository, IWorkEXPRepository workEXPRepository, ISalaryRepository salaryRepository,
                               ISocialNSListRepository snslRepository, IOtherSkillsRepository oskillsRepository, IPenaltyRepository penaltyRepository, ITimeZonesRepository timeZonesRepository,
                               IArchiveRepository archiveRepository, IPenaltyReadyRepository penaltyreadyRepository, IBonusRepository bonusRepository, IBonusReadyRepository bonusreadyRepository,
                               RoleManager<IdentityRole> roleManager, UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
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
            _bonusRepository = bonusRepository;
            _bonusreadyRepository = bonusreadyRepository;
        }


        /////////////////////////////////////////////////// UserList //
        public IActionResult UserList()
        {
            return View();
        }  // +
        public IActionResult IDCList()  // Approved
        {
            var ViewModel = new UserDetailsModel()
            {
                Users = _userManager.Users.ToList(),
                College = _collegeRepository.GetAll(),
                Uni = _universityRepository.GetAll(),
                Course = _courseRepository.GetAll(),
                WorkEXP = _workEXPRepository.GetAll(),
                MobilePhone = _mphoneRepository.GetAll(),
                Emails = _emailRepository.GetAll(),
                Salary = _salaryRepository.GetAll()
            };
            return View(ViewModel);
            //return View(_userManager.Users.Where(i => i.IsApproved).ToList());
        }  // +
        public IActionResult IDCUnApproved()  // UnApproved
        {
            return View(_userManager.Users.Where(i => i.IsApproved == false).ToList());
        }  // +
        public IActionResult FamilyList()
        {
            var ViewModel = new FamilyListViewModel()
            {
                Users = _userManager.Users.ToList(),
                Family = _childrepository.GetAll()
            };
            return View(ViewModel);
        }  // +
        public IActionResult BodyDList()
        {
            var ViewModel = new BodyDListViewModel()
            {
                Users = _userManager.Users.ToList(),
                BodyD = _bdRepository.GetAll()
            };
            return View(ViewModel);
        }  // +
        public IActionResult StudyList()
        {
            return View();
        }  // +
        public IActionResult SchoolList()
        {
            var ViewModel = new SchoolListViewModel()
            {
                Users = _userManager.Users.ToList(),
                Schools = _schoolRepository.GetAll()
            };
            return View(ViewModel);
        }  // +
        public IActionResult CollegeList()
        {
            var ViewModel = new CollegeListViewModel()
            {
                Users = _userManager.Users.ToList(),
                Colleges = _collegeRepository.GetAll()
            };
            return View(ViewModel);
        }  // +
        public IActionResult CollegeEditList(string id)
        {
            var ViewModel = new CollegeListViewModel()
            {
                Colleges = _collegeRepository.GetAll().Where(i => i.UserId == id).ToList(),
                UserId = id
            };
            return View(ViewModel);
        }  // +
        public IActionResult UniList()
        {
            var ViewModel = new UniListViewModel()
            {
                Users = _userManager.Users.ToList(),
                Uni = _universityRepository.GetAll()
            };
            return View(ViewModel);
        }  // +
        public IActionResult UniEditList(string id)
        {
            var ViewModel = new UniListViewModel()
            {
                Uni = _universityRepository.GetAll().Where(i => i.UserId == id).ToList(),
                UserId = id
            };
            return View(ViewModel);
        }  // +
        public IActionResult CourseList()
        {
            var ViewModel = new CourseListViewModel()
            {
                Users = _userManager.Users.ToList(),
                Courses = _courseRepository.GetAll()
            };
            return View(ViewModel);
        }  // +
        public IActionResult CourseEditList(string id)
        {
            var ViewModel = new CourseListViewModel()
            {
                Courses = _courseRepository.GetAll().Where(i => i.UserId == id).ToList(),
                UserId = id
            };
            return View(ViewModel);
        }  // +
        public IActionResult WorkEXPList()
        {
            var ViewModel = new WorkListViewModel()
            {
                Users = _userManager.Users.ToList(),
                Wexp = _workEXPRepository.GetAll(),
                Oskills = _oskillsRepository.GetAll()
            };
            return View(ViewModel);
        }  // +
        public IActionResult DCList()
        {
            var ViewModel = new DCListViewModel()
            {
                Users = _userManager.Users.ToList(),
                Dcs = _dlRepository.GetAll()
            };
            return View(ViewModel);
        }  // +
        public IActionResult ContactList()
        {
            var ViewModel = new ContactListViewModel()
            {
                Users = _userManager.Users.ToList(),
                Emails = _emailRepository.GetAll(),
                MobilePhones = _mphoneRepository.GetAll(),
                //SocialNetworks = _socialNRepository.GetAll()
            };
            return View(ViewModel);
        }  // +
        public IActionResult SalaryList()
        {
            var ViewModel = new SalaryListViewModel()
            {
                Users = _userManager.Users.ToList(),
                Salaries = _salaryRepository.GetAll(),
                TimeZones = _timeZonesRepository.GetAll()
            };
            return View(ViewModel);
        }  // +
        public IActionResult SNList()
        {
            var ViewModel = new SocialNSLViewModel()
            {
                Snsl = _snslRepository.GetAll()
            };
            return View(ViewModel);
        }  // +
        public IActionResult HR()
        {
            return View();
        }  // +
        public IActionResult ListTimeZone()
        {
            var ViewModel = new TimeZonesListViewModel()
            {
                TimeZones = _timeZonesRepository.GetAll()
            };
            return View(ViewModel);
        }  // +
        public IActionResult ListPenalty()
        {
            var ViewModel = new PenaltyListViewModel()
            {
                Penalties = _penaltyRepository.GetAll(),
                Users = _userManager.Users.ToList()
            };
            return View(ViewModel);
        }  // +
        public IActionResult ListReadyPenalty()
        {
            var ViewModel = new ReadyPenaltyListViewModel()
            {
                PenaltyReadies = _penaltyreadyRepository.GetAll()
            };
            return View(ViewModel);
        }  // +
        public IActionResult ListArchive()
        {
            var ViewModel = new ArchiveListViewModel()
            {
                Archives = _archiveRepository.GetAll(),
                Users = _userManager.Users.ToList()
            };
            return View(ViewModel);
        }  // +
        public IActionResult ListBonus()
        {
            var ViewModel = new BonusListViewModel()
            {
                Bonus = _bonusRepository.GetAll(),
                Users = _userManager.Users.ToList()
            };
            return View(ViewModel);
        }  // +
        public IActionResult ListReadyBonus()
        {
            var ViewModel = new ReadyBonusListViewModel()
            {
                BonusReadies = _bonusreadyRepository.GetAll()
            };
            return View(ViewModel);
        }  // +


        /////////////////////////////////////////////////// UserCreate //
        public IActionResult CreateUser()
        {
            var roles = _roleManager.Roles.Select(i => i.Name);
            ViewBag.Roles = roles;
            return View();
        }  // +
        [HttpPost]
        public async Task<ActionResult> CreateUser(RegisterModel model, string[] selectedRoles)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            double per = 0;
            if (model.FirstName != null)
            {
                per += 6.666666666666667;
            }
            if (model.LastName != null)
            {
                per += 6.666666666666667;
            }
            if (model.UserName != null)
            {
                per += 6.666666666666667;
            }
            if (model.Email != null)
            {
                per += 6.666666666666667;
            }
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                IsApproved = model.IsApproved = true,
                Email = model.Email,
                EmailConfirmed = model.EmailConfirmed = true,
                PercentID = per
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", model.Email); // Folder yaratmaq
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                else
                {

                }
                var userRoles = await _userManager.GetRolesAsync(user);
                selectedRoles = selectedRoles ?? new string[] { };
                await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles).ToArray<string>());

                return Redirect("/admin/users");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Yeni istifadəçi",
                Message = $"{model.FirstName} {model.LastName} adlı istifadəçi əlavə edildi",
                AlertType = "success"
            });

            ModelState.AddModelError("", "Bilinməyən xəta baş verdi");
            return View(model);
        }  // +

        public IActionResult CreateBodyD()  //  BodyDimension Create Get
        {
            var users = _userManager.Users.ToList();
            var model = new BodyDDetailsModel()
            {
                Users = users
            };
            return View(model);
        }  // +
        [HttpPost]
        public async Task<ActionResult> CreateBodyD(BodyDDetailsModel model)   //  BodyDimension Create Post
        {
            if (ModelState.IsValid)
            {
                double per = 0;
                if (model.Height != 0)
                {
                    per += 16.6;
                }
                if (model.Weight != 0)
                {
                    per += 16.6;
                }
                if (model.FootSize != 0)
                {
                    per += 16.6;
                }
                if (model.BodyDimensionUp != null)
                {
                    per += 16.6;
                }
                if (model.BodyDimensionDown != null)
                {
                    per += 16.6;
                }
                if (model.HeadDimension != null)
                {
                    per += 16.6;
                }
                var user = await _userManager.FindByIdAsync(model.UserId);
                user.PercentBD = per;

                var body = new BodyDimensions()
                {
                    UserId = model.UserId,
                    Height = model.Height,
                    Weight = model.Weight,
                    FootSize = model.FootSize,
                    BodyDimensionUp = model.BodyDimensionUp,
                    BodyDimensionDown = model.BodyDimensionDown,
                    HeadDimension = model.HeadDimension,
                    PercentBD = per
                };
                _bdRepository.Create(body);
                await _userManager.UpdateAsync(user);

                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğürlu Nəticə",
                    Message = "Bədən ölçüləri bölməsinə yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/user/bodydedit/{model.UserId}");

            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +
        public IActionResult CreateBDWithID(string id)  //  BodyDimension with id Create Get
        {
            var model = new BodyDWIDDetailsModel()
            {
                UserId = id
            };
            return View(model);
        }  // +
        [HttpPost]
        public async Task<ActionResult> CreateBDWithID(BodyDWIDDetailsModel model)   //  BodyDimension with id Create Post
        {
            if (ModelState.IsValid)
            {
                double per = 0;
                if (model.Height != 0)
                {
                    per += 16.6;
                }
                if (model.Weight != 0)
                {
                    per += 16.6;
                }
                if (model.FootSize != 0)
                {
                    per += 16.6;
                }
                if (model.BodyDimensionUp != null)
                {
                    per += 16.6;
                }
                if (model.BodyDimensionDown != null)
                {
                    per += 16.6;
                }
                if (model.HeadDimension != null)
                {
                    per += 16.6;
                }
                var user = await _userManager.FindByIdAsync(model.UserId);
                user.PercentBD = per;
                var body = new BodyDimensions()
                {
                    UserId = model.UserId,
                    Height = model.Height,
                    Weight = model.Weight,
                    FootSize = model.FootSize,
                    BodyDimensionUp = model.BodyDimensionUp,
                    BodyDimensionDown = model.BodyDimensionDown,
                    HeadDimension = model.HeadDimension,
                    PercentBD = per
                };
                _bdRepository.Create(body);
                await _userManager.UpdateAsync(user);

                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğürlu Nəticə",
                    Message = "Bədən ölçüləri bölməsinə yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/user/bodydedit/{model.UserId}");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +

        public IActionResult CreateDrivingL()  //  Driving License Create Get
        {
            var users = _userManager.Users.ToList();
            var model = new DrivingLDetailsModel()
            {
                Users = users
            };
            return View(model);
        }  // +
        [HttpPost]
        public async Task<ActionResult> CreateDrivingL(DrivingLDetailsModel model, IFormFile file1, IFormFile file2)   //  Driving License Create Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                double per = 0;
                if (model.IssuingAuthority != null)
                {
                    per += 14.285;
                }
                if (model.DL_SerialNumber != null)
                {
                    per += 14.285;
                }
                if (model.ImgUrl != null)
                {
                    per += 14.285;
                }
                if (model.Categories != null)
                {
                    per += 14.285;
                }
                if (model.PDFUrl != null)
                {
                    per += 14.285;
                }
                if (model.StartDate != DateTime.MinValue)
                {
                    per += 14.285;
                }
                if (model.ExpirationDate != DateTime.MinValue)
                {
                    per += 14.285;
                }
                var user = await _userManager.FindByIdAsync(model.UserId);
                user.PercentDl = per;

                var dl = new DrivingLicense()
                {
                    UserId = model.UserId,
                    IssuingAuthority = model.IssuingAuthority,
                    DL_SerialNumber = model.DL_SerialNumber,
                    StartDate = model.StartDate,
                    ExpirationDate = model.ExpirationDate,
                    Categories = model.Categories,
                    ImgUrl = model.ImgUrl,
                    PDFUrl = model.PDFUrl,
                    PercentDL = per
                };
                foreach (var item in users)
                {
                    if (item.Id == model.UserId)
                    {
                        if (file1 != null)
                        {
                            var extention = Path.GetExtension(file1.FileName);
                            var randomName = string.Format($"img_driving_{model.UserId}_{Guid.NewGuid()}{extention}");
                            dl.ImgUrl = randomName;
                            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{item.Email}", randomName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await file1.CopyToAsync(stream);
                            }
                        }
                        if (file2 != null)
                        {
                            var extention = Path.GetExtension(file2.FileName);
                            var randomName = string.Format($"pdf_driving_{model.UserId}_{Guid.NewGuid()}{extention}");
                            dl.PDFUrl = randomName;
                            var path0 = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{item.Email}", randomName);
                            using (var stream = new FileStream(path0, FileMode.Create))
                            {
                                await file2.CopyToAsync(stream);
                            }
                        }
                    }
                }
                _dlRepository.Create(dl);
                await _userManager.UpdateAsync(user);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Sürücülük bölməsinə yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/user/drivingledit/{model.UserId}");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +
        public IActionResult CreateDLWithID(string id)  //  Driving License with id Create Get
        {
            var model = new DrivingLWIDDetailsModel()
            {
                UserId = id
            };
            return View(model);
        }  // +
        [HttpPost]
        public async Task<ActionResult> CreateDLWithID(DrivingLWIDDetailsModel model, IFormFile file1, IFormFile file2)   //  Driving License with id Create Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                double per = 0;
                if (model.IssuingAuthority != null)
                {
                    per += 20;
                }
                if (model.DL_SerialNumber != null)
                {
                    per += 20;
                }
                if (model.ImgUrl != null)
                {
                    per += 20;
                }
                if (model.Categories != null)
                {
                    per += 20;
                }
                if (model.PDFUrl != null)
                {
                    per += 20;
                }
                var user = await _userManager.FindByIdAsync(model.UserId);
                user.PercentDl = per;

                var dl = new DrivingLicense()
                {
                    UserId = model.UserId,
                    IssuingAuthority = model.IssuingAuthority,
                    DL_SerialNumber = model.DL_SerialNumber,
                    StartDate = model.StartDate,
                    ExpirationDate = model.ExpirationDate,
                    Categories = model.Categories,
                    ImgUrl = model.ImgUrl,
                    PDFUrl = model.PDFUrl,
                    PercentDL = per
                };
                foreach (var item in users)
                {
                    if (item.Id == model.UserId)
                    {
                        if (file1 != null)
                        {
                            var extention = Path.GetExtension(file1.FileName);
                            var randomName = string.Format($"img_driving_{model.UserId}_{Guid.NewGuid()}{extention}");
                            dl.ImgUrl = randomName;
                            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{item.Email}", randomName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await file1.CopyToAsync(stream);
                            }
                        }
                        if (file2 != null)
                        {
                            var extention = Path.GetExtension(file2.FileName);
                            var randomName = string.Format($"pdf_driving_{model.UserId}_{Guid.NewGuid()}{extention}");
                            dl.PDFUrl = randomName;
                            var path0 = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{item.Email}", randomName);
                            using (var stream = new FileStream(path0, FileMode.Create))
                            {
                                await file2.CopyToAsync(stream);
                            }
                        }
                    }
                }
                _dlRepository.Create(dl);
                await _userManager.UpdateAsync(user);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Sürücülük bölməsinə yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/user/drivingledit/{model.UserId}");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +

        public IActionResult CreateWorkEXP()  //  Work EXP Create Get
        {
            var users = _userManager.Users.ToList();
            var model = new WorkDetailsModel()
            {
                Users = users
            };
            return View(model);
        }  // +
        [HttpPost]
        public async Task<ActionResult> CreateWorkEXP(WorkDetailsModel model, IFormFile file)   //  Work EXP Create Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                var w = new WorkEXP()
                {
                    UserId = model.UserId,
                    Company = model.Company,
                    Employer = model.Employer,
                    Start = model.Start,
                    Resignation = model.Resignation,
                    CVPDF = model.CVPDF
                };
                foreach (var item in users)
                {
                    if (item.Id == model.UserId)
                    {
                        if (file != null)
                        {
                            var extention = Path.GetExtension(file.FileName);
                            var randomName = string.Format($"pdf_cv_{model.UserId}_{Guid.NewGuid()}{extention}");
                            w.CVPDF = randomName;
                            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{item.Email}", randomName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }
                        }
                    }
                }
                _workEXPRepository.Create(w);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "İş bölməsinə yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/user/workexpedit/{model.UserId}");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +
        public IActionResult CreateWEWithID(string id)  //  Work EXP with id Create Get
        {
            var model = new WorkWIDDetailsModel()
            {
                UserId = id
            };
            return View(model);
        }  // +
        [HttpPost]
        public async Task<ActionResult> CreateWEWithID(WorkWIDDetailsModel model, IFormFile file)   //  Work EXP with id Create Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                var w = new WorkEXP()
                {
                    UserId = model.UserId,
                    Company = model.Company,
                    Employer = model.Employer,
                    Start = model.Start,
                    Resignation = model.Resignation,
                    CVPDF = model.CVPDF
                };
                foreach (var item in users)
                {
                    if (item.Id == model.UserId)
                    {
                        if (file != null)
                        {
                            var extention = Path.GetExtension(file.FileName);
                            var randomName = string.Format($"pdf_cv_{model.UserId}_{Guid.NewGuid()}{extention}");
                            w.CVPDF = randomName;
                            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{item.Email}", randomName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }
                        }
                    }
                }
                _workEXPRepository.Create(w);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "İş bölməsinə yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/user/workexpedit/{model.UserId}");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +

        public IActionResult CreateSchool()  //  School Create Get
        {
            var users = _userManager.Users.ToList();
            var model = new SchoolDetailsModel()
            {
                Users = users
            };
            return View(model);
        }  // +
        [HttpPost]
        public async Task<ActionResult> CreateSchool(SchoolDetailsModel model, IFormFile file1, IFormFile file2)   //  School Create Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                double per = 0;
                if (model.SchoolName != null)
                {
                    per += 20;
                }
                if (model.ImgUrl != null)
                {
                    per += 20;
                }
                if (model.PDFUrl != null)
                {
                    per += 20;
                }
                if (model.School_StartDate != DateTime.MinValue)
                {
                    per += 20;
                }
                if (model.School_CompletionDate != DateTime.MinValue)
                {
                    per += 20;
                }
                var user = await _userManager.FindByIdAsync(model.UserId);
                user.PercentS = per;

                var sc = new School()
                {
                    UserId = model.UserId,
                    SchoolName = model.SchoolName,
                    School_StartDate = model.School_StartDate,
                    School_CompletionDate = model.School_CompletionDate
                };
                foreach (var item in users)
                {
                    if (item.Id == model.UserId)
                    {
                        if (file1 != null)
                        {
                            var extention = Path.GetExtension(file1.FileName);
                            var randomName = string.Format($"img_school_{model.UserId}_{Guid.NewGuid()}{extention}");
                            sc.ImgUrl = randomName;
                            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{item.Email}", randomName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await file1.CopyToAsync(stream);
                            }
                        }
                        if (file2 != null)
                        {
                            var extention = Path.GetExtension(file2.FileName);
                            var randomName = string.Format($"pdf_school_{model.UserId}_{Guid.NewGuid()}{extention}");
                            sc.PDFUrl = randomName;
                            var path0 = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{item.Email}", randomName);
                            using (var stream = new FileStream(path0, FileMode.Create))
                            {
                                await file2.CopyToAsync(stream);
                            }
                        }
                    }
                }
                _schoolRepository.Create(sc);
                await _userManager.UpdateAsync(user);

                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Məktəb Siyahısına yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/user/schooledit/{model.UserId}");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +
        public IActionResult CreateScWithID(string id)  //  School with id Create Get
        {
            var model = new SchoolWIDDetailsModel()
            {
                UserId = id
            };
            return View(model);
        }  // +
        [HttpPost]
        public async Task<ActionResult> CreateScWithID(SchoolWIDDetailsModel model, IFormFile file1, IFormFile file2)   //  School with id Create Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                double per = 0;
                if (model.SchoolName != null)
                {
                    per += 20;
                }
                if (model.ImgUrl != null)
                {
                    per += 20;
                }
                if (model.PDFUrl != null)
                {
                    per += 20;
                }
                if (model.School_StartDate != DateTime.MinValue)
                {
                    per += 20;
                }
                if (model.School_CompletionDate != DateTime.MinValue)
                {
                    per += 20;
                }
                var user = await _userManager.FindByIdAsync(model.UserId);
                user.PercentS = per;

                var sc = new School()
                {
                    UserId = model.UserId,
                    SchoolName = model.SchoolName,
                    School_StartDate = model.School_StartDate,
                    School_CompletionDate = model.School_CompletionDate,
                    PercentSch = per
                };
                foreach (var item in users)
                {
                    if (item.Id == model.UserId)
                    {
                        if (file1 != null)
                        {
                            var extention = Path.GetExtension(file1.FileName);
                            var randomName = string.Format($"img_school_{model.UserId}_{Guid.NewGuid()}{extention}");
                            sc.ImgUrl = randomName;
                            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{item.Email}", randomName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await file1.CopyToAsync(stream);
                            }
                        }
                        if (file2 != null)
                        {
                            var extention = Path.GetExtension(file2.FileName);
                            var randomName = string.Format($"pdf_school_{model.UserId}_{Guid.NewGuid()}{extention}");
                            sc.PDFUrl = randomName;
                            var path0 = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{item.Email}", randomName);
                            using (var stream = new FileStream(path0, FileMode.Create))
                            {
                                await file2.CopyToAsync(stream);
                            }
                        }
                    }
                }
                _schoolRepository.Create(sc);
                await _userManager.UpdateAsync(user);

                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Məktəb Siyahısına yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/user/schooledit/{model.UserId}");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +

        public IActionResult CreateCollege()  //  College Create Get
        {
            var users = _userManager.Users.ToList();
            var model = new CollegeDetailsModel()
            {
                Users = users
            };
            return View(model);
        }  // +
        [HttpPost]
        public async Task<ActionResult> CreateCollege(CollegeDetailsModel model, IFormFile file1, IFormFile file2)   //  College Create Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                var col = new College()
                {
                    UserId = model.UserId,
                    CollegeName = model.CollegeName,
                    CollegeSpecialty = model.CollegeSpecialty,
                    College_StartDate = model.College_StartDate,
                    College_CompletionDate = model.College_CompletionDate
                };
                foreach (var item in users)
                {
                    if (item.Id == model.UserId)
                    {
                        if (file1 != null)
                        {
                            var extention = Path.GetExtension(file1.FileName);
                            var randomName = string.Format($"img_college_{model.UserId}_{Guid.NewGuid()}{extention}");
                            col.ImgUrl = randomName;
                            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{item.Email}", randomName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await file1.CopyToAsync(stream);
                            }
                        }
                        if (file2 != null)
                        {
                            var extention = Path.GetExtension(file2.FileName);
                            var randomName = string.Format($"pdf_college_{model.UserId}_{Guid.NewGuid()}{extention}");
                            col.PDFUrl = randomName;
                            var path0 = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{item.Email}", randomName);
                            using (var stream = new FileStream(path0, FileMode.Create))
                            {
                                await file2.CopyToAsync(stream);
                            }
                        }
                    }
                }
                _collegeRepository.Create(col);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Kollec Siyahısına yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/user/collegeedit/{model.UserId}");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +
        public IActionResult CreateColWithID(string id)  //  College with id Create Get
        {
            var model = new CollegeWIDDetailsModel()
            {
                UserId = id
            };
            return View(model);
        }  // +
        [HttpPost]
        public async Task<ActionResult> CreateColWithID(CollegeWIDDetailsModel model, IFormFile file1, IFormFile file2)   //  College with id Create Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                var col = new College()
                {
                    UserId = model.UserId,
                    CollegeName = model.CollegeName,
                    CollegeSpecialty = model.CollegeSpecialty,
                    College_StartDate = model.College_StartDate,
                    College_CompletionDate = model.College_CompletionDate
                };
                foreach (var item in users)
                {
                    if (item.Id == model.UserId)
                    {
                        if (file1 != null)
                        {
                            var extention = Path.GetExtension(file1.FileName);
                            var randomName = string.Format($"img_college_{model.UserId}_{Guid.NewGuid()}{extention}");
                            col.ImgUrl = randomName;
                            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{item.Email}", randomName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await file1.CopyToAsync(stream);
                            }
                        }
                        if (file2 != null)
                        {
                            var extention = Path.GetExtension(file2.FileName);
                            var randomName = string.Format($"pdf_college_{model.UserId}_{Guid.NewGuid()}{extention}");
                            col.PDFUrl = randomName;
                            var path0 = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{item.Email}", randomName);
                            using (var stream = new FileStream(path0, FileMode.Create))
                            {
                                await file2.CopyToAsync(stream);
                            }
                        }
                    }
                }
                _collegeRepository.Create(col);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Kollec Siyahısına yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/college/list/{model.UserId}");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +

        public IActionResult CreateUni()  //  Uni Create Get
        {
            var users = _userManager.Users.ToList();
            var model = new UniDetailsModel()
            {
                Users = users
            };
            return View(model);
        }  // +
        [HttpPost]
        public async Task<ActionResult> CreateUni(UniDetailsModel model, IFormFile file1, IFormFile file2)   //  Uni Create Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                var uni = new University()
                {
                    UserId = model.UserId,
                    UniversityLevel = model.UniversityLevel,
                    UniversityName = model.UniversityName,
                    UniversitySpecialty = model.UniversitySpecialty,
                    Uni_StartDate = model.Uni_StartDate,
                    Uni_CompletionDate = model.Uni_CompletionDate
                };
                foreach (var item in users)
                {
                    if (item.Id == model.UserId)
                    {
                        if (file1 != null)
                        {
                            var extention = Path.GetExtension(file1.FileName);
                            var randomName = string.Format($"img_uni_{model.UserId}_{Guid.NewGuid()}{extention}");
                            uni.ImgUrl = randomName;
                            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{item.Email}", randomName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await file1.CopyToAsync(stream);
                            }
                        }
                        if (file2 != null)
                        {
                            var extention = Path.GetExtension(file2.FileName);
                            var randomName = string.Format($"pdf_uni_{model.UserId}_{Guid.NewGuid()}{extention}");
                            uni.PDFUrl = randomName;
                            var path0 = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{item.Email}", randomName);
                            using (var stream = new FileStream(path0, FileMode.Create))
                            {
                                await file2.CopyToAsync(stream);
                            }
                        }
                    }
                }
                _universityRepository.Create(uni);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Universitet Siyahısına yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/user/universityedit/{model.UserId}");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +
        public IActionResult CreateUniWithID(string id)  //  Uni with id Create Get
        {
            var model = new UniWIDDetailsModel()
            {
                UserId = id
            };
            return View(model);
        }  // +
        [HttpPost]
        public async Task<ActionResult> CreateUniWithID(UniWIDDetailsModel model, IFormFile file1, IFormFile file2)   //  Uni with id Create Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                var uni = new University()
                {
                    UserId = model.UserId,
                    UniversityLevel = model.UniversityLevel,
                    UniversityName = model.UniversityName,
                    UniversitySpecialty = model.UniversitySpecialty,
                    Uni_StartDate = model.Uni_StartDate,
                    Uni_CompletionDate = model.Uni_CompletionDate
                };
                foreach (var item in users)
                {
                    if (item.Id == model.UserId)
                    {
                        if (file1 != null)
                        {
                            var extention = Path.GetExtension(file1.FileName);
                            var randomName = string.Format($"img_uni_{model.UserId}_{Guid.NewGuid()}{extention}");
                            uni.ImgUrl = randomName;
                            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{item.Email}", randomName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await file1.CopyToAsync(stream);
                            }
                        }
                        if (file2 != null)
                        {
                            var extention = Path.GetExtension(file2.FileName);
                            var randomName = string.Format($"pdf_uni_{model.UserId}_{Guid.NewGuid()}{extention}");
                            uni.PDFUrl = randomName;
                            var path0 = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{item.Email}", randomName);
                            using (var stream = new FileStream(path0, FileMode.Create))
                            {
                                await file2.CopyToAsync(stream);
                            }
                        }
                    }
                }
                _universityRepository.Create(uni);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Universitet Siyahısına yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/university/list/{model.UserId}");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +

        public IActionResult CreateCourse()  //  Course Create Get
        {
            var users = _userManager.Users.ToList();
            var model = new CourseDetailsModel()
            {
                Users = users
            };
            return View(model);
        }  // +
        [HttpPost]
        public async Task<ActionResult> CreateCourse(CourseDetailsModel model, IFormFile file1, IFormFile file2)   //  Course Create Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                var cor = new Course()
                {
                    UserId = model.UserId,
                    CourseName = model.CourseName,
                    CourseOnWhat = model.CourseOnWhat,
                    Course_StartDate = model.Course_StartDate,
                    Course_UCompletionDate = model.Course_UCompletionDate
                };
                foreach (var item in users)
                {
                    if (item.Id == model.UserId)
                    {
                        if (file1 != null)
                        {
                            var extention = Path.GetExtension(file1.FileName);
                            var randomName = string.Format($"img_uni_{model.UserId}_{Guid.NewGuid()}{extention}");
                            cor.ImgUrl = randomName;
                            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{item.Email}", randomName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await file1.CopyToAsync(stream);
                            }
                        }
                        if (file2 != null)
                        {
                            var extention = Path.GetExtension(file2.FileName);
                            var randomName = string.Format($"pdf_uni_{model.UserId}_{Guid.NewGuid()}{extention}");
                            cor.PDFUrl = randomName;
                            var path0 = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{item.Email}", randomName);
                            using (var stream = new FileStream(path0, FileMode.Create))
                            {
                                await file2.CopyToAsync(stream);
                            }
                        }
                    }
                }
                _courseRepository.Create(cor);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Kurs Siyahısına yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/user/courseedit/{model.UserId}");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +
        public IActionResult CreateCouWithID(string id)  //  Course with id Create Get
        {
            var model = new CourseWIDDetailsModel()
            {
                UserId = id
            };
            return View(model);
        }  // +
        [HttpPost]
        public async Task<ActionResult> CreateCouWithID(CourseWIDDetailsModel model, IFormFile file1, IFormFile file2)   //  Course with id Create Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                var cor = new Course()
                {
                    UserId = model.UserId,
                    CourseName = model.CourseName,
                    CourseOnWhat = model.CourseOnWhat,
                    Course_StartDate = model.Course_StartDate,
                    Course_UCompletionDate = model.Course_UCompletionDate
                };
                foreach (var item in users)
                {
                    if (item.Id == model.UserId)
                    {
                        if (file1 != null)
                        {
                            var extention = Path.GetExtension(file1.FileName);
                            var randomName = string.Format($"img_uni_{model.UserId}_{Guid.NewGuid()}{extention}");
                            cor.ImgUrl = randomName;
                            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{item.Email}", randomName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await file1.CopyToAsync(stream);
                            }
                        }
                        if (file2 != null)
                        {
                            var extention = Path.GetExtension(file2.FileName);
                            var randomName = string.Format($"pdf_uni_{model.UserId}_{Guid.NewGuid()}{extention}");
                            cor.PDFUrl = randomName;
                            var path0 = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{item.Email}", randomName);
                            using (var stream = new FileStream(path0, FileMode.Create))
                            {
                                await file2.CopyToAsync(stream);
                            }
                        }
                    }
                }
                _courseRepository.Create(cor);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Kurs Siyahısına yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/course/list/{model.UserId}");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +

        [HttpPost]
        public ActionResult CreateOtherSkills(WorkDetailsModel model, string Id)   //  Other Skills Create Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                var o = new OtherSkills()
                {
                    UserId = model.UserId,
                    Skill = model.os.Skill
                };
                _oskillsRepository.Create(o);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Bacarıq bölməsinə yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/user/workexpedit/{model.UserId}");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +

        public IActionResult CreateTimezone()  //  Timezone Create Get
        {
            return View();
        }  // +
        [HttpPost]
        public ActionResult CreateTimezone(TimeZonesDetailsModel model)   //  Timezone Create Post
        {
            if (ModelState.IsValid)
            {
                var tz = new TimeZones()
                {
                    TableName = model.TableName,
                    Type = model.Type,
                    OffDay = model.OffDay,
                    //StartDate = model.StartDate,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    One = model.One,
                    Two = model.Two,
                    Three = model.Three,
                    Four = model.Four,
                    Five = model.Five,
                    Six = model.Six,
                    Seven = model.Seven,
                    Eight = model.Eight,
                    Nine = model.Nine,
                    Ten = model.Ten,
                    Eleven = model.Eleven,
                    Twelve = model.Twelve,
                    Thirteen = model.Thirteen,
                    Fourteen = model.Fourteen,
                    Fifteen = model.Fifteen,
                    Sixteen = model.Sixteen,
                    Seventeen = model.Seventeen,
                    Eighteen = model.Eighteen,
                    Nineteen = model.Nineteen,
                    Twenty = model.Twenty,
                    TwentyOne = model.TwentyOne,
                    TwentyTwo = model.TwentyTwo,
                    TwentyThree = model.TwentyThree,
                    TwentyFour = model.TwentyFour,
                    TwentyFive = model.TwentyFive,
                    TwentySix = model.TwentySix,
                    TwentySeven = model.TwentySeven,
                    TwentyEight = model.TwentyEight,
                    TwentyNine = model.TwentyNine,
                    Thirty = model.Thirty,
                    ThirtyOne = model.ThirtyOne
                };

                _timeZonesRepository.Create(tz);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Yeni timezone əlavə edildi",
                    AlertType = "success"
                });
                return Redirect("/admin/timezones");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +

        public IActionResult CreateSalary()  //  Salary Create Get
        {
            var users = _userManager.Users.ToList();
            var zones = _timeZonesRepository.GetAll();

            var model = new SalaryDetailsModel()
            {
                Users = users,
                TimeZones = zones
            };
            return View(model);
        }  // +
        [HttpPost]
        public ActionResult CreateSalary(SalaryDetailsModel model)   //  Salary Create Post
        {
            if (ModelState.IsValid)
            {
                var sal = new Salary()
                {
                    UserId = model.UserId,
                    TimeZoneId = model.TimeZoneId,
                    Full_Salary = model.Full_Salary,
                    Hourly_Salary = model.Hourly_Salary,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate
                };

                _salaryRepository.Create(sal);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Maaş Siyahısına yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/user/salaryedit/{model.UserId}");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +
        public IActionResult CreateSalWithID(string id)  //  Salary with id Create Get
        {
            var model = new SalaryWIDDetailsModel()
            {
                UserId = id,
                TimeZones = _timeZonesRepository.GetAll()
            };
            return View(model);
        }  // +
        [HttpPost]
        public ActionResult CreateSalWithID(SalaryWIDDetailsModel model)   //  Salary with id Create Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                var sal = new Salary()
                {
                    UserId = model.UserId,
                    TimeZoneId = model.TimeZoneId,
                    Full_Salary = model.Full_Salary,
                    Hourly_Salary = model.Hourly_Salary,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate
                };

                _salaryRepository.Create(sal);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Maaş Siyahısına yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/user/salaryedit/{model.UserId}");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +

        [HttpPost]
        public ActionResult CreateSNSL(SocialNSLViewModel model)   //  Salary Create Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                var sal = new SocialNSList()
                {
                    Name = model.Name,
                    Key = model.Key
                };

                _snslRepository.Create(sal);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Sosial şəbəkə Siyahısına yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect("/admin/list/socialnetwork");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +

        public IActionResult CreatePenalty()  //  Penalty Create Get
        {
            var users = _userManager.Users.ToList();
            var model = new PenaltyDetailsModel()
            {
                Users = users,
                PenaltyReadies = _penaltyreadyRepository.GetAll()
            };
            return View(model);
        }  // +
        [HttpPost]
        public ActionResult CreatePenalty(PenaltyDetailsModel model)   //  Penalty Create Post
        {
            if (ModelState.IsValid)
            {
                var cor = new Penalty()
                {
                    UserId = model.UserId,
                    PenaltyAmount = model.PenaltyAmount,
                    Description = model.Description,
                    FinishDate = model.FinishDate
                };

                _penaltyRepository.Create(cor);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Cərimələrə yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/penalties");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +
        [HttpPost]
        public ActionResult CreatePenaltyR(PenaltyDetailsModel model)   //  Penalty With Ready Create Post
        {
            var pr = _penaltyreadyRepository.GetAll();
            if (ModelState.IsValid)
            {
                var cor = new Penalty()
                {
                    UserId = model.UserId
                };
                foreach (var r in pr)
                {
                    if (model.PenaltyId == r.Id)
                    {
                        cor.PenaltyAmount = r.PenaltyAmount;
                        cor.Description = r.PenaltyName;
                        cor.FinishDate = DateTime.Now;
                    }
                }

                _penaltyRepository.Create(cor);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Cərimələrə yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/penalties");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +
        public IActionResult CreatePenaltyWID(string id)  //  Penalty with id Create Get
        {
            var model = new PenaltyDetailsModel()
            {
                UserId = id,
                PenaltyReadies = _penaltyreadyRepository.GetAll()
            };
            return View(model);
        }  // +
        [HttpPost]
        public ActionResult CreatePenaltyWID(PenaltyDetailsModel model)   //  Penalty with id Create Post
        {
            if (ModelState.IsValid)
            {
                var cor = new Penalty()
                {
                    UserId = model.UserId,
                    PenaltyAmount = model.PenaltyAmount,
                    Description = model.Description,
                    FinishDate = model.FinishDate
                };

                _penaltyRepository.Create(cor);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Cərimələrə yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/penalties");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +
        [HttpPost]
        public ActionResult CreatePenaltyRWID(PenaltyDetailsModel model)   //  Penalty Ready with id Create Post
        {
            var pr = _penaltyreadyRepository.GetAll();
            if (ModelState.IsValid)
            {
                var cor = new Penalty()
                {
                    UserId = model.UserId
                };
                foreach (var r in pr)
                {
                    if (model.PenaltyId == r.Id)
                    {
                        cor.PenaltyAmount = r.PenaltyAmount;
                        cor.Description = r.PenaltyName;
                        cor.FinishDate = DateTime.Now;
                    }
                }

                _penaltyRepository.Create(cor);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Cərimələrə yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/penalties");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +
        [HttpPost]
        public ActionResult CreatePenaltyReady(ReadyPenaltyListViewModel model)   //  PenaltyReady Create Post
        {
            if (ModelState.IsValid)
            {
                var cor = new PenaltyReady()
                {
                    PenaltyName = model.PenaltyName,
                    PenaltyAmount = model.PenaltyAmount
                };

                _penaltyreadyRepository.Create(cor);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Hazır Cərimə əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/penalties/ready");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +

        public IActionResult CreateBonus()  //  Bonus Create Get
        {
            var users = _userManager.Users.ToList();
            var model = new BonusDetailsModel()
            {
                Users = users,
                BonusReadies = _bonusreadyRepository.GetAll()
            };
            return View(model);
        }  // +
        [HttpPost]
        public ActionResult CreateBonus(BonusDetailsModel model)   //  Bonus Create Post
        {
            if (ModelState.IsValid)
            {
                var cor = new Bonus()
                {
                    UserId = model.UserId,
                    BonusAmount = model.BonusAmount,
                    BonusPercent = model.BonusPercent,
                    Description = model.Description,
                    FinishDate = model.FinishDate
                };

                _bonusRepository.Create(cor);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Bonus əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/bonus");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +
        [HttpPost]
        public ActionResult CreateBonusR(BonusDetailsModel model)   //  Bonus With Ready Create Post
        {
            var br = _bonusreadyRepository.GetAll();
            if (ModelState.IsValid)
            {
                var cor = new Bonus()
                {
                    UserId = model.UserId
                };
                foreach (var r in br)
                {
                    if (model.BonusId == r.Id)
                    {
                        cor.BonusAmount = r.BonusAmount;
                        cor.BonusPercent = r.BonusPercent;
                        cor.Description = "(Ready)" + " " + r.BonusName;
                        cor.FinishDate = DateTime.Now;
                    }
                }

                _bonusRepository.Create(cor);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Bonus əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/bonus");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +
        public IActionResult CreateBonusWID(string id)  //  Penalty with id Create Get
        {
            var model = new BonusDetailsModel()
            {
                UserId = id,
                BonusReadies = _bonusreadyRepository.GetAll()
            };
            return View(model);
        }  // +
        [HttpPost]
        public ActionResult CreateBonusWID(BonusDetailsModel model)   //  Bonus with id Create Post
        {
            if (ModelState.IsValid)
            {
                var cor = new Bonus()
                {
                    UserId = model.UserId,
                    BonusAmount = model.BonusAmount,
                    BonusPercent = model.BonusPercent,
                    Description = model.Description,
                    FinishDate = model.FinishDate
                };

                _bonusRepository.Create(cor);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Bonus əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/bonus");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +
        [HttpPost]
        public ActionResult CreateBonusRWID(BonusDetailsModel model)   //  Bonus Ready with id Create Post
        {
            var br = _bonusreadyRepository.GetAll();
            if (ModelState.IsValid)
            {
                var cor = new Bonus()
                {
                    UserId = model.UserId
                };
                foreach (var r in br)
                {
                    if (model.BonusId == r.Id)
                    {
                        cor.BonusAmount = r.BonusAmount;
                        cor.BonusPercent = r.BonusPercent;
                        cor.Description = "(Ready)" + " " + r.BonusName;
                        cor.FinishDate = DateTime.Now;
                    }
                }

                _bonusRepository.Create(cor);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Bonus əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/bonus");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +
        [HttpPost]
        public ActionResult CreateBonusReady(ReadyBonusListViewModel model)   //  BonusReady Create Post
        {
            if (ModelState.IsValid)
            {
                if (model.BonusAmount == 0 && model.BonusPercent == 0)
                {
                    double diger = model.Hourly_Amount * model.Work_Hour * model.Work_Day;

                    var cor = new BonusReady()
                    {
                        BonusName = model.BonusName,
                        BonusAmount = diger
                    };

                    _bonusreadyRepository.Create(cor);
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Uğurlu Nəticə",
                        Message = "Hazır Bonus əlavə edildi",
                        AlertType = "success"
                    });
                    return Redirect($"/admin/bonus/ready");
                }
                else
                {
                    var cor = new BonusReady()
                    {
                        BonusName = model.BonusName,
                        BonusAmount = model.BonusAmount,
                        BonusPercent = model.BonusPercent
                    };

                    _bonusreadyRepository.Create(cor);
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Uğurlu Nəticə",
                        Message = "Hazır Bonus əlavə edildi",
                        AlertType = "success"
                    });
                    return Redirect($"/admin/bonus/ready");
                }
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +


        public IActionResult CreateArchive()  //  ArchiveArchive Create Get
        {
            var users = _userManager.Users.ToList();
            var model = new ArchiveDetailsModel()
            {
                Users = users
            };
            return View(model);
        }  // +
        [HttpPost]
        public ActionResult CreateArchive(ArchiveDetailsModel model)   //  ArchiveArchive Create Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                var cor = new Archive()
                {
                    UserId = model.UserId,
                    SalaryDate = model.SalaryDate,
                    Salary = model.Salary,
                    Type = model.Type,
                    Description = model.Description
                };

                _archiveRepository.Create(cor);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Arxivə yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/archives");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +
        public IActionResult CreateArchiveWID(string id)  //  Archive with id Create Get
        {
            var model = new ArchiveDetailsModel()
            {
                UserId = id,
                Users = _userManager.Users.Where(i => i.Id == id).ToList(),
                Salaries = _salaryRepository.GetAll().Where(i => i.UserId == id).ToList(),
                Penalties = _penaltyRepository.GetAll().Where(i => i.UserId == id).ToList(),
                TimeZones = _timeZonesRepository.GetAll(),
                Archives = _archiveRepository.GetAll().Where(i => i.UserId == id).ToList()
            };
            return View(model);
        }  // +
        [HttpPost]
        public ActionResult CreateArchiveWID(ArchiveDetailsModel model)   //  Archive with id Create Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                var cor = new Archive()
                {
                    UserId = model.UserId,
                    SalaryDate = model.SalaryDate,
                    Salary = model.Salary,
                    Type = model.Type,
                    Description = model.Description
                };

                _archiveRepository.Create(cor);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Uğurlu Nəticə",
                    Message = "Arxivə yeni məlumat əlavə edildi",
                    AlertType = "success"
                });
                return Redirect($"/admin/archives");
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Məlumatlar doğru doldurulmadı",
                AlertType = "warning"
            });
            return View(model);
        }  // +

        [HttpPost]
        public ActionResult AutoArchive(string id)   // Auto Archive with id Create Post
        {
            if (id != null)
            {
                double sal = 0;
                var penalty = _penaltyRepository.GetAll().Where(i => i.UserId == id && i.FinishDate.Month == DateTime.Now.Month && i.FinishDate.Year == DateTime.Now.Year).ToList();
                var bonus = _bonusRepository.GetAll().Where(i => i.UserId == id && i.FinishDate.Month == DateTime.Now.Month && i.FinishDate.Year == DateTime.Now.Year).ToList();
                foreach (var p in penalty)
                {
                    sal -= p.PenaltyAmount;
                }
                foreach (var b in bonus)
                {
                    if (b.BonusAmount != 0 && b.BonusPercent == 0)
                    {
                        sal += b.BonusAmount;
                    }
                }

                var sala = _salaryRepository.GetAll().Where(i => i.UserId == id).ToList();
                foreach (var e in sala)
                {
                    double q = 0;
                    if (e.Full_Salary > 0 && e.Hourly_Salary == 0)
                    {

                        var arc = _archiveRepository.GetAll().Where(i => i.UserId == id && i.SalaryDate.Month == DateTime.Now.Month && i.SalaryDate.Year == DateTime.Now.Year && i.Type == true).ToList();
                        foreach (var a in arc)
                        {
                            sal -= a.Salary;
                        }
                        foreach (var b in bonus)
                        {
                            if (b.BonusAmount == 0 && b.BonusPercent != 0)
                            {
                                q += e.Full_Salary * b.BonusPercent / 100;
                            }
                        }
                        sal += (e.Full_Salary + q);

                        var cor = new Archive()
                        {
                            UserId = id,
                            SalaryDate = DateTime.Now,
                            Type = false,
                            Description = "Auto Maaş",
                            Salary = sal
                        };

                        _archiveRepository.Create(cor);
                        TempData.Put("message", new AlertMessage()
                        {
                            Title = "Uğurlu Ödəniş Edildi",
                            Message = $"{sal} ödənildi",
                            AlertType = "success"
                        });
                        return Redirect($"/admin/user/edit/{id}");
                    }
                    else if (e.Full_Salary == 0 && e.Hourly_Salary > 0)
                    {
                        var arc = _archiveRepository.GetAll().Where(i => i.UserId == id && i.SalaryDate.Month == DateTime.Now.Month && i.SalaryDate.Year == DateTime.Now.Year && i.Type == true).ToList();
                        foreach (var a in arc)
                        {
                            sal -= a.Salary;
                        }

                        var tz = _timeZonesRepository.GetAll().Where(i => i.Id == e.TimeZoneId).ToList();
                        foreach (var t in tz)
                        {
                            double timeoneday = 0;
                            if ((t.EndTime - t.StartTime).TotalHours > 0)
                            {
                                timeoneday = ((t.EndTime - t.StartTime).TotalHours) * e.Hourly_Salary;
                            }
                            else
                            {
                                timeoneday = ((24 - t.StartTime.Hour) + t.EndTime.Hour) * e.Hourly_Salary;
                            }

                            if (t.Type == "Manual Həftə")
                            {
                                int count = 0;
                                if (t.One == true) count += 1;
                                if (t.Two == true) count += 1;
                                if (t.Three == true) count += 1;
                                if (t.Four == true) count += 1;
                                if (t.Five == true) count += 1;
                                if (t.Six == true) count += 1;
                                if (t.Seven == true) count += 1;

                                foreach (var b in bonus)
                                {
                                    if (b.BonusAmount == 0 && b.BonusPercent != 0)
                                    {
                                        q += count * timeoneday * 4 * b.BonusPercent / 100;
                                    }
                                }

                                sal += (count * timeoneday * 4) + q;

                                var cor = new Archive()
                                {
                                    UserId = id,
                                    SalaryDate = DateTime.Now,
                                    Type = false,
                                    Description = "Auto Maaş (Not:saatlıq hesablar 28 günlükdür)",
                                    Salary = sal
                                };

                                _archiveRepository.Create(cor);
                                TempData.Put("message", new AlertMessage()
                                {
                                    Title = "Uğurlu Ödəniş Edildi",
                                    Message = $"{sal} ödənildi",
                                    AlertType = "success"
                                });
                                return Redirect($"/admin/user/edit/{id}");
                            }
                            else if (t.Type == "Manual Ay")
                            {
                                int count = 0;
                                if (t.One == true) count += 1;
                                if (t.Two == true) count += 1;
                                if (t.Three == true) count += 1;
                                if (t.Four == true) count += 1;
                                if (t.Five == true) count += 1;
                                if (t.Six == true) count += 1;
                                if (t.Seven == true) count += 1;
                                if (t.Eight == true) count += 1;
                                if (t.Nine == true) count += 1;
                                if (t.Ten == true) count += 1;
                                if (t.Eleven == true) count += 1;
                                if (t.Twelve == true) count += 1;
                                if (t.Thirteen == true) count += 1;
                                if (t.Fourteen == true) count += 1;
                                if (t.Fifteen == true) count += 1;
                                if (t.Sixteen == true) count += 1;
                                if (t.Seventeen == true) count += 1;
                                if (t.Eighteen == true) count += 1;
                                if (t.Nineteen == true) count += 1;
                                if (t.Twenty == true) count += 1;
                                if (t.TwentyOne == true) count += 1;
                                if (t.TwentyTwo == true) count += 1;
                                if (t.TwentyThree == true) count += 1;
                                if (t.TwentyFour == true) count += 1;
                                if (t.TwentyFive == true) count += 1;
                                if (t.TwentySix == true) count += 1;
                                if (t.TwentySeven == true) count += 1;
                                if (t.TwentyEight == true) count += 1;
                                if (DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) == 29)
                                {
                                    if (t.TwentyNine == true) count += 1;
                                }
                                if (DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) == 30)
                                {
                                    if (t.Thirty == true) count += 1;
                                }
                                if (DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) == 31)
                                {
                                    if (t.ThirtyOne == true) count += 1;
                                }

                                foreach (var b in bonus)
                                {
                                    if (b.BonusAmount == 0 && b.BonusPercent != 0)
                                    {
                                        q += count * timeoneday * b.BonusPercent / 100;
                                    }
                                }

                                sal += count * timeoneday + q;

                                var cor = new Archive()
                                {
                                    UserId = id,
                                    SalaryDate = DateTime.Now,
                                    Type = false,
                                    Description = "Auto Maaş",
                                    Salary = sal
                                };

                                _archiveRepository.Create(cor);
                                TempData.Put("message", new AlertMessage()
                                {
                                    Title = "Uğurlu Ödəniş Edildi",
                                    Message = $"{sal} ödənildi",
                                    AlertType = "success"
                                });
                                return Redirect($"/admin/user/edit/{id}");
                            }
                            else if (t.Type == "Neçə Gündən Bir")
                            {
                                double r = Math.Floor((DateTime.Now - e.StartDate).TotalDays / (t.OffDay + 1));
                                double w = r * (t.OffDay + 1);
                                DateTime f = e.StartDate.AddDays(w);
                                int c = -1;

                                for (int i = f.Day; i <= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i = i + (t.OffDay + 1))
                                {
                                    if (i <= 31)
                                    {
                                        c++;
                                    }
                                }

                                for (int i = f.Day; i >= 1; i = i - (t.OffDay + 1))
                                {
                                    if (i >= 1)
                                    {
                                        c++;
                                    }
                                }

                                foreach (var b in bonus)
                                {
                                    if (b.BonusAmount == 0 && b.BonusPercent != 0)
                                    {
                                        q += c * timeoneday * b.BonusPercent / 100;
                                    }
                                }

                                sal += c * timeoneday + q;

                                var cor = new Archive()
                                {
                                    UserId = id,
                                    SalaryDate = DateTime.Now,
                                    Type = false,
                                    Description = "Auto Maaş",
                                    Salary = sal
                                };

                                _archiveRepository.Create(cor);
                                TempData.Put("message", new AlertMessage()
                                {
                                    Title = "Uğurlu Ödəniş Edildi",
                                    Message = $"{sal} ödənildi",
                                    AlertType = "success"
                                });
                                return Redirect($"/admin/user/edit/{id}");
                            }
                        }
                    }
                }
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Xəta",
                Message = "Bilinməyən Xəta Baş Verdi",
                AlertType = "warning"
            });
            return Redirect($"/admin/user/edit/{id}");
        }  // +


        /////////////////////////////////////////////////// UserEdit //
        public async Task<IActionResult> EditUser(string Id)
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

        public async Task<IActionResult> EditIDCUser(string id)  // ID Card Edit Get
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var selectedRoles = await _userManager.GetRolesAsync(user);
                var roles = _roleManager.Roles.Select(i => i.Name);

                ViewBag.Roles = roles;
                return View(new UserDetailsModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    ARAddress = user.ARAddress,
                    IsApproved = user.IsApproved,
                    Sex = user.Sex,
                    CitizenShip = user.CitizenShip,
                    DoB = user.DoB,
                    SerialNumber = user.SerialNumber,
                    IdentificationNumber = user.IdentificationNumber,
                    PeriodOfValidity = user.PeriodOfValidity,
                    BloodGroup = user.BloodGroup,
                    ImgUrl = user.ImgUrl,
                    PDFUrl = user.PDFUrl,
                    SelectedRoles = selectedRoles
                });
            }
            return Redirect("/admin/users");
        }  // +
        [HttpPost]
        public async Task<IActionResult> EditIDCUser(UserDetailsModel model, string[] selectedRoles, IFormFile file1, IFormFile file2)
        {
            if (ModelState.IsValid)                                          // ID Card Edit Post
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    double per = 0;
                    if (model.UserName != null)
                    {
                        per += 6.666666666666667;
                    }
                    if (model.Email != null)
                    {
                        per += 6.666666666666667;
                    }
                    if (model.FirstName != null)
                    {
                        per += 6.666666666666667;
                    }
                    if (model.LastName != null)
                    {
                        per += 6.666666666666667;
                    }
                    if (model.Sex != null)
                    {
                        per += 6.666666666666667;
                    }
                    if (model.CitizenShip != null)
                    {
                        per += 6.666666666666667;
                    }
                    if (model.DoB != DateTime.MinValue)
                    {
                        per += 6.666666666666667;
                    }
                    if (model.SerialNumber != null)
                    {
                        per += 6.666666666666667;
                    }
                    if (model.IdentificationNumber != null)
                    {
                        per += 6.666666666666667;
                    }
                    if (model.PeriodOfValidity != DateTime.MinValue)
                    {
                        per += 6.666666666666667;
                    }
                    if (model.BloodGroup != null)
                    {
                        per += 6.666666666666667;
                    }
                    if (model.ARAddress != null)
                    {
                        per += 6.666666666666667;
                    }
                    if (model.FatherName != null)
                    {
                        per += 6.666666666666667;
                    }
                    if (model.ImgUrl != null)
                    {
                        per += 6.666666666666667;
                    }
                    if (model.PDFUrl != null)
                    {
                        per += 6.666666666666667;
                    }
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.EmailConfirmed = model.EmailConfirmed;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.FatherName = model.FatherName;
                    user.ARAddress = model.ARAddress;
                    user.IsApproved = model.IsApproved;
                    user.Sex = model.Sex;
                    user.CitizenShip = model.CitizenShip;
                    user.DoB = model.DoB;
                    user.SerialNumber = model.SerialNumber;
                    user.IdentificationNumber = model.IdentificationNumber;
                    user.PeriodOfValidity = model.PeriodOfValidity;
                    user.BloodGroup = model.BloodGroup;
                    user.PercentID = per;

                    if (file1 != null)
                    {
                        var extention = Path.GetExtension(file1.FileName);
                        var randomName = string.Format($"img_idcard_{model.FirstName}_{model.LastName}_{model.UserId}_{Guid.NewGuid()}{extention}");
                        user.ImgUrl = randomName;
                        var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{model.Email}", randomName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file1.CopyToAsync(stream);
                        }
                    }
                    if (file2 != null)
                    {
                        var extention = Path.GetExtension(file2.FileName);
                        var randomName = string.Format($"pdf_idcard_{model.FirstName}_{model.LastName}_{model.UserId}_{Guid.NewGuid()}{extention}");
                        user.PDFUrl = randomName;
                        var path0 = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{model.Email}", randomName);
                        using (var stream = new FileStream(path0, FileMode.Create))
                        {
                            await file2.CopyToAsync(stream);
                        }
                    }
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        selectedRoles = selectedRoles ?? new string[] { };
                        await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles).ToArray<string>());
                        await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles).ToArray<string>());

                        return Redirect("/admin/users");
                    }
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "İstifadəçi profil yenilənməsi",
                        Message = $"{model.FirstName} {model.LastName} adlı istifadəçinin profili tənzimləndi",
                        AlertType = "success"
                    });
                }
                return Redirect("/admin/users");
            }
            return View(model);
        } // +

        public async Task<IActionResult> EditFUser(string id) // Family Edit Get
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(new UserDetailsModel()
                {
                    UserId = user.Id,
                    FatherName = user.FatherName,
                    MotherName = user.MotherName,
                    MaritalStatus = user.MaritalStatus,
                    Spouse = user.Spouse,
                    Family = _childrepository.GetAll().Where(i => i.UserId == id).ToList(),
                });
            }
            return Redirect($"/admin/user/edit/{id}");
        }  // +
        [HttpPost]
        public async Task<IActionResult> EditFUser(UserDetailsModel model)  // Family Edit Post
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    double per = 0;
                    if (model.FatherName != null)
                    {
                        per += 25;
                    }
                    if (model.MotherName != null)
                    {
                        per += 25;
                    }
                    if (model.MaritalStatus != null)
                    {
                        per += 25;
                    }
                    if (model.Spouse != null)
                    {
                        per += 25;
                    }
                    user.FatherName = model.FatherName;
                    user.MotherName = model.MotherName;
                    user.MaritalStatus = model.MaritalStatus;
                    user.Spouse = model.Spouse;
                    user.PercentF = per;
                    var entity = new Children()
                    {
                        UserId = model.UserId,
                        FullName = model.fdm.FullName,
                        Sex = model.fdm.Sex,
                        DoB = model.fdm.DoB
                    };
                    _childrepository.Create(entity);
                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        return Redirect($"/admin/user/familyedit/{model.UserId}");
                    }
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Məlumatlandırma",
                        Message = $"Uğurla məlumatlar təzimləndi",
                        AlertType = "success"
                    });

                }
                return Redirect("/admin/users");
            }
            return View(model);
        }  // +

        public async Task<IActionResult> EditBDUser(string id) // Body Dimensions Edit Get
        {
            var user = await _userManager.FindByIdAsync(id);
            var entity1 = _bdRepository.GetAll();

            foreach (var e in entity1)
            {
                if (e.UserId == id)
                {
                    var entity = _bdRepository.GetById((int)e.Id);

                    if (entity == null)
                    {
                        return NotFound();
                    }

                    var model = new BodyDDetailsModel()
                    {
                        Id = entity.Id,
                        UserId = user.Id,
                        Height = entity.Height,
                        Weight = entity.Weight,
                        FootSize = entity.FootSize,
                        BodyDimensionUp = entity.BodyDimensionUp,
                        BodyDimensionDown = entity.BodyDimensionDown,
                        HeadDimension = entity.HeadDimension,
                        //Users = _userManager.Users.ToList(),
                    };
                    return View(model);
                }
            }

            TempData.Put("message", new AlertMessage()
            {
                Title = "Tapılmadı",
                Message = $"Yeni yaradılmalıdır",
                AlertType = "warning"
            });
            return Redirect($"/admin/create/bodyd/{id}");
        }  // +
        [HttpPost]
        public async Task<IActionResult> EditBDUser(BodyDDetailsModel model)  // Body Dimensions Edit Post
        {
            if (ModelState.IsValid)
            {
                double per = 0;
                if (model.HeadDimension != null)
                {
                    per += 16.6;
                }
                if (model.BodyDimensionUp != null)
                {
                    per += 16.6;
                }
                if (model.BodyDimensionDown != null)
                {
                    per += 16.6;
                }
                if (model.FootSize != 0)
                {
                    per += 16.6;
                }
                if (model.Height != 0)
                {
                    per += 16.6;
                }
                if (model.Weight != 0)
                {
                    per += 16.6;
                }
                var entity = _bdRepository.GetById(model.Id);

                var user = await _userManager.FindByIdAsync(entity.UserId);
                user.PercentBD = per;

                if (entity == null)
                {
                    return NotFound();
                }
                entity.HeadDimension = model.HeadDimension;
                entity.BodyDimensionUp = model.BodyDimensionUp;
                entity.BodyDimensionDown = model.BodyDimensionDown;
                entity.FootSize = model.FootSize;
                entity.Height = model.Height;
                entity.Weight = model.Weight;
                entity.PercentBD = per;

                _bdRepository.Update(entity);
                await _userManager.UpdateAsync(user);

                TempData.Put("message", new AlertMessage()
                {
                    Title = "Məlumatlandırma",
                    Message = $"Uğurla məlumatlar təzimləndi",
                    AlertType = "success"
                });
                return Redirect($"/admin/user/bodydedit/{entity.UserId}");
            }
            return View(model);
        }  // +

        public async Task<IActionResult> EditDLUser(string id) // Driving License Edit Get
        {
            var user = await _userManager.FindByIdAsync(id);
            var entity1 = _dlRepository.GetAll();

            foreach (var e in entity1)
            {
                if (e.UserId == id)
                {
                    var entity = _dlRepository.GetById((int)e.Id);

                    if (entity == null)
                    {
                        return NotFound();
                    }

                    var model = new DrivingLDetailsModel()
                    {
                        Id = entity.Id,
                        UserId = user.Id,
                        IssuingAuthority = entity.IssuingAuthority,
                        DL_SerialNumber = entity.DL_SerialNumber,
                        StartDate = entity.StartDate,
                        ExpirationDate = entity.ExpirationDate,
                        Categories = entity.Categories,
                        ImgUrl = entity.ImgUrl,
                        PDFUrl = entity.PDFUrl,
                        Users = _userManager.Users.ToList(),
                    };
                    return View(model);
                }
            }

            TempData.Put("message", new AlertMessage()
            {
                Title = "Tapılmadı",
                Message = $"Yeni yaradılmalıdır",
                AlertType = "warning"
            });
            return Redirect($"/admin/create/drivingl/{id}");
        }  // +
        [HttpPost]
        public async Task<IActionResult> EditDLUser(DrivingLDetailsModel model, IFormFile file1, IFormFile file2)  // Driving License Edit Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                double per = 0;
                if (model.IssuingAuthority != null)
                {
                    per += 20;
                }
                if (model.DL_SerialNumber != null)
                {
                    per += 20;
                }
                if (model.StartDate != DateTime.MinValue)
                {
                    per += 20;
                }
                if (model.ExpirationDate != DateTime.MinValue)
                {
                    per += 20;
                }
                if (model.Categories != null)
                {
                    per += 20;
                }
                if (model.ImgUrl != null)
                {
                    per += 20;
                }
                if (model.PDFUrl != null)
                {
                    per += 20;
                }
                var entity = _dlRepository.GetById(model.Id);

                var user = await _userManager.FindByIdAsync(entity.UserId);
                user.PercentDl = per;

                if (entity == null)
                {
                    return NotFound();
                }
                entity.IssuingAuthority = model.IssuingAuthority;
                entity.DL_SerialNumber = model.DL_SerialNumber;
                entity.StartDate = model.StartDate;
                entity.ExpirationDate = model.ExpirationDate;
                entity.Categories = model.Categories;
                entity.PercentDL = per;
                foreach (var e in users)
                {
                    if (e.Id == model.UserId)
                    {
                        if (file1 != null)
                        {
                            var extention = Path.GetExtension(file1.FileName);
                            var randomName = string.Format($"img_drivingcard_{model.UserId}_{Guid.NewGuid()}{extention}");
                            entity.ImgUrl = randomName;
                            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{e.Email}", randomName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await file1.CopyToAsync(stream);
                            }
                        }
                        if (file2 != null)
                        {
                            var extention = Path.GetExtension(file2.FileName);
                            var randomName = string.Format($"pdf_drivingcard_{model.UserId}_{Guid.NewGuid()}{extention}");
                            entity.PDFUrl = randomName;
                            var path0 = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{e.Email}", randomName);
                            using (var stream = new FileStream(path0, FileMode.Create))
                            {
                                await file2.CopyToAsync(stream);
                            }
                        }
                    }
                }

                _dlRepository.Update(entity);
                await _userManager.UpdateAsync(user);

                TempData.Put("message", new AlertMessage()
                {
                    Title = "Məlumatlandırma",
                    Message = $"Uğurla məlumatlar təzimləndi",
                    AlertType = "success"
                });
                return Redirect($"/admin/user/bodydedit/{entity.UserId}");
            }
            return View(model);
        }  // +

        public async Task<IActionResult> EditWEUser(string id) // Work EXP Edit Get
        {
            var user = await _userManager.FindByIdAsync(id);
            var entity1 = _workEXPRepository.GetAll();
            var entity2 = _oskillsRepository.GetAll().Where(i => i.UserId == id).ToList();

            foreach (var e in entity1)
            {
                if (e.UserId == id)
                {
                    var entity = _workEXPRepository.GetById((int)e.Id);

                    if (entity == null)
                    {
                        return NotFound();
                    }

                    var model = new WorkDetailsModel()
                    {
                        Id = entity.Id,
                        UserId = user.Id,
                        Company = entity.Company,
                        Employer = entity.Employer,
                        Start = entity.Start,
                        Resignation = entity.Resignation,
                        CVPDF = entity.CVPDF,
                        Users = _userManager.Users.ToList(),
                        OSkills = entity2
                    };
                    return View(model);
                }
            }

            TempData.Put("message", new AlertMessage()
            {
                Title = "Tapılmadı",
                Message = $"Yeni yaradılmalıdır",
                AlertType = "warning"
            });
            return Redirect($"/admin/create/workexp/{id}");
        }  // +
        [HttpPost]
        public async Task<IActionResult> EditWEUser(WorkDetailsModel model, IFormFile file)  // Work EXP Edit Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                var entity = _workEXPRepository.GetById(model.Id);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.Company = model.Company;
                entity.Employer = model.Employer;
                entity.Start = model.Start;
                entity.Resignation = model.Resignation;
                entity.CVPDF = model.CVPDF;
                foreach (var e in users)
                {
                    if (e.Id == model.UserId)
                    {
                        if (file != null)
                        {
                            var extention = Path.GetExtension(file.FileName);
                            var randomName = string.Format($"pdf_cv_{model.UserId}_{Guid.NewGuid()}{extention}");
                            entity.CVPDF = randomName;
                            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{e.Email}", randomName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }
                        }
                    }
                }

                _workEXPRepository.Update(entity);

                TempData.Put("message", new AlertMessage()
                {
                    Title = "Məlumatlandırma",
                    Message = $"Uğurla məlumatlar təzimləndi",
                    AlertType = "success"
                });
                return Redirect($"/admin/user/workexpedit/{entity.UserId}");
            }
            return View(model);
        }  // +


        public async Task<IActionResult> EditCUser(string id) // Contact Edit Get
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(new ContactDetailsModel()
                {
                    UserId = user.Id,
                    Mp = _mphoneRepository.GetAll().Where(i => i.UserId == id).ToList(),
                    Em = _emailRepository.GetAll().Where(i => i.UserId == id).ToList(),
                    Sn = _socialNRepository.GetAll().Where(i => i.UserId == id).ToList(),
                    Snsl = _snslRepository.GetAll().ToList(),
                });
            }
            return Redirect($"/admin/user/edit/{id}");
        }  // +
        [HttpPost]
        public async Task<IActionResult> EditEmail(ContactDetailsModel model)  // Contact(Email) Edit Post
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    var entity = new Email()
                    {
                        UserId = model.UserId,
                        Emails = model.Emails
                    };
                    _emailRepository.Create(entity);

                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Məlumatlandırma",
                        Message = $"Uğurla məlumatlar təzimləndi",
                        AlertType = "success"
                    });
                    return Redirect($"/admin/user/contactedit/{model.UserId}");
                }
                return Redirect("/admin/users");
            }
            return View(model);
        }  // +
        [HttpPost]
        public async Task<IActionResult> EditMP(ContactDetailsModel model)  // Contact(MobilePhone) Edit Post
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    var entity = new MobilePhone()
                    {
                        UserId = model.UserId,
                        MobileNumber = model.MobileNumber
                    };
                    _mphoneRepository.Create(entity);

                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Məlumatlandırma",
                        Message = $"Uğurla məlumatlar təzimləndi",
                        AlertType = "success"
                    });
                    return Redirect($"/admin/user/contactedit/{model.UserId}");
                }
                return Redirect("/admin/users");
            }
            return View(model);
        }  // +
        [HttpPost]
        public async Task<IActionResult> EditSN(ContactDetailsModel model)  // Contact(SocialNetwork) Edit Post
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    var entity = new SocialNetwork()
                    {
                        UserId = model.UserId,
                        SocialNetworkName = model.SocialNetworkName,
                        Link = model.Link
                    };
                    _socialNRepository.Create(entity);

                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Məlumatlandırma",
                        Message = $"Uğurla məlumatlar təzimləndi",
                        AlertType = "success"
                    });
                    return Redirect($"/admin/user/contactedit/{model.UserId}");
                }
                return Redirect("/admin/users");
            }
            return View(model);
        }  // +


        public async Task<IActionResult> EditStudyList(string Id)
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
        public async Task<IActionResult> EditScUser(string id) // School Edit Get
        {
            var user = await _userManager.FindByIdAsync(id);
            var entity1 = _schoolRepository.GetAll();

            foreach (var e in entity1)
            {
                if (e.UserId == id)
                {
                    var entity = _schoolRepository.GetById((int)e.Id);

                    if (entity == null)
                    {
                        return NotFound();
                    }

                    var model = new SchoolDetailsModel()
                    {
                        Id = entity.Id,
                        UserId = user.Id,
                        SchoolName = entity.SchoolName,
                        School_StartDate = entity.School_StartDate,
                        School_CompletionDate = entity.School_CompletionDate,
                        ImgUrl = entity.ImgUrl,
                        PDFUrl = entity.PDFUrl,
                        Users = _userManager.Users.ToList(),
                    };
                    return View(model);
                }
            }

            TempData.Put("message", new AlertMessage()
            {
                Title = "Tapılmadı",
                Message = $"Yeni yaradılmalıdır",
                AlertType = "warning"
            });
            return Redirect($"/admin/create/school/{id}");
        }  // +
        [HttpPost]
        public async Task<IActionResult> EditScUser(SchoolDetailsModel model, IFormFile file1, IFormFile file2)  // School Edit Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                double per = 0;
                if (model.SchoolName != null)
                {
                    per += 20;
                }
                if (model.ImgUrl != null)
                {
                    per += 20;
                }
                if (model.PDFUrl != null)
                {
                    per += 20;
                }
                if (model.School_StartDate != DateTime.MinValue)
                {
                    per += 20;
                }
                if (model.School_CompletionDate != DateTime.MinValue)
                {
                    per += 20;
                }
                var entity = _schoolRepository.GetById(model.Id);
                var user = await _userManager.FindByIdAsync(entity.UserId);
                user.PercentS = per;

                if (entity == null)
                {
                    return NotFound();
                }
                entity.SchoolName = model.SchoolName;
                entity.School_StartDate = model.School_StartDate;
                entity.School_CompletionDate = model.School_CompletionDate;
                foreach (var e in users)
                {
                    if (e.Id == model.UserId)
                    {
                        if (file1 != null)
                        {
                            var extention = Path.GetExtension(file1.FileName);
                            var randomName = string.Format($"img_school_{model.UserId}_{Guid.NewGuid()}{extention}");
                            entity.ImgUrl = randomName;
                            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{e.Email}", randomName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await file1.CopyToAsync(stream);
                            }
                        }
                        if (file2 != null)
                        {
                            var extention = Path.GetExtension(file2.FileName);
                            var randomName = string.Format($"pdf_school_{model.UserId}_{Guid.NewGuid()}{extention}");
                            entity.PDFUrl = randomName;
                            var path0 = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{e.Email}", randomName);
                            using (var stream = new FileStream(path0, FileMode.Create))
                            {
                                await file2.CopyToAsync(stream);
                            }
                        }
                    }
                }

                _schoolRepository.Update(entity);
                await _userManager.UpdateAsync(user);

                TempData.Put("message", new AlertMessage()
                {
                    Title = "Məlumatlandırma",
                    Message = $"Uğurla məlumatlar təzimləndi",
                    AlertType = "success"
                });
                return Redirect($"/admin/user/schooledit/{entity.UserId}");
            }
            return View(model);
        }  // +
        public IActionResult EditColUser(int id) // College Edit Get
        {
            var entity = _collegeRepository.GetById((int)id);

            if (entity == null)
            {
                return NotFound();
            }

            var model = new CollegeDetailsModel()
            {
                Id = entity.Id,
                UserId = entity.UserId,
                CollegeName = entity.CollegeName,
                CollegeSpecialty = entity.CollegeSpecialty,
                College_StartDate = entity.College_StartDate,
                College_CompletionDate = entity.College_CompletionDate,
                ImgUrl = entity.ImgUrl,
                PDFUrl = entity.PDFUrl,
                Users = _userManager.Users.ToList(),
            };
            return View(model);
        }  // +
        [HttpPost]
        public async Task<IActionResult> EditColUser(CollegeDetailsModel model, IFormFile file1, IFormFile file2)  // College Edit Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                var entity = _collegeRepository.GetById(model.Id);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.CollegeName = model.CollegeName;
                entity.CollegeSpecialty = model.CollegeSpecialty;
                entity.College_StartDate = model.College_StartDate;
                entity.College_CompletionDate = model.College_CompletionDate;
                foreach (var e in users)
                {
                    if (e.Id == model.UserId)
                    {
                        if (file1 != null)
                        {
                            var extention = Path.GetExtension(file1.FileName);
                            var randomName = string.Format($"img_college_{model.UserId}_{Guid.NewGuid()}{extention}");
                            entity.ImgUrl = randomName;
                            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{e.Email}", randomName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await file1.CopyToAsync(stream);
                            }
                        }
                        if (file2 != null)
                        {
                            var extention = Path.GetExtension(file2.FileName);
                            var randomName = string.Format($"pdf_college_{model.UserId}_{Guid.NewGuid()}{extention}");
                            entity.PDFUrl = randomName;
                            var path0 = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{e.Email}", randomName);
                            using (var stream = new FileStream(path0, FileMode.Create))
                            {
                                await file2.CopyToAsync(stream);
                            }
                        }
                    }
                }
                _collegeRepository.Update(entity);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Məlumatlandırma",
                    Message = $"Uğurla məlumatlar təzimləndi",
                    AlertType = "success"
                });
                return Redirect($"/admin/college/list/{entity.UserId}");
            }
            return View(model);
        }  // +
        public IActionResult EditUniUser(int id) // Uni Edit Get
        {
            var entity = _universityRepository.GetById((int)id);

            if (entity == null)
            {
                return NotFound();
            }

            var model = new UniDetailsModel()
            {
                Id = entity.Id,
                UserId = entity.UserId,
                UniversityLevel = entity.UniversityLevel,
                UniversityName = entity.UniversityName,
                UniversitySpecialty = entity.UniversitySpecialty,
                Uni_StartDate = entity.Uni_StartDate,
                Uni_CompletionDate = entity.Uni_CompletionDate,
                ImgUrl = entity.ImgUrl,
                PDFUrl = entity.PDFUrl,
                Users = _userManager.Users.ToList(),
            };
            return View(model);
        }  // +
        [HttpPost]
        public async Task<IActionResult> EditUniUser(UniDetailsModel model, IFormFile file1, IFormFile file2)  // Uni Edit Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                var entity = _universityRepository.GetById(model.Id);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.UniversityLevel = model.UniversityLevel;
                entity.UniversityName = model.UniversityName;
                entity.UniversitySpecialty = model.UniversitySpecialty;
                entity.Uni_StartDate = model.Uni_StartDate;
                entity.Uni_CompletionDate = model.Uni_CompletionDate;
                foreach (var e in users)
                {
                    if (e.Id == model.UserId)
                    {
                        if (file1 != null)
                        {
                            var extention = Path.GetExtension(file1.FileName);
                            var randomName = string.Format($"img_uni_{model.UserId}_{Guid.NewGuid()}{extention}");
                            entity.ImgUrl = randomName;
                            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{e.Email}", randomName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await file1.CopyToAsync(stream);
                            }
                        }
                        if (file2 != null)
                        {
                            var extention = Path.GetExtension(file2.FileName);
                            var randomName = string.Format($"pdf_uni_{model.UserId}_{Guid.NewGuid()}{extention}");
                            entity.PDFUrl = randomName;
                            var path0 = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{e.Email}", randomName);
                            using (var stream = new FileStream(path0, FileMode.Create))
                            {
                                await file2.CopyToAsync(stream);
                            }
                        }
                    }
                }
                _universityRepository.Update(entity);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Məlumatlandırma",
                    Message = $"Uğurla məlumatlar təzimləndi",
                    AlertType = "success"
                });
                return Redirect($"/admin/university/list/{entity.UserId}");
            }
            return View(model);
        }  // +
        public IActionResult EditCosUser(int id) // Course Edit Get
        {
            var entity = _courseRepository.GetById((int)id);

            if (entity == null)
            {
                return NotFound();
            }

            var model = new CourseDetailsModel()
            {
                Id = entity.Id,
                UserId = entity.UserId,
                CourseName = entity.CourseName,
                CourseOnWhat = entity.CourseOnWhat,
                Course_StartDate = entity.Course_StartDate,
                Course_UCompletionDate = entity.Course_UCompletionDate,
                ImgUrl = entity.ImgUrl,
                PDFUrl = entity.PDFUrl,
                Users = _userManager.Users.ToList(),
            };
            return View(model);
        }  // +
        [HttpPost]
        public async Task<IActionResult> EditCosUser(CourseDetailsModel model, IFormFile file1, IFormFile file2)  // Course Edit Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                var entity = _courseRepository.GetById(model.Id);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.CourseName = model.CourseName;
                entity.CourseOnWhat = model.CourseOnWhat;
                entity.Course_StartDate = model.Course_StartDate;
                entity.Course_UCompletionDate = model.Course_UCompletionDate;
                foreach (var e in users)
                {
                    if (e.Id == model.UserId)
                    {
                        if (file1 != null)
                        {
                            var extention = Path.GetExtension(file1.FileName);
                            var randomName = string.Format($"img_cor_{model.UserId}_{Guid.NewGuid()}{extention}");
                            entity.ImgUrl = randomName;
                            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{e.Email}", randomName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await file1.CopyToAsync(stream);
                            }
                        }
                        if (file2 != null)
                        {
                            var extention = Path.GetExtension(file2.FileName);
                            var randomName = string.Format($"pdf_cor_{model.UserId}_{Guid.NewGuid()}{extention}");
                            entity.PDFUrl = randomName;
                            var path0 = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{e.Email}", randomName);
                            using (var stream = new FileStream(path0, FileMode.Create))
                            {
                                await file2.CopyToAsync(stream);
                            }
                        }
                    }
                }
                _courseRepository.Update(entity);
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Məlumatlandırma",
                    Message = $"Uğurla məlumatlar təzimləndi",
                    AlertType = "success"
                });
                return Redirect($"/admin/course/list/{entity.UserId}");
            }
            return View(model);
        }  // +

        public async Task<IActionResult> EditSalaryUser(string id) // Salary Edit Get
        {
            var user = await _userManager.FindByIdAsync(id);
            var entity1 = _salaryRepository.GetAll();

            foreach (var e in entity1)
            {
                if (e.UserId == id)
                {
                    var entity = _salaryRepository.GetById((int)e.Id);

                    if (entity == null)
                    {
                        return NotFound();
                    }

                    var model = new SalaryDetailsModel()
                    {
                        Id = entity.Id,
                        UserId = user.Id,
                        TimeZoneId = entity.TimeZoneId,
                        Full_Salary = entity.Full_Salary,
                        Hourly_Salary = entity.Hourly_Salary,
                        StartDate = entity.StartDate,
                        EndDate = entity.EndDate,
                        Users = _userManager.Users.ToList(),
                        TimeZones = _timeZonesRepository.GetAll()
                    };
                    return View(model);
                }
            }

            TempData.Put("message", new AlertMessage()
            {
                Title = "Tapılmadı",
                Message = $"Yeni yaradılmalıdır",
                AlertType = "warning"
            });
            return Redirect($"/admin/create/salary/{id}");
        }  // +
        [HttpPost]
        public IActionResult EditSalaryUser(SalaryDetailsModel model)  // Salary Edit Post
        {
            var users = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                var entity = _salaryRepository.GetById(model.Id);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.TimeZoneId = model.TimeZoneId;
                entity.Full_Salary = model.Full_Salary;
                entity.Hourly_Salary = model.Hourly_Salary;
                entity.StartDate = model.StartDate;
                entity.EndDate = model.EndDate;

                _salaryRepository.Update(entity);

                TempData.Put("message", new AlertMessage()
                {
                    Title = "Məlumatlandırma",
                    Message = $"Uğurla məlumatlar təzimləndi",
                    AlertType = "success"
                });
                return Redirect($"/admin/user/salaryedit/{entity.UserId}");
            }
            return View(model);
        }  // +

        public IActionResult EditTimezone(int id) // Timezone Edit Get
        {
            var entity = _timeZonesRepository.GetById((int)id);

            if (entity == null)
            {
                return NotFound();
            }

            var model = new TimeZonesDetailsModel()
            {
                Id = entity.Id,
                TableName = entity.TableName,
                Type = entity.Type,
                OffDay = entity.OffDay,
                //StartDate = entity.StartDate,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime,
                One = entity.One,
                Two = entity.Two,
                Three = entity.Three,
                Four = entity.Four,
                Five = entity.Five,
                Six = entity.Six,
                Seven = entity.Seven,
                Eight = entity.Eight,
                Nine = entity.Nine,
                Ten = entity.Ten,
                Eleven = entity.Eleven,
                Twelve = entity.Twelve,
                Thirteen = entity.Thirteen,
                Fourteen = entity.Fourteen,
                Fifteen = entity.Fifteen,
                Sixteen = entity.Sixteen,
                Seventeen = entity.Seventeen,
                Eighteen = entity.Eighteen,
                Nineteen = entity.Nineteen,
                Twenty = entity.Twenty,
                TwentyOne = entity.TwentyOne,
                TwentyTwo = entity.TwentyTwo,
                TwentyThree = entity.TwentyThree,
                TwentyFour = entity.TwentyFour,
                TwentyFive = entity.TwentyFive,
                TwentySix = entity.TwentySix,
                TwentySeven = entity.TwentySeven,
                TwentyEight = entity.TwentyEight,
                TwentyNine = entity.TwentyNine,
                Thirty = entity.Thirty,
                ThirtyOne = entity.ThirtyOne
            };
            return View(model);
        }  // +
        [HttpPost]
        public IActionResult EditTimezone(TimeZonesDetailsModel model)  // Timezone Edit Post
        {
            if (ModelState.IsValid)
            {
                var entity = _timeZonesRepository.GetById(model.Id);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.TableName = model.TableName;
                entity.Type = model.Type;
                entity.OffDay = model.OffDay;
                //entity.StartDate = model.StartDate;
                entity.StartTime = model.StartTime;
                entity.EndTime = model.EndTime;
                entity.One = model.One;
                entity.Two = model.Two;
                entity.Three = model.Three;
                entity.Four = model.Four;
                entity.Five = model.Five;
                entity.Six = model.Six;
                entity.Seven = model.Seven;
                entity.Eight = model.Eight;
                entity.Nine = model.Nine;
                entity.Ten = model.Ten;
                entity.Eleven = model.Eleven;
                entity.Twelve = model.Twelve;
                entity.Thirteen = model.Thirteen;
                entity.Fourteen = model.Fourteen;
                entity.Fifteen = model.Fifteen;
                entity.Sixteen = model.Sixteen;
                entity.Seventeen = model.Seventeen;
                entity.Eighteen = model.Eighteen;
                entity.Nineteen = model.Nineteen;
                entity.Twenty = model.Twenty;
                entity.TwentyOne = model.TwentyOne;
                entity.TwentyTwo = model.TwentyTwo;
                entity.TwentyThree = model.TwentyThree;
                entity.TwentyFour = model.TwentyFour;
                entity.TwentyFive = model.TwentyFive;
                entity.TwentySix = model.TwentySix;
                entity.TwentySeven = model.TwentySeven;
                entity.TwentyEight = model.TwentyEight;
                entity.TwentyNine = model.TwentyNine;
                entity.Thirty = model.Thirty;
                entity.ThirtyOne = model.ThirtyOne;

                _timeZonesRepository.Update(entity);

                TempData.Put("message", new AlertMessage()
                {
                    Title = "Məlumatlandırma",
                    Message = $"Uğurla məlumatlar təzimləndi",
                    AlertType = "success"
                });
                return Redirect("/admin/timezones");
            }
            return View(model);
        }  // +


        /////////////////////////////////////////////////// UserDelete //
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "İnformasiya",
                    Message = "İstifadəçi tapılmadı",
                    AlertType = "warning"
                });
                return View();
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "İnformasiya",
                        Message = "İstifadəçi silindi",
                        AlertType = "success"
                    });
                    return Redirect("/admin/idcardlist/unapproved");
                }

                TempData.Put("message", new AlertMessage()
                {
                    Title = "Xəta",
                    Message = "Bilinmiyən xəta baş verdi",
                    AlertType = "success"
                });
                return RedirectToAction("UserListUnApproved");
            }
        }  // +
        [HttpPost]
        public IActionResult DeleteUserF(string UserId, int Id)
        {
            var entity = _childrepository.GetById(Id);
            if (entity != null)
            {
                _childrepository.Delete(entity);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"Ailə bölməsindən məlumat silindi",
                AlertType = "warning"
            });
            return Redirect($"/admin/user/familyedit/{UserId}");
        }  // +
        [HttpPost]
        public IActionResult DeleteUserFlist(string UserId, int Id)
        {
            var entity = _childrepository.GetById(Id);
            if (entity != null)
            {
                _childrepository.Delete(entity);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"Ailə bölməsindən məlumat silindi",
                AlertType = "warning"
            });
            return Redirect("/admin/list/family");
        }  // +
        [HttpPost]
        public async Task<IActionResult> DeleteUserbd(int Id)
        {
            var entity = _bdRepository.GetById(Id);
            var user = await _userManager.FindByIdAsync(entity.UserId);
            user.PercentBD = 0;
            if (entity != null)
            {
                _bdRepository.Delete(entity);
                await _userManager.UpdateAsync(user);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"Bədən ölçüləri bölməsindən məlumat silindi",
                AlertType = "warning"
            });
            return Redirect("/admin/list/bodydimensions");
        }  // +
        [HttpPost]
        public IActionResult DeleteUserw(int Id)
        {
            var entity = _workEXPRepository.GetById(Id);
            if (entity != null)
            {
                _workEXPRepository.Delete(entity);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"İş təcrübəsi bölməsindən məlumat silindi",
                AlertType = "warning"
            });
            return Redirect("/admin/list/workexp");
        }  // +
        [HttpPost]
        public async Task<IActionResult> DeleteUserdl(int Id)
        {
            var entity = _dlRepository.GetById(Id);
            var user = await _userManager.FindByIdAsync(entity.UserId);
            user.PercentDl = 0;
            if (entity != null)
            {
                _dlRepository.Delete(entity);
                await _userManager.UpdateAsync(user);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"Sürücülük bölməsindən məlumat silindi",
                AlertType = "warning"
            });
            return Redirect("/admin/list/dirivingcard");
        }  // +
        [HttpPost]
        public IActionResult DeleteUsermp(string UserId, int Id)
        {
            var entity = _mphoneRepository.GetById(Id);
            if (entity != null)
            {
                _mphoneRepository.Delete(entity);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"Nömrə silindi",
                AlertType = "warning"
            });
            return Redirect($"/admin/user/contactedit/{UserId}");
        }  // +
        [HttpPost]
        public IActionResult DeleteUserem(string UserId, int Id)
        {
            var entity = _emailRepository.GetById(Id);
            if (entity != null)
            {
                _emailRepository.Delete(entity);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"Email silindi",
                AlertType = "warning"
            });
            return Redirect($"/admin/user/contactedit/{UserId}");
        }  // +
        [HttpPost]
        public IActionResult DeleteUsersn(string UserId, int Id)
        {
            var entity = _socialNRepository.GetById(Id);
            if (entity != null)
            {
                _socialNRepository.Delete(entity);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"Sosial şəbəkə hesabı silindi",
                AlertType = "warning"
            });
            return Redirect($"/admin/user/contactedit/{UserId}");
        }  // +
        [HttpPost]
        public async Task<IActionResult> DeleteUsersch(int Id)
        {
            var entity = _schoolRepository.GetById(Id);
            var user = await _userManager.FindByIdAsync(entity.UserId);
            user.PercentS = 0;
            if (entity != null)
            {
                _schoolRepository.Delete(entity);
                await _userManager.UpdateAsync(user);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"Məktəb siyahısından məlumat silindi",
                AlertType = "warning"
            });
            return Redirect("/admin/list/school");
        }  // +
        [HttpPost]
        public IActionResult DeleteUsercol(int Id)
        {
            var entity = _collegeRepository.GetById(Id);
            if (entity != null)
            {
                _collegeRepository.Delete(entity);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"Kollec siyahısından məlumat silindi",
                AlertType = "warning"
            });
            return Redirect("/admin/list/college");
        }  // +
        [HttpPost]
        public IActionResult DeleteUsercol2(int Id)
        {
            var entity = _collegeRepository.GetById(Id);
            if (entity != null)
            {
                _collegeRepository.Delete(entity);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"Kollec siyahısından məlumat silindi",
                AlertType = "warning"
            });
            return Redirect($"/admin/college/list/{entity.UserId}");
        }  // +
        [HttpPost]
        public IActionResult DeleteUseruni(int Id)
        {
            var entity = _universityRepository.GetById(Id);
            if (entity != null)
            {
                _universityRepository.Delete(entity);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"Universitet siyahısından məlumat silindi",
                AlertType = "warning"
            });
            return Redirect("/admin/list/university");
        }  // +
        [HttpPost]
        public IActionResult DeleteUseruni2(int Id)
        {
            var entity = _universityRepository.GetById(Id);
            if (entity != null)
            {
                _universityRepository.Delete(entity);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"Universitet siyahısından məlumat silindi",
                AlertType = "warning"
            });
            return Redirect($"/admin/university/list/{entity.UserId}");
        }  // +
        [HttpPost]
        public IActionResult DeleteUsercor(int Id)
        {
            var entity = _courseRepository.GetById(Id);
            if (entity != null)
            {
                _courseRepository.Delete(entity);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"Kurs siyahısından məlumat silindi",
                AlertType = "warning"
            });
            return Redirect("/admin/list/course");
        }  // +
        [HttpPost]
        public IActionResult DeleteUsercor2(int Id)
        {
            var entity = _courseRepository.GetById(Id);
            if (entity != null)
            {
                _courseRepository.Delete(entity);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"Kurs siyahısından məlumat silindi",
                AlertType = "warning"
            });
            return Redirect($"/admin/course/list/{entity.UserId}");
        }  // +
        [HttpPost]
        public IActionResult DeleteUseros(int Id)
        {
            var entity = _oskillsRepository.GetById(Id);
            if (entity != null)
            {
                _oskillsRepository.Delete(entity);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"Bacarıq siyahısından məlumat silindi",
                AlertType = "warning"
            });
            return Redirect("/admin/list/workexp");
        }  // +
        [HttpPost]
        public IActionResult DeleteUsersalary(int Id)
        {
            var entity = _salaryRepository.GetById(Id);
            if (entity != null)
            {
                _salaryRepository.Delete(entity);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"Maaş siyahısından məlumat silindi",
                AlertType = "warning"
            });
            return Redirect("/admin/list/salary");
        }  // +
        [HttpPost]
        public IActionResult DeleteUsersnsl(int Id)
        {
            var entity = _snslRepository.GetById(Id);
            if (entity != null)
            {
                _snslRepository.Delete(entity);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"Sosial şəbəkə siyahısından məlumat silindi",
                AlertType = "warning"
            });
            return Redirect("/admin/list/socialnetwork");
        }  // +
        [HttpPost]
        public IActionResult DeleteUsertimezone(int Id)
        {
            var entity = _timeZonesRepository.GetById(Id);
            if (entity != null)
            {
                _timeZonesRepository.Delete(entity);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"Timezone-dan məlumat silindi",
                AlertType = "warning"
            });
            return Redirect("/admin/timezones");
        }  // +
        [HttpPost]
        public IActionResult DeleteUserpenalty(int Id)
        {
            var entity = _penaltyRepository.GetById(Id);
            if (entity != null)
            {
                _penaltyRepository.Delete(entity);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"Cərimədən məlumat silindi",
                AlertType = "warning"
            });
            return Redirect("/admin/penalties");
        }  // +
        [HttpPost]
        public IActionResult DeleteUserpenaltyready(int Id)
        {
            var entity = _penaltyreadyRepository.GetById(Id);
            if (entity != null)
            {
                _penaltyreadyRepository.Delete(entity);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"Hazır Cərimə silindi",
                AlertType = "warning"
            });
            return Redirect("/admin/penalties/ready");
        }  // +
        [HttpPost]
        public IActionResult DeleteUserarchive(int Id)
        {
            var entity = _archiveRepository.GetById(Id);
            if (entity != null)
            {
                _archiveRepository.Delete(entity);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"Arxivdən məlumat silindi",
                AlertType = "warning"
            });
            return Redirect("/admin/archives");
        }  // +
        [HttpPost]
        public IActionResult DeleteUserbonus(int Id)
        {
            var entity = _bonusRepository.GetById(Id);
            if (entity != null)
            {
                _bonusRepository.Delete(entity);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"Cərimədən məlumat silindi",
                AlertType = "warning"
            });
            return Redirect("/admin/bonus");
        }  // +
        [HttpPost]
        public IActionResult DeleteUserbonusready(int Id)
        {
            var entity = _bonusreadyRepository.GetById(Id);
            if (entity != null)
            {
                _bonusreadyRepository.Delete(entity);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Məlumatlandırma",
                Message = $"Hazır Cərimə silindi",
                AlertType = "warning"
            });
            return Redirect("/admin/bonus/ready");
        }  // +


        /////////////////////////////////////////////////// User UnApproved & Approved //
        [HttpPost]
        public async Task<IActionResult> UnApprovedUser(string Id)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(Id);
                if (user == null)
                {
                    return NotFound();
                }
                user.IsApproved = false;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Marka təstiqi",
                        Message = $"{user.FirstName} {user.LastName} adlı şəxsin təstiqi silindi",
                        AlertType = "warning"
                    });
                    return Redirect("/admin/list/idcard");
                }

            }
            return Redirect("/admin/list/idcard");
        } // +
        [HttpPost]
        public async Task<IActionResult> ApprovedBrand(string Id)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(Id);
                if (user == null)
                {
                    return NotFound();
                }
                user.IsApproved = true;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {

                }
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Marka təstiqi",
                    Message = $"{user.FirstName} {user.LastName} adlı şəxs təkrar təstiqləndi",
                    AlertType = "warning"
                });
                return Redirect("/admin/idcardlist/unapproved");
            }
            return Redirect("/admin/idcardlist/unapproved");
        } // +


        /////////////////////////////////////////////////// RoleList //
        public IActionResult RoleList()
        {
            return View(_roleManager.Roles);
        } // +

        /////////////////////////// RoleCreate //
        public IActionResult CreateRole()
        {
            return View();
        } // +
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Yeni Rol",
                    Message = $"{model.Name} adlı rol əlavə edildi",
                    AlertType = "success"
                });
            }
            return View(model);
        } // +
        /////////////////////////// RoleEdit //
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role != null)
            {
                return View(new EditRoleModel()
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                });
            }
            return RedirectToAction("RoleList");
        } // +
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(model.RoleId);
                if (role != null)
                {
                    role.Name = model.RoleName;

                    var result = await _roleManager.UpdateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("RoleList");
                    }
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "İstifadəçi profil yenilənməsi",
                        Message = $"{model.RoleName}  adlı rol tənzimləndi",
                        AlertType = "success"
                    });
                }
                return RedirectToAction("RoleList");
            }
            return View(model);
        } // +
        /////////////////////////// RoleDelete //
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            if (role == null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "İnformasiya",
                    Message = "Rol tapılmadı",
                    AlertType = "warning"
                });
                return RedirectToAction("RoleList");
            }
            else
            {
                var result = await _roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
                TempData.Put("message", new AlertMessage()
                {
                    Title = "İnformasiya",
                    Message = "Rol silindi",
                    AlertType = "success"
                });
                return RedirectToAction("RoleList");
            }
        } // +

        /////////////////////////////////////////////////// DownloadFile //
        [HttpPost]
        public async Task<IActionResult> DownloadFile(string filePath, string Email)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/img/{Email}", filePath);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            var contentType = "APPLICATION/octet-stream";
            var fileName = Path.GetFileName(path);

            return File(memory, contentType, fileName);
        } // +

        /////////////////////////////////////////////////// ForgotPassword //
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Xəta",
                    Message = "ID boş göndərildi",
                    AlertType = "danger"
                });
                return View();
            }

            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Xəta",
                    Message = "Bu ID-ə sahib istifadəçi yoxdur",
                    AlertType = "danger"
                });
                return View();
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var url = Url.Action("ResetPassword", "Admin", new
            {
                userId = user.Id,
                token = code
            });

            return Redirect($"{url}");
        } // +

        /////////////////////////////////////////////////// ResetPassword //
        public IActionResult ResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Xəta",
                    Message = "Bilinməyən ID və ya Token göndərildi",
                    AlertType = "danger"
                });
                return RedirectToAction("Index", "Home");
            }

            var model = new ResetPasswordModel { Token = token };
            return View();
        } // +
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "İstifadəçi xətası",
                    Message = "Məlumatlar doğru doldurulmadı ,yenidən yoxlayın",
                    AlertType = "warning"
                });
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Xəta",
                    Message = "İstifadəçi tapılmadı",
                    AlertType = "danger"
                });
                return RedirectToAction("Index", "Home");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Məlumatlandırma",
                    Message = "Əməliyyat uğurla yerinə yetirildi",
                    AlertType = "success"
                });
                return Redirect("~/");
            }
            return View(model);
        } // +
    }
}