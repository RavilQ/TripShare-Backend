using ApiPractice.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPractice.Data.Configurations
{
    public class DriverConfiguraion : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.Property(x => x.CarNumer).HasMaxLength(10);
            builder.Property(x => x.CarImage).HasMaxLength(100);
            builder.Property(x => x.Review).HasMaxLength(500);
            builder.Property(x => x.SelfPhoto).HasMaxLength(100);
        }
    }
}
