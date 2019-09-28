//taken from the article 
//https://benfoster.io/blog/aspnet-identity-stripped-bare-mvc-part-1

using ASPIDentityExample_Stage2_DB.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;


namespace ASPIDentityExample_Stage2_DB.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private SecurityService _SecSvc=new SecurityService();

        // GET: Auth
        public ActionResult LogIn()
        {
            var LoginResult = _SecSvc.SignInManager.PasswordSignIn("Anas", "123", true, false);
            if (LoginResult == SignInStatus.Success)
            {
                ViewBag.Result = "Sucess";
            }

            return View();
        }

        public ActionResult LogOut()
        {
            _SecSvc.AuthManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("index", "home");
        }


    }
}