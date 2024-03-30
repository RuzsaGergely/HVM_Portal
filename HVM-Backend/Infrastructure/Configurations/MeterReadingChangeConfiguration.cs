﻿using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class MeterReadingChangeConfiguration : IEntityTypeConfiguration<MeterReadingChange>
    {
        public void Configure(EntityTypeBuilder<MeterReadingChange> builder)
        {
            builder.ToTable(nameof(MeterReadingChange));
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Meter);
        }
    }
}
