using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Impl;
using BLL.Interfaces;
using BusinessLogicalLayer.Impl;
using BusinessLogicalLayer.Interfaces;
using DAL.Context_EFCore_;
using DataAccessLayer.Interfaces_EFCore_;
using DataAccessLayer.Repositories_EFCore_;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PPParkingLot
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<SmartParkingContext>(options => options.UseSqlServer(Configuration["ConnectionString"]));
            //services.AddDbContextPool<SmartParkingContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));

            services.AddControllersWithViews();

            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IClientRepository, ClientRepository>();

            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            services.AddTransient<IVehicleService, VehicleService>();
            services.AddTransient<IVehicleRepository, VehicleRepository>();

            services.AddTransient<ILocationSevice, LocationService>();
            services.AddTransient<ILocationRepository, LocationRepository>();

            services.AddTransient<IModelService, ModelService>();
            services.AddTransient<IModelRepository, ModelRepository>();

            services.AddTransient<IParkingSpotService, ParkingSpotService>();
            services.AddTransient<IParkingSpotRepository, ParkingSpotRepository>();

            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<IBrandRepository, BrandRepository>();

            services.AddTransient<IUserService, UserService>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
