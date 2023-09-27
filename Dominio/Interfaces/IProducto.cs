using Dominio.Entities;
namespace Dominio.Interfaces
{
    public interface IProducto : IGenericRepository<Producto>
    {
        void Remove(ProductoProveedor llamado);
    }
}