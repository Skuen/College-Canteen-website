using CanteenCollegeAPI.Services.Implements;
using CanteenCollegeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI
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
            services.AddCors();
            services.AddControllers();

            services.AddScoped<ICategoriesServices, CategoriesServices>();
            services.AddScoped<IDishesServices, DishesServices>();
            services.AddScoped<IRoleServices, RoleServices>();
            services.AddScoped<IUsersServices, UsersServices>();
            services.AddScoped<IPaymentServices, PaymentServices>();
            services.AddScoped<IOrderServices, OrderServices>();
            services.AddScoped<IOrderDetailServices, OrderDetailServices>();
            services.AddScoped<IFileService, FileService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CanteenCollegeAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CanteenCollegeAPI v1"));
            }

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Images")),
                RequestPath = new PathString("/app-images")
            });
            app.UseHttpsRedirection();

            app.UseCors(option =>
            {
                option.AllowAnyOrigin().
                AllowAnyMethod().
                AllowAnyHeader();
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
