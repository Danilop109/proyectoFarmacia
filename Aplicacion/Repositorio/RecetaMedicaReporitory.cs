using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class RecetaMedicaReporitory : GenericRepository<RecetaMedica>, IRecetaMedica
    {
        public RecetaMedicaReporitory(ApiFarmaciaContext context) : base(context)
        {
        }
    }
}