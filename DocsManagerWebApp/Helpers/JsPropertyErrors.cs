// //JsPropertyErrors.cs
// // Copyright (c) 2018 07 03All Rights Reserved
// //  Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System;
using System.Web.Mvc;

namespace DocsManagerWebApp.Helpers
{
    public static class JsPropertyErrors
    {
        public static JsonResult ToJson(this Exception error)
        {
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new JsonResultModel
                {
                    ErrorMessage = error.Message
                }
            };
        }
    }
}