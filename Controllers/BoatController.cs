using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoatRentingAppKnorish.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BoatRentingAppKnorish.Controllers
{
    public class BoatController : Controller
    {
        private readonly IBoatRepository _boat;
        public BoatController(IBoatRepository boat)
        {
            _boat = boat;
        }
        public IActionResult Index()
        {
            IEnumerable<Boat> boatList;
            boatList = _boat.GetBoat();
            return View(boatList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Boat boat)
        {

            if(ModelState.IsValid)
            {
                string boatResult = _boat.AddBoat(boat);
                if(boatResult.Contains("Error"))
                {
                    ViewBag.Message = boatResult;
                }
                else
                {
                    ViewBag.Message = "The boat is successfully registered with Boat Number : '" + boatResult + "'";
                }
                return View();
            }
           
            return View(boat);

        }

        public IActionResult RentBoat()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RentBoat(RentBoatModel model)
        {
            if (ModelState.IsValid)
            {
                string boatResult = _boat.RentRequest(model);
                ViewBag.Message = boatResult;
                return View();
            }

            return View(model);
        }

    }
}