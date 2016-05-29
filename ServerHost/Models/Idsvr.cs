using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace ServerHost
{
    public class Idsvr
    {
        public static IEnumerable<Client> Clients
        {
            get
            {
                yield return new Client()
                {
                    ClientName = "My Mvc App",
                    Enabled = true,
                    ClientId = "mvc",
                    Flow = Flows.Implicit,
                    AllowAccessToAllScopes = true,
                    RedirectUris = new List<string>()
                    {
                        "https://localhost:44332/"
                    },
                    PostLogoutRedirectUris = new List<string>()
                    {
                        "https://localhost:44332/"
                    },
                    ClientUri = "https://localhost:44332/"
                };
            }
        }

        public static IEnumerable<InMemoryUser> Users
        {
            get
            {
                yield return new InMemoryUser()
                {
                    Username = "gideonkorir@gmail.com",
                    Enabled = true,
                    Password = "secret",
                    Subject = "1",
                    Claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.DateOfBirth, "1988/01/05"),
                        new Claim(ClaimTypes.GivenName, "Gideon"),
                        new Claim(ClaimTypes.Surname, "Korir")
                    }
                };
            }
        }

        public static IEnumerable<Scope> Scopes
        {
            get
            {
                IEnumerable<Scope> scopes = Enumerable.Repeat(
                    new Scope()
                    {
                        Name = "roles",
                        Claims = new List<ScopeClaim>() {  new ScopeClaim("role") },
                        Type = ScopeType.Identity,
                        Enabled = true
                    }, 1);
                return scopes.Union(StandardScopes.All);
            }
        }

        public static X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                string.Format(@"{0}\bin\idsrv3test.pfx", AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }
    }
}