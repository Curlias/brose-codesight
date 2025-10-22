using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brose_OnboardingDashboard.Models
{
    /// <summary>
    /// Representa un departamento o área de la empresa
    /// </summary>
    [Table("Departamentos")]
    public class Departamento
    {
        [Key]
        [Column("id_departamento")]
        public int IdDepartamento { get; set; }

        [Required(ErrorMessage = "El nombre del departamento es obligatorio")]
        [Column("nombre")]
        [StringLength(100)]
        [Display(Name = "Nombre del Departamento")]
        public string Nombre { get; set; } = string.Empty;

        [Column("id_jefe")]
        [StringLength(10)]
        [Display(Name = "Jefe del Departamento")]
        public string? IdJefe { get; set; }

        // Navegación
        [ForeignKey("IdJefe")]
        public virtual Empleado? Jefe { get; set; }

        public virtual ICollection<Puesto> Puestos { get; set; } = new List<Puesto>();
        public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
    }
}
