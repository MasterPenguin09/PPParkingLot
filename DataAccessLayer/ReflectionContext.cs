using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal class ContextReflection : SmartParkingContext
    {
        internal void ConfigureReflection<T>(ModelBuilder modelBuilder)
        {
            
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {

                    if (prop.Name != "ID")
                    {
                        if (prop.PropertyType == typeof(string))
                        {
                            
                                        

                        }
                        else if (prop.PropertyType == typeof(DateTime))
                        {

                        }

                    }
                
            }
        }

    }
}
