using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCatalogStudio.Api.Auth
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] Clave { get; set; }
        public bool Activo { get; set; }
    }
}
