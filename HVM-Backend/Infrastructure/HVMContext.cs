using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class HVMContext : DbContext
    {
        public HVMContext(DbContextOptions<HVMContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<PowerMeter> PowerMeters { get; set; }
        public DbSet<MeterReadingChange> MeterReadingChanges { get; set; }
    }
}
