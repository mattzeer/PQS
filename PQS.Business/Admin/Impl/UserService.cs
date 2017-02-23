using PQS.Business.Admin.Criteria;
using PQS.Business.Base.Impl;
using PQS.Business.Base.Result;
using PQS.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PQS.Business.Admin.Impl
{
    public class UserService : BaseService<PERSON,UserCriteria>, IUserService
    {
        public override async Task<EntityProcedureResult> DeleteAsync(PERSON entity)
        {
            EntityProcedureResult result = GetDefaultResult();
             
            try
            {
                await Manager.DeleteAsync(entity);
            }
            catch (Exception e)
            {
                result.IsError = true;
                result.ErrorCode = 1; //TODO
                result.ErrorMessage = "Error"; //TODO
            }
            return result;
           
        }

        public async Task<bool> EmailAlreaydUsedAsync(string email)
        {
            PERSON p = await Manager.FirstAsync<PERSON>(m => m.MAIL == email);
            return p == null ? false : true;
        }

        public async Task<PERSON> GetPersonByEmailAsync(string mail)
        {
            return await Manager.FirstAsync<PERSON>(m => m.MAIL == mail);
        }

        public async Task<PERSON> GetPersonByIdAsync(int id)
        {
            return await Manager.FirstAsync<PERSON>(m => m.ID == id);
        }

        public async Task<bool> LoginAsync(UserCriteria criteria)
        {
            PERSON p = await Manager.FirstAsync<PERSON>(m => m.MAIL == criteria.EmailUser && m.PASSWORD == criteria.PasswordUser);
            return p == null ? false : true;
        }

        public async Task<bool> PseudoAlreadyUsedAsync(string pseudo)
        {
            PERSON p = await Manager.FirstAsync<PERSON>(m => m.PSEUDO == pseudo);
            return p == null ? false : true;
                
        }

        public override async Task<EntityProcedureResult> SaveAsync(PERSON entity)
        {
            EntityProcedureResult result = GetDefaultResult();
            try
            {
                await Manager.AddAsync<PERSON>(entity);
            }
            catch (Exception e)
            {
                result.IsError = true;
                result.ErrorCode = 1; //TODO
                result.ErrorMessage = "Error"; //TODO
            }
            return result;

        }


    }
}
