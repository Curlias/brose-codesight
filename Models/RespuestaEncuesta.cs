using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brose_OnboardingDashboard.Models
{
    /// <summary>
    /// Representa una sesión de respuesta de un empleado a una encuesta
    /// </summary>
    [Table("Respuestas_Encuesta")]
    public class RespuestaEncuesta
    {
        [Key]
        [Column("id_respuesta")]
        public int IdRespuesta { get; set; }

        [Column("id_encuesta")]
        [Display(Name = "Encuesta")]
        public int IdEncuesta { get; set; }

        [Column("id_empleado")]
        [StringLength(10)]
        [Display(Name = "Empleado")]
        public string IdEmpleado { get; set; } = string.Empty;

        [Column("fecha_respuesta")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Respuesta")]
        public DateTime FechaRespuesta { get; set; }

        [Column("puntaje_general")]
        [Display(Name = "Puntaje General")]
        public decimal? PuntajeGeneral { get; set; }

        [Column("comentarios")]
        [Display(Name = "Comentarios")]
        public string? Comentarios { get; set; }

        // Navegación
        [ForeignKey("IdEncuesta")]
        public virtual Encuesta? Encuesta { get; set; }

        [ForeignKey("IdEmpleado")]
        public virtual Empleado? Empleado { get; set; }

        public virtual ICollection<DetalleRespuesta> Detalles { get; set; } = new List<DetalleRespuesta>();
    }
}
