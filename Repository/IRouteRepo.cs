using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
   // This interface defines the contract for a repository that manages Route entities.
/// It specifies the core data access operations (CRUD) for the Route model.
    public interface IRouteRepo
    {
        void AddRoute(Route route);// Adds a new route to the underlying data store
        void DeleteRoute(int RouteId);
        IEnumerable<Route> GetAllRoutes();
        Route GetRouteById(int RouteId);
        void UpdateRoute(Route route);
    }
}