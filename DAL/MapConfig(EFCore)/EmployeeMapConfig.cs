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
            builder.Property(c => c.CPF).IsRequired().HasMaxLength(14).IsFixedLength(true);
            builder.Property(c => c.CPF).IsRequired().IsUnicode(false);
            builder.HasIndex(c => c.CPF).IsUnique();

            builder.Property(c => c.Name).IsRequired().HasMaxLength(256);
            builder.Property(c => c.Name).IsRequired().IsUnicode(false);

            builder.Property(c => c.Email).IsRequired().IsUnicode(false);
            builder.HasIndex(c => c.Email).IsUnique();

            builder.Property(c => c.BirthDate).IsRequired();

            builder.Property(c => c.AccessLevel).IsRequired();

            builder.Property(c => c.IsActive).IsRequired().ValueGeneratedOnAdd();

            builder.Property(c => c.Number).IsRequired();
            builder.HasIndex(c => c.Number).IsUnique();

            builder.Property(c => c.Password).IsRequired().IsUnicode(false);

            builder.Property(c => c.SystemEntranceDate).IsRequired().ValueGeneratedOnAdd();

            builder.Property(c => c.Wage).IsRequired();
          
        }
    }
}
