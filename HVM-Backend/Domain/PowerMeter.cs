namespace Domain
{
    public class PowerMeter : BaseEntity
    {
        public string SerialNumber { get; set; }
        public int LastReading { get; set; }
        // Mérőóra címe
        public string AddressOfMeter { get; set; }
        // Mérőóra helyrajzi száma - abban az esetben ha nincs címe
        public string LotNumber { get; set; }
        public string Description { get; set; }
    }
}
