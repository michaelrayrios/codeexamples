using SkyDock.Controllers;
using SkyDock.Models;
using System.Collections.Generic;
using Xunit;

namespace SkyDock.Tests
{
    public class FlightTests
    {
        //Setup Test Environment
        FlightRepositoryF repository;
        FlightController controller;
        List<Flight> repoFlights;

        //Finish setup
        public FlightTests()
        {
            repository = new FlightRepositoryF();
            repoFlights = repository.GetAllFlights();
            controller = new FlightController(repository);
        }

        //Test
        [Fact]
        public void GetAllFlightsTest()
        {
            var flights = controller.ListFlights().ViewData.Model as List<Flight>;

            for(int i = 0; i < repoFlights.Count; i++)
            {
                Assert.Equal(repoFlights[i].Flight_Destination, flights[i].Flight_Destination);
                Assert.Equal(repoFlights[i].Flight_Details, flights[i].Flight_Details);
                Assert.Equal(repoFlights[i].Flight_Purpose, flights[i].Flight_Purpose);
                Assert.Equal(repoFlights[i].Flight_Origin, flights[i].Flight_Origin);
            }
        }

        //Test
        [Fact]
        public void GetFlightTest()
        {
            Flight aFlight = new Flight();
            aFlight.Flight_Destination = "Test dest";
            aFlight.Flight_Origin = "Test org";
            aFlight.Flight_Purpose = "Test purp";
            aFlight.Flight_Details = "Test det";

            repository.AddFlight(aFlight);

            List<Flight> flightList = repository.GetAllFlights();

            Assert.Equal(flightList[flightList.Count - 1].Flight_Destination, aFlight.Flight_Destination);
            Assert.Equal(flightList[flightList.Count - 1].Flight_Details, aFlight.Flight_Details);
            Assert.Equal(flightList[flightList.Count - 1].Flight_Purpose, aFlight.Flight_Purpose);
            Assert.Equal(flightList[flightList.Count - 1].Flight_Origin, aFlight.Flight_Origin);
        }

        //Test
        [Fact]
        public void FlightCreatesObjects()
        {
            //Check that flight creates both a blank contractor and a blank charter when it is created
            Flight aFlight = new Flight();
            Assert.NotNull(aFlight.FlightCharter);
            Assert.NotNull(aFlight.FlightContractor);
        }

        //Test
        [Fact]
        public void FlightCreatesBlankContractor()
        {
            Flight aFlight = new Flight();
            Assert.NotNull(aFlight.FlightContractor);
            Assert.Null(aFlight.FlightContractor.Contractor_Name_First);
            Assert.Null(aFlight.FlightContractor.Contractor_Name_Last);
            Assert.Null(aFlight.FlightContractor.Contractor_Name_Last);
            Assert.Null(aFlight.FlightContractor.Contractor_Details);
            Assert.Null(aFlight.FlightContractor.Contractor_Organization);
        }

        //Test
        [Fact]
        public void FlightCreatesBlankCharter()
        {
            Flight aFlight = new Flight();
            Assert.NotNull(aFlight.FlightCharter);
            Assert.Null(aFlight.FlightCharter.Charter_Name_First);
            Assert.Null(aFlight.FlightCharter.Charter_Name_Last);
            Assert.Null(aFlight.FlightCharter.Charter_Organization);
            Assert.Null(aFlight.FlightCharter.Charter_Details);
        }
    }
}
