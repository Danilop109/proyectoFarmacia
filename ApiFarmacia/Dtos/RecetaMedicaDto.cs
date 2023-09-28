using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFarmacia.Dtos
{
    public class RecetaMedicaDto
    {
        public int Id { get; set; }
        public DateTime FechaEmicion {get; set;}
        public DateTime FechaCaducidad {get; set;}
        public PersonaDto DoctorFk {get; set;}
        public PersonaDto PacienteFk {get; set;}
        public string Detalle {get; set;}

    }
}