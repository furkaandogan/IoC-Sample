using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task.Web.UI.Controllers
{
    public abstract class BaseController : Controller
    {
        Core.Infrastructures.ILogger ILogger;
        public BaseController(Core.Infrastructures.ILogger logger)
        {
            ILogger = logger;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            ILogger.Write(filterContext.Exception);
            base.OnException(filterContext);
        }
    }
}