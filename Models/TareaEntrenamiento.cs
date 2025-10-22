using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brose_OnboardingDashboard.Models
{
    /// <summary>
    /// Representa una tarea específica dentro de un plan de entrenamiento
    /// </summary>
    [Table("Tareas_Entrenamiento")]
    public class TareaEntrenamiento
    {
        [Key]
        [Column("id_tarea")]
        public int IdTarea { get; set; }

        [Column("id_plan")]
        [Display(Name = "Plan de Entrenamiento")]
        public int IdPlan { get; set; }

        [Required(ErrorMessage = "La descripción de la tarea es obligatoria")]
        [Column("descripcion")]
        [StringLength(500)]
        [Display(Name = "Descripción de la Tarea")]
        public string Descripcion { get; set; } = string.Empty;

        [Column("id_responsable")]
        [StringLength(10)]
        [Display(Name = "Responsable")]
        public string? IdResponsable { get; set; }

        [Column("id_estado")]
        [Display(Name = "Estado")]
        public int IdEstado { get; set; }

        [Column("fecha_limite")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Límite")]
        public DateTime? FechaLimite { get; set; }

        [Column("fecha_completado")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Completado")]
        public DateTime? FechaCompletado { get; set; }

        // Navegación
        [ForeignKey("IdPlan")]
        public virtual PlanEntrenamiento? Plan { get; set; }

        [ForeignKey("IdResponsable")]
        public virtual Empleado? Responsable { get; set; }

        [ForeignKey("IdEstado")]
        public virtual EstadoTarea? Estado { get; set; }
    }
}
