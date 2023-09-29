using Dominio.Entities;
namespace Dominio.Interfaces
{
    public interface IProducto : IGenericRepository<Producto>
    {
            Task<IEnumerable<Producto>> GetMediExpireBeforeDate( DateTime expireDate);
    }
}