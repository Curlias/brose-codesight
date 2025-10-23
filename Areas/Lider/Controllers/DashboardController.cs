using Microsoft.AspNetCore.Mvc;

namespace Brose_OnboardingDashboard.Areas.Lider.Controllers
{
    [Area("Lider")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            // Datos mock para el Dashboard de Líder
            
            // Nuevos ingresos 2025 por área
            var nuevosIngresos = new
            {
                GE = 12,
                OEL = 8,
                FL = 15,
                WS = 10,
                AYS = 7
            };
            
            // Cumplimiento por área con % satisfacción/inducción
            var cumplimientoPorArea = new List<dynamic>
            {
                new { Area = "Producción", Cumplimiento = 92.5, Satisfaccion = 4.3 },
                new { Area = "Calidad", Cumplimiento = 88.0, Satisfaccion = 4.1 },
                new { Area = "Logística", Cumplimiento = 85.0, Satisfaccion = 3.9 },
                new { Area = "Ingeniería", Cumplimiento = 95.0, Satisfaccion = 4.5 }
            };
            
            // Satisfacción onboarding por área (últimos 12 meses)
            var satisfaccionPorArea = new List<dynamic>
            {
                new { Area = "Producción", Promedio = 4.2 },
                new { Area = "Calidad", Promedio = 4.0 },
                new { Area = "Logística", Promedio = 3.8 },
                new { Area = "Ingeniería", Promedio = 4.4 }
            };
            
            // Evaluation process steps (1-5 scale)
            var evaluacionProceso = new List<dynamic>
            {
                new { Step = 1, Nombre = "Contact and information before first day", Score = 4.2 },
                new { Step = 2, Nombre = "Contract / New Hire Orientation", Score = 4.5 },
                new { Step = 3, Nombre = "Job-related training", Score = 3.9 },
                new { Step = 4, Nombre = "Cultural Training", Score = 4.1 },
                new { Step = 5, Nombre = "Identification", Score = 4.3 }
            };
            
            // Vencidos de entrada satisfacción
            var vencidosSatisfaccion = new
            {
                Total = 23,
                Porcentaje = 12.5
            };
            
            // Comparación equipo actual vs histórico
            var satisfaccionComparativa = new
            {
                Actual = 4.2,
                Historico = 3.9,
                Mejora = 7.7 // %
            };
            
            // Mi equipo - empleados en proceso de onboarding
            var miEquipo = new List<dynamic>
            {
                new { Nombre = "Ana García", Puesto = "Ingeniero de Calidad", Progreso = 85, DiasOnboarding = 12, Riesgo = "Bajo" },
                new { Nombre = "Carlos López", Puesto = "Técnico de Producción", Progreso = 60, DiasOnboarding = 8, Riesgo = "Medio" },
                new { Nombre = "María Rodríguez", Puesto = "Analista de Logística", Progreso = 45, DiasOnboarding = 5, Riesgo = "Bajo" },
                new { Nombre = "José Martínez", Puesto = "Supervisor de Calidad", Progreso = 90, DiasOnboarding = 15, Riesgo = "Bajo" }
            };
            
            // Score de onboarding - ranking de líderes
            var rankingLideres = new List<dynamic>
            {
                new { Nombre = "María González", Area = "Producción", Score = 96.5, Posicion = 1, Medalla = "gold", EsUsuario = false },
                new { Nombre = "Tú", Area = "Control de Calidad", Score = 92.3, Posicion = 2, Medalla = "silver", EsUsuario = true },
                new { Nombre = "Pedro Sánchez", Area = "Ingeniería", Score = 88.7, Posicion = 3, Medalla = "bronze", EsUsuario = false },
                new { Nombre = "Laura Torres", Area = "Logística", Score = 85.2, Posicion = 4, Medalla = "", EsUsuario = false }
            };
            
            // Alertas activas del equipo
            var alertasActivas = new List<dynamic>
            {
                new { Empleado = "Carlos López", Tipo = "Checklist vencido", Dias = 3, Prioridad = "Alta" },
                new { Empleado = "María Rodríguez", Tipo = "Encuesta pendiente", Dias = 1, Prioridad = "Media" }
            };
            
            // Datos del líder
            var lider = new
            {
                Nombre = "Juan",
                Apellido = "Pérez",
                Area = "Control de Calidad",
                TotalEmpleados = 15,
                EnOnboarding = 4,
                Planta = "Benito Juarez" // Planta del líder
            };
            
            ViewBag.Lider = lider;
            ViewBag.Planta = lider.Planta; // Para mostrar en el navbar
            ViewBag.NuevosIngresos = nuevosIngresos;
            ViewBag.CumplimientoPorArea = cumplimientoPorArea;
            ViewBag.SatisfaccionPorArea = satisfaccionPorArea;
            ViewBag.EvaluacionProceso = evaluacionProceso;
            ViewBag.VencidosSatisfaccion = vencidosSatisfaccion;
            ViewBag.SatisfaccionComparativa = satisfaccionComparativa;
            ViewBag.MiEquipo = miEquipo;
            ViewBag.RankingLideres = rankingLideres;
            ViewBag.AlertasActivas = alertasActivas;
            
            return View();
        }
    }
}
