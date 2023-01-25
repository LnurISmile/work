using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using work.data.Abstract;
using work.entity;

namespace work.data.Concrete.EfCore
{
    public class EfCorePenaltyReadyRepository :
        EfCoreGenericRepository<PenaltyReady>, IPenaltyReadyRepository
    {
        public EfCorePenaltyReadyRepository(WorkContext context) : base(context)
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

        public PenaltyReady GetDetails(int id)
        {
            return WorkContext.penaltyready
                .Where(a => a.Id == id)
                .FirstOrDefault();
        }
    }
}
