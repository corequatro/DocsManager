// //HandleExceptionFilter.cs
// // Copyright (c) 2018 07 02All Rights Reserved
// //  Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System;
using System.Linq;
using System.Web.Mvc;
using log4net.Repository.Hierarchy;
using Ninject.Extensions.Logging;
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