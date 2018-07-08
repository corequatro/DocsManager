// //HandleExceptionFilter.cs
// // Copyright (c) 2018 07 02All Rights Reserved
// //  Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System;
using System.Web.Mvc;
using DocsManagerWebApp.Helpers;
using ILoggerFactory = Ninject.Extensions.Logging.ILoggerFactory;

namespace DocsManagerWebApp.Filters
{
    public class HandleExceptionFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }
            LoggingException(filterContext.Exception);
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            bool isAjax = string.CompareOrdinal(filterContext.HttpContext.Request.Headers["X-Requested-With"], "XMLHttpRequest") == 0;
            if (isAjax)
            {
                filterContext.Result = filterContext.Exception.ToJson();
                filterContext.HttpContext.Response.StatusCode = 500;

            }
            else
            {
                var controllerName = (string)filterContext.RouteData.Values["controller"];
                var actionName = (string)filterContext.RouteData.Values["action"];
                var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
                filterContext.Result = new ViewResult
                {
                    ViewName = View,
                    MasterName = Master,
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                    TempData = filterContext.Controller.TempData
                };
                filterContext.HttpContext.Response.StatusCode = 500;
            }

            filterContext.ExceptionHandled = true;
        }

        private void LoggingException(Exception exception)
        {
            var log = DependencyResolver.Current.GetService<ILoggerFactory>().GetCurrentClassLogger();
            if (exception.InnerException != null)
            {
                if (exception.InnerException.InnerException != null)
                {
                    LoggingException(exception.InnerException);
                }
                else
                {
                    log.FatalException(exception.InnerException.Message, exception.InnerException);
                }
            }
            else
            {
                log.FatalException(exception.Message, exception);
            }
        }
    }
}