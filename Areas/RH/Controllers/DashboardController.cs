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
            
            // Nuevos Ingresos 2025 por tipo de empleado
            var nuevosIngresos2025 = new
            {
                GE = 52,
                GKL = 18,
                FL = 45,
                WS = 32,
                ATS = 23,
                Total = 170
            };

            // Totales de datos usuario por período
            var tiposEmpleados = new List<dynamic>
            {
                new { Tipo = "GE", NuevoIngreso = 12, CambioPosicion = 3, Satisfaccion = 4.2 },
                new { Tipo = "GKL", NuevoIngreso = 4, CambioPosicion = 2, Satisfaccion = 4.5 },
                new { Tipo = "FL", NuevoIngreso = 8, CambioPosicion = 1, Satisfaccion = 4.3 },
                new { Tipo = "WS", NuevoIngreso = 6, CambioPosicion = 2, Satisfaccion = 4.1 },
                new { Tipo = "ATS", NuevoIngreso = 5, CambioPosicion = 1, Satisfaccion = 4.4 }
            };

            // Cumplimiento de satisfacción individual
            var cumplimientoSatisfaccion = new
            {
                Porcentaje = 87.3,
                Meta = 90.0
            };

            // Evaluation of the current Onboarding process (5 pasos)
            var evaluacionProceso = new List<dynamic>
            {
                new { Paso = 1, Nombre = "Contract and Information received first day of work", Porcentaje = 94.5, Icono = "bi-file-earmark-check" },
                new { Paso = 2, Nombre = "Gaming started / New Orientation", Porcentaje = 88.6, Icono = "bi-controller" },
                new { Paso = 3, Nombre = "Job related training", Porcentaje = 85.5, Icono = "bi-mortarboard" },
                new { Paso = 4, Nombre = "Cultural Training", Porcentaje = 78.3, Icono = "bi-people" },
                new { Paso = 5, Nombre = "Identification", Porcentaje = 92.7, Icono = "bi-person-badge" }
            };

            // Gráficos de cumplimiento por área (histórico vs actual)
            var cumplimientoPorArea = new List<dynamic>
            {
                new { Area = "AKT", Actual = 94.5, Historico = 88.6 },
                new { Area = "MKTG-1", Actual = 88.6, Historico = 82.7 },
                new { Area = "WVL", Actual = 85.2, Historico = 79.4 },
                new { Area = "MKSS", Actual = 93.5, Historico = 87.2 },
                new { Area = "MDJB", Actual = 85.8, Historico = 81.3 },
                new { Area = "RH", Actual = 91.2, Historico = 86.5 },
                new { Area = "MKTG", Actual = 88.2, Historico = 83.1 },
                new { Area = "MDJB", Actual = 87.5, Historico = 82.6 },
                new { Area = "MKSS", Actual = 92.4, Historico = 88.3 },
                new { Area = "FP", Actual = 77.6, Historico = 71.2 },
                new { Area = "MKV", Actual = 75.5, Historico = 68.9 },
                new { Area = "QU", Actual = 74.3, Historico = 69.5 },
                new { Area = "LO", Actual = 72.5, Historico = 67.8 },
                new { Area = "BPS", Actual = 58.4, Historico = 52.3 }
            };

            // Satisfacción onboarding por área
            var satisfaccionPorArea = new List<dynamic>
            {
                new { Area = "AKT", Satisfaccion = 4.8 },
                new { Area = "MKTG-1", Satisfaccion = 4.6 },
                new { Area = "WVL", Satisfaccion = 4.5 },
                new { Area = "MKSS", Satisfaccion = 4.7 },
                new { Area = "MDJB", Satisfaccion = 4.4 },
                new { Area = "RH", Satisfaccion = 4.6 },
                new { Area = "MKTG", Satisfaccion = 4.5 },
                new { Area = "FP", Satisfaccion = 3.9 },
                new { Area = "MKV", Satisfaccion = 3.8 },
                new { Area = "QU", Satisfaccion = 3.7 },
                new { Area = "LO", Satisfaccion = 3.6 },
                new { Area = "BPS", Satisfaccion = 3.2 }
            };

            // Score de onboarding por líder (TOP 4)
            var scorePorLider = new List<dynamic>
            {
                new { Posicion = 1, Nombre = "María González", Area = "Control de Calidad", Score = 95.2, Empleados = 18 },
                new { Posicion = 2, Nombre = "Juan Pérez", Area = "Control de Calidad", Score = 92.3, Empleados = 15 },
                new { Posicion = 3, Nombre = "Carlos Rodríguez", Area = "Manufactura", Score = 89.7, Empleados = 22 },
                new { Posicion = 4, Nombre = "Ana Martínez", Area = "Logística", Score = 87.5, Empleados = 12 }
            };

            // Gamificación para usuarios (medallas completadas)
            var gamificacion = new List<dynamic>
            {
                new { Usuario = "AKT", Medallas = 15 },
                new { Usuario = "MKTG-1", Medallas = 14 },
                new { Usuario = "WVL", Medallas = 13 },
                new { Usuario = "MKSS", Medallas = 13 },
                new { Usuario = "MDJB", Medallas = 12 },
                new { Usuario = "RH", Medallas = 12 },
                new { Usuario = "MKTG", Medallas = 11 },
                new { Usuario = "FP", Medallas = 10 },
                new { Usuario = "MKV", Medallas = 9 },
                new { Usuario = "QU", Medallas = 8 },
                new { Usuario = "LO", Medallas = 7 },
                new { Usuario = "BPS", Medallas = 5 }
            };

            // Benchmark entre áreas (ranking mensual)
            var benchmarkAreas = new List<dynamic>
            {
                new { Posicion = 1, Area = "Control de Calidad", Puntos = 850 },
                new { Posicion = 2, Area = "Manufactura", Puntos = 820 },
                new { Posicion = 3, Area = "Ingeniería", Puntos = 795 },
                new { Posicion = 4, Area = "Logística", Puntos = 760 }
            };

            // Semáforos por área (estado del onboarding)
            var semaforosPorArea = new List<dynamic>
            {
                new { Area = "AKT", Verde = 12, Amarillo = 3, Rojo = 1 },
                new { Area = "MKTG-1", Verde = 10, Amarillo = 4, Rojo = 2 },
                new { Area = "WVL", Verde = 8, Amarillo = 5, Rojo = 2 },
                new { Area = "MKSS", Verde = 11, Amarillo = 3, Rojo = 1 },
                new { Area = "MDJB", Verde = 9, Amarillo = 4, Rojo = 3 }
            };

            // Alertas activas
            var alertasActivas = new List<dynamic>
            {
                new { Id = 1, Tipo = "Riesgo de rotación", Empleado = "Pedro López", Area = "Logística", Prioridad = "Alta", Dias = 5 },
                new { Id = 2, Tipo = "Falta de ejecución constante", Area = "BPS", Prioridad = "Media", Dias = 3 },
                new { Id = 3, Tipo = "Dashboard burocrático", Area = "General", Prioridad = "Media", Dias = 12 },
                new { Id = 4, Tipo = "No medir impacto real", Area = "RH", Prioridad = "Baja", Dias = 8 }
            };

            // Desglose de cumplimiento por área
            var desgloseCumplimiento = new
            {
                HitosCompletados = 145,
                HitosPendientes = 32,
                NETP = 89.5,
                FeedbacksCompletados = 128
            };

            // Datos del usuario RH
            var usuarioRH = new
            {
                Nombre = "Recursos Humanos",
                Rol = "Administrador",
                Planta = "Todas las Plantas",
                TotalEmpleados = 170,
                EnOnboarding = 35
            };

            ViewBag.NuevosIngresos2025 = nuevosIngresos2025;
            ViewBag.TiposEmpleados = tiposEmpleados;
            ViewBag.CumplimientoSatisfaccion = cumplimientoSatisfaccion;
            ViewBag.EvaluacionProceso = evaluacionProceso;
            ViewBag.CumplimientoPorArea = cumplimientoPorArea;
            ViewBag.SatisfaccionPorArea = satisfaccionPorArea;
            ViewBag.ScorePorLider = scorePorLider;
            ViewBag.Gamificacion = gamificacion;
            ViewBag.BenchmarkAreas = benchmarkAreas;
            ViewBag.SemaforosPorArea = semaforosPorArea;
            ViewBag.AlertasActivas = alertasActivas;
            ViewBag.DesgloseCumplimiento = desgloseCumplimiento;
            ViewBag.UsuarioRH = usuarioRH;
            ViewBag.Planta = usuarioRH.Planta;

            return View();
        }
    }
}
