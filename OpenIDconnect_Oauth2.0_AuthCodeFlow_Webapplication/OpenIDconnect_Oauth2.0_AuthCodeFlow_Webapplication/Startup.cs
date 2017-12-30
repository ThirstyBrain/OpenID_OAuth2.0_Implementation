using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OpenIDconnect_Oauth2._0_AuthCodeFlow_Webapplication.Startup))]
namespace OpenIDconnect_Oauth2._0_AuthCodeFlow_Webapplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
