namespace Domain
{
    public class MeterReadingChange : BaseEntity
    {
        public PowerMeter Meter { get; set; }
        public DateTime DateOfReading { get; set; }
        public int OldReading { get; set; }
        public int NewReading { get; set; }
    }
}
