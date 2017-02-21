using PQS.Business.Base.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PQS.Business.Quote.Criteria
{
    public class TypeQuoteCriteria : BaseCriteria
    {
        public string codeType { get; set; }

        public string LabelType { get; set; }

    }
}
