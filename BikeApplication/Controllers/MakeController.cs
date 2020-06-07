using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeApplication.AppDbContext;
using BikeApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeApplication.Controllers
{
    public class MakeController : Controller
    {
        private readonly VroomDbContext _db;

        public MakeController(VroomDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View(_db.Makes.ToList());
        }
        //Get method
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Make make)
        {
            if (ModelState.IsValid)
            {
                _db.Makes.Add(make);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(make);
        }
        //Make
        //Make/Bikes
        //[Route("Make")]
        //[Route("Make/Bikes")]
        //public IActionResult Bikes()
        //{
        //    Make make = new Make { Id = 1, Name = "Harley Davidson" };
        //    return View(make);
        //}
    }
}