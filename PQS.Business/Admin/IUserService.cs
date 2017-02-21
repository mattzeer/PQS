using PQS.Business.Admin.Criteria;
using PQS.Business.Base;
using PQS.Entities.DataModel;
using System.Threading.Tasks;

namespace PQS.Business.Admin
{
    public interface IUserService : IBaseService<PERSON, UserCriteria>
    {
        Task<PERSON> GetPersonByIdAsync(int id);
    }
}
