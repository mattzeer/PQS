using PQS.Business.Admin.Criteria;
using PQS.Business.Base;
using PQS.Business.Base.Result;
using PQS.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PQS.Business.Admin
{
    interface IFileService : IBaseService<ATTACHMENT, FileCriteria>
    {
        Task<EntityProcedureResult> CreateAttachment(FileCriteria criteria);

    }
}
