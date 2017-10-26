using System.Web.Mvc;
using uh365898_db.WebUI.Infrastructure.Abstract;
using uh365898_db.WebUI.Models;
using System.Web;
using System.Web.Security;
namespace uh365898_db.WebUI.Controllers
{

   
    public class AccountController : Controller
    {
        IAuthProvider authProvider;
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }
        
       

        public ViewResult Login()
        {
            return View();
        }


        public ActionResult Logout()
        {
            logger.Error("Выход на  сайт");
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

       
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            logger.Error("Вход администратора сайта");

            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Mainpage", "Controlsystem"));
                }
                else
                {
                    ModelState.AddModelError("", "Не корректный логин или пароль");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }


    

}