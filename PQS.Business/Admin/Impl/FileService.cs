using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PQS.Business.Admin.Criteria;
using PQS.Business.Base.Result;
using PQS.Entities.DataModel;

namespace PQS.Business.Admin.Impl
{
    class FileService : IFileService
    {
        public Task<EntityProcedureResult> CreateAttachment(FileCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public Task<EntityProcedureResult> DeleteAsync(ATTACHMENT entity)
        {
            throw new NotImplementedException();
        }

        public Task<EntityProcedureResult> SaveAsync(ATTACHMENT entity)
        {
            throw new NotImplementedException();
        }
    }
}
