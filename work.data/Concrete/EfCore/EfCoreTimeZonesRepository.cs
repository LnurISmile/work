using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using work.data.Abstract;
using work.entity;

namespace work.data.Concrete.EfCore
{
    public class EfCoreTimeZonesRepository :
        EfCoreGenericRepository<TimeZones>, ITimeZonesRepository
    {
        public EfCoreTimeZonesRepository(WorkContext context) : base(context)
        {
        }
        private WorkContext WorkContext
        {
            get { return context as WorkContext; }
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public TimeZones GetDetails(int id)
        {
            return WorkContext.timeZones
                .Where(a => a.Id == id)
                .FirstOrDefault();
        }
    }
}
