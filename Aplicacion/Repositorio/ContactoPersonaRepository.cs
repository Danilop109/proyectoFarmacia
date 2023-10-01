using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Persistencia;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repositorio
{
    public class ContactoPersonaRepository : GenericRepository<ContactoPersona>, IContactoPersona
    {
        private readonly ApiFarmaciaContext _context;
        public ContactoPersonaRepository(ApiFarmaciaContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<ContactoPersona>> GetAllAsync()
        {
            return await _context.ContactoPersonas
            .Include(p => p.Persona)
            .Include(p => p.TipoContacto)
            .ToListAsync();
        }

        public override async Task<ContactoPersona> GetByIdAsync (int id)
        {
            return await _context.ContactoPersonas
            .Include(p => p.Persona)
            .Include(p => p.TipoContacto)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}