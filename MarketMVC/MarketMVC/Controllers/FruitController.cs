using MarketMVC.Models;
using MarketMVC.Models.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MarketMVC.Controllers
{
    public class FruitController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FruitController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Fruit> fruits = new();

            try
            {
                fruits = _context.Fruits.ToList();
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }

            return View(fruits);
        }

        [HttpPost]
        public IActionResult Create(Fruit fruit)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            try
            {
                _context.Fruits.Add(fruit);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return RedirectToAction("Error");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                Fruit fruit = _context.Fruits.FirstOrDefault(f => f.Id == id);

                if (fruit != null)
                {
                    _context.Fruits.Remove(fruit);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }



            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Fruit fruit)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            try
            {
                Fruit editedFruit = _context.Fruits.FirstOrDefault(f => f.Id == fruit.Id);

                if (editedFruit != null)
                {
                    editedFruit.Name = fruit.Name;
                    editedFruit.Price = fruit.Price;
                    editedFruit.Quality = fruit.Quality;
                    editedFruit.ImagePath = fruit.ImagePath;

                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Error");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Fruit> fruits = _context.Fruits;
                return Ok(fruits);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occured: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }
    }
}
