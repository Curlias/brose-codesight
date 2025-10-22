using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brose_OnboardingDashboard.Models
{
    /// <summary>
    /// Representa un puesto de trabajo en la empresa
    /// </summary>
    [Table("Puestos")]
    public class Puesto
    {
        [Key]
        [Column("id_puesto")]
        public int IdPuesto { get; set; }

        [Required(ErrorMessage = "El título del puesto es obligatorio")]
        [Column("titulo")]
        [StringLength(100)]
        [Display(Name = "Título del Puesto")]
        public string Titulo { get; set; } = string.Empty;

        [Column("descripcion")]
        [StringLength(255)]
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        [Column("nivel_competencia")]
        [StringLength(50)]
        [Display(Name = "Nivel de Competencia")]
        public string? NivelCompetencia { get; set; }

        [Column("id_departamento")]
        [Display(Name = "Departamento")]
        public int? IdDepartamento { get; set; }

        // Navegación
        [ForeignKey("IdDepartamento")]
        public virtual Departamento? Departamento { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
    }
}
