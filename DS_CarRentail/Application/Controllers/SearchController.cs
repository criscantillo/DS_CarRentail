using AutoMapper;
using DS_CarRentail.Application.Query;
using DS_CarRentail.Infrastructure.Database;
using DS_CarRentail.Infrastructure.Shared;
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

        public SearchController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
    }
}
