using Microsoft.AspNetCore.Mvc;

namespace BlogDeCafe.Areas.Administrador.Controllers
{
    [Area(nameof(Administrador))]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
