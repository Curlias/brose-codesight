using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brose_OnboardingDashboard.Models
{
    /// <summary>
    /// Representa una categoría de actividades del checklist de onboarding
    /// </summary>
    [Table("Categorias_Checklist")]
    public class CategoriaChecklist
    {
        [Key]
        [Column("id_categoria")]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        [Column("nombre")]
        [StringLength(50)]
        [Display(Name = "Nombre de la Categoría")]
        public string Nombre { get; set; } = string.Empty;

        // Navegación
        public virtual ICollection<ActividadChecklist> Actividades { get; set; } = new List<ActividadChecklist>();
    }
}
