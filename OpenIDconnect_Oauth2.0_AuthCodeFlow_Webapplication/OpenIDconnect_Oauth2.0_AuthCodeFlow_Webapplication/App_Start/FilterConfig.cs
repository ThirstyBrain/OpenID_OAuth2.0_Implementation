using System.Web;
using System.Web.Mvc;

namespace OpenIDconnect_Oauth2._0_AuthCodeFlow_Webapplication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
