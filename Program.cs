using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MVC_TDPC_Net6.DB;

namespace MVC_TDPC_Net6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //general configuration
            var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json").Build();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<Repository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}