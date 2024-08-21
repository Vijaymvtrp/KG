using Microsoft.EntityFrameworkCore;
using H_M.Models;

namespace H_M.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public  DbSet<Rooms> Rooms { get; set; }
        public  DbSet<Bookings> Bookings { get; set; }

        public DbSet<RoomBookings> RoomBookings { get; set; }

        public DbSet<Reminders> Reminders { get; set; }

       public DbSet<Transactions> Transactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomBookings>()
                .HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
    }


}
