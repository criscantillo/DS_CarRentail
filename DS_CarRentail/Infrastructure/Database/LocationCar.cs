﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DS_CarRentail.Infrastructure.Database
{
    public class LocationCar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationCarId { get; set; }
        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public virtual Location? Location { get; set; }
        public int CarId { get; set; }
        [ForeignKey("CarId")]
        public virtual Car? Car { get; set; }
        public decimal CarPriceForDay { get; set; }
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
    }
}
