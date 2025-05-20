using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlightLibrary;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
       
    }

    public DbSet<Flight> Flight { get; set; }
    public DbSet<Passenger> Passenger { get; set; }
    public DbSet<Seat> Seat { get; set; }
}
