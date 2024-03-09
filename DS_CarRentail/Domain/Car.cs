﻿namespace DS_CarRentail.Domain
{
    public class Car
    {
        public int CarId { get; set; }
        public enum CarType 
        {
            Small = 1,
            Big = 2,
            Vans = 3,
            Pickup = 4,
            Luxury = 5,
            Hybrid_Electric = 6,
            Sporting = 7
        }
        public string Brand { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public bool HasAC { get; set; } = true;
        public bool TransmissionAuot { get; set; } = true;
    }
}
