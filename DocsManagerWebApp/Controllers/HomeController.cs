﻿using System.Web.Mvc;

namespace DocsManagerWebApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public ActionResult Index()
        {
            return View();
        }
 
    }
}