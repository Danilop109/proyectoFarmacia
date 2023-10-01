using Dominio.Entities;
namespace Dominio.Interfaces
{
    public interface IProducto : IGenericRepository<Producto>
    {
      Task<IEnumerable<Producto>> GetMediExpireBeforeDate( DateTime expireDate);
      Task<IEnumerable<Producto>> MedicamentosCompradosPorProveedor(string nombre);
      Task<Producto> MediMoreExpensive();
      // Task<IEnumerable<Producto>> GetProductosSale(DateTime fecha);
    }
    
}