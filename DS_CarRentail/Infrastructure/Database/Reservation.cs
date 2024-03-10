using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DS_CarRentail.Infrastructure.Database
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationId { get; set; }
        public int LocationCarId { get; set; }
        [ForeignKey("LocationCarId")]
        public virtual LocationCar? LocationCar { get; set; }
        public int LocationOrigin { get; set; }
        public int LocationDestination { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User? User {  get; set; } 
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
