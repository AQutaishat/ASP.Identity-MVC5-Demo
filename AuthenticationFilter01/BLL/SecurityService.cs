using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authentication01.BLL
{
    public class SecurityService
    {
        public UserAccount CurrentUser
        {
            get
            {
               var SessionUser= HttpContext.Current.Session["CurrentUser"];
                if (SessionUser==null)
                {
                    return null;
                }
                return (UserAccount)SessionUser;
            }
        }

        public List<Permission> CurrentPermissions
        {
            get
            {
                var SessionPermissions = HttpContext.Current.Session["CurrentPermissions"];
                if (SessionPermissions == null)
                {
                    return null;
                }
                return (List<Permission>)SessionPermissions;
            }
        }

        public bool Login(string UserName, string Password)
        {
            var CurrentUser = new UserAccount()
            {
                ID = 1,
                Name = "Anas"
            };
            var CurrentPermissions = new List<Permission>()
            {
                new Permission()
                {
                    ID=1,
                    Name="Permission1"
                },
                new Permission()
                {
                    ID=2,
                    Name="Permission2"
                },
                new Permission()
                {
                    ID=3,
                    Name="Permission3"
                },
            };

            HttpContext.Current.Session["CurrentUser"] = CurrentUser;
            HttpContext.Current.Session["CurrentPermissions"] = CurrentPermissions;
            return true;
        }
        public bool Logout()
        {
            HttpContext.Current.Session.Remove("CurrentUser");
            HttpContext.Current.Session.Remove("CurrentPermissions");

            HttpContext.Current.Session.Clear();
            return true;

        }

    }
}