using PersonalBlog.Core;
using PersonalBlog.Models;
using PersonalBlog.MotorVista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PersonalBlog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static List<Sitios> sitios;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            System.Web.Mvc.ViewEngines.Engines.Clear();
            System.Web.Mvc.ViewEngines.Engines.Add(new MultiSitioMotorVista());
            //ViewEngines.Engines.Insert(0, new DbDrivenViewEngine());

            sitios = Sitios.FetchAll();
        }
    }
}
