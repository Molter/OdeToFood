﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;
namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        IRestaurantData _restaurantData;
        IGreeter _greeter;
        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.MessageOfTheDay = _greeter.MessageOfTheDay();


            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if(model == null)
            {
                return NotFound();
            }
            return View(model);

        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var r = new Restaurant { Name = model.Name, Cuisine = model.Cuisine };
            r = _restaurantData.Add(r);


            return RedirectToAction(nameof(Details), new {id = r.Id});
        }

    }
}
