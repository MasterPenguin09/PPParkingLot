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
    internal class LocationMapConfig : IEntityTypeConfiguration<LocationDTO>
    {
        /// <summary>
        /// Classe Interna que herda de uma Interface Microsoft
        /// Tem um método publico que configura como sera 
        /// a construção da Tabela Location na DB
        /// </summary>
        /// <param name="builder"></param>

        public void Configure(EntityTypeBuilder<LocationDTO> builder)
        {


            builder.Property(c => c.EntryTime).IsRequired();

            builder.Property(c => c.ParkingSpotID).IsRequired();

            builder.Property(c => c.VehicleID).IsRequired();

           


        }
    }
}
