using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brose_OnboardingDashboard.Models
{
    /// <summary>
    /// Representa una actividad específica del checklist de onboarding
    /// </summary>
    [Table("Actividades_Checklist")]
    public class ActividadChecklist
    {
        [Key]
        [Column("id_actividad")]
        public int IdActividad { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [Column("descripcion")]
        [StringLength(500)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; } = string.Empty;

        [Column("id_categoria")]
        [Display(Name = "Categoría")]
        public int IdCategoria { get; set; }

        [Column("id_responsable")]
        [Display(Name = "Responsable")]
        public int IdResponsable { get; set; }

        [Column("duracion_estimada_dias")]
        [Display(Name = "Duración Estimada (días)")]
        public int? DuracionEstimadaDias { get; set; }

        // Navegación
        [ForeignKey("IdCategoria")]
        public virtual CategoriaChecklist? Categoria { get; set; }

        [ForeignKey("IdResponsable")]

        public virtual ICollection<EstadoChecklist> EstadosChecklist { get; set; } = new List<EstadoChecklist>();
    }
}
