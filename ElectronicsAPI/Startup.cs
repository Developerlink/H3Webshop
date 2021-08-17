using ElectronicsORM.Library;
using ElectronicsORM.Library.Interfaces;
using ElectronicsORM.Library.Repositories.EF;
using ElectronicsORM.Library.Repositories.MO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsAPI
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
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            var connectionString = "";

            if (Environment.MachineName == "WLT02")
            {
                connectionString = Configuration["connectionStrings:electronicsHomeDbConnectionString"];
            }
            else
            {
                connectionString = Configuration["connectionStrings:electronicsShcoolDbConnectionString"];
            }

            services.AddDbContext<ElectronicsDbContext>(cnn => cnn.UseSqlServer(connectionString));

            string ormChocie = "EF";

            if (ormChocie == "EF")
            {
                services.AddScoped<ICustomerRepository, CustomerRepository>()
                    .AddScoped<IDeliveryRepository, DeliveryRepository>()
                    .AddScoped<IEmployeeRepository, EmployeeRepository>()
                    .AddScoped<IOrderLineRepository, OrderLineRepository>()
                    .AddScoped<IProductRepository, ProductRepository>()
                    .AddScoped<IProductTypeRepository, ProductTypeRepository>()
                    .AddScoped<ISalesOrderRepository, SalesOrderRepository>()
                    .AddScoped<IStoreProductRepository, StoreProductRepository>()
                    .AddScoped<IStoreRepository, StoreRepository>()
                    .AddScoped<IPostalCodeRepository, PostalCodeRepository>();
            }
            else
            {
                services.AddScoped<ICustomerRepository, CustomerRepositoryMO>()
                    .AddScoped<IDeliveryRepository, DeliveryRepositoryMO>()
                    .AddScoped<IEmployeeRepository, EmployeeRepositoryMO>()
                    .AddScoped<IOrderLineRepository, OrderLineRepositoryMO>()
                    .AddScoped<IProductRepository, ProductRepositoryMO>()
                    .AddScoped<IProductTypeRepository, ProductTypeRepositoryMO>()
                    .AddScoped<ISalesOrderRepository, SalesOrderRepositoryMO>()
                    .AddScoped<IStoreProductRepository, StoreProductRepositoryMO>()
                    .AddScoped<IStoreRepository, StoreRepositoryMO>()
                    .AddScoped<IPostalCodeRepository, PostalCodeRepositoryMO>();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}