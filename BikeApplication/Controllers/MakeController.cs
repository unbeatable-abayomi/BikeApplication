﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BikeApplication.Controllers
{
    public class MakeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}