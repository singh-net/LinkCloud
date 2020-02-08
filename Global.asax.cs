using Microsoft.Web.WebPages.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LinkCloud
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public class OAuthConfig
        {
            public static void RegisterProviders()
            {
                OAuthWebSecurity.RegisterGoogleClient();
                OAuthWebSecurity.RegisterFacebookClient(appId: "256254958696216", appSecret: "36e35bc2ce59d52451e7a62b0496e152");
            }
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            OAuthConfig.RegisterProviders();
        }
    }
}
