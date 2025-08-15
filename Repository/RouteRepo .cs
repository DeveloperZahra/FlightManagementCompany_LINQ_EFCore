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
        
            private readonly FlightDbContext _context;

            public RouteRepo(FlightDbContext context)
            {
                _context = context;
            }


    }
}
