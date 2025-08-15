using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
   // This interface defines the contract for a repository that manages Flight entities.
/// It specifies the core data access operations (CRUD) for the Flight model.
    public interface IFlightRepo
    {
        void AddFlight(Flight flight); //Adds a new flight to the underlying data store.
        void DeleteFlight(int FlightId);//Deletes a flight from the data store based on its unique ID
        IEnumerable<Flight> GetAllFlights();//Retrieves all flights from the data store
        Flight GetFlightById(int FlightId);//Retrieves a single flight by its unique ID
        void UpdateFlight(Flight flight);//Updates an existing flight record in the data store.
    }
}