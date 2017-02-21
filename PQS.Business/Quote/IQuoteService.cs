using PQS.Business.Base;
using PQS.Business.Base.Result;
using PQS.Business.Quote.Criteria;
using PQS.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PQS.Business.Quote
{
    public interface IQuoteService : IBaseService<QUOTE, QuoteCriteria>
    {
        #region QUOTE

        Task<QUOTE> GetQuoteByIdAsync(int id);

        Task<IEnumerable<QUOTE>> GetQuoteListAsync();

        #endregion

        #region TypeQuote

        Task<IEnumerable<TYPEQUOTE>> GetTypeQuoteListAsync();

        Task<EntityProcedureResult> SaveTypeQuoteAsync(TypeQuoteCriteria criteria);

        Task<EntityProcedureResult> DeleteTypeQuoteAsync(TypeQuoteCriteria criteria);

        #endregion
    }
}
