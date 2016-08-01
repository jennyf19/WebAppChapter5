using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;

namespace WebAppChapter5.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public void SignIn()
        {
            //Send an OpenID Connect sign-in request
            if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext()
                    .Authentication.Challenge(new AuthenticationProperties { RedirectUri = "/" },
                        OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
        }
    }
}