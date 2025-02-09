using Hotel_Reservation_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation_API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {


    }
    public DbSet<Reservation> Reservations { get; set; }
}


