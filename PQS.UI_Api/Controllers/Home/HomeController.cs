using Microsoft.Practices.Unity;
using PQS.Business;
using PQS.Business.Admin;
using PQS.Entities.DataModel;
using System.Web.Mvc;
using System.Threading.Tasks;
using PQS.UI_Api.Models.Home;
using PQS.Business.Quote;
using PQS.UI_Api.Models.Transverse;
using PQS.UI_Api.Controllers.Transverse;
using PQS.Business.Admin.Criteria;

namespace PQS.UI_Api.Controllers
{
    public partial class HomeController : BaseController
    {

        [Dependency]
        public IQuoteService QuoteService => UnityConfig.Resolve<IQuoteService>();

        [Dependency]
        public IUserService UserService => UnityConfig.Resolve<IUserService>();

        // GET: Home
        public virtual async Task<ActionResult> Index()
        {
            IndexViewModel model = new IndexViewModel()
            {
                Quotes = await QuoteService.GetQuoteListAsync()
            };
            return View(model);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserCriteria criteria = new UserCriteria()
                {
                    EmailUser = model.Email,
                    PasswordUser = model.Password

                };
                if (await UserService.LoginAsync(criteria))
                {
                    HydrateUser(await UserService.GetPersonByEmailAsync(model.Email));
                    return RedirectToAction("Index");                }
                else
                {
                    ModelState.AddModelError("Email", "Cet utilisateur n'existe pas");
                    return PartialView(MVC.Shared.Views._LoginPartialView, model);
                }
            }
            else
            {
                return PartialView(MVC.Shared.Views._LoginPartialView, model);
            }
        }

        public virtual ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public virtual async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!await UserService.PseudoAlreadyUsedAsync(model.Pseudo))
                {
                    if (!await UserService.EmailAlreaydUsedAsync(model.Email))
                    {
                        PERSON p = new PERSON()
                        {
                            MAIL = model.Email,
                            PASSWORD = model.Password,
                            PSEUDO = model.Pseudo
                        };
                        await UserService.SaveAsync(p);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("Pseudo", "Ce pseudo est déjà utilisé");
                        return PartialView(MVC.Home.Views.Register, model);
                    }

                }
                else
                {
                    ModelState.AddModelError("Pseudo", "Ce pseudo est déjà utilisé");
                    return PartialView(MVC.Home.Views.Register, model);
                }

            }
            else
            {
                return PartialView(MVC.Home.Views.Register, model);
            }
        }
    }
}
