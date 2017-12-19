using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerCatalogStudio.Api.Maestros.MotoresDeBasesDeDatos
{
    [Table("Servidores_MotoresBasesDeDatos")]
    public class MotorBaseDeDatos
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="La descripción es requerida")]
        [MaxLength(50,ErrorMessage ="La descripción debe contener un máxmo de 50 caracteres")]
        public string Descripcion { get; set; }
        public int UsuarioAgregaId { get; set; }
        public bool Activo { get; set; } = true;
    }
}
