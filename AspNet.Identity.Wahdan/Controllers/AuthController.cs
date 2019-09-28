using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNet.Identity.Wahdan.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AuthController() : this(Startup.UserManagerFactory.Invoke(), Startup.RoleManagerFactory.Invoke())
        {
                
        }

        public AuthController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
 

        [HttpGet]
        public async Task<bool> Register()
        { 
            var user = new IdentityUser
            {
                UserName = "superadmin",
            };

            var result = await userManager.CreateAsync(user, "MH@123mh");

            return result.Succeeded;
        }

        [HttpGet]
        public  bool AddToRole()
        {

            var user = userManager.FindByName("superadmin");
            var result =   userManager.AddToRole(user.Id, "Admin");

            return result.Succeeded;
        }

        [HttpGet]
        public bool AddRole()
        {

            IdentityRole role = new IdentityRole()
            {
                Name = "Subsecriber"
            };
            var result = roleManager.Create(role);
            //roleManager.AddClaimAsync();
            return result.Succeeded;
        }

        [HttpGet]
        public bool DeleteRole()
        {
 
            var role = roleManager.FindByName("new  Admin");
            var result = roleManager.Delete(role);

            return result.Succeeded;
        }

        [HttpGet]
        public bool DeleteUser()
        {

            var user = userManager.FindByName("Anas");
            var result = userManager.Delete(user);

            return result.Succeeded;
        }

        [HttpGet]
        public bool UpdateRole()
        {

            var role = roleManager.FindByName("Admin");
            role.Name = "new  " + role.Name;
            var result = roleManager.Update(role);

            return result.Succeeded;
        }


        [HttpGet]
        public bool RemoveFromRole()
        {

            var user = userManager.FindByName("superadmin");
            var role = roleManager.FindByName("Admin");

            user.UserName = "new  " + user.UserName;
            var result = userManager.RemoveFromRole(user.Id, role.Id);

            return result.Succeeded;
        }



        [HttpGet]
        public bool UpdateUser()
        {

            var user = userManager.FindByName("superadmin");
            user.UserName = "new  " + user.UserName;
            var result = userManager.Update(user);

            return result.Succeeded;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && userManager != null)
            {
                userManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}