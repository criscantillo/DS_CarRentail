using DS_CarRentail.Infrastructure.Database;
using DS_CarRentail.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace DS_CarRentail.Services
{
    public class SearchCarService : ISearchCarService
    {
        private readonly DbSet<LocationCar> _dbSet;
        private readonly IUnitOfWork _unitOfWork;

        public SearchCarService(CarRentailContext context, IUnitOfWork unitOfWork) 
        {
            _dbSet = context.Set<LocationCar>();
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<LocationCar>> SearchCars(int locationOrigin, 
            int locationDestination, DateTime from, DateTime to)
        {
            if (locationDestination < 1)
                locationDestination = locationOrigin;

            string sql = GetQuery(locationOrigin, locationDestination, from, to);
            List<LocationCar> lstSearchCar =
                await _dbSet.FromSqlRaw(sql).ToListAsync();

            IEnumerable<Car> lstCars = await _unitOfWork.Cars.GetAll();
            IEnumerable<Company> lstCompanies = await _unitOfWork.Companies.GetAll();

            lstSearchCar.ForEach(locationCar => {
                locationCar.Car = lstCars.Where(x => x.CarId == locationCar.CarId).First();
                locationCar.Company = lstCompanies.Where(x => x.CompanyId == locationCar.CompanyId).First();
            });

            return lstSearchCar;
        }

        public string GetQuery(int locationOrigin,
            int locationDestination, DateTime from, DateTime to)
        {
            string fromStr = from.ToString("yyyy-MM-dd HH:mm");
            string toStr = to.ToString("yyyy-MM-dd HH:mm");

            string sql = @$" SELECT lc.*
                            FROM LocationCar lc
	                            INNER JOIN LocationCar lcd ON lc.CompanyId = lcd.CompanyId 
		                             AND lc.CarId = lcd.CarId AND lcd.LocationId = {locationDestination}
	                            LEFT JOIN Reservation r ON lc.LocationCarId = r.LocationCarId
                            WHERE lc.InDate < '{fromStr}' 
                            AND lc.OutDate > '{toStr}'
                            AND lc.LocationId = {locationOrigin}
                            AND (r.[From] IS NULL
	                            OR (r.[From] NOT BETWEEN '{fromStr}' AND '{toStr}'
		                            AND r.[To] NOT BETWEEN '{fromStr}' AND '{toStr}')
	                            )
                            ORDER BY lc.LocationCarId";
            return sql;
        }
    }
}
