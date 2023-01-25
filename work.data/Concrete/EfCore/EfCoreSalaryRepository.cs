using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using work.data.Abstract;
using work.entity;

namespace work.data.Concrete.EfCore
{
    public class EfCoreSalaryRepository :
        EfCoreGenericRepository<Salary>, ISalaryRepository
    {
        public EfCoreSalaryRepository(WorkContext context) : base(context)
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

        public Salary GetDetails(string id)
        {
            return WorkContext.salary
                .Where(a => a.UserId == id)
                .FirstOrDefault();
        }
    }
}
