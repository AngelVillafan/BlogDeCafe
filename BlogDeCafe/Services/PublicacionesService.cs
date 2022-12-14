using BlogDeCafe.Models;
using BlogDeCafe.Models.ViewModels;

namespace BlogDeCafe.Services
{
    public class PublicacionesService
    {
        private readonly sistem21_DolceGustoContext context;

        public PublicacionesService(sistem21_DolceGustoContext context)
        {
            this.context = context;
        }

        //ViewModel para que no se lleve tanta informacion
        public IEnumerable<HomeViewModel> GetCuatroMasComentadas()
        {
            return context.Publicacions.Select(x => new HomeViewModel()
            { 
                Id = x.Id, FechaPublicacion = x.FechaPublicacion, Titulo = x.Titulo, Archivado = x.Archivado, TotalComentarios = x.Comentarios.Count }
            )
            .Where(x => x.Archivado == false).OrderBy(y => y.FechaPublicacion).ToList();
        }

        //ViewModel para que no se lleve tanta informacion
        public IEnumerable<Publicacion> GetCuatroMasRecientes()
        {
            return context.Publicacions.Where(x => x.Archivado == false).OrderBy(y => y.FechaPublicacion).Take(4).ToList();
        }

        //ViewModel para que no se lleve tanta informacion
        public IEnumerable<Publicacion> GetAll()
        {
            return context.Publicacions.Where(x => x.Archivado == false).OrderBy(y => y.FechaPublicacion).ToList();
        }

    }
}
