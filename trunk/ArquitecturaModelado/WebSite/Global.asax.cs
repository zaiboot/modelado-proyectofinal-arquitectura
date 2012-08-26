using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ZAP.Model;
using ZAP.ErrorHandler;

namespace WebSite
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
        /// <summary>
        /// Used for processing unhandled errors on the mvc layer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception error = Server.GetLastError();
            Response.Clear();
            Server.ClearError();

            string path = Request.Path;
            ErrorHandler eHandler = new ErrorHandler();
            var errorData = eHandler.HandleError<BaseModel>(error);
            Session["errorData"] = errorData;
            Response.Redirect("~/Error");
        }
    }
}