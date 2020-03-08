using DataTransferObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SamartParkingContext : DbContext
    {
        public SamartParkingContext() : base()
        {

        }
        public DbSet<BrandDTO> Brands { get; set; }
        public DbSet<EmployeeDTO> Employees { get; set; }
        public DbSet<LocationDTO> Locations { get; set; }
        public DbSet<ModelDTO> Models { get; set; }
        public DbSet<VehicleDTO> Vehicles  { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Utilizar Reflection para criar configurações
            //globais

            base.OnModelCreating(modelBuilder);
        }
    }
}
