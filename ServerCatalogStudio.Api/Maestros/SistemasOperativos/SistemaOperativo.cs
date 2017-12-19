using ServerCatalogStudio.Api.Servidores;
using System.Collections.Generic;
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
        [MaxLength(50,ErrorMessage ="La descripción debe contener un máxmo de 50 caracteres")]
        public string Descripcion { get; set; }
        public int UsuarioAgregaId { get; set; }
        public bool Activo { get; set; } = true;

        public List<Servidor> Servidores { get; set; }
    }
}
