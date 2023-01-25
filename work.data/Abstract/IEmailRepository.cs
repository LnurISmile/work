using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using work.entity;

namespace work.data.Abstract
{
    public interface IEmailRepository : IRepository<Email>
    {
        int GetCount();
        Email GetDetails(string id);
    }
}
