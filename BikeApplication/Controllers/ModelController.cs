using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeApplication.AppDbContext;
using BikeApplication.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeApplication.Controllers
{
    public class ModelController : Controller
    {
        private readonly VroomDbContext _vroomDb;
        [BindProperty]
        public ModelViewModel ModelVM {get; set;}

        public ModelController(VroomDbContext vroomDb)
        {
            _vroomDb = vroomDb;
            ModelVM = new ModelViewModel()
            {
                Makes = _vroomDb.Makes.ToList(),
                Model = new Models.Model()
            };
        }
        public IActionResult Index()
        {
            var model = _vroomDb.Models.Include(m => m.Make);
            return View(model);
        }

        public IActionResult Create()
        {
            return View(ModelVM);
        }
        [HttpPost,ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(ModelVM);
            }
            _vroomDb.Models.Add(ModelVM.Model);
            _vroomDb.SaveChanges();
            return RedirectToAction(nameof(Index));


        }
    }
}
