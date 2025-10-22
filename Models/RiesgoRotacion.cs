using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brose_OnboardingDashboard.Models
{
    /// <summary>
    /// Representa el nivel de riesgo de rotación de un empleado
    /// </summary>
    [Table("Riesgos_Rotacion")]
    public class RiesgoRotacion
    {
        [Key]
        [Column("id_riesgo")]
        public int IdRiesgo { get; set; }

        [Required(ErrorMessage = "El nivel de riesgo es obligatorio")]
        [Column("nivel")]
        [StringLength(10)]
        public string Nivel { get; set; } = string.Empty;

        // Navegación
        public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
    }
}
