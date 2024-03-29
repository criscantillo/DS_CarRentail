﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DS_CarRentail.Infrastructure.Database
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarId { get; set; }
        public int Type { get; set; }
        public string Brand { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public bool HasAC { get; set; } = true;
        public bool TransmissionAuto { get; set; } = true;
    }
}
