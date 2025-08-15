using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface IRouteRepo
    {
        void AddRoute(Route route);
        void DeleteRoute(int RouteId);
        IEnumerable<Route> GetAllRoutes();
        Route GetRouteById(int RouteId);
        void UpdateRoute(Route route);
    }
}