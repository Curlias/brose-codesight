using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brose_OnboardingDashboard.Models
{
    /// <summary>
    /// Representa la respuesta específica de un empleado a una pregunta de la encuesta
    /// </summary>
    [Table("Detalle_Respuestas")]
    public class DetalleRespuesta
    {
        [Key]
        [Column("id_detalle")]
        public int IdDetalle { get; set; }

        [Column("id_respuesta")]
        [Display(Name = "Respuesta")]
        public int IdRespuesta { get; set; }

        [Column("id_pregunta")]
        [Display(Name = "Pregunta")]
        public int IdPregunta { get; set; }

        [Column("valor_numerico")]
        [Display(Name = "Valor Numérico")]
        public int? ValorNumerico { get; set; }

        [Column("valor_texto")]
        [Display(Name = "Valor Texto")]
        public string? ValorTexto { get; set; }

        // Navegación
        [ForeignKey("IdRespuesta")]
        public virtual RespuestaEncuesta? RespuestaEncuesta { get; set; }

        [ForeignKey("IdPregunta")]
        public virtual PreguntaEncuesta? Pregunta { get; set; }
    }
}
