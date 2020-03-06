using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SmartParkingContext : DbContext
    {
      
            //Não esqueça de setar a connectionString
            //public SmartParkingContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\?????????????????\Documents\SmartParkingDB.mdf;Integrated Security=True;Connect Timeout=30")
            //{

            //}

            //public DbSet<ClienteDTO> Clientes { get; set; }
            
            //internal Task<UserDTO> FirstOrDefaultAsync(Func<object, bool> p)
            //{
            //    throw new NotImplementedException();
            //}
            //protected override void OnModelCreating(DbModelBuilder modelBuilder)
            //{
            //    //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //    modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            //    modelBuilder.Properties()
            //                .Where(c => c.PropertyType == typeof(string))
            //                .Configure(c => c.IsRequired().IsUnicode(false));

            //    base.OnModelCreating(modelBuilder);
            //}
        }
    }

