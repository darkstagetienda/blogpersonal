using PersonalBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
namespace PersonalBlog.MultiSitio
{
    public class MultiSitiosController : Controller
    {
        public Sitios CurrentTenant;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.Assert(filterContext.HttpContext.Request.Url != null, "filterContext.HttpContext.Request.Url != null");
            CurrentTenant = GetCurrentTenant(filterContext.HttpContext.Request.Url.Host.ToLower().Replace("www.", ""));
            ViewBag.CurrentTenant = CurrentTenant;
        }
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;
            if (viewResult != null)
            {
                viewResult.MasterName = viewResult.MasterName != "IGNORE" ? "_Layout" : "";
            }

            Debug.Assert(filterContext.HttpContext.Request.Url != null, "filterContext.HttpContext.Request.Url != null");
            CurrentTenant = GetCurrentTenant(filterContext.HttpContext.Request.Url.Host.ToLower().Replace("www.", ""));
        }

        internal static Sitios GetCurrentTenant(string host)
        {

            if (host == null)
            {
                host = "";
            }
            var Tenant = MvcApplication.sitios.Where(x => x.Url.Contains(host)).FirstOrDefault();
            /*var Tenant = MvcApplication.sitios.Where(p =>
            {
                var match = p.Url + ".";
                return host.StartsWith(match);
            }).FirstOrDefault();*/
            if (Tenant == null)
            {
                Tenant = MvcApplication.sitios.Where(p =>
                {
                    var match = p.FolderName + ".";
                    return host.Contains("." + match);
                }).FirstOrDefault();
            }

            return Tenant ?? MvcApplication.sitios[0];
        }
    }
}