using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brose_OnboardingDashboard.Models
{
    /// <summary>
    /// Representa el historial de cambios en el riesgo de rotación de un empleado
    /// </summary>
    [Table("Historial_Riesgo")]
    public class HistorialRiesgo
    {
        [Key]
        [Column("id_historial")]
        public int IdHistorial { get; set; }

        [Column("id_empleado")]
        [StringLength(10)]
        [Display(Name = "Empleado")]
        public string? IdEmpleado { get; set; }

        [Column("fecha_calculo")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Cálculo")]
        public DateTime FechaCalculo { get; set; }

        [Column("id_riesgo")]
        [Display(Name = "Riesgo")]
        public int IdRiesgo { get; set; }

        [Column("factores")]
        [Display(Name = "Factores")]
        public string? Factores { get; set; }

        // Navegación
        [ForeignKey("IdEmpleado")]
        public virtual Empleado? Empleado { get; set; }

        [ForeignKey("IdRiesgo")]
        public virtual RiesgoRotacion? Riesgo { get; set; }
    }
}
