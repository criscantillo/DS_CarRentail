using AutoMapper;
using DS_CarRentail.Application.Command;
using DS_CarRentail.Application.Query;
using DS_CarRentail.Infrastructure.Database;

namespace DS_CarRentail.Application
{
    public class ApiModelProfiles : Profile
    {
        public ApiModelProfiles() 
        {
            CreateMap<CreateCarCommand, Car>();
            CreateMap<UpdateCarCommand, Car>();
            CreateMap<Car, CarQuery>();
            CreateMap<Location, SimpleLocationQuery>();
        }
    }
}
