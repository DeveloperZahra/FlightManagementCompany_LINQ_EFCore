using FlightManagementCompany.Models;
using FlightManagementCompany.Repository;
using FlightManagementCompany_LINQ_EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Service
{
    // Central service class that aggregates operations 
    /// across all repositories for Flight Management System.
    public class FlightManagementService
    {
        private readonly AirportRepo _airportRepo;
        private readonly RouteRepo _routeRepo;
        private readonly AircraftRepo _aircraftRepo;
        private readonly FlightRepo _flightRepo;
        private readonly PassengerRepo _passengerRepo;
        private readonly BookingRepo _bookingRepo;
        private readonly TicketRepo _ticketRepo;
        private readonly BaggageRepo _baggageRepo;
        private readonly CrewMemberRepo _crewRepo;
        private readonly FlightCrewRepo _flightCrewRepo;
        private readonly AircraftMaintenanceRepo _maintenanceRepo;

        // Inject all repositories through constructor dependency injection.
        public FlightManagementService(FlightDbContext context)
        {
            _airportRepo = new AirportRepo(context);
            _routeRepo = new RouteRepo(context);
            _aircraftRepo = new AircraftRepo(context);
            _flightRepo = new FlightRepo(context);
            _passengerRepo = new PassengerRepo(context);
            _bookingRepo = new BookingRepo(context);
            _ticketRepo = new TicketRepo(context);
            _baggageRepo = new BaggageRepo(context);
            _crewRepo = new CrewMemberRepo(context);
            _flightCrewRepo = new FlightCrewRepo(context);
            _maintenanceRepo = new AircraftMaintenanceRepo(context);


        }
        // ================= MENU OPERATIONS =================

        // Daily Flight Manifest: List all flights for a specific date 
        /// with assigned crew and passengers
        public void GetDailyManifest(DateTime date)
        {
            var flights = _flightRepo.GetAllFlights()
                .Where(f => f.DepartureUtc.Date == date.Date)
                .ToList();

            foreach (var flight in flights)
            {
                Console.WriteLine($"Flight {flight.FlightNumber} | {flight.DepartureUtc} -> {flight.ArrivalUtc}");

                var crew = _flightCrewRepo.GetAllFlightCrews()
                    .Where(fc => fc.FlightId == flight.FlightId)
                    .Select(fc => fc.CrewMember);

                Console.WriteLine("Crew Members:");
                foreach (var member in crew)
                {
                    Console.WriteLine($" - {member.M_F_Name} {member.M_L_Name}({member.Role})");
                }

                var passengers = _bookingRepo.GetAllBooking()
                    .Where(b => b.FlightId == flight.FlightId)
                    .Select(b => b.Passenger);

                Console.WriteLine("Passengers:");
                foreach (var passenger in passengers)
                {
                    Console.WriteLine($" - {passenger.P_F_Name} {passenger.P_L_Name}");
                }
                Console.WriteLine("-------------------------------------------------");
            }
        }
        // Frequent Fliers: List passengers who booked more than 2 flights.


        public void GetFrequentFliers()
        {
            var frequentFliers = _bookingRepo.GetAllBooking()
                .GroupBy(b => b.PassengerId)
                .Where(g => g.Count() > 2)
                .Select(g => g.First().Passenger);

            Console.WriteLine("Frequent Fliers (More than 2 bookings):");
            foreach (var passenger in frequentFliers)
            {
                Console.WriteLine($" - {passenger.P_F_Name} {passenger.P_L_Name}");
            }
        }

        // Baggage Summary: Show total baggage per flight
        public void GetBaggageSummary()
        {
            var baggageSummary = _baggageRepo.GetAllBaggages()
                .GroupBy(b => b.FlightId)
                .Select(g => new
                {
                    FlightId = g.Key,
                    TotalBags = g.Count(),
                    TotalWeight = g.Sum(b => b.WeightKg)
                });

            Console.WriteLine("Baggage Summary:");
            foreach (var item in baggageSummary)
            {
                Console.WriteLine($"Flight {item.FlightId}: {item.TotalBags} bags | {item.TotalWeight} kg");
            }
        }

        // Maintenance Alert: List aircrafts with maintenance in last 30 days
        public void GetMaintenanceAlerts()
        {
            var cutoffDate = DateTime.Now.AddDays(-30);

            var recentMaintenance = _maintenanceRepo.GetAllAircraftMaintenance()
                .Where(m => m.MaintenanceDate >= cutoffDate)
                .Select(m => new { m.Aircraft.TailNumber, m.MaintenanceDate, m.Type });

            Console.WriteLine("Recent Maintenance Alerts (last 30 days):");
            foreach (var item in recentMaintenance)
            {
                Console.WriteLine($"Aircraft {item.TailNumber} | {item.Type} | {item.MaintenanceDate}");
            }
        }
    }
    }
}
    

