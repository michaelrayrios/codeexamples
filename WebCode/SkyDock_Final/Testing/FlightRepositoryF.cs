using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkyDock.Models;
using SkyDock.Repositories;

namespace SkyDock.Tests
{
    public class FlightRepositoryF : IFlightRepository
    {
        static List<Flight> aFlightList = new List<Flight>();

        public FlightRepositoryF() //Construct the fake repo
        {
            Charter theCharter = new Charter
            {
                Charter_Name_First = "Joe",
                Charter_Name_Last = "Jango",
                Charter_Organization = "JoeJoePlace",
                Charter_Details = "Not Much"
            };            

            Contractor theContractor = new Contractor
            {
                Contractor_Name_First = "Super Joe",
                Contractor_Name_Last = "Super Joe Jango",
                Contractor_Organization = "JoeJoeSuperJoePlace",
                Contractor_Details = "So Much"
            };

            Flight theFlight = new Flight
            {
                Flight_Purpose = "Go places",
                Flight_Origin = "This place",
                Flight_Destination = "That place",
                Flight_Details = "So cool",
                FlightCharter = theCharter,
                FlightContractor = theContractor
            };

            aFlightList.Add(theFlight);

            theCharter = new Charter
            {
                Charter_Name_First = "Fat Tom",
                Charter_Name_Last = "Brodo",
                Charter_Organization = "Bacon House",
                Charter_Details = "Too many"
            };

            theContractor = new Contractor
            {
                Contractor_Name_First = "Old pete hummbucker",
                Contractor_Name_Last = "smit",
                Contractor_Organization = "Ol Tooty Rooty",
                Contractor_Details = "None"
            };

            theFlight = new Flight
            {
                Flight_Purpose = "Make go",
                Flight_Origin = "Lame place",
                Flight_Destination = "Cool place",
                Flight_Details = "Not really",
                FlightCharter = theCharter,
                FlightContractor = theContractor
            };

            aFlightList.Add(theFlight);

            theCharter = new Charter
            {
                Charter_Name_First = "Little banko",
                Charter_Name_Last = "Boopa",
                Charter_Organization = "TututuMook",
                Charter_Details = "Got a lot of details for you."
            };

            theContractor = new Contractor
            {
                Contractor_Name_First = "Yo yo man",
                Contractor_Name_Last = "man man",
                Contractor_Organization = " Yo Yo mania",
                Contractor_Details = "Super time yo yo fun"
            };

            theFlight = new Flight
            {
                Flight_Purpose = "Yo yos to space yo",
                Flight_Origin = "new york",
                Flight_Destination = "moon",
                Flight_Details = "dunno",
                FlightCharter = theCharter,
                FlightContractor = theContractor
            };

            aFlightList.Add(theFlight);
        }

        public List<Flight> GetAllFlights()
        {
            return aFlightList;
        }

        public void AddFlight(Flight aFlight)
        {
            aFlightList.Add(aFlight);
        }

        public Flight GetFlightByID(int id)
        {
            foreach(Flight f in aFlightList)
            {
                if(f.FlightID == id)
                {
                    return f;
                }
            }
            return null;
        }

        public List<Contractor> GetAllContractors()
        {
            List<Contractor> tempList = new List<Contractor>();
            foreach (Flight f in aFlightList)
            {
                tempList.Add(f.FlightContractor);
            }
            return tempList;
        }

        public List<Charter> GetAllCharters()
        {
            List<Charter> tempList = new List<Charter>();
            foreach (Flight f in aFlightList)
            {
                tempList.Add(f.FlightCharter);
            }
            return tempList;
        }

        public List<Charter> SearchResultsCharter(string searchString)
        {
            List<Charter> results = new List<Charter>();
            List<Charter> tempCharterList = new List<Charter>();
            foreach (Flight f in aFlightList)
            {
                tempCharterList.Add(f.FlightCharter);
            }
            foreach (Charter c in tempCharterList)
            {
                if (c.Charter_Organization.Contains(searchString))
                {
                    results.Add(c);
                }
            }
            return results;
        }

        public List<Contractor> SearchResultsContractor(string searchString)
        {
            List<Contractor> results = new List<Contractor>();
            List<Contractor> tempContractorList = new List<Contractor>();
            foreach (Flight f in aFlightList)
            {
                tempContractorList.Add(f.FlightContractor);
            }
            foreach (Contractor c in tempContractorList)
            {
                if (c.Contractor_Organization.Contains(searchString))
                {
                    results.Add(c);
                }
            }
            return results;
        }

        int IFlightRepository.AddFlight(Flight flight)
        {
            aFlightList.Add(flight);
            return 0;
        }

        public int Edit(Flight flight)
        {
            foreach(Flight f in aFlightList)
            {
                if(f.FlightID == flight.FlightID)
                {
                    aFlightList.Remove(f);
                    break;
                }
            }
            aFlightList.Add(flight);
            return 0;
        }

        public int Delete(int id)
        {
            foreach (Flight f in aFlightList)
            {
                if (f.FlightID == id)
                {
                    aFlightList.Remove(f);
                    break;
                }
            }
            return 0;
        }
    }
}