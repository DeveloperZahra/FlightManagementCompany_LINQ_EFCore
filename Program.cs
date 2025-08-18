using FlightManagementCompany_LINQ_EFCore;
using Microsoft.EntityFrameworkCore;

namespace FlightManagementCompany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Configure database context options
            var options = new DbContextOptionsBuilder<FlightDbContext>()
                .UseSqlServer("Data Source=.;Initial Catalog=FlightManagementDB;Integrated Security=True;TrustServerCertificate=True")
                .Options;

            using var context = new FlightDbContext(options);


            // Ensure database is created
            context.Database.EnsureCreated();

            // Initialize seed data if needed
            SeedData.Initialize(context);

            // Initialize service classes (Business Logic Layer)
            var flightService = new FlightService(context);
            var passengerService = new PassengerService(context);
            var crewService = new CrewService(context);
            var maintenanceService = new MaintenanceService(context);
            var baggageService = new BaggageService(context);
            var analysisService = new AnalysisService(context);
            var demoService = new DemoService(context);

        }
    }
}
