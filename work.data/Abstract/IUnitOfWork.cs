using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work.data.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IBodyDRepository Body { get; }
        IChildrenRepository Children { get; }
        ICollegeRepository College { get; }
        ICourseRepository Course { get; }
        IDrivingLRepository Driving { get; }
        IEmailRepository Email { get; }
        IMPhoneRepository Mobile { get; }
        ISchoolRepository School { get; }
        ISocialNRepository Social { get; }
        IUniversityRepository University { get; }
        IWorkEXPRepository WorkEXP { get; }
        IOtherSkillsRepository OSkills { get; }
        ISocialNSListRepository SNSL { get; }
        ISalaryRepository Salary { get; }
        IArchiveRepository Archive { get; }
        IPenaltyRepository Penalty { get; }
        IPenaltyReadyRepository PenaltyReady { get; }
        ITimeZonesRepository TimeZones { get; }
        IBonusRepository Bonus { get; }
        IBonusReadyRepository BonusReady { get; }
        void Save();
    }
}
