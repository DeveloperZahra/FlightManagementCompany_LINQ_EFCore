using FlightManagementCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
    //This repository class handles all data access operations for the Booking entity.
/// It provides methods for performing CRUD operations on booking records.
    public class BookingRepo
    {
      //  A private, read-only field to hold the database context.
    // This context is the bridge between the application's models and the database.
        private readonly FlightDbContext _context;

        //Initializes a new instance of the BookingRepo class.
    /// This constructor is typically used by a dependency injection container.
        public BookingRepo(FlightDbContext context)
        {
            _context = context;
        }

        // Retrieve all bookings from the database
        public IEnumerable<Booking> GetAllBooking()
        {
            return _context.booking.ToList();
        }

        // Retrieve a single booking by ID
        public Booking GetById(int BookingId)
        {
            return _context.booking.Find(BookingId);
        }

        // Add a new booking to the database
        public void AddBooking(Booking booking)
        {
            _context.booking.Add(booking);
            _context.SaveChanges();
        }

        // Update an existing booking
        public void UpdateBooking(Booking booking)
        {
            _context.booking.Update(booking);
            _context.SaveChanges();
        }

        // Delete a booking by ID
        public void DeleteBooking(int BookingId)
        {
            var booking = _context.booking.Find(BookingId);
            if (booking != null)
            {
                _context.booking.Remove(booking);
                _context.SaveChanges();
            }
        }
    }
}
