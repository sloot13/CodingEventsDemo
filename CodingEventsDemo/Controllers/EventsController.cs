﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {

        static private Dictionary<string, string> Events = new Dictionary<string, string>();
        // GET: /<controller>/
        public IActionResult Index()
        {
            
            ViewBag.events = Events;

            return View();
        }

        [HttpGet]
        public IActionResult Add1()
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/Add1")]
        public IActionResult NewEvent(string name, string description)
        {
            Events.Add(name, description);

            return Redirect("/Events");
        }
    }
}
