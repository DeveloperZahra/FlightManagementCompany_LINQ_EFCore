using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlightManagementCompany.Models;

namespace FlightManagementCompany_LINQ_EFCore
{
    // DbContext class responsible for interacting with the Flight Management database
    public class FlightDbContext : DbContext
    {
        // Constructor that accepts DbContextOptions (used for dependency injection)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-J26O8DP\\SQLEXPRESS01 ;Initial Catalog=FlightManagementDB;Integrated Security=True;TrustServerCertificate=True");
        }




    }
}
