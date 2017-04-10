using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalBlog.Models;
using PersonalBlog.MultiSitio;

namespace PersonalBlog.Controllers
{
    public class AdminController : MultiSitiosController
    {
        public Sitios sitio;
        public AdminController(){
            sitio = new Sitios();
        sitio = MvcApplication.sitios.Where(x => x.Url.Contains(sitio.getCurrentHost())).FirstOrDefault();
    }
    // GET: Admin
    public ActionResult Index()
        {
            return View(sitio);
        }


        [ValidateInput(false)]
        public ActionResult Crear()
        {
            return View();

        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Crear(FormCollection collection)
        {
            try
            {
                string namefile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");

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
                result += "/articulo/" + url;
                result += "\",\"contenido1\":\"";
                result += contenido1;
                result += "\",\"contenido2\":\"";
                result += contenido2;
                result += "\",\"id\":\"";
                result += namefile + "\"}";


                //buscar el file
                string path = HttpContext.Server.MapPath(sitio.ContentFolder);
                //System.IO.File.WriteAllText("D:\\_data\\deploy\\Content\\2\\xml\\mi primer articulo.txt", result);
                System.IO.File.WriteAllText(path + "\\" + namefile + ".txt", result);

                //actualizar


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [ValidateInput(false)]
        public ActionResult Editar(string id)
        {
            Sitios model = new Sitios();
            model = MvcApplication.sitios.Where(x => x.Url.Contains(model.getCurrentHost())).FirstOrDefault();
            return View(model.articulos.Where(x => x.id.Contains(id)).FirstOrDefault());

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Editar(FormCollection collection)
        {
            try
            {
                string namefile = Convert.ToString(collection["id"]);
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
                result += "/articulo/" + url;
                result += "\",\"contenido1\":\"";
                result += contenido1;
                result += "\",\"contenido2\":\"";
                result += contenido2;
                result += "\",\"id\":\"";
                result += namefile + "\"}";


                //buscar el file
                string path = HttpContext.Server.MapPath(sitio.ContentFolder);
                //System.IO.File.WriteAllText("D:\\_data\\deploy\\Content\\2\\xml\\mi primer articulo.txt", result);
                System.IO.File.WriteAllText(path + "\\" + namefile + ".txt", result);

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