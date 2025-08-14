using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
   // This interface defines the contract for a repository that manages Baggage entities.
/// It specifies the core data access operations (CRUD) for the Baggage model
    public interface IBaggageRepo
    {
        void AddBaggage(Baggage baggage); // Adds a new baggage record to the underlying data store
        void DeleteBaggage(int BaggageId);
        IEnumerable<Baggage> GetAllBaggages();
        Baggage GetBaggageById(int BaggageId);
        void UpdateBaggage(Baggage baggage);
    }
}