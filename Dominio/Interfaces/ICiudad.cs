using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface ICiudad : IGenericRepository<Ciudad>
    {
        Task<Ciudad> GetByIdAsync(string id);
    }
}