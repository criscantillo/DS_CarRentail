using AutoMapper;
using DS_CarRentail.Application.Query;
using DS_CarRentail.Infrastructure.Database;
using DS_CarRentail.Infrastructure.Shared;
using DS_CarRentail.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DS_CarRentail.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISearchCarService _searchCarService;

        public SearchController(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            ISearchCarService searchCarService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _searchCarService = searchCarService;
        }

        [Route("locations")]
        [HttpGet]
        [ActionName(nameof(GetLocations))]
        public async Task<ActionResult<IEnumerable<CarQuery>>> GetLocations()
        {
            IEnumerable<Location> locations = await _unitOfWork.Locations.GetAll();
            var locationsQuery = _mapper.Map<IEnumerable<SimpleLocationQuery>>(locations);

            return Ok(locationsQuery);
        }

        [HttpGet]
        [ActionName(nameof(SearchCar))]
        public async Task<ActionResult<IEnumerable<LocationCarQuery>>> SearchCar(int locationOrigin, 
            int locationDestination, DateTime from, DateTime to)
        {
            IEnumerable<LocationCar> locationCars = await _searchCarService.SearchCars(locationOrigin, locationDestination, from, to);
            var locationCarQuery = _mapper.Map<IEnumerable<LocationCarQuery>>(locationCars);

            return Ok(locationCarQuery);
        }
    }
}
