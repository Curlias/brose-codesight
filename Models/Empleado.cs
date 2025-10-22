using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brose_OnboardingDashboard.Models
{
    /// <summary>
    /// Representa un empleado de la empresa
    /// </summary>
    [Table("Empleados")]
    public class Empleado
    {
        [Key]
        [Column("id_empleado")]
        [StringLength(10)]
        public string IdEmpleado { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Column("nombre")]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido paterno es obligatorio")]
        [Column("apellido_paterno")]
        [StringLength(100)]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; } = string.Empty;

        [Column("apellido_materno")]
        [StringLength(100)]
        [Display(Name = "Apellido Materno")]
        public string? ApellidoMaterno { get; set; }

        [Column("fecha_ingreso")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }

        [Column("id_puesto")]
        [Display(Name = "Puesto")]
        public int IdPuesto { get; set; }

        [Column("id_departamento")]
        [Display(Name = "Departamento")]
        public int IdDepartamento { get; set; }

        [Column("id_jefe")]
        [StringLength(10)]
        [Display(Name = "Jefe Directo")]
        public string? IdJefe { get; set; }

        [Column("id_mentor")]
        [StringLength(10)]
        [Display(Name = "Mentor")]
        public string? IdMentor { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [Column("correo")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        [Display(Name = "Correo Electrónico")]
        public string Correo { get; set; } = string.Empty;

        [Column("telefono")]
        [StringLength(20)]
        [Phone(ErrorMessage = "Formato de teléfono inválido")]
        [Display(Name = "Teléfono")]
        public string? Telefono { get; set; }

        [Column("id_estado")]
        [Display(Name = "Estado")]
        public int IdEstado { get; set; }

        [Column("id_riesgo")]
        [Display(Name = "Riesgo de Rotación")]
        public int? IdRiesgo { get; set; }

        // Propiedades de navegación
        [ForeignKey("IdPuesto")]
        public virtual Puesto? Puesto { get; set; }

        [ForeignKey("IdDepartamento")]
        public virtual Departamento? Departamento { get; set; }

        [ForeignKey("IdEstado")]
        public virtual EstadoEmpleado? Estado { get; set; }

        [ForeignKey("IdRiesgo")]
        public virtual RiesgoRotacion? Riesgo { get; set; }

        [ForeignKey("IdJefe")]
        public virtual Empleado? Jefe { get; set; }

        [ForeignKey("IdMentor")]
        public virtual Empleado? Mentor { get; set; }

        // Navegación inversa
        public virtual ICollection<Empleado> Subordinados { get; set; } = new List<Empleado>();
        public virtual ICollection<Empleado> Mentorados { get; set; } = new List<Empleado>();
        public virtual Usuario? Usuario { get; set; }
        public virtual ICollection<EstadoChecklist> EstadosChecklist { get; set; } = new List<EstadoChecklist>();
        public virtual ICollection<PlanEntrenamiento> PlanesEntrenamiento { get; set; } = new List<PlanEntrenamiento>();

        /// <summary>
        /// Devuelve el nombre completo del empleado
        /// </summary>
        [NotMapped]
        public string NombreCompleto => $"{Nombre} {ApellidoPaterno} {ApellidoMaterno}".Trim();
    }
}
