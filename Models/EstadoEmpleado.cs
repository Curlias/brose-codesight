using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brose_OnboardingDashboard.Models
{
    /// <summary>
    /// Representa el estado de un empleado (Activo, Inactivo, etc.)
    /// </summary>
    [Table("Estados_Empleado")]
    public class EstadoEmpleado
    {
        [Key]
        [Column("id_estado")]
        public int IdEstado { get; set; }

        [Required(ErrorMessage = "El nombre del estado es obligatorio")]
        [Column("nombre")]
        [StringLength(20)]
        public string Nombre { get; set; } = string.Empty;

        // Navegación
        public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
    }
}
