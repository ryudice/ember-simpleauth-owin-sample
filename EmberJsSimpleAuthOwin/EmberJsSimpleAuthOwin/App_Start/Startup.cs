using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmberJsSimpleAuthOwin.App_Start;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace EmberJsSimpleAuthOwin.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseOAuthBearerTokens(new OAuthAuthorizationServerOptions()
            {
                
            });
        }
    }


    class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {


         
    }
}