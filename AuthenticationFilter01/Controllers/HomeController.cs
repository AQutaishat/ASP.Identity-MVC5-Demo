using Authentication01.BLL;
using Authentication01.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Authentication01.Controllers
{
    [MyAuthorize]
    public class HomeController : Controller
    {
        SecurityService SecuritySVC = new SecurityService();

        public HomeController()
        {
            ViewBag.CurrentUser = SecuritySVC.CurrentUser;
        }
        public ActionResult Index()
        {
            ViewBag.CurrentUser = SecuritySVC.CurrentUser;

            return View();
        }
        //[MyAuthorize("NoneExistPermission", "Permission1")]
        [MyAuthorize("NoneExistPermission")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [MyAuthorize("Permission1")]

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {
            SecuritySVC.Login(UserName, Password);
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            SecuritySVC.Logout();
            return RedirectToAction("Login");
        }

    }
}