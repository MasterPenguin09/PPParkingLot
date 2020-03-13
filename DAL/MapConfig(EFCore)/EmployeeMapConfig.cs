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
        /// <summary>
        /// Classe Interna que herda de uma Interface Microsoft
        /// Tem um método publico que configura como sera 
        /// a construção da Tabela Employee na DB
        /// </summary>
        /// <param name="builder"></param>

        public void Configure(EntityTypeBuilder<EmployeeDTO> builder)
        {
            builder.Property(c => c.Wage).IsRequired();
          
        }
    }
}
