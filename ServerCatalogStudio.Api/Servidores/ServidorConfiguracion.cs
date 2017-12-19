using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerCatalogStudio.Api.Servidores
{
    [Table("Servidores_Configuraciones_MotorBaseDeDatos")]
    public class ServidorConfiguracion
    {
        [Key]
        public int Id { get; set; }
        public int MotorBaseDeDatosId { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Direccion { get; set; }
        public string Puerto { get; set; }
        public int UsuarioAgregaId { get; set; }
        public bool Activo { get; set; } = true;
        public List<Servidor> Servidores { get; set; }
    }
}
