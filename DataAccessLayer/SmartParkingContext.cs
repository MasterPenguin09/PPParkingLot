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
        public SmartParkingContext(DbContextOptions<SmartParkingContext> options) : base (options)
        {

        }
        
        public SmartParkingContext() : base()
        {

        }
        public DbSet<BrandDTO> Brands { get; set; }
        public DbSet<EmployeeDTO> Employees { get; set; }
        public DbSet<LocationDTO> Locations { get; set; }
        public DbSet<ModelDTO> Models { get; set; }
        public DbSet<VehicleDTO> Vehicles  { get; set; }
        public DbSet<ClientDTO> Clients { get; set; }
        public DbSet<ParkingSpotDTO> ParkingSpots { get; set; }
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

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
       
                .SelectMany(t => t.GetForeignKeys())
        
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            
            base.OnModelCreating(modelBuilder);
        }
    }
}
