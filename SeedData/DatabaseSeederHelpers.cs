using System;
using System.Collections.Generic;
using System.Linq;
using FlightManagementCompany.Models;
using FlightManagementCompany.Repository;
using FlightManagementCompany_LINQ_EFCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static FlightManagementCompany.Models.CrewMember;

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
            IAircraftMaintenanceRepo maintenanceRepo) //The repository for managing AircraftMaintenance entities, Flight flight)
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

            // ===== PASSENGERS =====
            if (!passengerRepo.GetAllPassengers().Any())
            {
                var passengers = new List<Passenger>
                {
                    new Passenger { P_F_Name = "Fatema",  P_L_Name= "Hamed",   PassportNo = "A1234567", Nationality = "Omani",      DOB = new DateOnly(2000,5,20) },
                    new Passenger { P_F_Name = "John",    P_L_Name ="Smith",   PassportNo = "B7654321", Nationality = "British",    DOB = new DateOnly(1995,3,10) },
                    new Passenger { P_F_Name = "Emma",    P_L_Name ="Johnson", PassportNo = "C1112233", Nationality = "American",   DOB = new DateOnly(1990,8,15) },
                    new Passenger { P_F_Name = "Ali",     P_L_Name="Khan",     PassportNo = "D2223344", Nationality = "Pakistani",  DOB = new DateOnly(1985,1,5)  },
                    new Passenger { P_F_Name = "Sophia",  P_L_Name ="Lee",     PassportNo = "E3334455", Nationality = "Singaporean",DOB = new DateOnly(1998,7,12) },
                    new Passenger { P_F_Name = "Carlos",  P_L_Name="Garcia",   PassportNo = "F4445566", Nationality = "Spanish",    DOB = new DateOnly(1987,2,23) },
                    new Passenger { P_F_Name = "Fatima",  P_L_Name="Alsaaidi", PassportNo = "G5556677", Nationality = "Moroccan",   DOB = new DateOnly(1993,11,30)},
                    new Passenger { P_F_Name = "David",   P_L_Name="Brown",    PassportNo = "H6667788", Nationality = "Canadian",   DOB = new DateOnly(1980,4,2)  },
                    new Passenger { P_F_Name = "Maria",   P_L_Name ="Rossi",   PassportNo = "I7778899", Nationality = "Italian",    DOB = new DateOnly(1992,9,19) },
                    new Passenger { P_F_Name = "Chen",    P_L_Name="Wei",      PassportNo = "J8889900", Nationality = "Chinese",    DOB = new DateOnly(1996,12,25)}
                };
                foreach (var p in passengers) passengerRepo.Addpassenger(p);
                db.SaveChanges();
            }

            // ===== BOOKINGS =====
            if (!bookingRepo.GetAllBooking().Any())
            {
                var bookings = new List<Booking>
                {
                    new Booking { FlightId = 1, PassengerId = 1, BookingDate = DateTime.Now, Status = "Confirmed" },
                    new Booking { FlightId = 2, PassengerId = 2, BookingDate = DateTime.Now, Status = "Confirmed" },
                    new Booking { FlightId = 3, PassengerId = 3, BookingDate = DateTime.Now, Status = "Confirmed" },
                    new Booking { FlightId = 4, PassengerId = 4, BookingDate = DateTime.Now, Status = "Confirmed" },
                    new Booking { FlightId = 5, PassengerId = 5, BookingDate = DateTime.Now, Status = "Confirmed" },
                    new Booking { FlightId = 6, PassengerId = 6, BookingDate = DateTime.Now, Status = "Confirmed" },
                    new Booking { FlightId = 7, PassengerId = 7, BookingDate = DateTime.Now, Status = "Confirmed" },
                    new Booking { FlightId = 8, PassengerId = 8, BookingDate = DateTime.Now, Status = "Confirmed" },
                    new Booking { FlightId = 9, PassengerId = 9, BookingDate = DateTime.Now, Status = "Confirmed" },
                    new Booking { FlightId = 10, PassengerId = 10, BookingDate = DateTime.Now, Status = "Confirmed" }
                };
                foreach (var b in bookings) bookingRepo.AddBooking(b);
                db.SaveChanges();
            }

            // ===== TICKETS =====
            if (!ticketRepo.GetAllTickets().Any())
            {
                var booking = db.booking.ToList();
                var flights = db.Flights.ToList();

                var tickets = new List<Ticket>
                {
                    new Ticket { SeatNumber = "12A", Fare = 150m, CheckedIn = false, BookingId = booking[0].BookingId, FlightId = flights[0].FlightId },
                    new Ticket { SeatNumber = "14B", Fare = 200m, CheckedIn = true, BookingId = booking[1].BookingId, FlightId = flights[1].FlightId },
                    new Ticket { SeatNumber = "15B", Fare = 300m, CheckedIn = false, BookingId = booking[2].BookingId, FlightId = flights[2].FlightId },
                    new Ticket { SeatNumber = "16D", Fare = 180m, CheckedIn = false, BookingId = booking[3].BookingId, FlightId = flights[3].FlightId },
                    new Ticket { SeatNumber = "17A", Fare = 220m, CheckedIn = true, BookingId = booking[4].BookingId, FlightId = flights[4].FlightId },
                    new Ticket { SeatNumber = "18B", Fare = 270m, CheckedIn = false, BookingId = booking[5].BookingId, FlightId = flights[5].FlightId },
                    new Ticket { SeatNumber = "19C", Fare = 190m, CheckedIn = true, BookingId = booking[6].BookingId, FlightId = flights[6].FlightId },
                    new Ticket { SeatNumber = "20D", Fare = 250m, CheckedIn = false, BookingId = booking[7].BookingId, FlightId = flights[7].FlightId },
                    new Ticket { SeatNumber = "20A", Fare = 230m, CheckedIn = false, BookingId = booking[8].BookingId, FlightId = flights[8].FlightId },
                    new Ticket { SeatNumber = "22B", Fare = 300m, CheckedIn = true, BookingId = booking[9].BookingId, FlightId = flights[9].FlightId }
                };
            }


            // ===== BAGGAGE =====
            if (!baggageRepo.GetAllBaggages().Any())
            {
                var tickets = db.Tickets.ToList();
                var baggages = new List<Baggage>
                {
                    new Baggage { TicketId = tickets[0].TicketId, WeightKg = 20.5m, TagNumber = "BG001" },
                    new Baggage { TicketId = tickets[1].TicketId, WeightKg = 18.0m, TagNumber = "BG002" },
                    new Baggage { TicketId = tickets[2].TicketId, WeightKg = 22.3m, TagNumber = "BG003" },
                    new Baggage { TicketId = tickets[3].TicketId, WeightKg = 19.0m, TagNumber = "BG004" },
                    new Baggage { TicketId = tickets[4].TicketId, WeightKg = 23.5m, TagNumber = "BG005" },
                    new Baggage { TicketId = tickets[5].TicketId, WeightKg = 21.2m, TagNumber = "BG006" },
                    new Baggage { TicketId = tickets[6].TicketId, WeightKg = 20.0m, TagNumber = "BG007" },
                    new Baggage { TicketId = tickets[7].TicketId, WeightKg = 24.0m, TagNumber = "BG008" },
                    new Baggage { TicketId = tickets[8].TicketId, WeightKg = 22.5m, TagNumber = "BG009" },
                    new Baggage { TicketId = tickets[9].TicketId, WeightKg = 19.8m, TagNumber = "BG010" }
                };
            }


            // ===== CREW MEMBERS =====
            if (!crewRepo.GetAllCrewMembers().Any())
            {
                var crew = new List<CrewMember>
                {
                    new CrewMember { M_F_Name = "Captain Ali" , M_L_Name = "Al-Hinai",Role = CrewRole.Pilot,  LicenseNo = "123" },
                    new CrewMember { M_F_Name = "Captain Said", M_L_Name =  "Al-Balushi", Role = CrewRole.CoPilot,  LicenseNo = "123" },
                    new CrewMember { M_F_Name = "First Officer Khalid" , M_L_Name =  "Al-Riyami",  Role = CrewRole.FlightAttendant, LicenseNo = "123" },
                    new CrewMember { M_F_Name = "First Officer Yousuf", M_L_Name = "Al-Kindi", Role = CrewRole.FlightAttendant, LicenseNo = "123" },
                    new CrewMember { M_F_Name = "Layla" , M_L_Name = "Al-Maskari", Role = CrewRole.FlightAttendant, LicenseNo = "123" },
                    new CrewMember { M_F_Name = "Aisha" , M_L_Name = "Al-Zadjali", Role = CrewRole.FlightAttendant , LicenseNo= "123"},
                    new CrewMember { M_F_Name = "Huda" , M_L_Name =  " Al-Lawati", Role = CrewRole.FlightAttendant, LicenseNo="123" },
                    new CrewMember { M_F_Name = "Fatma" , M_L_Name = "Al-Harthi", Role = CrewRole.FlightAttendant, LicenseNo="123" },
                    new CrewMember { M_F_Name = "Omar" , M_L_Name = "Al-Maamari", Role = CrewRole.CoPilot, LicenseNo="123" },
                    new CrewMember { M_F_Name = "Salim" , M_L_Name =" Al-Siyabi", Role = CrewRole.Pilot, LicenseNo= "123" }
                };
                foreach (var c in crew) crewRepo.AddCrewMember(c);
                db.SaveChanges();
            }


            //===== FLIGHT CREW(Assignments) =====
            if (!flightCrewRepo.GetAllFlightCrews().Any())
            {
                var flights = db.Flights.ToList();
                var crew = db.CrewMembers.ToList();
                var flightCrews = new List<FlightCrew>
                {
                    new FlightCrew { FlightId = flights[0].FlightId, CrewId = crew[0].CrewId, RoleOnFlight = "Pilot" },
                    new FlightCrew { FlightId = flights[0].FlightId, CrewId = crew[1].CrewId, RoleOnFlight = "CoPilot" },
                    new FlightCrew { FlightId = flights[0].FlightId, CrewId = crew[2].CrewId, RoleOnFlight = "FlightAttendant" },
                    new FlightCrew { FlightId = flights[1].FlightId, CrewId = crew[3].CrewId, RoleOnFlight = "FlightAttendant" },
                    new FlightCrew { FlightId = flights[1].FlightId, CrewId = crew[4].CrewId, RoleOnFlight = "FlightAttendant" },
                    new FlightCrew { FlightId = flights[2].FlightId, CrewId = crew[5].CrewId, RoleOnFlight = "FlightAttendant" },
                    new FlightCrew { FlightId = flights[2].FlightId, CrewId = crew[6].CrewId, RoleOnFlight = "CoPilot" },
                    new FlightCrew { FlightId = flights[3].FlightId, CrewId = crew[7].CrewId, RoleOnFlight = "Pilot" },
                    new FlightCrew { FlightId = flights[4].FlightId, CrewId = crew[8].CrewId, RoleOnFlight = "FlightAttendant" },
                    new FlightCrew { FlightId = flights[5].FlightId, CrewId = crew[9].CrewId, RoleOnFlight = "FlightAttendant" }
                };
                foreach (var fc in flightCrews) flightCrewRepo.AddFlightCrew(fc);
                db.SaveChanges();
            }


            // ===== AIRCRAFT MAINTENANCE =====
            if (!maintenanceRepo.GetAllAircraftMaintenance().Any())
            {
                var aircrafts = db.Aircrafts.ToList();
                var maintenances = new List<AircraftMaintenance>
                {
                    new AircraftMaintenance { AircraftId = aircrafts[0].AircraftId, MaintenanceDate = DateTime.UtcNow.AddDays(-30), Type = "Engine check",              Notes = "Good" },
                    new AircraftMaintenance { AircraftId = aircrafts[1].AircraftId, MaintenanceDate = DateTime.UtcNow.AddDays(-15), Type = "Landing gear inspection",   Notes = "Good" },
                    new AircraftMaintenance { AircraftId = aircrafts[2].AircraftId, MaintenanceDate = DateTime.UtcNow.AddDays(-10), Type = "Avionics software update",  Notes = "Good" },
                    new AircraftMaintenance { AircraftId = aircrafts[3].AircraftId, MaintenanceDate = DateTime.UtcNow.AddDays(-5),  Type = "Cabin pressure test",       Notes = "Good" },
                    new AircraftMaintenance { AircraftId = aircrafts[4].AircraftId, MaintenanceDate = DateTime.UtcNow.AddDays(-25), Type = "Hydraulic system check",    Notes = "Good" },
                    new AircraftMaintenance { AircraftId = aircrafts[5].AircraftId, MaintenanceDate = DateTime.UtcNow.AddDays(-20), Type = "Fuel system inspection",    Notes = "Good" },
                    new AircraftMaintenance { AircraftId = aircrafts[6].AircraftId, MaintenanceDate = DateTime.UtcNow.AddDays(-18), Type = "Engine oil replacement",    Notes = "Good" },
                    new AircraftMaintenance { AircraftId = aircrafts[7].AircraftId, MaintenanceDate = DateTime.UtcNow.AddDays(-12), Type = "Flight control calibration",Notes = "Good" },
                    new AircraftMaintenance { AircraftId = aircrafts[8].AircraftId, MaintenanceDate = DateTime.UtcNow.AddDays(-8),  Type = "Propeller inspection",      Notes = "Good" },
                    new AircraftMaintenance { AircraftId = aircrafts[9].AircraftId, MaintenanceDate = DateTime.UtcNow.AddDays(-3),  Type = "Emergency exit check",      Notes = "Good" }
                };
                foreach (var m in maintenances) maintenanceRepo.AddAircraftMaintenance(m);
                db.SaveChanges();
            }


        } 



    
    
    }
}