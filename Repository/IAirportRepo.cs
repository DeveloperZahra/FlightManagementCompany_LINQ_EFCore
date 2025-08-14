using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    //This interface defines the contract for a repository that manages Airport entities.
/// It specifies the core data access operations (CRUD) for the Airport model
    public interface IAirportRepo
    {
        void AddAirport(Airport airport);
        void DeleteAirport(int AirportId);
        Airport GetAirportById(int AirportId);
        IEnumerable<Airport> GetAllAirports();
        void UpdateAirport(Airport airport);
    }
}