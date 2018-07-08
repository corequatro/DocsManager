using System.Web.Mvc;
using DocsManagerWebApp.Filters;

namespace DocsManagerWebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new HandleExceptionFilter());
            filters.Add(new LogActionFilter());
        }
    }
}
