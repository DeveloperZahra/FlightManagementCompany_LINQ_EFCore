using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    //This interface defines the contract for a repository that manages Ticket entities.
    /// It specifies the core data access operations (CRUD) for the Ticket model
    public interface ITicketRepo
    {
        void AddTicket(Ticket ticket);// Adds a new ticket to the underlying data store
        void DeleteTicket(int TicketId);
        IEnumerable<Ticket> GetAllTickets();
        Ticket GetTicketById(int TicketId);
        void UpdateTicket(Ticket ticket);
    }
}