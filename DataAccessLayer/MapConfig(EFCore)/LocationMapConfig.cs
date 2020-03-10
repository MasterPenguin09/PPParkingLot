﻿using DataTransferObject;
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
        public void Configure(EntityTypeBuilder<LocationDTO> builder)
        {
            builder.Property(c => c.PayForm).IsRequired();

            builder.Property(c => c.Value).IsRequired();

            builder.Property(c => c.ParkingSpotID).IsRequired();

            builder.Property(c => c.VehicleID).IsRequired();

            builder.Property(c => c.).IsRequired();


        }
    }
}
