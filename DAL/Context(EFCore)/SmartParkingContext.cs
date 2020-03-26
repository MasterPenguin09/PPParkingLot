using DataTransferObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DAL.Context_EFCore_
{
    public class SmartParkingContext : DbContext
    {
       
        public SmartParkingContext(DbContextOptions<SmartParkingContext> options) : base(options)
        {
            
        }

       
        public DbSet<BrandDTO> Brands { get; set; }
        public DbSet<EmployeeDTO> Employees { get; set; }
        public DbSet<LocationDTO> Locations { get; set; }
        public DbSet<ModelDTO> Models { get; set; }
        public DbSet<VehicleDTO> Vehicles { get; set; }
        public DbSet<ClientDTO> Clients { get; set; }
        public DbSet<ParkingSpotDTO> ParkingSpots { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        
        }
    }
}
