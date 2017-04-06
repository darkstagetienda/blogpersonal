using PersonalBlog.MultiSitio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalBlog.Models;
namespace PersonalBlog.Controllers
{
    public class HomeController : MultiSitiosController
    {
        public ActionResult Index()
        {
            Sitios model = new Sitios();
            model = MvcApplication.sitios.Where(x => x.Url.Contains(model.getCurrentHost())).FirstOrDefault();
            //var Model2 = MvcApplication.sitios.Where(x => x.Url.Contains(HttpContext.Request.Url.Host.ToLower().Replace("www.", ""))).FirstOrDefault();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ViewResult Dynamic(string id)
        {
            return View(id);
        }
    }
}