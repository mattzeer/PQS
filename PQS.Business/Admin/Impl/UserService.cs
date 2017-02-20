using PQS.Business.Admin.Criteria;
using PQS.Business.Base.Impl;
using PQS.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PQS.Business.Admin.Impl
{
    class UserService : BaseService<PERSON,UserCriteria>, IUserService
    {
        public override Task DeleteAsync(PERSON entity)
        {
            throw new NotImplementedException();
        }

        public async Task<PERSON> getPersonByIdAsync(int id)
        {
            return await Manager.FirstAsync<PERSON>(m => m.ID == id);
        }

        //public override Task<List<PERSON>> ReadAsync(Base.Impl.BaseService criteria)
        //{
        //    throw new NotImplementedException();
        //}

        public override Task SaveAsync(PERSON entity)
        {
            throw new NotImplementedException();
        }
    }
}
