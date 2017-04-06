using PersonalBlog.Models;
using PersonalBlog.MultiSitio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalBlog.Controllers
{
    public class ArticuloController : MultiSitiosController
    {
        // GET: Articulo
        public ActionResult Index(string id)
        {
            Sitios model = new Sitios();
            model = MvcApplication.sitios.Where(x => x.Url.Contains(model.getCurrentHost())).FirstOrDefault();
            //model.articulos.Select(x => x.url == id);
            //var articulo = model.s
            //Articulo articulo = new Articulo();
            var articulo = model.articulos.Where(x => x.url.Contains(id)).FirstOrDefault();
            return View("Index", articulo); 
            //return View(id);
        }
    }
}