using DataTransferObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DAL.Context_EFCore_
{/// <summary>
/// Uma classe publica que herda da classe microsoft DbContext
/// Possui todo o contexto em que o SmartParking esta inserido
/// Tem um construtor usando DbcontextOptions
/// </summary>
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

        /// <summary>
        /// Um método override, usamos para mudar o contexto atual da DB
        /// Para não usar as formas padrões do EF e sim as nossas proprias
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
