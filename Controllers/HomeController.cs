using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private CRUDContext dbContext;

        public HomeController(CRUDContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Dish> EveryDish = dbContext.Dishes.OrderByDescending(d => d.CreatedAt).ToList();
            ViewBag.AllDishes = EveryDish;
            return View("Index");
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View("AddDish");
        }

        [HttpPost("create")]
        public IActionResult Create(Dish dish)
        {
            dbContext.Add(dish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("{dishId}")]
        public IActionResult ViewDish(int dishId)
        {
            Dish getDish = dbContext.Dishes.FirstOrDefault(d => d.DishId == dishId);
            ViewBag.ThisDish = getDish;
            return View("ViewDish");
        }

        [HttpGet("delete/{dishId}")]
        public IActionResult DeleteDish(int dishId)
        {
            Dish delDish = dbContext.Dishes.SingleOrDefault(d => d.DishId == dishId);
            dbContext.Dishes.Remove(delDish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("edit/{dishId}")]
        public IActionResult EditDish(int dishId)
        {
            Dish getDish = dbContext.Dishes.SingleOrDefault(d => d.DishId == dishId);
            ViewBag.ThisDish = getDish;
            return View("EditDish");
        }

        [HttpPost("update")]
        public IActionResult Update(Dish dish)
        {
            Dish updtDish = dbContext.Dishes.FirstOrDefault(d => d.DishId == dish.DishId);
            updtDish.Name = dish.Name;
            updtDish.Chef = dish.Chef;
            updtDish.Calories = dish.Calories;
            updtDish.Tastiness = dish.Tastiness;
            updtDish.Description = dish.Description;
            updtDish.UpdatedAt = DateTime.Now;
            dbContext.SaveChanges();
            ViewBag.ThisDish = updtDish;
            return View("ViewDish");
        }
    }
}