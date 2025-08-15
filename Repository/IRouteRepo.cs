using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
   // This interface defines the contract for a repository that manages Route entities.
/// It specifies the core data access operations (CRUD) for the Route model.
    public interface IRouteRepo
    {
        void AddRoute(Route route);// Adds a new route to the underlying data store
        void DeleteRoute(int RouteId);//Deletes a route from the data store based on its unique ID
        IEnumerable<Route> GetAllRoutes();//Retrieves all routes from the data store
        Route GetRouteById(int RouteId);//Retrieves a single route by its unique ID
        void UpdateRoute(Route route);
    }
}