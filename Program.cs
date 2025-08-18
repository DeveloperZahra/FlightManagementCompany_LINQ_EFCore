using FlightManagementCompany_LINQ_EFCore;
using Microsoft.EntityFrameworkCore;

namespace FlightManagementCompany
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
        }
    }
}
