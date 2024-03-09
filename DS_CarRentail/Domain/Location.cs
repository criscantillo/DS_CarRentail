namespace DS_CarRentail.Domain
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Coordinates { get; set; } = string.Empty;
    }
}
