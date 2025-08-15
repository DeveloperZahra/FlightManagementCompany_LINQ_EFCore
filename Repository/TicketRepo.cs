using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
    //This repository class handles all data access operations for the Ticket entity.
    /// It provides a connection to the database context to perform these operations.
    public class TicketRepo
    {
        // A private, read-only field to hold the database context.
        // This is the bridge between the application's models and the database.
        private readonly FlightDbContext _context;

            public TicketRepo(FlightDbContext context)
            {
                _context = context;
            }







    }
}
