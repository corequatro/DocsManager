// //LogActionFilter.cs
// // Copyright (c) 2018 07 02All Rights Reserved
// //  Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System;
using System.Text;
using System.Web.Mvc;
using log4net;
using Ninject.Extensions.Logging;

namespace DocsManagerWebApp.Filters
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class LogActionFilter : FilterAttribute, IActionFilter
    {

        public LogActionFilter()
        {
            ILoggerFactory loggerFactory = DependencyResolver.Current.GetService<ILoggerFactory>();
            _logger = loggerFactory.GetCurrentClassLogger();
        }

        private readonly ILogger _logger;
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var rd = filterContext.HttpContext.Request.RequestContext.RouteData;
            string currentAction = rd.GetRequiredString("action");
            string currentController = rd.GetRequiredString("controller");
            var sb = new StringBuilder();
            sb.Append("Entered action ").Append(currentAction).Append(" in controller ").Append(currentController).Append(".");
            _logger.Info(sb.ToString());
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }
}