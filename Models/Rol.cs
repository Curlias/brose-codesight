using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brose_OnboardingDashboard.Models
{
    /// <summary>
    /// Representa un rol de usuario en el sistema (ej: Administrador RH, Empleado)
    /// </summary>
    [Table("Roles")]
    public class Rol
    {
        [Key]
        [Column("id_rol")]
        public int IdRol { get; set; }

        [Required(ErrorMessage = "El nombre del rol es obligatorio")]
        [Column("nombre_rol")]
        [StringLength(50)]
        public string NombreRol { get; set; } = string.Empty;

        // Navegación
        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
