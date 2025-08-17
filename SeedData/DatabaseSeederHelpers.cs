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


            // ===== AIRCRAFT =====
            if (!aircraftRepo.GetAllAircraft().Any())
            {
                var aircrafts = new List<Aircraft>
                {
                    new Aircraft { Model = "Boeing 737", Capacity = 180,     TailNumber = "A4O-BA" },
                    new Aircraft { Model = "Airbus A320", Capacity = 150,    TailNumber = "A4O-BB" },
                    new Aircraft { Model = "Boeing 787", Capacity = 260,     TailNumber = "A4O-BC" },
                    new Aircraft { Model = "Airbus A330", Capacity = 270,    TailNumber = "A4O-BD" },
                    new Aircraft { Model = "Embraer E175", Capacity = 80,    TailNumber = "A4O-BE" },
                    new Aircraft { Model = "Boeing 737 MAX", Capacity = 190, TailNumber = "A4O-BF" },
                    new Aircraft { Model = "Airbus A321", Capacity = 200,    TailNumber = "A4O-BG" },
                    new Aircraft { Model = "ATR 72", Capacity = 70,          TailNumber = "A4O-BH" },
                    new Aircraft { Model = "Bombardier Q400", Capacity = 76, TailNumber = "A4O-BI" },
                    new Aircraft { Model = "Boeing 777", Capacity = 320,     TailNumber = "A4O-BJ" }
                };
                foreach (var ac in aircrafts) aircraftRepo.AddAircraft(ac);
                db.SaveChanges();
            }


            // ===== FLIGHTS =====
            if (!flightRepo.GetAllFlights().Any())
            {
                var flights = new List<Flight>
                {
                    new Flight { RouteId = 1, AircraftId = 1, DepartureUtc = DateTime.Now.AddHours(2), ArrivalUtc = DateTime.Now.AddHours(4), Status = "Scheduled" },
                    new Flight { RouteId = 2, AircraftId = 2, DepartureUtc = DateTime.Now.AddHours(3), ArrivalUtc = DateTime.Now.AddHours(5), Status = "Scheduled" },
                    new Flight { RouteId = 3, AircraftId = 3, DepartureUtc = DateTime.Now.AddHours(4), ArrivalUtc = DateTime.Now.AddHours(6), Status = "Scheduled" },
                    new Flight { RouteId = 4, AircraftId = 4, DepartureUtc = DateTime.Now.AddHours(5), ArrivalUtc = DateTime.Now.AddHours(7), Status = "Scheduled" },
                    new Flight { RouteId = 5, AircraftId = 5, DepartureUtc = DateTime.Now.AddHours(6), ArrivalUtc = DateTime.Now.AddHours(8), Status = "Scheduled" },
                    new Flight { RouteId = 6, AircraftId = 6, DepartureUtc = DateTime.Now.AddHours(7), ArrivalUtc = DateTime.Now.AddHours(9), Status = "Scheduled" },
                    new Flight { RouteId = 7, AircraftId = 7, DepartureUtc = DateTime.Now.AddHours(8), ArrivalUtc = DateTime.Now.AddHours(10), Status = "Scheduled" },
                    new Flight { RouteId = 8, AircraftId = 8, DepartureUtc = DateTime.Now.AddHours(9), ArrivalUtc = DateTime.Now.AddHours(12), Status = "Scheduled" },
                    new Flight { RouteId = 9, AircraftId = 9, DepartureUtc = DateTime.Now.AddHours(10),ArrivalUtc = DateTime.Now.AddHours(13), Status = "Scheduled" },
                    new Flight { RouteId = 10,AircraftId =10, DepartureUtc = DateTime.Now.AddHours(11),ArrivalUtc = DateTime.Now.AddHours(14), Status = "Scheduled" }
                };      
                foreach (var f in flights) flightRepo.AddFlight(f);
                db.SaveChanges();
            }




        }
    }
}