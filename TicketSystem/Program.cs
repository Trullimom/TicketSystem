using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TicketSystem.Models;
using TicketSystem.Models.Data;

namespace TicketSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AnwendungsDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<ITicketsystemRepository, AnfragenListe>();


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {

                var services = scope.ServiceProvider;

                var context = services.GetService<AnwendungsDbContext>();

                DbInitializer.Initialize(context);
            }

            // Test 
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
            //
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

              


        }
    }
}
