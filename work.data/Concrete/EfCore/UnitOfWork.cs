using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using work.data.Abstract;

namespace work.data.Concrete.EfCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WorkContext _context;
        public UnitOfWork(WorkContext context)
        {
            _context = context;
        }

        private EfCoreBodyDRepository _bodyDRepository;
        private EfCoreChildrenRepository _childrenRepository;
        private EfCoreCollegeRepository _collegeRepository;
        private EfCoreCourseRepository _courseRepository;
        private EfCoreDrivingLRepository _drivingLRepository;
        private EfCoreEmailRepository _emailRepository;
        private EfCoreMPhoneRepository _phoneRepository;
        private EfCoreSchoolRepository _schoolRepository;
        private EfCoreSocialNRepository _socialNRepository;
        private EfCoreUniversityRepository _universityRepository;
        private EfCoreWorkEXPRepository _workEXPRepository;
        private EfCoreSocialNSListRepository _socialnslRepository;
        private EfCoreOtherSkillsRepository _oskillsRepository;
        private EfCoreSalaryRepository _salaryRepository;
        private EfCorePenaltyRepository _penaltyRepository;
        private EfCorePenaltyReadyRepository _penaltyreadyRepository;
        private EfCoreTimeZonesRepository _timeZonesRepository;
        private EfCoreArchiveRepository _archiveRepository;
        private EfCoreBonusRepository _bonusRepository;
        private EfCoreBonusReadyRepository _bonusreadyRepository;

        public IBodyDRepository Body =>
            _bodyDRepository = _bodyDRepository ?? new EfCoreBodyDRepository(_context);
        public IChildrenRepository Children =>
            _childrenRepository = _childrenRepository ?? new EfCoreChildrenRepository(_context);
        public ICollegeRepository College =>
            _collegeRepository = _collegeRepository ?? new EfCoreCollegeRepository(_context);
        public ICourseRepository Course =>
            _courseRepository = _courseRepository ?? new EfCoreCourseRepository(_context);
        public IDrivingLRepository Driving =>
            _drivingLRepository = _drivingLRepository ?? new EfCoreDrivingLRepository(_context);
        public IEmailRepository Email =>
            _emailRepository = _emailRepository ?? new EfCoreEmailRepository(_context);
        public IMPhoneRepository Mobile =>
            _phoneRepository = _phoneRepository ?? new EfCoreMPhoneRepository(_context);
        public ISchoolRepository School =>
            _schoolRepository = _schoolRepository ?? new EfCoreSchoolRepository(_context);
        public ISocialNRepository Social =>
            _socialNRepository = _socialNRepository ?? new EfCoreSocialNRepository(_context);
        public IUniversityRepository University =>
            _universityRepository = _universityRepository ?? new EfCoreUniversityRepository(_context);
        public IWorkEXPRepository WorkEXP =>
            _workEXPRepository = _workEXPRepository ?? new EfCoreWorkEXPRepository(_context);
        public ISocialNSListRepository SNSL =>
            _socialnslRepository = _socialnslRepository ?? new EfCoreSocialNSListRepository(_context);
        public ISalaryRepository Salary =>
            _salaryRepository = _salaryRepository ?? new EfCoreSalaryRepository(_context);
        public IOtherSkillsRepository OSkills =>
            _oskillsRepository = _oskillsRepository ?? new EfCoreOtherSkillsRepository(_context);
        public IPenaltyRepository Penalty =>
            _penaltyRepository = _penaltyRepository ?? new EfCorePenaltyRepository(_context);
        public ITimeZonesRepository TimeZones =>
            _timeZonesRepository = _timeZonesRepository ?? new EfCoreTimeZonesRepository(_context);
        public IArchiveRepository Archive =>
            _archiveRepository = _archiveRepository ?? new EfCoreArchiveRepository(_context);
        public IPenaltyReadyRepository PenaltyReady =>
            _penaltyreadyRepository = _penaltyreadyRepository ?? new EfCorePenaltyReadyRepository(_context);
        public IBonusRepository Bonus =>
            _bonusRepository = _bonusRepository ?? new EfCoreBonusRepository(_context);
        public IBonusReadyRepository BonusReady =>
            _bonusreadyRepository = _bonusreadyRepository ?? new EfCoreBonusReadyRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
