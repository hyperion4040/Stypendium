using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
//            services.AddDbContext<DataAccess>(opt => opt.UseInMemoryDatabase());
           services.AddDbContext<DataAccess>(opt => opt.UseSqlServer(Configuration.GetSection("ConnectionStrings")["AzureConnection"]));
            
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
            


            if (context.Database.EnsureCreated())
            {
                
                var testUser1 = new Person()
                {
                    //Id = 1,
                    Name = "Adrian"
                };
 
                context.Persons.Add(testUser1);
 
                var testUser2 = new Person()
                {
                    //Id = 2,
                    Name = "Sebastian"
                };
 
                context.Persons.Add(testUser2);

                var testUser3 = new Person()
                {
                    //Id = 3,
                    Name = "Hadrianus"
                };
                context.Persons.Add(testUser3);

                var przedmiotS1 = new Przedmiot("Programowanie komputerów",2);

                var przedmiotS2 = new Przedmiot("Analiza matematyczna", 2);
                var przedmiot1 = new Kierunek()
                {
                    Semestr = 3,
                    Przedmiot = przedmiotS1
                 };
                var przedmiot2 = new Kierunek()
                {
                    Semestr = 3,
                    Przedmiot = przedmiotS2
                    
                };
                context.Przedmioty.Add(przedmiotS1);
                context.Przedmioty.Add(przedmiotS2);
                
                context.Informatyka.Add(przedmiot1);
                context.Informatyka.Add(przedmiot2);
                
                context.SaveChanges();
            }
            
           /* Dictionary = new Dictionary<string, int>()
            {
                
                {"Analiza matematyczna",2},
                {"Architektura sprzętu komputerowego",2},
                {"Architektura systemów komputerowych",2},
                {"Matematyka dyskretna",2},
                {"Algebra Liniowa",2},
                {"Algorytmy i złożoność obliczeniowa",2},
                {"Bazy danych",2},
                {"Podstawy sieci komputerowych",2},
                {"Rachunek prawdopodobieństwa",2}
            }*/
            
            
                
               
            }
           
            
            
            
            
           
        }
    }
