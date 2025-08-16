using FlightManagementCompany.Models;
using FlightManagementCompany_LINQ_EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
    //This repository class handles all data access operations for the Booking entity.
    /// It provides methods for performing CRUD operations on booking records.
    public class BookingRepo : IBookingRepo
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

        // Retrieves all booking records from the database.
        public IEnumerable<Booking> GetAllBooking()
        {
            return _context.booking.ToList();  // Accesses the Bookings DbSet and retrieves all records, returning them as a list.
        }

        // Retrieves a single booking by its unique ID.
        public Booking GetById(int BookingId)
        {
            return _context.booking.Find(BookingId);// Uses the efficient Find() method to look up the booking by its primary key.
        }

        // Adds a new booking record to the database.
        public void AddBooking(Booking booking)
        {
            _context.booking.Add(booking);  // Adds the new entity to the context
            _context.SaveChanges();
        }

        // Updates an existing booking record in the database
        public void UpdateBooking(Booking booking)
        {
            _context.booking.Update(booking); // Marks the entity as updated.
            _context.SaveChanges();
        }

        // Deletes a booking record from the database by its ID.
        public void DeleteBooking(int BookingId)
        {
            var booking = _context.booking.Find(BookingId);//Finds the booking record by its ID
            if (booking != null) // Checks if the booking was found before attempting to delete it.
            {
                _context.booking.Remove(booking); // Removes the entity from the context.
                _context.SaveChanges();
            }
        }
    }
}
