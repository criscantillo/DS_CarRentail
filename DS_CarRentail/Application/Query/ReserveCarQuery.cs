namespace DS_CarRentail.Application.Query
{
    public class ReserveCarQuery
    {
        public int ReservationId { get; set; }
        public int LocationCarId { get; set; }
        public int LocationOrigin { get; set; }
        public int LocationDestination { get; set; }
        public int UserId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
