using BlogDeCafe.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogDeCafe.Areas.Administrador.Controllers
{
    [Area(nameof(Administrador))]
    public class CategoriasController : Controller
    {
        private readonly sistem21_DolceGustoContext context;

        public CategoriasController(sistem21_DolceGustoContext context)
        {
            this.context = context;
        }







        public IActionResult Index()
        {
            return View();
        }
    }
}
