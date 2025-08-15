using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    //This interface defines the contract for a repository that manages Ticket entities.
    /// It specifies the core data access operations (CRUD) for the Ticket model
    public interface ITicketRepo
    {
        void AddTicket(Ticket ticket);// Adds a new ticket to the underlying data store
        void DeleteTicket(int TicketId);//Deletes a ticket from the data store based on its unique ID
        IEnumerable<Ticket> GetAllTickets();//Retrieves all tickets from the data store
        Ticket GetTicketById(int TicketId);// Retrieves a single ticket by its unique ID.
        void UpdateTicket(Ticket ticket);//Updates an existing ticket record in the data store
    }
}