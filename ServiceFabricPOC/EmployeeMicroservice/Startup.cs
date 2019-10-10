using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary.Utility;
using EmployeeMicroservice.Domain;
using EmployeeMicroservice.Models;
using EmployeeMicroservice.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Unity;

namespace EmployeeMicroservice
{
    public class Startup
    {
        public static string CLIENTSECRET = "r77P5u6zCpONMGZGOp:E]?jgAG:v.H71";
        public static string CLIENTID = "dcaf8ee3-938a-4211-b50c-3ded910359f6";
        public static string BASESECRETURI = "https://bzservicefabrickeyvault.vault.azure.net";

        static KeyVaultClient kvc = null;

        public IUtility Utility { get; }

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IUtility utility)
        {
            Configuration = configuration;
            Utility = utility;
        }

        

        // Configure Unity container
        public void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterSingleton<IEmployeeService, EmployeService>();
            container.RegisterSingleton<IEmployeeRepository, EmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

          kvc = Utility.GetKeyClient("employeesqlkey");
            SecretBundle secret = Utility.GetSecret("employeesqlkey");
            services.AddDbContext<employeeContext>
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
