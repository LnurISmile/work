using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work.data.Abstract;
using work.mvc.Identity;

namespace work.mvc.Controllers
{
    public class HomeController : Controller
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
        public HomeController(IBodyDRepository bdRepository, IChildrenRepository childrepository, ICollegeRepository collegeRepository, ICourseRepository courseRepository,
                               IDrivingLRepository dlRepository, IEmailRepository emailRepository, IMPhoneRepository mphoneRepository, ISchoolRepository schoolRepository,
                               ISocialNRepository socialNRepository, IUniversityRepository universityRepository, IWorkEXPRepository workEXPRepository, ISalaryRepository salaryRepository,
                               ISocialNSListRepository snslRepository, IOtherSkillsRepository oskillsRepository, IPenaltyRepository penaltyRepository, ITimeZonesRepository timeZonesRepository,
                               IArchiveRepository archiveRepository, IPenaltyReadyRepository penaltyreadyRepository, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
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
        public IActionResult Index()
        {
            return View();
        }
    }
}
