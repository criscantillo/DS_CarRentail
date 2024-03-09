using DS_CarRentail.Infrastructure.Database;

namespace DS_CarRentail.Infrastructure.Shared
{
    public interface IUnitOfWork
    {
        public IRepository<Car> Cars { get; }
        public IRepository<Location> Locations { get; }
        public IRepository<LocationCar> LocationCars { get; }
        public IRepository<Reservation> Reservations { get; }
        public Task<int> Save();
    }
}
