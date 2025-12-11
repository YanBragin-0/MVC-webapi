using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MVC_webapi.Infrastructure;
using MVC_webapi.Models.RepoInterfaces;
using MVC_webapi.Models.Repositories;
using MVC_webapi.Models.ServiceInterfaces;
using MVC_webapi.Models.Services;

namespace MVC_webapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Birds",
                    Version = "v1"
                });
            });
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));


            builder.Services.AddScoped<IBirdsRepository, BirdsRepository>();
            builder.Services.AddScoped<IBirdService, BirdService>();
            builder.Services.AddScoped<ICageRepository, CageRepository>();
            builder.Services.AddScoped<ICageService, CageService>();
            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Birds API V1");
                x.RoutePrefix = string.Empty;
            }
            );
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllers();


            app.Run();
        }
    }
}
