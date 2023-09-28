using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface IRecetaMedica : IGenericRepository<RecetaMedica>
    {
        Task<IEnumerable<RecetaMedica>> GetRecetaSinceDate(DateTime date);
    }
}