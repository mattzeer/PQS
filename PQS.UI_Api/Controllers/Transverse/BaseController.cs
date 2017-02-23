using PQS.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PQS.UI_Api.Controllers.Transverse
{
    public partial class BaseController : Controller
    {

        public PQSUser User { get; set; }

        public void HydrateUser(PERSON p)
        {
            User = new PQSUser()
            {
                EmailUser = p.MAIL,
                IdUser = p.ID,
                PseudoUser = p.PSEUDO
            };
        }
        
    }

    public class PQSUser
    {
        public int IdUser { get; set; }

        public string EmailUser { get; set; }
        public string PseudoUser { get; set; }
    }
}