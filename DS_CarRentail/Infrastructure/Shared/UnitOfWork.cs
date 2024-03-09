using DS_CarRentail.Infrastructure.Database;

namespace DS_CarRentail.Infrastructure.Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarRentailContext _context;
        private readonly IRepository<Car> _carRepository;
        private readonly IRepository<Location> _locationRepository;
        private readonly IRepository<LocationCar> _locationCarRepository;
        private readonly IRepository<Reservation> _reservationRepository;

        public IRepository<Car> Cars => _carRepository;
        public IRepository<Location> Locations => _locationRepository;
        public IRepository<LocationCar> LocationCars => _locationCarRepository;
        public IRepository<Reservation> Reservations => _reservationRepository;

        public UnitOfWork(CarRentailContext context)
        {
            _context = context;
            _carRepository = new Repository<Car>(context);
            _locationRepository = new Repository<Location>(context);
            _locationCarRepository = new Repository<LocationCar>(context);
            _reservationRepository = new Repository<Reservation>(context);
        }

        public async Task<int> Save()
        {
            int result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
