using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Events/Add")]
        public IActionResult NewEvent(Event newEvent)
        {
            EventData.Add(newEvent);
      
            return Redirect("/Events");
        }

        public IActionResult Delete()
        {
            //ViewBag.title = "Delete Events";
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }

        [HttpGet]
        [Route("Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            // controller code will go here
            ViewBag.eventToEdit = EventData.GetById(eventId);
            ViewBag.title = "Edit Event {Eventdata.Name} (id={EventData.ID})";
            return View();
        }

        [HttpPost]
        [Route("Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            // controller code will go here
            EventData.GetById(eventId).Name = name;
            EventData.GetById(eventId).Description = description;

            return Redirect("/Events");
        }
    }
}
