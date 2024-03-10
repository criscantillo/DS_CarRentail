using DS_CarRentail.Infrastructure.Database;

namespace DS_CarRentail.Services
{
    public interface ISearchCarService
    {
        Task<IEnumerable<LocationCar>> SearchCars(int locationOrigin, int locationDestination, DateTime from, DateTime to);
    }
}
