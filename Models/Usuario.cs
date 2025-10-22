using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brose_OnboardingDashboard.Models
{
    /// <summary>
    /// Representa un usuario del sistema con acceso a la aplicación
    /// </summary>
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id_usuario")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [Column("nombre_usuario")]
        [StringLength(50)]
        [Display(Name = "Nombre de Usuario")]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [Column("contrasena_hash")]
        [StringLength(255)]
        public string ContrasenaHash { get; set; } = string.Empty;

        [Column("id_rol")]
        [Display(Name = "Rol")]
        public int IdRol { get; set; }

        [Column("id_empleado")]
        [StringLength(10)]
        [Display(Name = "Empleado")]
        public string? IdEmpleado { get; set; }

        [Column("fecha_creacion")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; }

        [Column("ultimo_acceso")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Último Acceso")]
        public DateTime? UltimoAcceso { get; set; }

        // Navegación
        [ForeignKey("IdRol")]
        public virtual Rol? Rol { get; set; }

        [ForeignKey("IdEmpleado")]
        public virtual Empleado? Empleado { get; set; }
    }
}
