using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_TDPC_Net6.DB;
using MVC_TDPC_Net6.DB.Entities;

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

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            builder.Services.AddDbContext<AuthDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("AuthDB")));

            builder.Services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<AuthDBContext>()
                .AddDefaultTokenProviders();
            builder.Services.AddScoped<SignInManager<User>>();
            builder.Services.AddScoped<UserManager<User>>();
            builder.Services.AddScoped<RoleManager<Role>>();


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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}