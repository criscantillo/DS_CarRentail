using Microsoft.EntityFrameworkCore;

namespace DS_CarRentail.Infrastructure.Database
{
    public class CarRentailContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationCar> LocationCars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public CarRentailContext(DbContextOptions<CarRentailContext> optons) : base(optons) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable(nameof(User));
            modelBuilder.Entity<Car>().ToTable(nameof(Car));
            modelBuilder.Entity<Company>().ToTable(nameof(Company));
            modelBuilder.Entity<Location>().ToTable(nameof(Location));
            modelBuilder.Entity<LocationCar>().ToTable(nameof(LocationCar));
            modelBuilder.Entity<Reservation>().ToTable(nameof(Reservation));
        }
    }
}
