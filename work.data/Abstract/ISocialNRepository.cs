using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using work.entity;

namespace work.data.Abstract
{
    public interface ISocialNRepository : IRepository<SocialNetwork> 
    {
        int GetCount();
        SocialNetwork GetDetails(string id);
    }
}
