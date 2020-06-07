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

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var make = _db.Makes.Find(Id);
            if(make == null)
            {
                return NotFound();
            }
            _db.Makes.Remove(make);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Edit(int Id)
        {
            var make = _db.Makes.Find(Id);
            if (make == null)
            {
                return NotFound();
            }

            return View(make);

        }
        [HttpPost]
        public IActionResult Edit(Make make)
        {
            if (ModelState.IsValid)
            {
                //_db.Makes.Add(make);
                _db.Makes.Update(make);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(make);
        }
        //[HttpPost]
        //public IActionResult Delete()
        //{
        //    return View();
        //}
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