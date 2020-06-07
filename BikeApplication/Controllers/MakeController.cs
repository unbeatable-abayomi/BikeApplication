using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace BikeApplication.Controllers
{
    public class MakeController : Controller
    {
        //Make
        //Make/Bikes
        [Route("Make")]
        [Route("Make/Bikes")]
        public IActionResult Bikes()
        {
            Make make = new Make { Id = 1, Name = "Harley Davidson" };
            return View(make);
        }
    }
}