using BlogDeCafe.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogDeCafe.Areas.Administrador.Controllers
{
    [Area(nameof(Administrador))]
    public class PublicacionesController : Controller
    {
        private readonly sistem21_DolceGustoContext context;

        public PublicacionesController(sistem21_DolceGustoContext context)
        {
            this.context = context;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
