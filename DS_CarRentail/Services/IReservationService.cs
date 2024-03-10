using DS_CarRentail.Application.Command;
using DS_CarRentail.Infrastructure.Database;

namespace DS_CarRentail.Services
{
    public interface IReservationService
    {
        Task<Reservation> ReserveCar(ReserveCarCommand reserveCarCommand);
    }
}
