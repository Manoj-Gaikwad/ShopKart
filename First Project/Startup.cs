using First_Project.Data;
using First_Project.IRepository;
using First_Project.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Project
{
    public class Startup
    {
        private readonly string ShopKartPolicy = "admin";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("ConnString");
            services.AddDbContext<DBConnection>(options => options.UseSqlServer(connectionString));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.RequireHttpsMetadata = false; // Set to true in production
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("admin", policy =>
                    policy.RequireRole("admin"));
            });

            services.AddHttpClient("RazerPay", c =>
            {
                c.BaseAddress = new Uri("https://api.razerpay.com/v1/"); // Replace with the appropriate base URL
                c.DefaultRequestHeaders.Add("MerchantId", "MAQ53v6n9xW6hA"); // Replace with your Merchant ID
                c.DefaultRequestHeaders.Add("Authorization", "WoAkzG1B13nKOnWYO0s6sJQa"); // Replace with your Secret Key
            });

            services.AddTransient<IEmplyeeDetailsRepository, EmployeeDetailsRepository>();
            services.AddTransient<IPersonsDataRepositiory,PersonsDataRepository>();
            services.AddTransient<ICompanyDataRepository, CompanyDataRepository>();
            services.AddTransient<IClothsDetailsRepository, ClothsDetailsRepository>();
            services.AddTransient<ICartDataRepository, CartDataRepository>();
            services.AddTransient<ICustomerDataRepository, CustomerDataRepository>();
            services.AddTransient<ICosmeticsDetailsRepository, CosmeticsDetailsRepository>();
            services.AddTransient<IShoesDetailsRepository, ShoesDetailsRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IPaymentDetailsRepository, PaymentDetailsRepository>();


            services.AddControllers();

            services.AddCors(options => options.AddPolicy(name: ShopKartPolicy, p => p
            .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader()
         ));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShopKart", Version = "v1" });
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
            app.UseCors(ShopKartPolicy);

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();
           

           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
