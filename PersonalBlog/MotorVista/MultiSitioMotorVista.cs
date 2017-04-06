using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using PersonalBlog.MultiSitio;

namespace PersonalBlog.MotorVista
{
    public class MultiSitioMotorVista: RazorViewEngine
    {
        public MultiSitioMotorVista()
        {
            AreaViewLocationFormats = new[] {
            "~/Areas/{2}/Views/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/{1}/{0}.vbhtml",
            "~/Areas/{2}/Views/Shared/{0}.cshtml",
            "~/Areas/{2}/Views/Shared/{0}.vbhtml"
            };

            AreaMasterLocationFormats = new[] {
            "~/Areas/{2}/Views/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/{1}/{0}.vbhtml",
            "~/Areas/{2}/Views/Shared/{0}.cshtml",
            "~/Areas/{2}/Views/Shared/{0}.vbhtml"
            };

            AreaPartialViewLocationFormats = new[] {
            "~/Areas/{2}/Views/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/{1}/{0}.vbhtml",
            "~/Areas/{2}/Views/Shared/{0}.cshtml",
            "~/Areas/{2}/Views/Shared/{0}.vbhtml"
            };

            ViewLocationFormats = new[] {
            "~/Views/%1/{1}/{0}.cshtml",
            "~/Views/%1/{1}/{0}.vbhtml",
            "~/Views/%1/Shared/{0}.cshtml",
            "~/Views/%1/Shared/{0}.vbhtml",
            "~/Views/Global/{1}/{0}.cshtml",
            "~/Views/Global/{1}/{0}.vbhtml",
            "~/Views/Global/Shared/{0}.cshtml",
            "~/Views/Global/Shared/{0}.vbhtml"
            };

            MasterLocationFormats = new[] {
            "~/Views/%1/{1}/{0}.cshtml",
            "~/Views/%1/{1}/{0}.vbhtml",
            "~/Views/%1/Shared/{0}.cshtml",
            "~/Views/%1/Shared/{0}.vbhtml",
            "~/Views/Global/{1}/{0}.cshtml",
            "~/Views/Global/{1}/{0}.vbhtml",
            "~/Views/Global/Shared/{0}.cshtml",
            "~/Views/Global/Shared/{0}.vbhtml"
            };

            PartialViewLocationFormats = new[] {
            "~/Views/%1/{1}/{0}.cshtml",
            "~/Views/%1/{1}/{0}.vbhtml",
            "~/Views/%1/Shared/{0}.cshtml",
            "~/Views/%1/Shared/{0}.vbhtml",
            "~/Views/Global/{1}/{0}.cshtml",
            "~/Views/Global/{1}/{0}.vbhtml",
            "~/Views/Global/Shared/{0}.cshtml",
            "~/Views/Global/Shared/{0}.vbhtml"
            };
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            var PassedController = controllerContext.Controller as MultiSitiosController;
            Debug.Assert(PassedController != null, "PassedController != null");
            return base.CreatePartialView(controllerContext, partialPath.Replace("%1", PassedController.CurrentTenant.FolderName));
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            var PassedController = controllerContext.Controller as MultiSitiosController;
            Debug.Assert(PassedController != null, "PassedController != null");
            return base.CreateView(controllerContext, viewPath.Replace("%1", PassedController.CurrentTenant.FolderName), masterPath.Replace("%1", PassedController.CurrentTenant.FolderName));
        }

        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            try
            {

                var PassedController = controllerContext.Controller as MultiSitiosController;
                if (PassedController != null)
                {
                    return base.FileExists(controllerContext, virtualPath.Replace("%1", PassedController.CurrentTenant.FolderName));
                }
                else
                {
                    var newEx = new Exception("PassedController is null, Controller must inherit MultiTenantController");
                    //Elmah.ErrorSignal.FromCurrentContext().Raise(newEx);
                    return base.FileExists(controllerContext, virtualPath);
                }
                
            }
            catch (HttpException exception)
            {
                //Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
                if (exception.GetHttpCode() != 0x194)
                {
                    throw;
                }
                return false;
            }
            catch (Exception exception)
            {
                var newEx = new Exception((controllerContext == null).ToString(), exception);
                //Elmah.ErrorSignal.FromCurrentContext().Raise(newEx);
                return false;
            }
        }
    }
}