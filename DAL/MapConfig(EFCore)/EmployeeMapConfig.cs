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
    internal class EmployeeMapConfig : IEntityTypeConfiguration<EmployeeDTO>
    {
        public void Configure(EntityTypeBuilder<EmployeeDTO> builder)
        {
            builder.Property(c => c.Wage).IsRequired();
          
        }
    }
}
