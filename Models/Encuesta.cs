using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brose_OnboardingDashboard.Models
{
    /// <summary>
    /// Representa una encuesta aplicada en el sistema
    /// </summary>
    [Table("Encuestas")]
    public class Encuesta
    {
        [Key]
        [Column("id_encuesta")]
        public int IdEncuesta { get; set; }

        [Column("nombre")]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Column("descripcion")]
        [StringLength(255)]
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        [Column("dias_desde_ingreso")]
        [Display(Name = "Días desde Ingreso")]
        public int? DiasDesdIngreso { get; set; }

        [Column("id_tipo")]
        [Display(Name = "Tipo de Encuesta")]
        public int IdTipo { get; set; }

        // Navegación
        [ForeignKey("IdTipo")]
        public virtual TipoEncuesta? TipoEncuesta { get; set; }

        public virtual ICollection<PreguntaEncuesta> Preguntas { get; set; } = new List<PreguntaEncuesta>();
        public virtual ICollection<RespuestaEncuesta> Respuestas { get; set; } = new List<RespuestaEncuesta>();
    }
}
