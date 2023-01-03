using BlogDeCafe.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using BlogDeCafe.Models.ViewModels;

namespace BlogDeCafe.Controllers
{
    public class HomeController : Controller
    {
        private readonly sistem21_DolceGustoContext context;

        public HomeController(sistem21_DolceGustoContext context)
        {
            this.context = context;
        }


        [Route("/")]
        [Route("/home")]
        [Route("/principal")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Cat/{id}")]
        public IActionResult Categorias(string id)
        {
            id = id.Replace("-", " ");
            var datos = context.Categoria.Include(x => x.Publicacions).Where(x => x.Nombre == id).Select(x => new CategoriaViewModel
            {
                NombreCategoria = x.Nombre,
                Id = x.Id,
                Publicacion = x.Publicacions.Select(x => new Publicacion
                {
                    Id = x.Id,
                    Titulo = x.Titulo,
                    FechaPublicacion = x.FechaPublicacion
                })
            }).FirstOrDefault();
            return View(datos);
        }

        [Route("/P/{id}")]
        [Route("/Publicaciones/{id}")]
        public IActionResult Publicacion(string? id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return RedirectToAction(nameof(Index));
            }
            id = id.Replace("-", " ");
            var publicacion = context.Publicacions.Include(x => x.Comentarios).FirstOrDefault(x=>x.Titulo == id);
            if (publicacion == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(publicacion);
            }
        }

        [Route("/about")]
        [Route("/acercade")]
        [Route("/Nosotros")]
        public IActionResult Nosotros()
        {
            return View();
        }


        [Route("/Publicaciones")]
        [Route("/P")]
        public IActionResult VerTodo()
        {
            var publicaciones = context.Publicacions.OrderBy(x => x.FechaPublicacion);
            return View(publicaciones);
        }










        [Route("/Admin")]
        [Route("/IniciarSesion")]
        [HttpGet]
        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IniciarSesion(Login login)
        {
            if (login.UserName == "JennyCoffee" && login.Password == "arabica")
            {
                // Crear los claims (datos sobre quien se logeo)
                var listaClaims = new List<Claim>()
                {
                    new Claim("Id", "1"),
                    new Claim(ClaimTypes.Name, "Jennifer Alamilla"),
                    new Claim(ClaimTypes.Role, "Administrador") //Impersonalizacion
                };

                // Crear la identidad 
                var identidad = new ClaimsIdentity(listaClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Autenticsr
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identidad), new AuthenticationProperties()
                {

                });

                return RedirectToAction("Index", "Home", new { Area = "Administrador" });
            }
            else
            {
                ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectas");
                return View(login);
            }

        }

        public IActionResult CerrarSesion()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }










    }
}
