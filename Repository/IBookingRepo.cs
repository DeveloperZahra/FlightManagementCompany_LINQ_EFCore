using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    // This interface defines the contract for a repository that manages Booking entities.
    /// It specifies the core data access operations (CRUD) for the Booking model.
    public interface IBookingRepo
    {
        void AddBooking(Booking booking);
        void DeleteBooking(int BookingId);
        IEnumerable<Booking> GetAllBooking();
        Booking GetById(int BookingId);
        void UpdateBooking(Booking booking);
    }
}