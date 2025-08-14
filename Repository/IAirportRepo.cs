using FlightManagementCompany.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlightManagementCompany.Repository
{
    //This interface defines the contract for a repository that manages Airport entities.
    /// It specifies the core data access operations (CRUD) for the Airport model
    public interface IAirportRepo
    {
        void AddAirport(Airport airport); //Adds a new airport to the underlying data store
        void DeleteAirport(int AirportId);
        Airport GetAirportById(int AirportId);
        IEnumerable<Airport> GetAllAirports();
        void UpdateAirport(Airport airport);
    }
}