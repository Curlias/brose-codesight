using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brose_OnboardingDashboard.Models
{
    /// <summary>
    /// Representa el estado de una actividad de checklist para un empleado específico
    /// Tabla con clave compuesta (id_empleado, id_actividad)
    /// </summary>
    [Table("Estado_Checklist")]
    public class EstadoChecklist
    {
        [Key, Column("id_empleado", Order = 0)]
        [StringLength(10)]
        public string IdEmpleado { get; set; } = string.Empty;

        [Key, Column("id_actividad", Order = 1)]
        public int IdActividad { get; set; }

        [Column("fecha_limite")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Límite")]
        public DateTime? FechaLimite { get; set; }

        [Column("fecha_completado")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Completado")]
        public DateTime? FechaCompletado { get; set; }

        [Column("id_estado")]
        [Display(Name = "Estado")]
        public int IdEstado { get; set; }

        // Navegación
        [ForeignKey("IdEmpleado")]
        public virtual Empleado? Empleado { get; set; }

        [ForeignKey("IdActividad")]
        public virtual ActividadChecklist? Actividad { get; set; }

        [ForeignKey("IdEstado")]
        public virtual EstadoTarea? Estado { get; set; }
    }
}
