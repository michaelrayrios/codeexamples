using SkyDock.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace SkyDock
{
    //Seed data for first entry
    public class SeedData
    {
        public static void Initialize(IServiceProvider services)
        {
            ApplicationDbContext context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            if (!context._Flights.Any())
            {
                
                Flight aFlight = new Flight
                {
                    Flight_Purpose = "Geo-Reserve Administration Group Pacific Transport",
                    Flight_Origin = "Sharjah, UAE",
                    Flight_Destination = "Singapore",
                    Flight_Details = "A shuttle capable of carrying 58 passengers from the launch site at Arabian Gulf Two to the recovery site at Pacific Three."};
                Contractor aContractor = new Contractor
                {
                    Contractor_Name_First = "Falen",
                    Contractor_Name_Last = "Meelam",
                    Contractor_Organization = "T-Movers",
                    Contractor_Details = "T-Movers is a transorbital logistics company.",
                    FlightID = aFlight.FlightID
                };
                context._Contractors.Add(aContractor);
                aFlight.FlightContractor = aContractor;
                Charter aCharter = new Charter
                {
                    Charter_Name_First = "Alan",
                    Charter_Name_Last = "Veo",
                    Charter_Organization = "W.E.O.",
                    Charter_Details = "W.E.O. is a security firm.",
                    FlightID = aFlight.FlightID
                };
                context._Charters.Add(aCharter);
                aFlight.FlightCharter = aCharter;
                context._Flights.Add(aFlight);    // add the to DB context
                context.SaveChanges();      // save it for ID

                context.SaveChanges(); // save the last addition
            }
        }
    }
}

