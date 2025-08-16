using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlightManagementCompany.Models;
using Microsoft.Extensions.Options;

namespace FlightManagementCompany_LINQ_EFCore
{
    // DbContext class responsible for interacting with the Flight Management database
    public class FlightDbContext : DbContext
    {
        // Constructor that accepts DbContextOptions (used for dependency injection)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-J26O8DP\\SQLEXPRESS01 ;Initial Catalog=FlightManagementDB;Integrated Security=True;TrustServerCertificate=True");
        }

        // DbSets represent tables in the database for each entity
        public DbSet<Aircraft> Aircrafts { get; set; }                // Table for Aircrafts
        public DbSet<AircraftMaintenance> AircraftMaintenances { get; set; } // Table for Aircraft Maintenances
        public DbSet<Airport> Airports { get; set; }                  // Table for Airports
        public DbSet<Baggage> Baggages { get; set; }                  // Table for Baggages
        public DbSet<Booking> booking { get; set; }                  // Table for Booking
        public DbSet<CrewMember> CrewMembers { get; set; }            // Table for Crew Members
        public DbSet<Flight> Flights { get; set; }                    // Table for Flights
        public DbSet<FlightCrew> FlightCrews { get; set; }            // Table for Flight Crew assignments
        public DbSet<Passenger> Passengers { get; set; }              // Table for Passengers
        public DbSet<Route> Routes { get; set; }                      // Table for Routes
        public DbSet<Ticket> Tickets { get; set; }                    // Table for Tickets

        // This method is used to configure entity relationships, constraints, and table mappings
       // It allows customization of how the entities map to the database schema
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Relationship: One Passenger -> Many Bookings
            modelBuilder.Entity<Booking>()
           .HasOne( b => b.Passenger)         // Booking is linked to one Passenger
            .WithMany( p => p.booking)        // Passenger can have many Bookings
           .HasForeignKey( b => b.PassengerId);


            // Relationship: One Flight -> Many Bookings
            modelBuilder.Entity<Booking>()
            .HasOne( b => b.Flights)            // Booking belongs to one Flight
            .WithMany( f => f.booking)        // Flight can have many Bookings
            .HasForeignKey( b => b.FlightId);

            // Relationship: One Booking -> Many Tickets
            modelBuilder.Entity<Ticket>()
              .HasOne(t => t.booking)           // Ticket belongs to one Booking
              .WithMany(b => b.Tickets)         // Booking can have many Tickets
              .HasForeignKey(t => t.BookingId);

            // Relationship: Many-to-Many (Flight ↔ CrewMember) via FlightCrew
            modelBuilder.Entity<FlightCrew>()
           .HasOne(fc => fc.Flight)          // FlightCrew refers to one Flight
           .WithMany(f => f.FlightCrews)     // Flight can have many FlightCrew records
           .HasForeignKey(fc => fc.FlightId);

            modelBuilder.Entity<FlightCrew>()
           .HasOne(fc => fc.CrewMember)      // FlightCrew refers to one CrewMember
           .WithMany(c => c.FlightCrews)     // CrewMember can be assigned to many Flights
           .HasForeignKey(fc => new { fc.FlightId, fc.CrewId }); // Composite PK to prevent duplicates

            // Relationship: Route -> Origin Airport
            modelBuilder.Entity<Route>()
            .HasOne(r => r.OriginAirport)     // Route starts from one Origin Airport
            .WithMany(a => a.DistenationAirport) // Airport can have many departing Routes
            .HasForeignKey(r => r.OriginAirportId)
            .OnDelete(DeleteBehavior.Restrict); // Prevents cascading delete issues




        }
    }
}
