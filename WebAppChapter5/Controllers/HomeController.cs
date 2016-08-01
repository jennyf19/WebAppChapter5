using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

namespace WebAppChapter5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize]
        //this attribute ensures the resource is returned only to authenticated users and will trigger
        //a 401 upon receiving unauthenticated requests
        public ActionResult Contact()
        {
            string userFirstName = ClaimsPrincipal.Current.FindFirst(ClaimTypes.GivenName).Value;
            ViewBag.Message = string.Format("Welcome, {0}!", userFirstName);

            return View();
        }

        public void SignOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(
                OpenIdConnectAuthenticationDefaults.AuthenticationType,
                CookieAuthenticationDefaults.AuthenticationType);
        }
    }

}