﻿using System.Web.Mvc;

namespace SQLiDemoUserAgent.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}