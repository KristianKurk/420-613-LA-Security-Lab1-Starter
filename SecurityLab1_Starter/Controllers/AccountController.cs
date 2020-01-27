using SecurityLab1_Starter.Infrastructure.Abstract;
using SecurityLab1_Starter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityLab1_Starter.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;

        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    Logger.Log("Successful Login -  " + model.UserName, "C:\\Users\\Kristian\\Desktop\\useraccess.log");
                    if (returnUrl != null)
                        return Redirect(returnUrl);
                    else
                        return Redirect(Url.Action("Index", "Home"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout() {
            Logger.Log("Successful Logout", "C:\\Users\\Kristian\\Desktop\\useraccess.log");
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("index", "Home", "");
        }
    }
}