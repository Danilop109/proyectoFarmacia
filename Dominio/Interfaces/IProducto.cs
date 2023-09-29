using Dominio.Entities;
namespace Dominio.Interfaces
{
    public interface IProducto : IGenericRepository<Producto>
    {
<<<<<<< HEAD
      Task<IEnumerable<Producto>> MedicamentosCompradosPorProveedor(string nombre);
=======
            Task<IEnumerable<Producto>> GetMediExpireBeforeDate( DateTime expireDate);
>>>>>>> 0758ef3057c78aa3976eff085edd50ccd4ef57e6
    }
    
}