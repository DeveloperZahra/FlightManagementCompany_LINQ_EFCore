using FlightManagementCompany.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlightManagementCompany.Repository
{
    //This interface defines the contract for a repository that manages Airport entities.
    /// It specifies the core data access operations (CRUD) for the Airport model
    public interface IAirportRepo
    {
        void AddAirport(Airport airport); //Adds a new airport to the underlying data store
        void DeleteAirport(int AirportId);//Deletes an airport from the data store based on its unique ID.
        Airport GetAirportById(int AirportId); // Retrieves a single airport by its unique ID
        IEnumerable<Airport> GetAllAirports();// Retrieves all airports from the data store
        void UpdateAirport(Airport airport);
    }
}