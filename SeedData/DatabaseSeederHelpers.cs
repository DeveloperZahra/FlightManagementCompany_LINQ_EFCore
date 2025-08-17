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


            // ===== ROUTES =====
            if (!routeRepo.GetAllRoutes().Any())
            {
                var routes = new List<Route>
                {
                    new Route { OriginAirportId = 1, DestinationAirportId = 2, DistanceKm = 870 },   // Muscat -> Salalah
                    new Route { OriginAirportId = 1, DestinationAirportId = 3, DistanceKm = 220 },   // Muscat -> Sohar
                    new Route { OriginAirportId = 1, DestinationAirportId = 4, DistanceKm = 550 },   // Muscat -> Duqm
                    new Route { OriginAirportId = 1, DestinationAirportId = 6, DistanceKm = 340 },   // Muscat -> Dubai
                    new Route { OriginAirportId = 1, DestinationAirportId = 7, DistanceKm = 730 },   // Muscat -> Doha
                    new Route { OriginAirportId = 1, DestinationAirportId = 8, DistanceKm = 1800 },  // Muscat -> Jeddah
                    new Route { OriginAirportId = 1, DestinationAirportId = 9, DistanceKm = 2500 },  // Muscat -> Cairo
                    new Route { OriginAirportId = 1, DestinationAirportId = 10,DistanceKm = 3800 }, // Muscat -> Bangkok
                    new Route { OriginAirportId = 2, DestinationAirportId = 6, DistanceKm = 950 },   // Salalah -> Dubai
                    new Route { OriginAirportId = 3, DestinationAirportId = 7, DistanceKm = 1100 }   // Sohar -> Doha
                };
                foreach (var r in routes) routeRepo.AddRoute(r);
                db.SaveChanges();
            }


        }
    }
}