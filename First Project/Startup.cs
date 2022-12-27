using First_Project.Data;
using First_Project.IRepository;
using First_Project.Repository;
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

namespace First_Project
{
    public class Startup
    {
        private readonly string HRMSPolicy = "HRMSPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("MasterConnString");
            services
               .AddDbContext<DBConnection>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            services.AddTransient<IEmplyeeDetailsRepository, EmployeeDetailsRepository>();
            services.AddTransient<IPersonsDataRepositiory,PersonsDataRepository>();
            services.AddTransient<ICompanyDataRepository, CompanyDataRepository>();
            services.AddTransient<ISignInRepositiory, SignInRepository>();
            services.AddTransient<IClothsDetailsRepository, ClothsDetailsRepository>();
            services.AddTransient<ICartDataRepository, CartDataRepository>();
            services.AddTransient<ICustomerDataRepository, CustomerDataRepository>();
            
          

            services.AddControllers();

            services.AddCors(options => options.AddPolicy(name: HRMSPolicy, p => p
            .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader()
         ));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "First_Project", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "First_Project v1"));
            }
            app.UseCors(HRMSPolicy);

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
