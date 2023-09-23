using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
    public class User: BaseEntity
    {
        public string Nombre {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public int IdPersonaFk {get;}
        public Persona Persona {get; set;}
        public ICollection<RefreshToken> RefreshTokens {get; set;} = new HashSet<RefreshToken>(); 
        public ICollection<Rol> Rols {get; set;} = new HashSet<Rol>();
        public ICollection<UserRol> UserRols {get; set;}

    }
