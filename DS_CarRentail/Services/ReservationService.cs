using AutoMapper;
using DS_CarRentail.Application.Command;
using DS_CarRentail.Infrastructure.Database;
using DS_CarRentail.Infrastructure.Shared;

namespace DS_CarRentail.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReservationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Reservation> ReserveCar(ReserveCarCommand reserveCarCommand)
        {
            LocationCar? locationCar = 
                await _unitOfWork.LocationCars.Get(reserveCarCommand.LocationCarId);

            if(locationCar is not null)
            {
                var diffOfDates = reserveCarCommand.To - reserveCarCommand.From;
                decimal totalPrice = locationCar.CarPriceForDay * diffOfDates.Days;

                Reservation reservation = _mapper.Map<Reservation>(reserveCarCommand);
                reservation.TotalPrice = totalPrice;

                await _unitOfWork.Reservations.Add(reservation);
                await MoveLocationCarByReservation(reserveCarCommand);
                await _unitOfWork.Save();

                return reservation;
            }

            return new Reservation();
        }

        public async Task MoveLocationCarByReservation(ReserveCarCommand reserveCarCommand)
        {
            if(reserveCarCommand.LocationOrigin != reserveCarCommand.LocationDestination)
            {
                LocationCar? locationCarOrigin = 
                    await _unitOfWork.LocationCars.Get(reserveCarCommand.LocationOrigin);

                if(locationCarOrigin is not null)
                {
                    locationCarOrigin.OutDate = reserveCarCommand.From;
                    _unitOfWork.LocationCars.Update(locationCarOrigin);

                    await CreateLocationFromArriveCar(reserveCarCommand, locationCarOrigin);
                }
            }
        }

        public async Task CreateLocationFromArriveCar(ReserveCarCommand reserveCarCommand,
            LocationCar locationCarOrigin)
        {
            LocationCar locationCarDest = new LocationCar
            {
                CompanyId = locationCarOrigin.CompanyId,
                LocationId = reserveCarCommand.LocationDestination,
                CarId = locationCarOrigin.CarId,
                CarPriceForDay = locationCarOrigin.CarPriceForDay,
                InDate = reserveCarCommand.To,
                OutDate = reserveCarCommand.To.AddYears(4),
            };

            await _unitOfWork.LocationCars.Add(locationCarDest);
        }
    }
}
