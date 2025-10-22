using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brose_OnboardingDashboard.Models
{
    /// <summary>
    /// Representa el estado de una tarea de entrenamiento (Pendiente, En Progreso, Completada)
    /// </summary>
    [Table("Estados_Tarea")]
    public class EstadoTarea
    {
        [Key]
        [Column("id_estado_tarea")]
        public int IdEstadoTarea { get; set; }

        [Required(ErrorMessage = "El nombre del estado es obligatorio")]
        [Column("nombre")]
        [StringLength(20)]
        [Display(Name = "Estado de la Tarea")]
        public string Nombre { get; set; } = string.Empty;

        // Navegación
        public virtual ICollection<TareaEntrenamiento> Tareas { get; set; } = new List<TareaEntrenamiento>();
    }
}
