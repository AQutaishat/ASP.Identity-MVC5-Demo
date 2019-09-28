//taken from the article 
//https://benfoster.io/blog/aspnet-identity-stripped-bare-mvc-part-1

using ASPIDentityExample_Stage2_DB.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;

namespace ASPIDentityExample_Stage2_DB
{
    public class Startup
    {
        //public static Func<UserManager<AppUser>> UserManagerFactory { get; private set; }
        //public static Func<RoleManager<IdentityRole>> RoleManagerFactory { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new AppDbContext());
            app.CreatePerOwinContext((IdentityFactoryOptions<UserManager<AppUser>> options, IOwinContext owin) => {

                var usermanager = new UserManager<AppUser>(
                    new UserStore<AppUser>(new AppDbContext()));
                // allow alphanumeric characters in username
                usermanager.UserValidator = new UserValidator<AppUser>(usermanager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };
                //usermanager.ClaimsIdentityFactory = new AppUserClaimsIdentityFactory();
                return usermanager;
            });

            //app.CreatePerOwinContext<SignInManager<AppUser, string>>( ()=> {
            //    IOwinContext owin = new object();
            //    return new SignInManager<AppUser,string>(owin.GetUserManager<UserManager<AppUser,string>>(),owin.Authentication);
            //});

            //app.CreatePerOwinContext<RoleManager<IdentityRole>>((IdentityFactoryOptions<UserManager<AppUser>> options, IOwinContext owin) => {
            //    var roleManager = new RoleManager<IdentityRole>(
            //        new RoleStore<IdentityRole>(new AppDbContext()));
            //    // allow alphanumeric characters in username
            //    roleManager.RoleValidator = new RoleValidator<IdentityRole>(roleManager)
            //    {
            //    };

            //    return roleManager;

            //});


            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/auth/login")
            });

            //UserManagerFactory = () =>
            //{
            //    var usermanager = new UserManager<AppUser>(
            //        new UserStore<AppUser>(new AppDbContext()));
            //    // allow alphanumeric characters in username
            //    usermanager.UserValidator = new UserValidator<AppUser>(usermanager)
            //    {
            //        AllowOnlyAlphanumericUserNames = false
            //    };

            //    //usermanager.ClaimsIdentityFactory = new AppUserClaimsIdentityFactory();

            //    return usermanager;
            //};

            //RoleManagerFactory = () =>
            //{
            //    var roleManager = new RoleManager<IdentityRole>(
            //        new RoleStore<IdentityRole>(new ApplicationDbContext()));
            //    // allow alphanumeric characters in username
            //    roleManager.RoleValidator = new RoleValidator<IdentityRole>(roleManager)
            //    {
            //    };

            //    return roleManager;
            //};
        }
    }
}