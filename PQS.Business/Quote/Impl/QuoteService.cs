using PQS.Business.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PQS.Business.Base.Result;
using PQS.Entities.DataModel;
using PQS.Business.Quote.Criteria;
using PQS.Business.Base.Impl;

namespace PQS.Business.Quote.Impl
{
    class QuoteService : BaseService<QUOTE,QuoteCriteria> , IQuoteService
    {
        

        public override Task<EntityProcedureResult> DeleteAsync(QUOTE entity)
        {
            throw new NotImplementedException();
        }

        public Task<EntityProcedureResult> DeleteTypeQuoteAsync(TypeQuoteCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public Task<QUOTE> GetQuoteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<QUOTE>> GetQuoteListAsync()
        {
            return await Task.FromResult(Manager.GetAll<QUOTE>());
        }

        public Task<IEnumerable<TYPEQUOTE>> GetTypeQuoteListAsync()
        {
            throw new NotImplementedException();
        }
        

        public override Task<EntityProcedureResult> SaveAsync(QUOTE entity)
        {
            throw new NotImplementedException();
        }

        public Task<EntityProcedureResult> SaveTypeQuoteAsync(TypeQuoteCriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
