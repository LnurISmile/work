using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using work.data.Abstract;
using work.entity;

namespace work.data.Concrete.EfCore
{
    public class EfCoreChildrenRepository :
        EfCoreGenericRepository<Children>, IChildrenRepository
    {
        public EfCoreChildrenRepository(WorkContext context) : base(context)
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

        public Children GetDetails(string id)
        {
            return WorkContext.children
                .Where(a => a.UserId == id)
                .FirstOrDefault();
        }
    }
}
