using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PQS.Dal.SqlServer.DataModel
{
    public partial class pqsEntities
    {
        public pqsEntities(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
    }
}
