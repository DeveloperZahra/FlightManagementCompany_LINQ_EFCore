using FlightManagementCompany.Models;
using static System.Formats.Asn1.AsnWriter;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace FlightManagementCompany.Repository
{
    // This interface defines the contract for a repository that manages Aircraft entities.
    /// It specifies the core data access operations (CRUD) for the Aircraft model
    public interface IAircraftRepo
    {
       // Adds a new aircraft to the underlying data store
       void AddAircraft(Aircraft aircraft); //The Aircraft object to be added
       void DeleteAircraft(int AircraftId); //Deletes an aircraft from the data store based on its unique ID
        Aircraft GetAircraftById(int AircraftId); //Retrieves a single aircraft by its unique ID
        IEnumerable<Aircraft> GetAllAircraft();
        void UpdateAircraft(Aircraft aircraft);
    }
}