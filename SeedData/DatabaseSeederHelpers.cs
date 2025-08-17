using System;
using System.Collections.Generic;
using System.Linq;
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
            IFlightRepo flightRepo,
            IPassengerRepo passengerRepo,
            IBookingRepo bookingRepo,
            ITicketRepo ticketRepo,
            IBaggageRepo baggageRepo,
            ICrewMemberRepo crewRepo,
            IFlightCrewRepo flightCrewRepo,
            IAircraftMaintenanceRepo maintenanceRepo
        )
        {




        }
    }
}