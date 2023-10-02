using Dominio.Entities;
namespace Dominio.Interfaces
{
    public interface IProducto : IGenericRepository<Producto>
    {
      Task<IEnumerable<Producto>> GetMediExpireBeforeDate();
      Task<IEnumerable<Producto>> MedicamentosCompradosPorProveedor(string nombre);
      Task<Producto> MediMoreExpensive();
      // Task<IEnumerable<Producto>> GetProductosSale(DateTime fecha);
      Task<IEnumerable<Producto>> GetProductosPrecioMayorA50StockMenorA100();
      Task<IEnumerable<object>> GetTotMediVenProveedor();
    }
    
}