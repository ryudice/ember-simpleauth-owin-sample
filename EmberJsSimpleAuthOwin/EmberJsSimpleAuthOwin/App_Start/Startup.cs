using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using EmberJsSimpleAuthOwin.App_Start;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace EmberJsSimpleAuthOwin.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions()
            {
                Provider = new ApplicationOAuthProvider(),
                TokenEndpointPath = new PathString("/token"),
                AllowInsecureHttp = true,
                AuthenticationType = "Bearer",
                AuthenticationMode = AuthenticationMode.Active

            });

            app.UseOAuthBearerTokens(new OAuthAuthorizationServerOptions()
            {
                //Provider = new ApplicationOAuthProvider(),
                //TokenEndpointPath = new PathString("/token"),
                //AllowInsecureHttp = true,
                //AuthenticationType = "Bearer",
                //AuthenticationMode = AuthenticationMode.Active

            });
        }
    }


    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();

            return Task.FromResult(0);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (context.UserName == "username" && context.Password == "pwd")
            {
                var claimsIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
                claimsIdentity.AddClaim(new Claim("username", context.UserName));

                context.Validated(claimsIdentity);
            }
            else
            {
                context.SetError("Invalid credentials");
                context.Rejected();
            }

            return Task.FromResult(0);

        }

       
    }
}