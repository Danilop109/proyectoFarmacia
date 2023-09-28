using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface IProductoProveedor : IGenericRepository<ProductoProveedor>
    {

        Task<IEnumerable<ProductoProveedor>> ObtenerTodaInformacion();
    }
}