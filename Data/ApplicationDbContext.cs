using Microsoft.EntityFrameworkCore;
using Brose_OnboardingDashboard.Models;

namespace Brose_OnboardingDashboard.Data
{
    /// <summary>
    /// Contexto de base de datos para el sistema de onboarding de Brose
    /// Maneja todas las entidades y relaciones del sistema
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets para todas las entidades del sistema
        public DbSet<Rol> Roles { get; set; }
        public DbSet<EstadoEmpleado> EstadosEmpleado { get; set; }
        public DbSet<RiesgoRotacion> RiesgosRotacion { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<CategoriaChecklist> CategoriasChecklist { get; set; }
        public DbSet<ResponsableChecklist> ResponsablesChecklist { get; set; }
        public DbSet<ActividadChecklist> ActividadesChecklist { get; set; }
        public DbSet<EstadoChecklist> EstadosChecklist { get; set; }
        public DbSet<EstadoTarea> EstadosTarea { get; set; }
        public DbSet<PlanEntrenamiento> PlanesEntrenamiento { get; set; }
        public DbSet<TareaEntrenamiento> TareasEntrenamiento { get; set; }
        public DbSet<TipoEncuesta> TiposEncuesta { get; set; }
        public DbSet<TipoPregunta> TiposPreguntas { get; set; }
        public DbSet<Encuesta> Encuestas { get; set; }
        public DbSet<PreguntaEncuesta> PreguntasEncuesta { get; set; }
        public DbSet<RespuestaEncuesta> RespuestasEncuesta { get; set; }
        public DbSet<DetalleRespuesta> DetallesRespuesta { get; set; }
        public DbSet<HistorialRiesgo> HistorialRiesgos { get; set; }
        public DbSet<Archivo> Archivos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de EstadoChecklist con clave compuesta
            modelBuilder.Entity<EstadoChecklist>()
                .HasKey(ec => new { ec.IdEmpleado, ec.IdActividad });

            // Configuración de relaciones auto-referentes de Empleado (Jefe y Mentor)
            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Jefe)
                .WithMany(e => e.Subordinados)
                .HasForeignKey(e => e.IdJefe)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Mentor)
                .WithMany(e => e.Mentorados)
                .HasForeignKey(e => e.IdMentor)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de relación Departamento-Empleado
            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Departamento)
                .WithMany(d => d.Empleados)
                .HasForeignKey(e => e.IdDepartamento)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de relación Departamento.Jefe
            modelBuilder.Entity<Departamento>()
                .HasOne(d => d.Jefe)
                .WithMany()
                .HasForeignKey(d => d.IdJefe)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de índices para mejorar el rendimiento
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.NombreUsuario)
                .IsUnique();

            modelBuilder.Entity<Empleado>()
                .HasIndex(e => e.Correo)
                .IsUnique();

            // Valores predeterminados
            modelBuilder.Entity<Archivo>()
                .Property(a => a.FechaSubida)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<RespuestaEncuesta>()
                .Property(r => r.FechaRespuesta)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<HistorialRiesgo>()
                .Property(hr => hr.FechaCalculo)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Usuario>()
                .Property(u => u.FechaCreacion)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
