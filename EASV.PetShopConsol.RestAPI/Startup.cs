using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EASV.PetShopConsol.Core.Application;
using EASV.PetShopConsol.Core.Application.Impl;
using EASV.PetShopConsol.Core.Domain;
using EASV.PetShopConsol.InfrastructureEntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EASV.PetShopConsol.RestAPI
{
    public class Startup
    {
        /*public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }*/

        public IConfiguration _conf { get; }
        public IHostingEnvironment _env { get; }

        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            _conf = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (_env.IsDevelopment())
            {
                // In-memory database:
                //services.AddDbContext<PetConsolContext>(opt => opt.UseInMemoryDatabase("PetsList"));
                services.AddDbContext<PetConsolContext>(opt => opt.UseSqlite("Data Source = petConsolApp.db"));
            }
            else
            {
                // SQL Server on Azure:
                services.AddDbContext<PetConsolContext>(opt =>
                         opt.UseSqlServer(_conf.GetConnectionString("defaultConnection")));
            }

            var MVC = services.AddMvc();
            MVC.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            MVC.AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            services.AddScoped<IPetRepository, PetDBRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IOwnerRepository, OwnerDBRepository>();
            services.AddScoped<IPetColorService, PetColorService>();
            services.AddScoped<IPetColorRepository, PetColorDBRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetConsolContext>();
                    ctx.Database.EnsureDeleted();
                    ctx.Database.EnsureCreated();
                    DBInitializer.Initialize(ctx);
                }
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetConsolContext>();
                    ctx.Database.EnsureCreated();
                }
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
