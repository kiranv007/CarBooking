﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarBooking.Controllers
{
    public class HomepageController : Controller
    {
        // GET: Homepage
        public ActionResult Index()
        {
            return View();
        }
    }
}