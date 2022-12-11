using Microsoft.AspNetCore.Mvc;

namespace BlogDeCafe.Controllers
{
    public class HomeController : Controller
    {



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


    }
}
