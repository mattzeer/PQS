using PQS.Business.Base.Criteria;
using PQS.Business.Base.Impl;
using PQS.Business.Base.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PQS.Business.Base
{
    public interface IBaseService<TEntity, TCriteria> where TCriteria : BaseCriteria
    {

        Task<EntityProcedureResult> DeleteAsync(TEntity entity);

        Task<EntityProcedureResult> SaveAsync(TEntity entity);
    }
}
