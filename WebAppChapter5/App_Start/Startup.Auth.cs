using System.Web.UI;
using Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;

namespace WebAppChapter5
{
    public partial class Startup
    {
        //method to initialize the entire OpenID Connect pipeline
        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            //adds an instance of the cookie middleware in the pipeline
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            //adds an instance of the OpenID Connect middleware in the pipeline
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = "06be8f72-af78-41dc-bd01-3790f85ee2ab",
                Authority = "https://login.microsoftonline.com/DeveloperTenant.onmicrosoft.com/",
            }
                );
            new OpenIdConnectAuthenticationOptions
            {
                ClientId = "06be8f72-af78-41dc-bd01-3790f85ee2ab",
                Authority = "https://login.microsoftonline.com/DeveloperTenant.onmicrosoft.com/",
                PostLogoutRedirectUri = "https://localhost:44322/"
            };
        }
    }


}
