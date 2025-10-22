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
        // private readonly ApplicationDbContext _context;

        // public DashboardController(ApplicationDbContext context)
        // {
        //     _context = context;
        // }

        /// <summary>
        /// Dashboard principal con KPIs de RH - VERSIÓN MOCK PARA PRUEBAS DE FRONTEND
        /// </summary>
        public IActionResult Index()
        {
            // DATOS MOCK - Sin conexión a base de datos
            
            // KPI 1: Nuevos ingresos por mes (últimos 12 meses)
            var nuevosIngresosPorMes = new List<dynamic>
            {
                new { Mes = "11/2024", Cantidad = 5 },
                new { Mes = "12/2024", Cantidad = 8 },
                new { Mes = "01/2025", Cantidad = 12 },
                new { Mes = "02/2025", Cantidad = 7 },
                new { Mes = "03/2025", Cantidad = 15 },
                new { Mes = "04/2025", Cantidad = 10 },
                new { Mes = "05/2025", Cantidad = 9 },
                new { Mes = "06/2025", Cantidad = 11 },
                new { Mes = "07/2025", Cantidad = 14 },
                new { Mes = "08/2025", Cantidad = 13 },
                new { Mes = "09/2025", Cantidad = 16 },
                new { Mes = "10/2025", Cantidad = 18 }
            };

            // KPI 2: Porcentaje de checklist completado
            var porcentajeChecklist = 78.5;

            // KPI 3: Promedio de satisfacción por tipo de encuesta
            var promedioSatisfaccion = new List<dynamic>
            {
                new { TipoEncuesta = "Onboarding - Día 30", Promedio = 4.2 },
                new { TipoEncuesta = "Onboarding - Día 60", Promedio = 4.5 },
                new { TipoEncuesta = "Onboarding - Día 90", Promedio = 4.3 },
                new { TipoEncuesta = "Clima Laboral", Promedio = 4.1 }
            };

            // KPI 4: Distribución de riesgo de rotación
            var distribucionRiesgo = new List<dynamic>
            {
                new { Nivel = "Bajo", Cantidad = 45 },
                new { Nivel = "Medio", Cantidad = 28 },
                new { Nivel = "Alto", Cantidad = 12 }
            };

            // KPI adicionales
            var totalEmpleadosActivos = 85;
            var tareasEntrenamientoPendientes = 34;
            var encuestasActivas = 5;

            ViewBag.NuevosIngresosPorMes = nuevosIngresosPorMes;
            ViewBag.PorcentajeChecklist = porcentajeChecklist;
            ViewBag.PromedioSatisfaccion = promedioSatisfaccion;
            ViewBag.DistribucionRiesgo = distribucionRiesgo;
            ViewBag.TotalEmpleadosActivos = totalEmpleadosActivos;
            ViewBag.TareasEntrenamientoPendientes = tareasEntrenamientoPendientes;
            ViewBag.EncuestasActivas = encuestasActivas;

            return View();
        }
    }
}
