using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface ITicketRepo
    {
        void AddTicket(Ticket ticket);
        void DeleteTicket(int TicketId);
        IEnumerable<Ticket> GetAllTickets();
        Ticket GetTicketById(int TicketId);
        void UpdateTicket(Ticket ticket);
    }
}