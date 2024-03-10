namespace DS_CarRentail.Application.Query
{
    public class LocationCarQuery
    {
        public int LocationCarId { get; set; }
        public CompanyQuery? Company { get; set; }
        public int LocationId { get; set; }
        public CarQuery? Car { get; set; }
        public decimal CarPriceForDay { get; set; }
    }
}
