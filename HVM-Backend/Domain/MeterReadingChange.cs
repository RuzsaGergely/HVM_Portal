namespace Domain
{
    public class MeterReadingChange : BaseEntity
    {
        public int IdOfMeter { get; set; }
        public int IdOfUser { get; set; }
        public DateTime DateOfReading { get; set; }
        public int OldReading { get; set; }
        public int NewReading { get; set; }
    }
}
