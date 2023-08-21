using Product.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Product.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            SetupConfigurations();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutomapperWebProfile.Run();
        }

        private void SetupConfigurations()
        {
            GlobalDeclarations.DBContextConnectionString  = ConfigurationManager.ConnectionStrings["ProductDBEntities"].ConnectionString;
            GlobalDeclarations.ApplicationPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
        }
    }
}
