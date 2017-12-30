using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using OpenIDconnect_Oauth2._0_AuthCodeFlow_Webapplication.Models;

namespace OpenIDconnect_Oauth2._0_AuthCodeFlow_Webapplication.Controllers
{
    
    public class AccountController : Controller
    {
        public void SignIn() {
            if (!Request.IsAuthenticated)
                HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties { RedirectUri = "/" }, OpenIdConnectAuthenticationDefaults.AuthenticationType);
        }

        public void SignOut() {
            HttpContext.GetOwinContext().Authentication.SignOut(new AuthenticationProperties { RedirectUri = "/" }, OpenIdConnectAuthenticationDefaults.AuthenticationType);
        }
    }
}