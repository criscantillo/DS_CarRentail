namespace DS_CarRentail.Application.Command
{
    public class CreateCarCommand
    {
        public int Type { get; set; }
        public string Brand { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public bool HasAC { get; set; } = true;
        public bool TransmissionAuto { get; set; } = true;
    }
}
