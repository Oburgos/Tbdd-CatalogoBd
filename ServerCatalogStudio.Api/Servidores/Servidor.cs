using ServerCatalogStudio.Api.Maestros.Ambientes;
using ServerCatalogStudio.Api.Maestros.SistemasOperativos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerCatalogStudio.Api.Servidores
{
    [Table("Servidores")]
    public class Servidor
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public int Cores { get; set; }
        public decimal Ram { get; set; }
        public decimal Almacenamiento { get; set; }

        public bool Activo { get; set; } = true;
        public int ConfiguracionId { get; set; }
        public ServidorConfiguracion configuracion { get; set; }
        public int SistemaOperativoId { get; set; }
        public SistemaOperativo SistemaOperativo { get; set; }
        public int AmbienteId { get; set; }
        public Ambiente Ambiente { get; set; }
        public int UsuarioAgregaId { get; set; }
    }
}
