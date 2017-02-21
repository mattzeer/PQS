using PQS.Business.Base.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PQS.Business.Admin.Criteria
{
    class FileCriteria : BaseCriteria
    {
        public int IdFile { get; set; }

        public string UrlFile { get; set; }
        public string NameFile { get; set; }
    }
}
