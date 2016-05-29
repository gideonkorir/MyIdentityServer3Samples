using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: Microsoft.Owin.OwinStartup(typeof(WebApplication1.Startup))]

namespace WebApplication1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = CookieAuthenticationDefaults.AuthenticationType
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions()
            {
                AuthenticationType = OpenIdConnectAuthenticationDefaults.AuthenticationType,
                Authority = "https://localhost:44379/",
                ResponseType = "id_token",
                RedirectUri = "https://localhost:44332/",
                PostLogoutRedirectUri = "https://localhost:44332/",
                SignInAsAuthenticationType = CookieAuthenticationDefaults.AuthenticationType,
                ClientId = "mvc"                
            });
        }
    }
}