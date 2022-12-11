using BlogDeCafe.Models;

namespace BlogDeCafe.Services
{
    public class PublicacionesService
    {
        private readonly sistem21_DolceGustoContext context;

        public PublicacionesService(sistem21_DolceGustoContext context)
        {
            this.context = context;
        }

        public IEnumerable<Publicacion> Get()
        {
            return context.Publicacions.Where(x => x.Archivado == false).OrderBy(y => y.FechaPublicacion);
        }


    }
}
