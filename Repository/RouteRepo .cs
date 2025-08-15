using FlightManagementCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
    //This repository class handles all data access operations for the Route entity.
/// It provides a connection to the database context to perform these operations
    public class RouteRepo
    {
        // A private, read-only field to hold the database context.
        // This is the bridge between the application's models and the database

        private readonly FlightDbContext _context;

        //Initializes a new instance of the RouteRepository class.
    /// This constructor receives the database context via dependency injection.
            public RouteRepo(FlightDbContext context)
            {
                _context = context;
            }

        // Retrieve all routes
        public IEnumerable<Route> GetAllRoutes()
        {
            return _context.Routes.ToList();
        }

        // Retrieve a route by ID
        public Route GetRouteById(int RouteId)
        {
            return _context.Routes.Find(RouteId);
        }

        // Add a new route
        public void AddRoute(Route route)
        {
            _context.Routes.Add(route);
            _context.SaveChanges();
        }

        // Update an existing route
        public void UpdateRoute(Route route)
        {
            _context.Routes.Update(route);
            _context.SaveChanges();
        }


    }
}
