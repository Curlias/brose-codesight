using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Brose_OnboardingDashboard.Data;

namespace Brose_OnboardingDashboard.Areas.Empleado.Controllers
{
    /// <summary>
    /// Controlador del Dashboard Personal del Empleado
    /// </summary>
    [Area("Empleado")]
    // [Authorize(Policy = "RequiereEmpleado")] // Deshabilitado temporalmente para desarrollo
    public class DashboardController : Controller
    {
        // private readonly ApplicationDbContext _context;

        // public DashboardController(ApplicationDbContext context)
        // {
        //     _context = context;
        // }

        /// <summary>
        /// Dashboard personal con progreso del empleado - VERSIÓN MOCK PARA PRUEBAS DE FRONTEND
        /// </summary>
        public IActionResult Index()
        {
            // DATOS MOCK - Sin conexión a base de datos
            
            // Información del empleado simulada
            var empleado = new
            {
                IdEmpleado = "EMP001",
                Nombre = "Juan",
                ApellidoPaterno = "Pérez",
                ApellidoMaterno = "García",
                Email = "juan.perez@brose.com",
                FechaIngreso = new DateTime(2024, 9, 15),
                Puesto = new { Titulo = "Gerente de Calidad" },
                Departamento = new { Nombre = "Benito Juarez" }, // Esta es la planta
                Area = "Control de Calidad", // Área real de trabajo
                Estado = new { Nombre = "Activo" },
                Riesgo = new { Nivel = "Bajo", Color = "#28a745" }
            };

            // Checklist: actividades completadas y pendientes
            var checklistCompletados = 15;
            
            DateTime? fecha1 = DateTime.Now.AddDays(5);
            DateTime? fecha2 = DateTime.Now.AddDays(3);
            DateTime? fecha3 = DateTime.Now.AddDays(7);
            
            var checklistPendientes = new List<dynamic>
            {
                new { Actividad = new { Descripcion = "Completar perfil de seguridad", Categoria = new { Nombre = "Seguridad" } }, FechaLimite = fecha1 },
                new { Actividad = new { Descripcion = "Reunión con mentor", Categoria = new { Nombre = "Desarrollo" } }, FechaLimite = fecha2 },
                new { Actividad = new { Descripcion = "Capacitación de herramientas", Categoria = new { Nombre = "Capacitación" } }, FechaLimite = fecha3 }
            };

            var totalChecklist = checklistCompletados + checklistPendientes.Count;
            var porcentajeChecklist = totalChecklist > 0 
                ? (checklistCompletados * 100.0 / totalChecklist) 
                : 0;

            // Tareas de entrenamiento
            var tareasCompletadas = 8;
            
            DateTime? fechaTarea1 = DateTime.Now.AddDays(10);
            DateTime? fechaTarea2 = DateTime.Now.AddDays(15);
            DateTime? fechaTarea3 = DateTime.Now.AddDays(20);
            
            var tareasPendientes = new List<dynamic>
            {
                new { IdEstado = 2, Descripcion = "Módulo de introducción a C#", Estado = new { Nombre = "En Progreso" }, FechaLimite = fechaTarea1 },
                new { IdEstado = 1, Descripcion = "Curso de Git y GitHub", Estado = new { Nombre = "Pendiente" }, FechaLimite = fechaTarea2 },
                new { IdEstado = 2, Descripcion = "Certificación Azure Fundamentals", Estado = new { Nombre = "En Progreso" }, FechaLimite = fechaTarea3 }
            };

            var totalTareas = tareasCompletadas + tareasPendientes.Count;

            // Encuestas respondidas
            var encuestasRespondidas = 2;

            // Días trabajados
            var diasTrabajados = (DateTime.Now - empleado.FechaIngreso).Days;

            // Roadmap de Onboarding - Training & onboarding
            var roadmapOnboarding = new List<dynamic>
            {
                new { 
                    Nombre = "Induction program innovation",
                    Responsable = "Rodríguez/QUE Q1 2025",
                    Estado = "Completado", // Completado, En Progreso, Pendiente, Atrasado
                    Fecha = new DateTime(2024, 9, 15),
                    DiasDesdeInicio = 0,
                    Icono = "bi-clipboard-check"
                },
                new { 
                    Nombre = "Skill matrix Prio 1 - NETP 100%",
                    Responsable = "Rodríguez/QUE Q1 2025",
                    Estado = "Completado",
                    Fecha = new DateTime(2024, 9, 20),
                    DiasDesdeInicio = 5,
                    Icono = "bi-star"
                },
                new { 
                    Nombre = "Onboarding satisfaction",
                    Responsable = "García/QUE Q1 2025",
                    Estado = "En Progreso",
                    Fecha = new DateTime(2024, 10, 1),
                    DiasDesdeInicio = 16,
                    Icono = "bi-emoji-smile"
                },
                new { 
                    Nombre = "Mentorship program FLs & GKLs",
                    Responsable = "Rodríguez/QUE Q2 2025",
                    Estado = "En Progreso",
                    Fecha = new DateTime(2024, 10, 15),
                    DiasDesdeInicio = 30,
                    Icono = "bi-people"
                },
                new { 
                    Nombre = "CSRs Effectiveness",
                    Responsable = "Rodríguez/QUE Q2 2025",
                    Estado = "Pendiente",
                    Fecha = new DateTime(2024, 11, 1),
                    DiasDesdeInicio = 47,
                    Icono = "bi-graph-up-arrow"
                },
                new { 
                    Nombre = "Priorities technologies definition",
                    Responsable = "Ortega/QUE Q2 2025",
                    Estado = "Pendiente",
                    Fecha = new DateTime(2024, 11, 15),
                    DiasDesdeInicio = 61,
                    Icono = "bi-cpu"
                },
                new { 
                    Nombre = "Training plan key positions (LO, IE, QU)",
                    Responsable = "García/QUE Q2 2025",
                    Estado = "Pendiente",
                    Fecha = new DateTime(2024, 12, 1),
                    DiasDesdeInicio = 77,
                    Icono = "bi-mortarboard"
                },
                new { 
                    Nombre = "Product and process knowledge training program",
                    Responsable = "Ortega/QUE Q2 2025",
                    Estado = "Pendiente",
                    Fecha = new DateTime(2024, 12, 15),
                    DiasDesdeInicio = 91,
                    Icono = "bi-lightbulb"
                }
            };

            ViewBag.Empleado = empleado;
            ViewBag.Planta = empleado.Departamento.Nombre; // Para mostrar en el navbar
            ViewBag.ChecklistCompletados = checklistCompletados;
            ViewBag.ChecklistPendientes = checklistPendientes;
            ViewBag.PorcentajeChecklist = Math.Round(porcentajeChecklist, 1);
            ViewBag.TareasCompletadas = tareasCompletadas;
            ViewBag.TareasPendientes = tareasPendientes;
            ViewBag.TotalTareas = totalTareas;
            ViewBag.EncuestasRespondidas = encuestasRespondidas;
            ViewBag.DiasTrabajados = diasTrabajados;
            ViewBag.RoadmapOnboarding = roadmapOnboarding;

            return View();
        }
    }
}
