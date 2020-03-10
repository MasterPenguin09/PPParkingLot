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
    internal class ModelMapConfig : IEntityTypeConfiguration<ModelDTO>
    {
        public void Configure(EntityTypeBuilder<ModelDTO> builder)
        {
            builder.Property(c => c.Name).IsRequired().IsUnicode(false);
            builder.HasIndex(c => c.Name).IsUnique();

            builder.Property(c => c.BrandDTO).IsRequired();

            
        }
    }
}
