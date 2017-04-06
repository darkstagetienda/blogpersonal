using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;

using System.Web.UI;
namespace PersonalBlog.Core
{
   /* public class DbDrivenView: IView
    {
        public void Render(ViewContext viewContext, TextWriter writer)
        {
            writer.Write("Hello World");
        }
    }*/

    public class DbDrivenView : IView
    {
        string _viewName;
        public DbDrivenView(string viewName)
        {
            if (string.IsNullOrEmpty(viewName))
            {
                throw new ArgumentNullException("viewName", new ArgumentException("View Name cannot be null"));
            }
            _viewName = viewName;
        }
        public void Render(ViewContext viewContext, TextWriter writer)
        {
            //HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
            /*DataForm form = dbContext.DataForms.Include("Fields").First(f => f.Name == _viewName);
            HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
            htmlWriter.RenderBeginTag(HtmlTextWriterTag.Div);
            foreach (var item in form.Fields)
            {
                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Div);
                htmlWriter.WriteEncodedText(item.DisplayLabel);
                htmlWriter.RenderBeginTag(GetHtmlRenderKey(item.DisplayType));
                htmlWriter.RenderEndTag();
                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Div);
            }*/
            //htmlWriter.RenderEndTag();
            writer.Write("Hello World");
        }
     
    }
}