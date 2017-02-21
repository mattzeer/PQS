using Microsoft.Practices.Unity;
using PQS.Business.Admin;
using PQS.Business.Base.Criteria;
using PQS.Business.Base.Result;
using PQS.Dal.SqlServer.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PQS.Business.Base.Impl
{
    public abstract class BaseService <TEntity, TCriteria> : IBaseService<TEntity, TCriteria> where TCriteria : BaseCriteria
    {
        [Dependency]
        public IManagerData Manager
        {
            get;
            set;
        }

        public abstract Task<EntityProcedureResult> DeleteAsync(TEntity entity);

        public abstract Task<EntityProcedureResult> SaveAsync(TEntity entity);

        public EntityProcedureResult GetDefaultResult()
        {
            EntityProcedureResult result = new EntityProcedureResult()
            {
                ErrorCode = 0,
                IsError = false
            };
            return result;
        }
        
    }
}
