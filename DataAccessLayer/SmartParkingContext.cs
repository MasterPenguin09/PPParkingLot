using DataTransferObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SmartParkingContext : DbContext
    {
        //https://www.learnentityframeworkcore.com/configuration/fluent-api
        public SmartParkingContext() : base()
        {

        }
        public DbSet<BrandDTO> Brands { get; set; }
        public DbSet<EmployeeDTO> Employees { get; set; }
        public DbSet<LocationDTO> Locations { get; set; }
        public DbSet<ModelDTO> Models { get; set; }
        public DbSet<VehicleDTO> Vehicles  { get; set; }
        public DbSet<ClientDTO> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        private void LoadStringConfig(ModelBuilder modelBuilder)
        {
            Assembly assemblyDTO = Assembly.GetAssembly(typeof(BrandDTO));

            List<Type> types = assemblyDTO.GetTypes().Where(c => c.Namespace == "DTO").ToList();

            foreach (Type item in types)
            {
                foreach (PropertyInfo propriedade in item.GetProperties().Where(c => c.PropertyType == typeof(string)))
                {
                    modelBuilder.Entity(item.Name).Property(propriedade.Name).IsRequired().IsUnicode(false);
                }
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Configurções globais

            //base.OnModelCreating(modelBuilder);

            //// series of statements
            //modelBuilder.Entity<Order>().Property(t => t.Length.).IsRequired();
            //modelBuilder.Entity<Order>().Property(t => t.OrderDate).HasColumnType("Date");
            //modelBuilder.Entity<Order>().Property(t => t.OrderDate).HasDefaultValueSql("GetDate()");
            //// fluent api chained calls
            //modelBuilder.Entity<Order>()
            //    .Property(t => t.OrderDate)
            //        .IsRequired()
            //        .HasColumnType("Date")
            //        .HasDefaultValueSql("GetDate()");

            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
