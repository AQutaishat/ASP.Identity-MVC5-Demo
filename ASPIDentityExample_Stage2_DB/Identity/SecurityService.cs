using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPIDentityExample_Stage2_DB.Identity
{
    public class SecurityService
    {
        public IOwinContext ctx
        {
            get
            {
                return HttpContext.Current.GetOwinContext();

            }
        }

        public UserManager<AppUser> UserManager
        {

            get
            {
                return ctx.GetUserManager<UserManager<AppUser>>();
            }
        }

        public SignInManager<AppUser, string> SignInManager
        {

            get
            {
                return ctx.Get<SignInManager<AppUser, string>>();
            }
        }

        public IAuthenticationManager AuthManager
        {

            get
            {
                return ctx.Authentication;
            }
        }

        public string CurrentUserId
        {

            get
            {
                string Result = null;
                if (HttpContext.Current.User.Identity.GetUserId() != null)
                {
                    Result = HttpContext.Current.User.Identity.GetUserId();
                }

                return Result;
            }
        }
        public AppUser CurrentUser
        {

            get {
              AppUser Result = null;
                if (HttpContext.Current.User.Identity.GetUserId() != null)
                {
                    var UserId = HttpContext.Current.User.Identity.GetUserId();
                    Result = UserManager.FindById<AppUser,string>(UserId);                    
                }

                return Result;
            }
        }
    }
}