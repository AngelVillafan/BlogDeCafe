using BlogDeCafe.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Security.Claims;

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
        public IActionResult Categorias()
        {
            return View();
        }

        [Route("/P/{id}")]
        public IActionResult Publicacion(string id)
        {
            return View();
        }

















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
