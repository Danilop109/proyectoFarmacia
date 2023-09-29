using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFarmacia.Dtos
{
    public class PersonaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TipoDocumentoFk {get; set;}
<<<<<<< HEAD
        public TipoDocumentoDto TipoDocumentoDto {get; set;}
        public string DocumentoPer  {get; set; }
        public int IdTipoPersonaFk {get; set;}
=======
        public string Documento  {get; set; }
>>>>>>> 0758ef3057c78aa3976eff085edd50ccd4ef57e6
        public TipoPersonaDto TipoPersona {get; set; }
        public RolDto TipoRol {get; set; }

        public int IdProductoProveedor {get; set;}
        public ProductoDto ProductoDto {get;set;}

    }
}