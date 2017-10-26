namespace WebUI.Controllers
{
    using System;
    using System.Web.Mvc;
	using Moveax.Mvc.ErrorHandler;
    
    public class ErrorController : Controller
    {

        protected new HttpNotFoundResult HttpNotFound(string statusDescription = null)
        {
            return new HttpNotFoundResult(statusDescription);
        }

        
        /// <summary>Default action.</summary>
        /// <param name="errorDescription">The error description.</param>
        

        /// <summary>HTTP 404 Error: Not found.</summary>
        /// <param name="errorDescription">The error description.</param>
        public ActionResult Http404(ErrorDescription errorDescription)
        {
            Response.StatusCode = 404;
            return this.View("Http404");
        }

        public ActionResult Http500(ErrorDescription errorDescription)
        {

            Response.StatusCode = 500;
            return this.View("Http500");
        }

      //  public ViewResult NotFound()
       // {
         //   Response.StatusCode = 404;  //you may want to set this to 200
           // return View("NotFound");
     //   }

        
		/// <summary>Called before the action method is invoked. Use it for error logging etc</summary>
        /// <param name="errorDescription">The error description.</param>
        
    }
}
