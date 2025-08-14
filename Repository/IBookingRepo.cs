using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    // This interface defines the contract for a repository that manages Booking entities.
    /// It specifies the core data access operations (CRUD) for the Booking model.
    public interface IBookingRepo
    {
        void AddBooking(Booking booking); //Adds a new booking to the underlying data store.
        void DeleteBooking(int BookingId); //Deletes a booking from the data store based on its unique ID.
        IEnumerable<Booking> GetAllBooking();
        Booking GetById(int BookingId);
        void UpdateBooking(Booking booking);
    }
}