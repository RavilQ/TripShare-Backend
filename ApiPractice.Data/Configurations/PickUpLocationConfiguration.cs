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
    public class PickUpLocationConfiguration : IEntityTypeConfiguration<PickupLocations>
    {
        public void Configure(EntityTypeBuilder<PickupLocations> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Link).HasMaxLength(100);
        }
    }
}
