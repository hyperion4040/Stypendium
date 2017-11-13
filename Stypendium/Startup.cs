using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stypendium.Models;

namespace Stypendium
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
            services.AddDbContext<DataAccess>(opt => opt.UseInMemoryDatabase());
            services.AddDbContext<DataAccess>(opt => opt.UseSqlServer("Server=tcp:stypendium.database.windows.net,1433;Initial Catalog=stypendium;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
 
            var context = app.ApplicationServices.GetService<DataAccess>();
            AddTestData(context);
            
            
            app.UseMvc();
        }
        
        
        private static void AddTestData(DataAccess context)
        {
            var testUser1 = new Person()
            {
                Id = 1,
                Name = "Adrian"
            };
 
            context.Persons.Add(testUser1);
 
            var testPost1 = new Person()
            {
               Id = 2,
                Name = "Sebastian"
            };
 
            context.Persons.Add(testPost1);
 
            context.SaveChanges();
        }
    }
}