using System;
using Microsoft.EntityFrameworkCore;
using FlightManagementCompany.SeedData;
using FlightManagementCompany.Services;

namespace FlightManagementCompany_LINQ_EFCore;
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

            // Reads user input from the console to determine the desired action.
            // The '?' after 'string' indicates that the variable can be null.
            string? choice = Console.ReadLine();

            // A switch statement is used to execute different blocks of code
            // based on the user's input ('choice').
            switch (choice)
                {
                    case "1": // Case "1": Demonstrates how to retrieve all flights along with their passengers.
                    Console.WriteLine("\n=== All Flights with Passengers ===");
                        var flights = flightService.GetAllFlightsWithPassengers();
                        foreach (var f in flights)
                        {
                            Console.WriteLine($"Flight {f.FlightNumber} from {f.Origin} to {f.Destination}");
                            Console.WriteLine("Passengers: " + string.Join(", ", f.PassengerNames));
                        }
                        break;

                    case "2":
                        Console.WriteLine("\n=== Top Routes by Revenue ===");
                        var topRoutes = flightService.GetTopRoutesByRevenue(5);
                        foreach (var route in topRoutes)
                        {
                            Console.WriteLine($"Route: {route.Origin} -> {route.Destination}, Revenue: {route.TotalRevenue:C}");
                        }
                        break;

                    case "3":
                        Console.WriteLine("\n=== On-Time Performance ===");
                        var perf = flightService.GetOnTimePerformance();
                        foreach (var p in perf)
                        {
                            Console.WriteLine($"Flight {p.FlightNumber} | Departed: {p.DepartureStatus} | Arrived: {p.ArrivalStatus}");
                        }
                        break;

                    case "4":
                        Console.WriteLine("\n=== Seat Occupancy Heatmap ===");
                        var occupancy = flightService.GetSeatOccupancyHeatmap();
                        foreach (var o in occupancy)
                        {
                            Console.WriteLine($"Flight {o.FlightNumber} | Occupied: {o.OccupiedSeats}/{o.TotalSeats}");
                        }
                        break;

                    case "5":
                        Console.WriteLine("\nEnter Flight Number to check available seats:");
                        string? flightNo = Console.ReadLine();
                        var seats = flightService.GetAvailableSeats(flightNo);
                        Console.WriteLine($"Available seats for {flightNo}: {string.Join(", ", seats)}");
                        break;

                    case "6":
                        Console.WriteLine("\n=== Crew Scheduling Conflicts ===");
                        var conflicts = crewService.FindSchedulingConflicts();
                        if (conflicts.Count == 0) Console.WriteLine("No conflicts found.");
                        else
                        {
                            foreach (var c in conflicts)
                            {
                                Console.WriteLine($"Crew {c.CrewName} has overlapping flights {c.FlightNumber1} and {c.FlightNumber2}");
                            }
                        }
                        break;

                    case "7":
                        Console.WriteLine("\n=== Passengers with Connections ===");
                        var connectingPassengers = passengerService.GetPassengersWithConnections();
                        foreach (var p in connectingPassengers)
                        {
                            Console.WriteLine($"{p.Name} has connecting flights: {string.Join(", ", p.Flights)}");
                        }
                        break;

                    case "8":
                        Console.WriteLine("\n=== Frequent Fliers ===");
                        var frequentFliers = passengerService.GetFrequentFliers(10);
                        foreach (var ff in frequentFliers)
                        {
                            Console.WriteLine($"{ff.Name} | Flights Taken: {ff.FlightCount}");
                        }
                        break;

                    case "9":
                        Console.WriteLine("\n=== Maintenance Alerts ===");
                        var alerts = maintenanceService.GetMaintenanceAlerts();
                        foreach (var a in alerts)
                        {
                            Console.WriteLine($"Aircraft {a.AircraftTail} requires {a.AlertType} (Last Check: {a.LastCheck:yyyy-MM-dd})");
                        }
                        break;

                    case "10":
                        Console.WriteLine("\n=== Baggage Overweight Alerts ===");
                        var overweight = baggageService.GetOverweightAlerts();
                        foreach (var b in overweight)
                        {
                            Console.WriteLine($"Passenger {b.PassengerName}, Flight {b.FlightNumber}, Baggage {b.Weight}kg (Over limit!)");
                        }
                        break;

                    case "11":
                        Console.WriteLine("\n=== Complex Set/Partitioning Examples ===");
                        var partitions = analysisService.RunComplexSetExamples();
                        foreach (var part in partitions)
                        {
                            Console.WriteLine(part);
                        }
                        break;

                    case "12":
                        Console.WriteLine("\n=== Conversion Operators Demonstration ===");
                        var conversions = demoService.RunConversionDemo();
                        foreach (var conv in conversions)
                        {
                            Console.WriteLine(conv);
                        }
                        break;

                    case "13":
                        Console.WriteLine("\n=== Window-like Operation (Running Totals) ===");
                        var totals = analysisService.GetRunningTotals();
                        foreach (var t in totals)
                        {
                            Console.WriteLine($"Date: {t.Date:yyyy-MM-dd}, Running Total Revenue: {t.RunningTotal:C}");
                        }
                        break;

                    case "14":
                        Console.WriteLine("\n=== Forecasting (Simple) ===");
                        var forecast = analysisService.GetSimpleForecast();
                        foreach (var f in forecast)
                        {
                            Console.WriteLine($"Month: {f.Month}, Predicted Flights: {f.PredictedFlights}, Predicted Revenue: {f.PredictedRevenue:C}");
                        }
                        break;

                    case "0":
                        Console.WriteLine("Exiting... Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }

        }
    }


