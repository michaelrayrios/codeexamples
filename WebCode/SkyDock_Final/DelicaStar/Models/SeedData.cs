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
                //First
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
                
                //Second
                aFlight = new Flight
                {
                    Flight_Purpose = "Transportation of consumer goods",
                    Flight_Origin = "Hong-Kong, CA Admin",
                    Flight_Destination = "Cape Town, South Africa",
                    Flight_Details = "A transportation of consumer goods ranging from consumables to luxury materials."
                };
                aContractor = new Contractor
                {
                    Contractor_Name_First = "Dera",
                    Contractor_Name_Last = "Tura",
                    Contractor_Organization = "VeTonSeco",
                    Contractor_Details = "VeTonSeco is a spanish orbital mover and logistics company.",
                    FlightID = aFlight.FlightID
                };
                context._Contractors.Add(aContractor);
                aFlight.FlightContractor = aContractor;
                aCharter = new Charter
                {
                    Charter_Name_First = "Thomas",
                    Charter_Name_Last = "Rio",
                    Charter_Organization = "Tuurv Enterprises C",
                    Charter_Details = "Tuurv Enterprices C is a manufacturing company of aerospace components.",
                    FlightID = aFlight.FlightID
                };
                context._Charters.Add(aCharter);
                aFlight.FlightCharter = aCharter;
                context._Flights.Add(aFlight);    // add the to DB context
                context.SaveChanges();      // save it for ID

                //Third
                aFlight = new Flight
                {
                    Flight_Purpose = "Transports of delegates to the UN17 Conference.",
                    Flight_Origin = "New York, USA",
                    Flight_Destination = "Geneva, Switzerland",
                    Flight_Details = "34 passengers need to be transported to the UN17 conference."
                };
                aContractor = new Contractor
                {
                    Contractor_Name_First = "Alex",
                    Contractor_Name_Last = "Palen",
                    Contractor_Organization = "Turnkey-SKYWAYS",
                    Contractor_Details = "Turnkey-SKYWAYS is an international moving company.",
                    FlightID = aFlight.FlightID
                };
                context._Contractors.Add(aContractor);
                aFlight.FlightContractor = aContractor;
                aCharter = new Charter
                {
                    Charter_Name_First = "Vess",
                    Charter_Name_Last = "Altura",
                    Charter_Organization = "UN/Security",
                    Charter_Details = "UN/S is a security firm responsible for US delegates to the UN.",
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

