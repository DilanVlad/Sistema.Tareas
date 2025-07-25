using Gestion.API.Consummer;

namespace Gestion.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Crud<Modelos.Usuario>.EndPoint = "https://localhost:7105/api/Usuarios";
            Crud<Modelos.Proyecto>.EndPoint = "https://localhost:7105/api/Proyectos";
            Crud<Modelos.Tarea>.EndPoint = "https://localhost:7105/api/Tareas";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            
            var app = builder.Build();
            app.UseSession();

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
