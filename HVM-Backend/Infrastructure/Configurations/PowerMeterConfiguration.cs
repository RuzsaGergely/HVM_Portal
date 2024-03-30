using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class PowerMeterConfiguration : IEntityTypeConfiguration<PowerMeter>
    {
        public void Configure(EntityTypeBuilder<PowerMeter> builder)
        {
            builder.ToTable(nameof(PowerMeter));

            builder.HasKey(x => x.Id);
        }
    }
}
