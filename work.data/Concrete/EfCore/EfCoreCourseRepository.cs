using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using work.data.Abstract;
using work.entity;

namespace work.data.Concrete.EfCore
{
    public class EfCoreCourseRepository :
        EfCoreGenericRepository<Course>, ICourseRepository
    {
        public EfCoreCourseRepository(WorkContext context) : base(context)
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

        public Course GetDetails(string id)
        {
            return WorkContext.courses
                .Where(a => a.UserId == id)
                .FirstOrDefault();
        }
    }
}
