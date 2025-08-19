using FlightManagementCompany.Repository;
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
        private readonly IAirportRepo _airportRepo;
        private readonly IRouteRepo _routeRepo;
        private readonly IAircraftRepo _aircraftRepo;
        private readonly IFlightRepo _flightRepo;
        private readonly IPassengerRepo _passengerRepo;
        private readonly IBookingRepo _bookingRepo;
        private readonly ITicketRepo _ticketRepo;
        private readonly IBaggageRepo _baggageRepo;
        private readonly ICrewMemberRepo _crewRepo;
        private readonly IFlightCrewRepo _flightCrewRepo;
        private readonly IAircraftMaintenanceRepo _maintenanceRepo;
    }
}
