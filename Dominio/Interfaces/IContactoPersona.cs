using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface IContactoPersona : IGenericRepository<ContactoPersona>
    {
         Task<IEnumerable<object>> GetContactSupplier();
    }
}