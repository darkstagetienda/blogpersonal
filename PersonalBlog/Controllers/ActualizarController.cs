using PersonalBlog.Models;
using PersonalBlog.MultiSitio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalBlog.Models;
namespace PersonalBlog.Controllers
{
    public class ActualizarController : MultiSitiosController
    {
        // GET: Actualizar
        public ActionResult Index()
        {
            Sitios model = new Sitios();
            model = MvcApplication.sitios.Where(x => x.Url.Contains(HttpContext.Request.Url.Host.ToLower().Replace("www.", ""))).FirstOrDefault();

            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                string url = Convert.ToString(collection["url"]);
                string titulo = Convert.ToString(collection["titulo"]);
                string contenido1 = Convert.ToString(collection["contenido1"]);
                contenido1 = contenido1.Replace("class=\"MsoNormal\"", "");
                string contenido2 = Convert.ToString(collection["contenido2"]);
                contenido2 = contenido2.Replace("class=\"MsoNormal\"", "");
                // TODO: Add insert logic here
                string result = "{\"titulo\":\"";
                result += titulo;
                result += "\",\"url\":\"";
                result += url;
                result += "\",\"contenido1\":\"";
                result += contenido1;
                result += "\",\"contenido2\":\"";
                result += contenido2+"\"}";

                //buscar el file
                System.IO.File.WriteAllText("D:\\_data\\deploy\\Content\\2\\xml\\mi primer articulo.txt", result);

                //actualizar


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

}