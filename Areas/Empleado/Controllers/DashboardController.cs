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
                Puesto = new { Titulo = "Ingeniero de Software" },
                Departamento = new { Nombre = "Desarrollo" },
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

            ViewBag.Empleado = empleado;
            ViewBag.ChecklistCompletados = checklistCompletados;
            ViewBag.ChecklistPendientes = checklistPendientes;
            ViewBag.PorcentajeChecklist = Math.Round(porcentajeChecklist, 1);
            ViewBag.TareasCompletadas = tareasCompletadas;
            ViewBag.TareasPendientes = tareasPendientes;
            ViewBag.TotalTareas = totalTareas;
            ViewBag.EncuestasRespondidas = encuestasRespondidas;
            ViewBag.DiasTrabajados = diasTrabajados;

            return View();
        }
    }
}
