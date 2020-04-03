using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using FinalThesisBackend.Core.Entities;
using FinalThesisBackend.Core.Interfaces;
using FinalThesisBackend.Infrastructure;
using FinalThesisBackend.Infrastructure.Repositories;

namespace FinalThesisBackend
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
            services.AddControllers().AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore); // Prevent self reference loop issue.


            services.AddCors(options => options.AddPolicy("DevPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            }));

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LDCMacDockerConnection")));

            services.AddScoped<IAsyncRepository<Account>, AccountRepository>();
            services.AddScoped<IAsyncRepository<CustomerCartItem>, CustomerCartItemsRepository>();
            services.AddScoped<IAsyncRepository<ProductCollection>, ProductCollectionRepository>();
            services.AddScoped<IAsyncRepository<CustomerOrder>, CustomerOrderRepository>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(DataAsyncRepository<>));
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

            app.UseCors("DevPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
