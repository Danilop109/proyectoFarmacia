using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class UserRepository : GenericRepository<User>, IUser
    {
        private readonly ApiFarmaciaContext _context;

        public UserRepository(ApiFarmaciaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByRefreshTokenAsync(string refreshToken)
        {
            return await _context.Users
                .Include(u => u.Rols)
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
        }

        public async Task<User> GetByUsernameAsync(string nombre)
        {
            return await _context.Users
                .Include(u => u.Rols)
                .Include(u => u.RefreshTokens)
                .Include(u => u.Persona)
                .FirstOrDefaultAsync(u => u.Username.ToLower() == nombre.ToLower());
        }
        public override async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                .ToListAsync();
        }

        public override async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}