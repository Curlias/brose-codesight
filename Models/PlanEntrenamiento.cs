using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brose_OnboardingDashboard.Models
{
    /// <summary>
    /// Representa un plan de entrenamiento asignado a un empleado
    /// </summary>
    [Table("Planes_Entrenamiento")]
    public class PlanEntrenamiento
    {
        [Key]
        [Column("id_plan")]
        public int IdPlan { get; set; }

        [Column("id_empleado")]
        [StringLength(10)]
        [Display(Name = "Empleado")]
        public string IdEmpleado { get; set; } = string.Empty;

        [Column("fecha_inicio")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Inicio")]
        public DateTime? FechaInicio { get; set; }

        [Column("fecha_fin")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Fin")]
        public DateTime? FechaFin { get; set; }

        [Column("id_estado")]
        [Display(Name = "Estado")]
        public int IdEstado { get; set; }

        // Navegación
        [ForeignKey("IdEmpleado")]
        public virtual Empleado? Empleado { get; set; }

        [ForeignKey("IdEstado")]
        public virtual EstadoTarea? Estado { get; set; }

        public virtual ICollection<TareaEntrenamiento> Tareas { get; set; } = new List<TareaEntrenamiento>();
    }
}
