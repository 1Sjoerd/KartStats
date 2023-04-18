namespace KartStats.Models
{
    public class Kart
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int MaxSpeed { get; set; }
        public int DriverId { get; set; }
    }
}