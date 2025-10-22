using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Brose_OnboardingDashboard.Data;

namespace Brose_OnboardingDashboard.Areas.RH.Controllers
{
    /// <summary>
    /// Controlador del Dashboard de RH con KPIs ejecutivos
    /// </summary>
    [Area("RH")]
    // [Authorize(Policy = "RequiereRH")] // Deshabilitado temporalmente para desarrollo
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Dashboard principal con KPIs de RH
        /// </summary>
        public async Task<IActionResult> Index()
        {
            // KPI 1: Nuevos ingresos por mes (últimos 12 meses)
            var haceUnAno = DateTime.Now.AddMonths(-12);
            var nuevosIngresosPorMes = await _context.Empleados
                .Where(e => e.FechaIngreso >= haceUnAno)
                .GroupBy(e => new { e.FechaIngreso.Year, e.FechaIngreso.Month })
                .Select(g => new
                {
                    Mes = $"{g.Key.Month}/{g.Key.Year}",
                    Cantidad = g.Count()
                })
                .OrderBy(x => x.Mes)
                .ToListAsync();

            // KPI 2: Porcentaje de checklist completado
            var totalActividades = await _context.EstadosChecklist.CountAsync();
            var actividadesCompletadas = await _context.EstadosChecklist
                .Where(ec => ec.IdEstado == 3) // 3 = Completado
                .CountAsync();
            var porcentajeChecklist = totalActividades > 0 
                ? (actividadesCompletadas * 100.0 / totalActividades) 
                : 0;

            // KPI 3: Promedio de satisfacción por tipo de encuesta
            var promedioSatisfaccion = await _context.RespuestasEncuesta
                .GroupBy(r => r.Encuesta!.TipoEncuesta!.Nombre)
                .Select(g => new
                {
                    TipoEncuesta = g.Key,
                    Promedio = g.Average(r => r.PuntajeGeneral ?? 0)
                })
                .ToListAsync();

            // KPI 4: Distribución de riesgo de rotación
            var distribucionRiesgo = await _context.Empleados
                .Where(e => e.IdEstado == 1) // Solo empleados activos
                .GroupBy(e => e.Riesgo!.Nivel)
                .Select(g => new
                {
                    Nivel = g.Key,
                    Cantidad = g.Count()
                })
                .ToListAsync();

            var totalEmpleados = distribucionRiesgo.Sum(d => d.Cantidad);

            // KPI adicionales
            var totalEmpleadosActivos = await _context.Empleados.CountAsync(e => e.IdEstado == 1);
            var tareasEntrenamientoPendientes = await _context.TareasEntrenamiento
                .CountAsync(t => t.IdEstado == 1); // Pendiente
            var encuestasActivas = await _context.Encuestas.CountAsync();

            ViewBag.NuevosIngresosPorMes = nuevosIngresosPorMes;
            ViewBag.PorcentajeChecklist = Math.Round(porcentajeChecklist, 1);
            ViewBag.PromedioSatisfaccion = promedioSatisfaccion;
            ViewBag.DistribucionRiesgo = distribucionRiesgo;
            ViewBag.TotalEmpleadosActivos = totalEmpleadosActivos;
            ViewBag.TareasEntrenamientoPendientes = tareasEntrenamientoPendientes;
            ViewBag.EncuestasActivas = encuestasActivas;

            return View();
        }
    }
}
