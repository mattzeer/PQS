using PQS.Business.Admin.Criteria;
using PQS.Business.Base;
using PQS.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PQS.Business.Admin
{
    public interface IUserService : IBaseService<PERSON, UserCriteria>
    {
        Task<PERSON> getPersonByIdAsync(int id);
    }
}
