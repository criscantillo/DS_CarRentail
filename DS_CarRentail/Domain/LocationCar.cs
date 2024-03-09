namespace DS_CarRentail.Domain
{
    public class LocationCar
    {
        public int LocationCarId { get; set; }
        public Location Location { get; set; } = new Location();
        public Car Car { get; set; } = new Car();
        public decimal CarPriceForDay { get; set; }
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
    }
}
