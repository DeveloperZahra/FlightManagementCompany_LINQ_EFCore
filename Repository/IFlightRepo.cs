using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
   // This interface defines the contract for a repository that manages Flight entities.
/// It specifies the core data access operations (CRUD) for the Flight model.
    public interface IFlightRepo
    {
        void AddFlight(Flight flight);
        void DeleteFlight(int FlightId);
        IEnumerable<Flight> GetAllFlights();
        Flight GetFlightById(int FlightId);
        void UpdateFlight(Flight flight);
    }
}