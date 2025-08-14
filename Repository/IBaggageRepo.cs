using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
   // This interface defines the contract for a repository that manages Baggage entities.
/// It specifies the core data access operations (CRUD) for the Baggage model
    public interface IBaggageRepo
    {
        void AddBaggage(Baggage baggage); // Adds a new baggage record to the underlying data store
        void DeleteBaggage(int BaggageId); //eletes a baggage record from the data store based on its unique ID
        IEnumerable<Baggage> GetAllBaggages();//Retrieves all baggage records from the data store
        Baggage GetBaggageById(int BaggageId); //Retrieves a single baggage record by its unique ID
        void UpdateBaggage(Baggage baggage);//Updates an existing baggage record in the data store.
    }
}