using BlogDeCafe.Models;
using Microsoft.AspNetCore.Mvc;

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

        [Route("/Categorias/{id}")]
        [Route("/Cafegorias/{id}")]
        public IActionResult Categorias()
        {
            return View();
        }

        [Route("/")]
        public IActionResult Publicacion(string id)
        {
            return View();
        }


    }
}
