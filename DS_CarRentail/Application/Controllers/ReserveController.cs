using AutoMapper;
using DS_CarRentail.Application.Command;
using DS_CarRentail.Application.Query;
using DS_CarRentail.Infrastructure.Database;
using DS_CarRentail.Infrastructure.Shared;
using DS_CarRentail.Services;
using Microsoft.AspNetCore.Mvc;

namespace DS_CarRentail.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReserveController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;

        public ReserveController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        [HttpPost]
        [ActionName(nameof(ReserveCar))]
        public async Task<ActionResult<ReserveCarQuery>> ReserveCar(ReserveCarCommand reserveCarCommand)
        {
            Reservation reservation = await _reservationService.ReserveCar(reserveCarCommand);
            ReserveCarQuery reserveCarQuery = _mapper.Map<ReserveCarQuery>(reservation);

            return Ok(reserveCarQuery);
        }
    }
}
