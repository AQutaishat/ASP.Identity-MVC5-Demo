using Authentication01.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Authentication01.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class MyAPIAuthorizeAttribute : AuthorizeAttribute
    {
        private List<string> UsePermissions { get; set; }
        private SecurityService SecuritySVC = new SecurityService();
        public MyAPIAuthorizeAttribute(params object[] UsePermissions)
        {
            //if (UsePermissions.Any(p => p.GetType().BaseType != typeof(Enum)))
            //    throw new ArgumentException("UsePermissionsRequired");

            //this.UsePermissions = UsePermissions.Select(p => Enum.GetName(p.GetType(), p)).ToArray();
            this.UsePermissions = UsePermissions.Select(x => x.ToString()).ToList();
        }

        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext context)
        {

            var CurrentUser = SecuritySVC.CurrentUser;
            var CurrentPermisisons = SecuritySVC.CurrentPermissions;

            bool AllowAnnounous = context.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Count > 0;

            bool authorized = true;
            if (AllowAnnounous)
            {
                authorized = true;
            }
            else
            {
                if (authorized && CurrentUser == null)
                {
                    authorized = false;
                }

                if (authorized && CurrentPermisisons == null)
                {
                    authorized = false;
                }

                if (authorized && this.UsePermissions.Count() > 0)
                {
                    if (!CurrentPermisisons.Any(x => this.UsePermissions.Contains(x.Name)))
                    {
                        authorized = false;
                    }
                }
            }

            if (!authorized)
            {
                context.Response = context.Request.CreateResponse(HttpStatusCode.Unauthorized, "Not allowed");
                return;
            }

            //foreach (var role in this.UserProfilesRequired)
            //{
            //    if (HttpContext.Current.User.IsInRole(role))
            //    {
            //        authorized = true;
            //        break;
            //    }
            //}

        }
    }


}