// //BaseController.cs
// // Copyright (c) 2018 06 26All Rights Reserved
// // Cq, Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace DocsManagerWebApp.Controllers
{
    public class BaseController : Controller
    {
        protected ActionResult GetJson(object data)
        {
            HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            HttpContext.Response.Cache.SetValidUntilExpires(false);
            HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Response.Cache.SetNoStore();
            HttpContext.Response.ContentType = "application/json";
            return Content(JsonConvert.SerializeObject(data, new JsonSerializerSettings()
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Local
            }));

        }

        protected ActionResult ReturnSuccess()
        {
            return GetJson(new { Success = true });
        }
    }
}