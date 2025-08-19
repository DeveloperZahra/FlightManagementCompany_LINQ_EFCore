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

           // ======================= AIRPORTS =======================
        public IEnumerable<Airport> GetAllAirports()
        {
            return _airportRepo.GetAllAirports();
        }

        // ======================= ROUTES ========================
        public IEnumerable<Route> GetAllRoutes()
        {
            return _routeRepo.GetAllRoutes();
        }

        // ======================= AIRCRAFTS =====================
        public IEnumerable<Aircraft> GetAllAircrafts()
        {
            return _aircraftRepo.GetAllAircraft();
        }

    }
}
    

