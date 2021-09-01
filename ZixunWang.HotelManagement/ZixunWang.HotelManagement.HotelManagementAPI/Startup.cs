using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZixunWang.HotelManagement.ApplicationCore.Entities;
using ZixunWang.HotelManagement.ApplicationCore.RepositoryInterfaces;
using ZixunWang.HotelManagement.ApplicationCore.ServiceInterfaces;
using ZixunWang.HotelManagement.Infrastructure.Data;
using ZixunWang.HotelManagement.Infrastructure.Repositories;
using ZixunWang.HotelManagement.Infrastructure.Services;

namespace ZixunWang.HotelManagement.HotelManagementAPI
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ZixunWang.HotelManagement.HotelManagementAPI", Version = "v1" });
            });

            services.AddDbContext<HotelManagementDbContext>
                (
                options => options.UseSqlServer(Configuration.GetConnectionString("HotelManagementDbConnection"))
                );

            services.AddScoped<IAsyncRepository<RoomType>, EfRepository<RoomType>>();
            services.AddScoped<IRoomTypeService, RoomTypeService>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IAsyncRepository<Service>, EfRepository<Service>>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZixunWang.HotelManagement.HotelManagementAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(builder =>
            {
                builder.WithOrigins(Configuration.GetValue<string>("clientSPAUrl")).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
