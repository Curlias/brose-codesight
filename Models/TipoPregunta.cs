using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brose_OnboardingDashboard.Models
{
    /// <summary>
    /// Representa el tipo de pregunta (Escala 1-5, Sí/No, Texto libre)
    /// </summary>
    [Table("Tipos_Pregunta")]
    public class TipoPregunta
    {
        [Key]
        [Column("id_tipo_pregunta")]
        public int IdTipoPregunta { get; set; }

        [Required(ErrorMessage = "El nombre del tipo de pregunta es obligatorio")]
        [Column("nombre")]
        [StringLength(20)]
        [Display(Name = "Tipo de Pregunta")]
        public string Nombre { get; set; } = string.Empty;

        // Navegación
        public virtual ICollection<PreguntaEncuesta> Preguntas { get; set; } = new List<PreguntaEncuesta>();
    }
}
