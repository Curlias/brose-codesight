using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brose_OnboardingDashboard.Models
{
    /// <summary>
    /// Representa quién es responsable de completar una actividad del checklist
    /// </summary>
    [Table("Responsables_Checklist")]
    public class ResponsableChecklist
    {
        [Key]
        [Column("id_responsable")]
        public int IdResponsable { get; set; }

        [Required(ErrorMessage = "El nombre del responsable es obligatorio")]
        [Column("nombre")]
        [StringLength(20)]
        [Display(Name = "Nombre del Responsable")]
        public string Nombre { get; set; } = string.Empty;

        // Navegación
        public virtual ICollection<ActividadChecklist> Actividades { get; set; } = new List<ActividadChecklist>();
    }
}
