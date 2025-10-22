using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brose_OnboardingDashboard.Models
{
    /// <summary>
    /// Representa una pregunta dentro de una encuesta
    /// </summary>
    [Table("Preguntas_Encuesta")]
    public class PreguntaEncuesta
    {
        [Key]
        [Column("id_pregunta")]
        public int IdPregunta { get; set; }

        [Column("id_encuesta")]
        [Display(Name = "Encuesta")]
        public int IdEncuesta { get; set; }

        [Column("texto_pregunta")]
        [StringLength(500)]
        [Display(Name = "Pregunta")]
        public string? TextoPregunta { get; set; }

        [Column("id_tipo_pregunta")]
        [Display(Name = "Tipo de Pregunta")]
        public int IdTipoPregunta { get; set; }

        [Column("opciones")]
        [Display(Name = "Opciones")]
        public string? Opciones { get; set; }

        // Navegación
        [ForeignKey("IdEncuesta")]
        public virtual Encuesta? Encuesta { get; set; }

        [ForeignKey("IdTipoPregunta")]
        public virtual TipoPregunta? TipoPregunta { get; set; }

        public virtual ICollection<DetalleRespuesta> DetallesRespuesta { get; set; } = new List<DetalleRespuesta>();
    }
}
