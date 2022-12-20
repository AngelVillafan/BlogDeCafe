using BlogDeCafe.Models;

namespace BlogDeCafe.Services
{
    public class CategoriasService
    {
        private readonly sistem21_DolceGustoContext context;

        public CategoriasService(sistem21_DolceGustoContext context)
        {
            this.context = context;
        }

        public IEnumerable<Categorium> GetAll()
        {
            return context.Categoria.ToList();
        }










    }
}
