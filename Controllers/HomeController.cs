using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsAndDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsAndDishes.Controllers
{
    public class HomeController : Controller
    {
        private ChefContext dbContext;

        public HomeController(ChefContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.Chefs
                .Include(chef => chef.CreatedDishes)
                .ToList();
            return View(AllChefs);
        }

        [HttpGet]
        [Route("/dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDishes = dbContext.Dishes
            .Include(dish => dish.Creator)
            .ToList();
            return View(AllDishes);
        }

        [HttpGet]
        [Route("/dishes/new")]
        public IActionResult AddDish() {
            List<Chef> AllChefs = dbContext.Chefs.ToList();
            ViewBag.Chefs = AllChefs;
            return View();
        }

        [HttpGet]
        [Route("/new")]
        public IActionResult AddChef() {
            return View();
        }

        [HttpPost]
        [Route("/create")]
        public IActionResult CreateChef(Chef newChef) {
            if(ModelState.IsValid){
                dbContext.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddChef");
        }

        [HttpPost]
        [Route("/dishes/create")]
        public IActionResult CreateDish(Dish newDish) {
            if(ModelState.IsValid){
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            return View("AddDish");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
