using System;
using Microsoft.EntityFrameworkCore;
using FlightManagementCompany.SeedData;
using FlightManagementCompany.Service; 
using FlightManagementCompany_LINQ_EFCore;
using FlightManagementCompany.Repository;
using System.Threading.Tasks;
namespace FlightManagementCompany_LINQ_EFCore
{
    // Entry point of the Flight Management System
    internal class Program
    {

        static async Task Main()
        {
            using var context = new FlightDbContext();
            context.Database.EnsureCreated();


            //await db.Database.EnsureDeletedAsync();

            await context.Database.MigrateAsync();

            // Initialize repositories
            IAirportRepo airportRepo = new AirportRepo(context);
            IRouteRepo routeRepo = new RouteRepo(context);
            IAircraftRepo aircraftRepo = new AircraftRepo(context);
            IFlightRepo flightRepo = new FlightRepo(context);
            IPassengerRepo passengerRepo = new PassengerRepo(context);
            IBookingRepo bookingRepo = new BookingRepo(context);
            ITicketRepo ticketRepo = new TicketRepo(context);
            IBaggageRepo baggageRepo = new BaggageRepo(context);
            ICrewMemberRepo crewRepo = new CrewMemberRepo(context);
            IFlightCrewRepo flightCrewRepo = new FlightCrewRepo(context);
            IAircraftMaintenanceRepo maintenanceRepo = new AircraftMaintenanceRepo(context);

            // Initialize service with all repositories
            var service = new FlightManagementService(
                airportRepo, routeRepo, aircraftRepo, flightRepo, passengerRepo,
                bookingRepo, ticketRepo, baggageRepo, crewRepo, flightCrewRepo, maintenanceRepo
            );
            bool exit = false;  // A boolean flag to control the main application loop.

            while (!exit)
            {
                Console.WriteLine("====================================");
                Console.WriteLine("   Flight Management System Menu");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Daily Flight Manifest");
                Console.WriteLine("2. Frequent Fliers");
                Console.WriteLine("3. Baggage Summary");
                Console.WriteLine("4. Maintenance Alerts");
                Console.WriteLine("5. Seat Availability Report");
                Console.WriteLine("6. Exit");
                Console.WriteLine("====================================");
                Console.Write("Enter your choice: ");

            }
        }
    }
}



