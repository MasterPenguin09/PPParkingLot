using DataTransferObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MapConfig_EFCore_
{
    internal class VehicleMapConfig : IEntityTypeConfiguration<VehicleDTO>
    {
        public void Configure(EntityTypeBuilder<VehicleDTO> builder)
        {
            builder.Property(c => c.CarBoard).IsRequired().IsUnicode(false);
            builder.HasIndex(c => c.CarBoard).IsUnique();

            builder.Property(c => c.ModelID).IsRequired();

            builder.Property(c => c.Type).IsRequired();

        }
    }
}
