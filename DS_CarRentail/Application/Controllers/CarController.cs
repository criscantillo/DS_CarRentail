using AutoMapper;
using DS_CarRentail.Application.Command;
using DS_CarRentail.Application.Query;
using DS_CarRentail.Infrastructure.Database;
using DS_CarRentail.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DS_CarRentail.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CarController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ActionName(nameof(GetCars))]
        public async Task<ActionResult<IEnumerable<CarQuery>>> GetCars()
        {
            IEnumerable<Car> cars = await _unitOfWork.Cars.GetAll();
            IEnumerable<CarQuery> lstCars = _mapper.Map<IEnumerable<CarQuery>>(cars);

            return Ok(lstCars);
        }

        [HttpPost]
        [ActionName(nameof(CreateCar))]
        public async Task<ActionResult<CarQuery>> CreateCar(CreateCarCommand createCarCommand)
        {
            Car car = _mapper.Map<Car>(createCarCommand);
            await _unitOfWork.Cars.Add(car);
            await _unitOfWork.Save();

            CarQuery carQuery = _mapper.Map<CarQuery>(car);
            return Ok(carQuery);
        }

        [HttpPut]
        [ActionName(nameof(UpdateCar))]
        public async Task<ActionResult<CarQuery>> UpdateCar(UpdateCarCommand updateCarCommand)
        {
            Car car = _mapper.Map<Car>(updateCarCommand);
            _unitOfWork.Cars.Update(car);
            await _unitOfWork.Save();

            CarQuery carQuery = _mapper.Map<CarQuery>(car);
            return Ok(carQuery);
        }

        [HttpDelete("{carId}")]
        [ActionName(nameof(DeleteCar))]
        public async Task<ActionResult<CarQuery>> DeleteCar(int carId)
        {
            Car? car = await _unitOfWork.Cars.Get(carId);

            if(car is null) { 
                return NotFound();
            }

            await _unitOfWork.Cars.Delete(carId);
            await _unitOfWork.Save();

            CarQuery carQuery = _mapper.Map<CarQuery>(car);
            return Ok(carQuery);
        }
    }
}
