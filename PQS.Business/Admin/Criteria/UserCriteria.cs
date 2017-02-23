﻿using PQS.Business.Base.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PQS.Business.Admin.Criteria
{
    public class UserCriteria : BaseCriteria
    {
        public string EmailUser { get; set; }

        public string PasswordUser { get; set; }
    }
}
