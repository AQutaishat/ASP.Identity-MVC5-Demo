using AspNet.Identity.Wahdan.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet.Identity
{
    public class Startup
    {
        public static Func<UserManager<IdentityUser>> UserManagerFactory { get; private set; }
        public static Func<RoleManager<IdentityRole>> RoleManagerFactory { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/auth/login")
            });


            // configure the user manager
            UserManagerFactory = () =>
            {
                var usermanager = new UserManager<IdentityUser>(
                    new UserStore<IdentityUser>(new ApplicationDbContext()));
                // allow alphanumeric characters in username
                usermanager.UserValidator = new UserValidator<IdentityUser>(usermanager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };

                return usermanager;
            };

            RoleManagerFactory = () =>
            {
                var roleManager = new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(new ApplicationDbContext()));
                // allow alphanumeric characters in username
                roleManager.RoleValidator = new RoleValidator<IdentityRole>(roleManager)
                {
                };

                return roleManager;
            };
        }


    }
}