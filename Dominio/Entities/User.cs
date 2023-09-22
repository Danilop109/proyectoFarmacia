using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
    public class User: BaseEntity
    {
        public string Nombre {get; set;}
        public string Apellido {get; set;}
        public string Password {get; set;}
        public ICollection<Rol> Rols {get; set;} = new HashSet<Rol>();
        public ICollection<UserRol> UserRols {get; set;}

    }
