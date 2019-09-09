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

namespace DepartmentMicroservice
{
    public class Startup
    {
        //public static string CLIENTSECRET = "E@K:9ZW6vp+AN.m3NM5QZ]6r@JWTBMQJ";
        //public static string CLIENTID = "5283d103-868b-4aa0-bf5e-62619cd7d718";
        //public static string BASESECRETURI = "https://bzservicefabrickeyvault.vault.azure.net";

        //static KeyVaultClient kvc = null;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Configure Unity container
        public void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterSingleton<IDepartmentService, DepartmentService>();
            container.RegisterSingleton<IDepartmentRepository, DepartmentsRepository>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //kvc = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(GetToken));
            //SecretBundle secret = Task.Run(() => kvc.GetSecretAsync(BASESECRETURI +
            //    @"/secrets/" + "servicefabrickey")).ConfigureAwait(false).GetAwaiter().GetResult();

            //services.AddDbContext<DepartmentContext>
            //    (options => options.UseSqlServer(secret.Value));

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

        //public static async Task<string> GetToken(string authority, string resource, string scope)
        //{
        //    var authContext = new AuthenticationContext(authority);
        //    ClientCredential clientCred = new ClientCredential(CLIENTID, CLIENTSECRET);
        //    AuthenticationResult result = await authContext.AcquireTokenAsync(resource, clientCred);

        //    if (result == null)
        //        throw new InvalidOperationException("Failed to obtain the JWT token");

        //    return result.AccessToken;
        //}

    }
}
