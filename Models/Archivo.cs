using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brose_OnboardingDashboard.Models
{
    /// <summary>
    /// Representa un archivo cargado en el sistema (certificados, evidencias, etc.)
    /// </summary>
    [Table("Archivos")]
    public class Archivo
    {
        [Key]
        [Column("id_archivo")]
        public int IdArchivo { get; set; }

        [Column("id_empleado")]
        [StringLength(10)]
        [Display(Name = "Empleado")]
        public string? IdEmpleado { get; set; }

        [Column("nombre_archivo")]
        [StringLength(200)]
        [Display(Name = "Nombre del Archivo")]
        public string? NombreArchivo { get; set; }

        [Column("ruta")]
        [StringLength(255)]
        public string? Ruta { get; set; }

        [Column("fecha_subida")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Subida")]
        public DateTime FechaSubida { get; set; }

        [Column("subido_por")]
        [Display(Name = "Subido Por")]
        public int? SubidoPor { get; set; }

        [Column("tipo")]
        [StringLength(50)]
        [Display(Name = "Tipo")]
        public string? Tipo { get; set; }

        // Navegación
        [ForeignKey("IdEmpleado")]
        public virtual Empleado? Empleado { get; set; }

        [ForeignKey("SubidoPor")]
        public virtual Usuario? Usuario { get; set; }
    }
}
