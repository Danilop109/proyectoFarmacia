using Dominio.Entities;
using System.Globalization;

namespace Dominio.Interfaces
{
    public interface IRecetaMedica : IGenericRepository<RecetaMedica>
    {
        Task<IEnumerable<RecetaMedica>> GetRecetaSinceDate();
    }
}