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
            
            // Obtener perfil del query string o usar default
            var nombrePerfil = Request.Query["perfil"].ToString();
            
            // Información del empleado simulada - varía según el perfil
            dynamic empleado;
            int checklistCompletados;
            int tareasCompletadas;
            string planta;
            
            if (nombrePerfil == "Juan Pérez García")
            {
                // Empleado con onboarding completado
                empleado = new
                {
                    IdEmpleado = "EMP001",
                    Nombre = "Juan",
                    ApellidoPaterno = "Pérez",
                    ApellidoMaterno = "García",
                    Email = "juan.perez@brose.com",
                    FechaIngreso = new DateTime(2024, 6, 15),
                    Puesto = new { Titulo = "Ingeniero de Manufactura" },
                    Departamento = new { Nombre = "Benito Juárez" },
                    Area = "GE - Ingeniería",
                    Estado = new { Nombre = "Activo" },
                    Riesgo = new { Nivel = "Bajo", Color = "#28a745" }
                };
                checklistCompletados = 18;
                tareasCompletadas = 12;
                planta = "Benito Juárez";
            }
            else if (nombrePerfil == "Laura Sánchez M.")
            {
                empleado = new
                {
                    IdEmpleado = "EMP002",
                    Nombre = "Laura",
                    ApellidoPaterno = "Sánchez",
                    ApellidoMaterno = "Morales",
                    Email = "laura.sanchez@brose.com",
                    FechaIngreso = new DateTime(2024, 9, 1),
                    Puesto = new { Titulo = "Analista de Calidad" },
                    Departamento = new { Nombre = "El Marqués" },
                    Area = "GKL - Control de Calidad",
                    Estado = new { Nombre = "Activo" },
                    Riesgo = new { Nivel = "Medio", Color = "#ffc107" }
                };
                checklistCompletados = 12;
                tareasCompletadas = 8;
                planta = "El Marqués";
            }
            else if (nombrePerfil == "Carlos Ramírez S.")
            {
                empleado = new
                {
                    IdEmpleado = "EMP003",
                    Nombre = "Carlos",
                    ApellidoPaterno = "Ramírez",
                    ApellidoMaterno = "Sánchez",
                    Email = "carlos.ramirez@brose.com",
                    FechaIngreso = new DateTime(2024, 10, 1),
                    Puesto = new { Titulo = "Técnico de Mantenimiento" },
                    Departamento = new { Nombre = "Aeropuerto" },
                    Area = "FL - Mantenimiento",
                    Estado = new { Nombre = "En Onboarding" },
                    Riesgo = new { Nivel = "Medio", Color = "#ffc107" }
                };
                checklistCompletados = 7;
                tareasCompletadas = 4;
                planta = "Aeropuerto";
            }
            else if (nombrePerfil == "Ana Martínez T.")
            {
                empleado = new
                {
                    IdEmpleado = "EMP004",
                    Nombre = "Ana",
                    ApellidoPaterno = "Martínez",
                    ApellidoMaterno = "Torres",
                    Email = "ana.martinez@brose.com",
                    FechaIngreso = new DateTime(2024, 7, 10),
                    Puesto = new { Titulo = "Supervisora de Línea" },
                    Departamento = new { Nombre = "Puebla" },
                    Area = "WS - Producción",
                    Estado = new { Nombre = "Activo" },
                    Riesgo = new { Nivel = "Bajo", Color = "#28a745" }
                };
                checklistCompletados = 16;
                tareasCompletadas = 10;
                planta = "Puebla";
            }
            else
            {
                // Default - Juan Pérez
                empleado = new
                {
                    IdEmpleado = "EMP001",
                    Nombre = "Juan",
                    ApellidoPaterno = "Pérez",
                    ApellidoMaterno = "García",
                    Email = "juan.perez@brose.com",
                    FechaIngreso = new DateTime(2024, 9, 15),
                    Puesto = new { Titulo = "Ingeniero de Manufactura" },
                    Departamento = new { Nombre = "Benito Juárez" },
                    Area = "GE - Ingeniería",
                    Estado = new { Nombre = "Activo" },
                    Riesgo = new { Nivel = "Bajo", Color = "#28a745" }
                };
                checklistCompletados = 15;
                tareasCompletadas = 8;
                planta = "Benito Juárez";
            }

            // Checklist: actividades completadas y pendientes
            DateTime? fecha1 = DateTime.Now.AddDays(5);
            DateTime? fecha2 = DateTime.Now.AddDays(3);
            DateTime? fecha3 = DateTime.Now.AddDays(7);
            
            var checklistPendientes = new List<dynamic>
            {
                new { Actividad = new { Descripcion = "Completar perfil de seguridad", Categoria = new { Nombre = "Seguridad" } }, FechaLimite = fecha1 },
                new { Actividad = new { Descripcion = "Reunión con mentor", Categoria = new { Nombre = "Desarrollo" } }, FechaLimite = fecha2 },
                new { Actividad = new { Descripcion = "Capacitación de herramientas", Categoria = new { Nombre = "Capacitación" } }, FechaLimite = fecha3 }
            };

            // Si el onboarding está completo, no hay pendientes
            if (nombrePerfil == "Juan Pérez García")
            {
                checklistPendientes = new List<dynamic>();
            }

            var totalChecklist = checklistCompletados + checklistPendientes.Count;
            var porcentajeChecklist = totalChecklist > 0 
                ? (checklistCompletados * 100.0 / totalChecklist) 
                : 0;

            // Tareas de entrenamiento
            DateTime? fechaTarea1 = DateTime.Now.AddDays(10);
            DateTime? fechaTarea2 = DateTime.Now.AddDays(15);
            DateTime? fechaTarea3 = DateTime.Now.AddDays(20);
            
            var tareasPendientes = new List<dynamic>
            {
                new { IdEstado = 2, Descripcion = "Módulo de introducción a C#", Estado = new { Nombre = "En Progreso" }, FechaLimite = fechaTarea1 },
                new { IdEstado = 1, Descripcion = "Curso de Git y GitHub", Estado = new { Nombre = "Pendiente" }, FechaLimite = fechaTarea2 },
                new { IdEstado = 2, Descripcion = "Certificación Azure Fundamentals", Estado = new { Nombre = "En Progreso" }, FechaLimite = fechaTarea3 }
            };

            // Si el onboarding está completo, no hay pendientes
            if (nombrePerfil == "Juan Pérez García")
            {
                tareasPendientes = new List<dynamic>();
            }

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
                    Estado = checklistCompletados >= 15 ? "Completado" : "En Progreso",
                    Fecha = new DateTime(2024, 9, 20),
                    DiasDesdeInicio = 5,
                    Icono = "bi-star"
                },
                new { 
                    Nombre = "Onboarding satisfaction",
                    Responsable = "García/QUE Q1 2025",
                    Estado = checklistCompletados >= 12 ? "En Progreso" : "Pendiente",
                    Fecha = new DateTime(2024, 10, 1),
                    DiasDesdeInicio = 16,
                    Icono = "bi-emoji-smile"
                },
                new { 
                    Nombre = "Mentorship program FLs & GKLs",
                    Responsable = "Rodríguez/QUE Q2 2025",
                    Estado = checklistCompletados >= 10 ? "En Progreso" : "Pendiente",
                    Fecha = new DateTime(2024, 10, 15),
                    DiasDesdeInicio = 30,
                    Icono = "bi-people"
                },
                new { 
                    Nombre = "CSRs Effectiveness",
                    Responsable = "Rodríguez/QUE Q2 2025",
                    Estado = checklistCompletados >= 18 ? "Completado" : "Pendiente",
                    Fecha = new DateTime(2024, 11, 1),
                    DiasDesdeInicio = 47,
                    Icono = "bi-graph-up-arrow"
                },
                new { 
                    Nombre = "Priorities technologies definition",
                    Responsable = "Ortega/QUE Q2 2025",
                    Estado = checklistCompletados >= 18 ? "Completado" : "Pendiente",
                    Fecha = new DateTime(2024, 11, 15),
                    DiasDesdeInicio = 61,
                    Icono = "bi-cpu"
                },
                new { 
                    Nombre = "Training plan key positions (LO, IE, QU)",
                    Responsable = "García/QUE Q2 2025",
                    Estado = checklistCompletados >= 18 ? "Completado" : "Pendiente",
                    Fecha = new DateTime(2024, 12, 1),
                    DiasDesdeInicio = 77,
                    Icono = "bi-mortarboard"
                },
                new { 
                    Nombre = "Product and process knowledge training program",
                    Responsable = "Ortega/QUE Q2 2025",
                    Estado = checklistCompletados >= 18 ? "Completado" : "Pendiente",
                    Fecha = new DateTime(2024, 12, 15),
                    DiasDesdeInicio = 91,
                    Icono = "bi-lightbulb"
                }
            };

            ViewBag.Empleado = empleado;
            ViewBag.Planta = planta;
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
