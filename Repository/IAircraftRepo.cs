using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
   // This interface defines the contract for a repository that manages Aircraft entities.
/// It specifies the core data access operations (CRUD) for the Aircraft model
    public interface IAircraftRepo
    {
        void AddAircraft(Aircraft aircraft);
        void DeleteAircraft(int AircraftId);
        Aircraft GetAircraftById(int AircraftId);
        IEnumerable<Aircraft> GetAllAircraft();
        void UpdateAircraft(Aircraft aircraft);
    }
}