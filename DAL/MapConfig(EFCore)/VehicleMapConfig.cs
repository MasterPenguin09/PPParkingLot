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
        /// <summary>
        /// Classe Interna que herda de uma Interface Microsoft
        /// Tem um método publico que configura como sera 
        /// a construção da Tabela Vechile na DB
        /// </summary>
        /// <param name="builder"></param>

        public void Configure(EntityTypeBuilder<VehicleDTO> builder)
        {
            builder.Property(c => c.CarBoard).IsRequired().IsUnicode(false);
            builder.HasIndex(c => c.CarBoard).IsUnique();

            builder.Property(c => c.ModelID).IsRequired();

            builder.Property(c => c.Type).IsRequired();

        }
    }
}
