namespace DS_CarRentail.Domain
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Location>? Locations { get; set; }
    }
}
