using FlightManagementCompany.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlightManagementCompany.Repository
{
    // This interface defines the contract for a repository that manages Aircraft entities.
    /// It specifies the core data access operations (CRUD) for the Aircraft model
    public interface IAircraftRepo
    {
       // Adds a new aircraft to the underlying data store

        void AddAircraft(Aircraft aircraft); //The Aircraft object to be added
        void DeleteAircraft(int AircraftId);
        Aircraft GetAircraftById(int AircraftId);
        IEnumerable<Aircraft> GetAllAircraft();
        void UpdateAircraft(Aircraft aircraft);
    }
}