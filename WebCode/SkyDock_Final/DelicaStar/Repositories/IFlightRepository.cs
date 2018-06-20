using SkyDock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyDock.Repositories
{   
    public interface IFlightRepository
    {
        //Method signatures
        List<Flight> GetAllFlights();
        Flight GetFlightByID(int id);
        List<Contractor> GetAllContractors();
        List<Charter> GetAllCharters();
        List<Charter> SearchResultsCharter(string searchString);
        List<Contractor> SearchResultsContractor(string searchString);
        int AddFlight(Flight flight);
        int Edit(Flight flight);
        int Delete(int id);
    }
}
