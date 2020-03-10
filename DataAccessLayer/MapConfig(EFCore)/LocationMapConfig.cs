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
        public void Configure(EntityTypeBuilder<LocationDTO> builder)
        {
            //Nada          
        }
    }
}
