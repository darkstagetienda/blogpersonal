using PersonalBlog.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Web;
using System.Web.Mvc;
namespace PersonalBlog.Models
{
    public class Sitios
    {
        public Sitios()
        {
                //articulos = Directory.GetFiles(HttpContext.Current.Server.MapPath("/xml"));
        }
   


        public int TenantID { get; set; }
        public string Url { get; set; }
        public string FolderName { get; set; }

        public string getCurrentHost()
        {
            string host;
            if ( HttpContext.Current.Request.Url.Host.ToLower().Contains("localhost"))
                host = "miguelsamrobles.com";
            else
                host = HttpContext.Current.Request.Url.Host.ToLower().Replace("www.", "");
            return host;

        }
        public List<Articulo> articulos { get; set; }

        /*public string GetData(string item)
        {
            return document.Descendants(item).Single().Value;
            foreach(var node in )
        }*/
        internal static List<Sitios> FetchAll()
        {
            //this should return your list of Tenants from the database or wherever else you stored it
           
            Articulo articulo = new Articulo();
            return new List<Sitios>
                       {
                           new Sitios
                               {
                                   TenantID = 1,
                                   Url = "miguelsamrobles.com",
                                   FolderName = "miguelsamrobles",
                                   articulos = articulo.All("/Content/2/xml")
                               },
                           new Sitios
                                {
                                    TenantID = 2,
                                    Url = "codigoescalable.com",
                                    FolderName = "codigoescalable",
                                    articulos = articulo.All("/Content/2/xml")
                                }
                       };
        }
    }
    public class Articulo
    {
        public List<Articulo> All(string direccion)
        {

            List<Articulo> articulos = new List<Articulo>();
            var files = Directory.GetFiles(HttpContext.Current.Server.MapPath(direccion));

            foreach(var i in files)
            {
                string json = System.IO.File.ReadAllText(i);
                var serializer = new JavaScriptSerializer();
                serializer.RegisterConverters(new[] { new DynamicJsonConverter() });
                dynamic obj = serializer.Deserialize(json, typeof(object));

                Articulo articulo = new Articulo();
                articulo.titulo = GetValue("titulo", obj);
                articulo.url = GetValue("url", obj);
                articulo.contenido1 = GetValue("contenido1", obj);
                articulo.contenido2 = GetValue("contenido2", obj);
                articulos.Add(articulo);
            }

            /*
            var xml = Directory.GetFiles(HttpContext.Current.Server.MapPath(direccion));
            foreach(var i in xml)
            {
                XDocument document = XDocument.Load(i);
                Articulo articulo = new Articulo();
                articulo.titulo = document.Descendants("titulo").Single().Value;
                articulo.url = document.Descendants("url").Single().Value;
                articulo.contenido1 = document.Descendants("contenido1").Single().Value;
                articulo.contenido2 = document.Descendants("contenido2").Single().Value;
                articulos.Add(articulo);
            }*/

            return articulos;
        }
        private string GetValue(string Key, dynamic obj)
        {
            return obj[Key]; 
        }
        public string titulo { get; set; }
        public string url { get; set; }
        public string contenido1 { get; set; }
        public string contenido2 { get; set; }

    }
}