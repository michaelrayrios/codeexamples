using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkyDock.Models;
using Microsoft.EntityFrameworkCore;

namespace SkyDock.Repositories
{
    public class FlightRepositoryR : IFlightRepository
    {
        private ApplicationDbContext context;

        public FlightRepositoryR(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        //Returns the list complete with all joined
        public List<Flight> GetAllFlights()
        {
            return context._Flights.Include(c => c.FlightCharter).Include(con => con.FlightContractor).ToList();

        }

        //returns only contractors
        public List<Contractor> GetAllContractors()
        {
            return context._Contractors.ToList();

        }

        //returns only charters
        public List<Charter> GetAllCharters()
        {
            return context._Charters.ToList();

        }

        //Search results for charters using an incoming string
        public List<Charter> SearchResultsCharter(string search)
        {
            List<Charter> results = new List<Charter>();
            foreach(Charter c in context._Charters)
            {
                if (c.Charter_Organization.Contains(search)){ results.Add(c); }
            }
            return results;
        }

        //Search results for contractors using an incoming string
        public List<Contractor> SearchResultsContractor(string search)
        {
            List<Contractor> results = new List<Contractor>();
            foreach (Contractor c in context._Contractors)
            {
                if (c.Contractor_Organization.Contains(search)) { results.Add(c); }
            }
            return results;
        }

        //Get a flight by an id
        public Flight GetFlightByID(int id)
        {
            return context._Flights.Include(c => c.FlightCharter).Include(con => con.FlightContractor).First(f => f.FlightID == id);
        }

        //Add a flight to the context
        public int AddFlight(Flight aFlight)
        {
            context._Flights.Update(aFlight);
            context.SaveChanges();

            return context.SaveChanges();
        }

        //edit a flight on context
        public int Edit(Flight flight)
        {
            context._Flights.Update(flight);
            context._Charters.Update(flight.FlightCharter);
            context._Contractors.Update(flight.FlightContractor);
            return context.SaveChanges();
        }

        //delete a flight
        public int Delete(int id)
        {
            var flightFromDB = context._Flights.First(a => a.FlightID == id);
            context.Remove(flightFromDB);
            return context.SaveChanges();
        }
    }
}