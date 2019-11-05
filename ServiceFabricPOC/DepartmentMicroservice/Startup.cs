using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Unity;
using DepartmentMicroservice.Domain;
using DepartmentMicroservice.Repository;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.EntityFrameworkCore;
using DepartmentMicroservice.Models;
using CommonLibrary.Utility;
using System.IO;

namespace DepartmentMicroservice
{
    public class Startup
    {
        static KeyVaultClient kvc = null;

        public IConfiguration Configuration { get; set; }
        public IUtility Utility { get; }

        public Startup(IConfiguration configuration, IUtility utility)
        {
            Configuration = configuration;
            Utility = utility;
        }

        // Configure Unity container
        public void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterSingleton<IUtility, Utility>();
            
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            kvc = Utility.GetKeyClient(Configuration.GetSection("KeyVault").GetSection("department").Value);
            SecretBundle secret = Utility.GetSecret(Configuration.GetSection("KeyVault").GetSection("department").Value);
            services.AddDbContext<DepartmentContext>
                (options => options.UseSqlServer(secret.Value));

            
            services.AddOptions();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

    }
}
