using PQS.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PQS.UI_Api.Models.Home
{
    public class IndexViewModel
    {
        public IEnumerable<QUOTE> Quotes { get; set; }
    }
}