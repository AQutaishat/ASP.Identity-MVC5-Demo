//taken from the article 
//https://benfoster.io/blog/aspnet-identity-stripped-bare-mvc-part-1

using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace ASPIDentityExample_Stage1_NoDB
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/auth/login")
            });
        }
        
    }
}