using Microsoft.EntityFrameworkCore;
using BlogDeCafe.Models;
using BlogDeCafe.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();

builder.Services.AddTransient<PublicacionesService>();
builder.Services.AddDbContext<sistem21_DolceGustoContext>(
    optionsBuilder =>
                    optionsBuilder.UseMySql("server=198.38.83.169;user=sistem21_Villafan;database=sistem21_DolceGusto;password=Tuloseras1", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.17-mariadb"))

    );

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(x =>
{
    x.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
    x.MapDefaultControllerRoute();
});
app.Run();
