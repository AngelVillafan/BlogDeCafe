using Microsoft.EntityFrameworkCore;
using BlogDeCafe.Models;
using BlogDeCafe.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Home/IniciarSesion";
    options.ExpireTimeSpan = TimeSpan.FromDays(365);
});

builder.Services.AddTransient<PublicacionesService>();
builder.Services.AddTransient<CategoriasService>();
builder.Services.AddDbContext<sistem21_DolceGustoContext>(
    optionsBuilder =>
                    optionsBuilder.UseMySql("server=198.38.83.169;user=sistem21_Villafan;database=sistem21_DolceGusto;password=Tuloseras1", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.17-mariadb"))                    
    );


builder.Services.AddMvc();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();
app.UseEndpoints(x =>
{
    x.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
    x.MapDefaultControllerRoute();
});
app.Run();
