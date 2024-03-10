using AutoMapper;
using DS_CarRentail.Application;
using DS_CarRentail.Application.Command;
using DS_CarRentail.Infrastructure.Database;
using DS_CarRentail.Infrastructure.Shared;
using DS_CarRentail.Services;
using Moq;

namespace DS_CarRentailTest.ServicesTest
{
    public class ReservationServiceTest
    {
        private readonly ReservationService _reservationService;

        public ReservationServiceTest()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var locationCarRepositoryMock = new Mock<IRepository<LocationCar>>();
            var reservationRepositoryMock = new Mock<IRepository<Reservation>>();

            locationCarRepositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(new LocationCar {
                    CarPriceForDay = 35,
                    CompanyId = 1,
                    CarId = 4
                });

            unitOfWorkMock.Setup(x => x.LocationCars).Returns(locationCarRepositoryMock.Object);
            unitOfWorkMock.Setup(x => x.Reservations).Returns(reservationRepositoryMock.Object);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApiModelProfiles());
            });
            var mapper = mockMapper.CreateMapper();

            _reservationService = new ReservationService(unitOfWorkMock.Object, mapper);
        }

        [Fact]
        public async Task ReserveCar_GiveReserveCarCommand_ReturnsReservation()
        {
            ReserveCarCommand reserveCarCommand = new ReserveCarCommand 
            {
                LocationCarId = 1,
                LocationOrigin = 3,
                LocationDestination = 4,
                UserId = 2,
                From = DateTime.Parse("2024-03-09 00:00:00"),
                To = DateTime.Parse("2024-03-12 00:00:00")
            };

            Reservation reservation = await _reservationService.ReserveCar(reserveCarCommand);

            Assert.NotNull(reservation);
            Assert.Equal(105, reservation.TotalPrice);
        }

        [Fact]
        public async Task MoveLocationCarByReservation_GiveReserveCarCommand()
        {
            ReserveCarCommand reserveCarCommand = new ReserveCarCommand
            {
                LocationCarId = 1,
                LocationOrigin = 3,
                LocationDestination = 4,
                UserId = 2,
                From = DateTime.Parse("2024-03-09 00:00:00"),
                To = DateTime.Parse("2024-03-12 00:00:00")
            };

            try
            {
                await _reservationService.MoveLocationCarByReservation(reserveCarCommand);
                Assert.True(true);
            }catch(Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

        [Fact]
        public async Task CreateLocationFromArriveCar_GiveReserveCarCommand()
        {
            ReserveCarCommand reserveCarCommand = new ReserveCarCommand
            {
                LocationCarId = 1,
                LocationOrigin = 3,
                LocationDestination = 4,
                UserId = 2,
                From = DateTime.Parse("2024-03-09 00:00:00"),
                To = DateTime.Parse("2024-03-12 00:00:00")
            };

            LocationCar locationCar = new LocationCar
            {
                CarPriceForDay = 35,
                CompanyId = 1,
                CarId = 4
            };

            try
            {
                await _reservationService.CreateLocationFromArriveCar(reserveCarCommand, locationCar);
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }
    }
}
