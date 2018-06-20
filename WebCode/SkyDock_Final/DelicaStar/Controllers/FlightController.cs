using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkyDock.Models;
using SkyDock.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace SkyDock.Controllers
{
    //The flight controller for the majority of tasks
    public class FlightController : Controller
    {
        //Setup repo
        private IFlightRepository flightRepo;

        public FlightController(IFlightRepository repo)
        {
            flightRepo = repo;
        }

        //User filters
        public IActionResult Flights()
        {
            if (User != null && User.IsInRole("Admins"))
            {
                return Redirect("ListFlightsAdmin");
            }
            if (User != null && User.IsInRole("control"))
            {
                return Redirect("ListOpenFlights");
            }
            return Redirect("ListFlights");
        }

        public IActionResult RequestF()
        {
            if (User != null && User.IsInRole("member"))
            {
                return Redirect("FlightRequest");
            }
            else
                return Redirect("NoRequestAllowed");
        }

        //Rejection error
        public ViewResult NoRequestAllowed()
        {
            return View(flightRepo.GetAllFlights());
        }

        //List of all flights
        [Authorize]
        public ViewResult ListFlights()
        {
            return View(flightRepo.GetAllFlights());
        }

        [Authorize]
        //List of charters with search included
        public IActionResult ListCharters(string searchString)
        {
            if(searchString == null) { return View(flightRepo.GetAllCharters()); }
            else { return View(flightRepo.SearchResultsCharter(searchString)); }   
        }

        [Authorize]
        //List of contractors with search included
        public IActionResult ListContractors(string searchString)
        {
            if (searchString == null) { return View(flightRepo.GetAllContractors()); }
            else { return View(flightRepo.SearchResultsContractor(searchString)); }
        }

        //List of all open flights - filtered via page
        [Authorize]
        public ViewResult ListOpenFlights()
        {
            return View(flightRepo.GetAllFlights());
        }

        //List of all flights - using the admin view
        [Authorize]
        public ViewResult ListFlightsAdmin()
        {
            return View(flightRepo.GetAllFlights());
        }

        //Flightrequest form empty
        [HttpGet]
        [Authorize(Roles = "member")]
        public IActionResult FlightRequest() => View(new Flight());

        //Flight request form filled out - sent via post
        [HttpPost]
        [Authorize]
        public IActionResult FlightRequest(Flight flightModel)
        {
            if (ModelState.IsValid)
            {
                flightRepo.AddFlight(flightModel);
                return View("Thanks", flightModel);
            }
            else
            {
                return View();
            }
        }

        //For editing flights - retreival 
        [Authorize(Roles = "Admins, control")]
        [HttpGet]
        public ViewResult EditFlight(int id)
        {
            return View(flightRepo.GetFlightByID(id));
        }

        //For editing flights - update via post
        [Authorize(Roles = "Admins, control")]
        [HttpPost]
        public RedirectToActionResult EditFlight(Flight flight)
        {
            flightRepo.Edit(flight);
            if (User != null && User.IsInRole("Admins"))
            {
                return RedirectToAction("ListFlightsAdmin");
            }
            return RedirectToAction("ListFlights");
            
        }

        //Removal - admin only
        [Authorize(Roles = "Admins")]
        public RedirectToActionResult Delete(int id)
        {
            flightRepo.Delete(id);
            return RedirectToAction("ListFlightsAdmin");
        }
    }
}
