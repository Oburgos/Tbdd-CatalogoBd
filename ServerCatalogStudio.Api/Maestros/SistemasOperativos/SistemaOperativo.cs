using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerCatalogStudio.Api.Maestros.SistemasOperativos
{
    [Table("SistemasOperativos")]
    public class SistemaOperativo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="La descripción es requerida")]
        public string Descripcion { get; set; }
        public int UsuarioAgregaId { get; set; }
        public bool Activo { get; set; } = true;
    }
}
