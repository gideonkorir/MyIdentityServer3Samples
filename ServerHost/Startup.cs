using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static IdentityServer3.Core.Constants;

[assembly: Microsoft.Owin.OwinStartup(typeof(ServerHost.Startup))]
namespace ServerHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var options = new IdentityServerOptions();
            options.SiteName = "Korir's App";
            options.RequireSsl = true;
            options.SigningCertificate = Idsvr.LoadCertificate();
            options.Factory = new IdentityServerServiceFactory();
            options.Factory.UseInMemoryClients(Idsvr.Clients);
            options.Factory.UseInMemoryUsers(Idsvr.Users.ToList());
            
            options.Factory.UseInMemoryScopes(Idsvr.Scopes);
            app.UseIdentityServer(options);
        }
    }
}