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

            // Main menu loop
            while (true)
            {
                Console.WriteLine("\n==============================");
                Console.WriteLine("✈️  FLIGHT MANAGEMENT SYSTEM");
                Console.WriteLine("==============================");
                Console.WriteLine("1. List All Flights with Passengers");
                Console.WriteLine("2. Top Routes by Revenue");
                Console.WriteLine("3. On-Time Performance");
                Console.WriteLine("4. Seat Occupancy Heatmap");
                Console.WriteLine("5. Find Available Seats for a Flight");
                Console.WriteLine("6. Crew Scheduling Conflicts");
                Console.WriteLine("7. Passengers with Connections");
                Console.WriteLine("8. Frequent Fliers");
                Console.WriteLine("9. Maintenance Alerts");
                Console.WriteLine("10. Baggage Overweight Alerts");
                Console.WriteLine("11. Complex Set/Partitioning Examples");
                Console.WriteLine("12. Conversion Operators Demonstration");
                Console.WriteLine("13. Window-like Operations (Running Totals)");
                Console.WriteLine("14. Forecasting (Simple Example)");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                string? choice = Console.ReadLine();
            }
    }
}
