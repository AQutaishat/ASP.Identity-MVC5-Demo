//taken from the article 
//https://benfoster.io/blog/aspnet-identity-stripped-bare-mvc-part-1


using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace ASPIDentityExample_Stage1_NoDB.Controllers
{
    public class HomeController : Controller
    {

        public ClaimsPrincipal CurrentUser
        {
            get
            {
                return this.User as ClaimsPrincipal;
            }
        }
        // GET: Home
        public ActionResult Index()
        {
            
            ViewBag.Name = CurrentUser.FindFirst(ClaimTypes.Name).Value;
            ViewBag.Email = CurrentUser.FindFirst(ClaimTypes.Email).Value;
            ViewBag.Country = CurrentUser.FindFirst(ClaimTypes.Country).Value;

            return View();
        }
    }
}