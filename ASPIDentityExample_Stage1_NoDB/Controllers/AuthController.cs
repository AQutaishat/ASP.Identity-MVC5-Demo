//taken from the article 
//https://benfoster.io/blog/aspnet-identity-stripped-bare-mvc-part-1

using System.Security.Claims;
using System.Web;
using System.Web.Mvc;


namespace ASPIDentityExample_Stage1_NoDB.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult LogIn()
        {
            var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, "Ben"),
                new Claim(ClaimTypes.Email, "a@b.com"),
                new Claim(ClaimTypes.Country, "England")
            },
                "ApplicationCookie");

            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignIn(identity);


            return View();
        }

        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "home");
        }
    }
}