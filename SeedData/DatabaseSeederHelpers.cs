using System;
using System.Collections.Generic;
using System.Linq;
using FlightManagementCompany.Models;
using FlightManagementCompany.Repository;
using FlightManagementCompany_LINQ_EFCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlightManagementCompany.SeedData
{
   // A static helper class responsible for seeding the database with initial sample data.
/// This class orchestrates the creation of all entities, ensuring referential integrity.
    public static class DatabaseSeederHelpers
    {

        // Creates a complete set of sample data for the Flight Management System.
        /// This method uses the repository pattern to interact with each database entity.
        public static void CreateSampleData(
            FlightDbContext db, //The primary database context, used for overall management (e.g., saving changes)
            IAirportRepo airportRepo, //The repository for managing Airport entities
            IRouteRepo routeRepo, //The repository for managing Route entities
            IAircraftRepo aircraftRepo,//The repository for managing Aircraft entities
            IFlightRepo flightRepo, //The repository for managing Flight entities
            IPassengerRepo passengerRepo,//The repository for managing Passenger entities
            IBookingRepo bookingRepo, //The repository for managing Booking entities
            ITicketRepo ticketRepo, //The repository for managing Ticket entities
            IBaggageRepo baggageRepo,//The repository for managing Baggage entities
            ICrewMemberRepo crewRepo,//The repository for managing CrewMember entities
            IFlightCrewRepo flightCrewRepo, //The repository for managing FlightCrew (the join table) entities
            IAircraftMaintenanceRepo maintenanceRepo//The repository for managing AircraftMaintenance entities
        )
        {

            // ===== AIRPORTS =====
            if (!airportRepo.GetAllAirports().Any())
            {
                var airports = new List<Airport>
                {
                    new Airport { IATA = "MCT", AirportName = "Muscat Intl", City = "Muscat", Country = "Oman", TimeZone = "Asia/Muscat" },
                    new Airport { IATA = "SLL", AirportName = "Salalah Intl", City = "Salalah", Country = "Oman", TimeZone = "Asia/Muscat" },
                    new Airport { IATA = "OHS", AirportName = "Sohar Airport", City = "Sohar", Country = "Oman", TimeZone = "Asia/Muscat" },
                    new Airport { IATA = "DQM", AirportName = "Duqm Intl", City = "Duqm", Country = "Oman", TimeZone = "Asia/Muscat" },
                    new Airport { IATA = "KHS", AirportName = "Khasab Airport", City = "Khasab", Country = "Oman", TimeZone = "Asia/Muscat" },
                    new Airport { IATA = "DXB", AirportName = "Dubai Intl", City = "Dubai", Country = "UAE", TimeZone = "Asia/Dubai" },
                    new Airport { IATA = "DOH", AirportName = "Hamad Intl", City = "Doha", Country = "Qatar", TimeZone = "Asia/Qatar" },
                    new Airport { IATA = "JED", AirportName = "King Abdulaziz Intl", City = "Jeddah", Country = "Saudi Arabia", TimeZone = "Asia/Riyadh" },
                    new Airport { IATA = "CAI", AirportName = "Cairo Intl", City = "Cairo", Country = "Egypt", TimeZone = "Africa/Cairo" },
                    new Airport { IATA = "BKK", AirportName = "Suvarnabhumi Airport", City = "Bangkok", Country = "Thailand", TimeZone = "Asia/Bangkok" }
                };
                foreach (var a in airports) airportRepo.AddAirport(a);
                db.SaveChanges();
            }


        }
    }
}