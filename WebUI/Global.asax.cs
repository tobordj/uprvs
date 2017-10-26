using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using uh365898_db.WebUI.Infrastructure;
using uh365898_db.WebUI;
using uh365898_db.Domain.Entities;
using uh365898_db.WebUI.Binders;
using Moveax.Mvc.ErrorHandler;
using System.IO;
namespace WebUI
{
    // Примечание: Инструкции по включению классического режима IIS6 или IIS7 
    // см. по ссылке http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
           
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
            log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));
        }
        protected void Application_BeginRequest()
        {
          // Response.Cache.SetCacheability(HttpCacheability.NoCache);
           Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
        //    Response.Cache.SetNoStore();
        }

        protected void Application_Error(object sender, System.EventArgs e)
        {
            var errorHandler = new MvcApplicationErrorHandler(application: this, exception: this.Server.GetLastError())
            {
                EnableHttpReturnCodes = true,
                PassThroughHttp401 = false
            };

            errorHandler.Execute();
        }
    
    
    }

    }