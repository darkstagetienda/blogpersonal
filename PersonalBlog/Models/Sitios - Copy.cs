using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace PersonalBlog.Models
{
    public class Sitios
    {
        private XDocument document;
        public Sitios()
        {
                //articulos = Directory.GetFiles(HttpContext.Current.Server.MapPath("/xml"));
        }
    
        public int TenantID { get; set; }
        public string Url { get; set; }
        public string FolderName { get; set; }

        public string[] articulos { get; set; }

        public string GetData(string item)
        {
            return document.Descendants(item).Single().Value;
            foreach(var node in )
        }
        internal static List<Sitios> FetchAll()
        {
            //this should return your list of Tenants from the database or wherever else you stored it


            return new List<Sitios>
                       {
                           new Sitios
                               {
                                   TenantID = 1,
                                   Url = "miguelsamrobles.com",
                                   FolderName = "miguelsamrobles",
                                   articulos = Directory.GetFiles(HttpContext.Current.Server.MapPath("/Content/2/xml"))
                               },
                           new Sitios
                                {
                                    TenantID = 2,
                                    Url = "codigoescalable.com",
                                    FolderName = "codigoescalable",
                                    articulos = Directory.GetFiles(HttpContext.Current.Server.MapPath("/Content/3/xml"))
                                }
                       };
        }
    }
    public class Articulo
    {

        public string titulo { get; set; }
        public string url { get; set; }
        public string contenido { get; set;}

    }
}