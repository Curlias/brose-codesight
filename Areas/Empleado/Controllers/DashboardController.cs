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
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Dashboard personal con progreso del empleado
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var idEmpleado = User.FindFirstValue("IdEmpleado");

            // Si no hay autenticación, usar el primer empleado como demo
            if (string.IsNullOrEmpty(idEmpleado))
            {
                idEmpleado = await _context.Empleados
                    .Select(e => e.IdEmpleado)
                    .FirstOrDefaultAsync() ?? "DEMO001";
            }

            // Obtener información del empleado
            var empleado = await _context.Empleados
                .Include(e => e.Puesto)
                .Include(e => e.Departamento)
                .Include(e => e.Estado)
                .Include(e => e.Riesgo)
                .FirstOrDefaultAsync(e => e.IdEmpleado == idEmpleado);

            if (empleado == null)
            {
                return NotFound();
            }

            // Checklist: actividades completadas y pendientes
            var checklistCompletados = await _context.EstadosChecklist
                .Where(ec => ec.IdEmpleado == idEmpleado && ec.IdEstado == 3)
                .CountAsync();

            var checklistPendientes = await _context.EstadosChecklist
                .Where(ec => ec.IdEmpleado == idEmpleado && ec.IdEstado != 3)
                .Include(ec => ec.Actividad)
                .ThenInclude(a => a!.Categoria)
                .ToListAsync();

            var totalChecklist = checklistCompletados + checklistPendientes.Count;
            var porcentajeChecklist = totalChecklist > 0 
                ? (checklistCompletados * 100.0 / totalChecklist) 
                : 0;

            // Tareas de entrenamiento
            var tareasCompletadas = await _context.TareasEntrenamiento
                .Where(t => t.Plan!.IdEmpleado == idEmpleado && t.IdEstado == 3)
                .CountAsync();

            var tareasPendientes = await _context.TareasEntrenamiento
                .Where(t => t.Plan!.IdEmpleado == idEmpleado && t.IdEstado != 3)
                .Include(t => t.Estado)
                .ToListAsync();

            var totalTareas = tareasCompletadas + tareasPendientes.Count;

            // Encuestas respondidas
            var encuestasRespondidas = await _context.RespuestasEncuesta
                .Where(r => r.IdEmpleado == idEmpleado)
                .CountAsync();

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
