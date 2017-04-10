using PersonalBlog.MultiSitio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalBlog.Models;
namespace PersonalBlog.Controllers
{
    public class ArticulosController: MultiSitiosController
    {
        // GET: Articulos
        public ActionResult Index()
        { 
            Sitios model = new Sitios();
            model = MvcApplication.sitios.Where(x => x.Url.Contains(model.getCurrentHost())).FirstOrDefault();
            //var Model2 = MvcApplication.sitios.Where(x => x.Url.Contains(HttpContext.Request.Url.Host.ToLower().Replace("www.", ""))).FirstOrDefault();
            return View(model);
        }
    }
}