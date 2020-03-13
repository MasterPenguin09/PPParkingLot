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
    internal class BrandMapConfig : IEntityTypeConfiguration<CLientDTO>
    {
        public void Configure(EntityTypeBuilder<BrandDTO> builder)
        {
            builder.Property(c => c.Name).IsRequired().IsUnicode(false);
            builder.Property(c => c.Name).IsRequired().IsUnicode(false);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(256);
        }
    }
}
