using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brose_OnboardingDashboard.Models
{
    /// <summary>
    /// Representa el tipo de encuesta (Satisfacción, Clima Laboral, etc.)
    /// </summary>
    [Table("Tipos_Encuesta")]
    public class TipoEncuesta
    {
        [Key]
        [Column("id_tipo")]
        public int IdTipo { get; set; }

        [Required(ErrorMessage = "El nombre del tipo de encuesta es obligatorio")]
        [Column("nombre")]
        [StringLength(30)]
        [Display(Name = "Tipo de Encuesta")]
        public string Nombre { get; set; } = string.Empty;

        // Navegación
        public virtual ICollection<Encuesta> Encuestas { get; set; } = new List<Encuesta>();
    }
}
