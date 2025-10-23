using Microsoft.AspNetCore.Mvc;

namespace Brose_OnboardingDashboard.Areas.RH.Controllers
{
    [Area("RH")]
    public class ReportesController : Controller
    {
        // Reportes Generales
        public IActionResult Generales()
        {
            // Datos generales de la organización
            ViewBag.TotalEmpleados = 67;
            ViewBag.EmpleadosActivos = 62;
            ViewBag.EmpleadosEnRiesgo = 5;
            ViewBag.ProgresoPromedio = 86.5;
            ViewBag.SatisfaccionPromedio = 4.4;
            ViewBag.TasaRetencion = 92.5;

            // Distribución por planta
            var distribucionPlanta = new List<dynamic>
            {
                new { Planta = "Planta Aguascalientes", Empleados = 25, Progreso = 88.2, Satisfaccion = 4.5 },
                new { Planta = "Planta Silao", Empleados = 20, Progreso = 85.4, Satisfaccion = 4.4 },
                new { Planta = "Planta Puebla", Empleados = 15, Progreso = 86.1, Satisfaccion = 4.3 },
                new { Planta = "Planta León", Empleados = 7, Progreso = 84.8, Satisfaccion = 4.2 }
            };

            // Distribución por área
            var distribucionArea = new List<dynamic>
            {
                new { Area = "Producción", Empleados = 25, Porcentaje = 37.3 },
                new { Area = "Ingeniería", Empleados = 18, Porcentaje = 26.9 },
                new { Area = "Calidad", Empleados = 15, Porcentaje = 22.4 },
                new { Area = "Logística", Empleados = 12, Porcentaje = 17.9 },
                new { Area = "Mantenimiento", Empleados = 10, Porcentaje = 14.9 },
                new { Area = "Finanzas", Empleados = 9, Porcentaje = 13.4 },
                new { Area = "Compras", Empleados = 11, Porcentaje = 16.4 },
                new { Area = "RH", Empleados = 8, Porcentaje = 11.9 }
            };

            // Tendencia mensual (últimos 6 meses)
            var tendenciaMensual = new List<dynamic>
            {
                new { Mes = "Enero", Ingresos = 8, Bajas = 1, ProgresoPromedio = 82.5 },
                new { Mes = "Febrero", Ingresos = 12, Bajas = 2, ProgresoPromedio = 83.8 },
                new { Mes = "Marzo", Ingresos = 10, Bajas = 1, ProgresoPromedio = 84.2 },
                new { Mes = "Abril", Ingresos = 15, Bajas = 3, ProgresoPromedio = 85.5 },
                new { Mes = "Mayo", Ingresos = 11, Bajas = 2, ProgresoPromedio = 86.0 },
                new { Mes = "Junio", Ingresos = 14, Bajas = 1, ProgresoPromedio = 86.5 }
            };

            ViewBag.DistribucionPlanta = distribucionPlanta;
            ViewBag.DistribucionArea = distribucionArea;
            ViewBag.TendenciaMensual = tendenciaMensual;

            return View();
        }

        // Riesgos de Rotación
        public IActionResult Riesgos()
        {
            // Empleados en riesgo alto
            var empleadosRiesgoAlto = new List<dynamic>
            {
                new { Id = 5, Nombre = "Pedro García", Puesto = "Operador de Producción", Area = "Producción", Lider = "María González", NivelRiesgo = "Alto", Progreso = 45, Satisfaccion = 2.8, DiasOnboarding = 75, FactoresRiesgo = new[] { "Baja satisfacción", "Progreso lento", "Tiempo prolongado" } },
                new { Id = 12, Nombre = "Elena Vázquez", Puesto = "Técnico de Calidad", Area = "Calidad", Lider = "Carlos Rodríguez", NivelRiesgo = "Alto", Progreso = 52, Satisfaccion = 3.0, DiasOnboarding = 68, FactoresRiesgo = new[] { "Baja satisfacción", "Progreso lento" } },
                new { Id = 18, Nombre = "Francisco Núñez", Puesto = "Analista de Compras", Area = "Compras", Lider = "Jorge Torres", NivelRiesgo = "Alto", Progreso = 48, Satisfaccion = 2.9, DiasOnboarding = 72, FactoresRiesgo = new[] { "Baja satisfacción", "Tiempo prolongado" } }
            };

            // Empleados en riesgo medio
            var empleadosRiesgoMedio = new List<dynamic>
            {
                new { Id = 8, Nombre = "Lucía Moreno", Puesto = "Ingeniero de Procesos", Area = "Ingeniería", Lider = "Ana Martínez", NivelRiesgo = "Medio", Progreso = 68, Satisfaccion = 3.8, DiasOnboarding = 55, FactoresRiesgo = new[] { "Satisfacción media" } },
                new { Id = 15, Nombre = "Ricardo Campos", Puesto = "Técnico de Mantenimiento", Area = "Mantenimiento", Lider = "Patricia López", NivelRiesgo = "Medio", Progreso = 72, Satisfaccion = 3.9, DiasOnboarding = 50, FactoresRiesgo = new[] { "Satisfacción media" } }
            };

            // Resumen de riesgos
            ViewBag.TotalEmpleados = 67;
            ViewBag.EmpleadosRiesgoAlto = empleadosRiesgoAlto.Count;
            ViewBag.EmpleadosRiesgoMedio = empleadosRiesgoMedio.Count;
            ViewBag.EmpleadosRiesgoBajo = 62;

            // Factores de riesgo principales
            var factoresRiesgo = new List<dynamic>
            {
                new { Factor = "Baja satisfacción (<3.5)", Empleados = 3, Porcentaje = 60.0 },
                new { Factor = "Progreso lento (<60%)", Empleados = 3, Porcentaje = 60.0 },
                new { Factor = "Tiempo prolongado (>60 días)", Empleados = 3, Porcentaje = 60.0 },
                new { Factor = "Satisfacción media (3.5-4.0)", Empleados = 2, Porcentaje = 40.0 }
            };

            ViewBag.EmpleadosRiesgoAlto = empleadosRiesgoAlto;
            ViewBag.EmpleadosRiesgoMedio = empleadosRiesgoMedio;
            ViewBag.FactoresRiesgo = factoresRiesgo;

            return View();
        }

        // Exportar Datos
        public IActionResult Exportar()
        {
            // Tipos de reportes disponibles
            var tiposReportes = new List<dynamic>
            {
                new { Id = 1, Nombre = "Reporte General de Empleados", Descripcion = "Lista completa de empleados con métricas principales", Formato = new[] { "Excel", "PDF", "CSV" } },
                new { Id = 2, Nombre = "Reporte de Progreso por Empleado", Descripcion = "Detalle del progreso individual en el plan de entrenamiento", Formato = new[] { "Excel", "PDF" } },
                new { Id = 3, Nombre = "Reporte de Satisfacción", Descripcion = "Resultados de encuestas de satisfacción por periodo", Formato = new[] { "Excel", "PDF" } },
                new { Id = 4, Nombre = "Reporte de Riesgos de Rotación", Descripcion = "Empleados en riesgo con factores identificados", Formato = new[] { "Excel", "PDF" } },
                new { Id = 5, Nombre = "Reporte de Líderes", Descripcion = "Desempeño de líderes y sus equipos", Formato = new[] { "Excel", "PDF" } },
                new { Id = 6, Nombre = "Reporte por Área", Descripcion = "Métricas consolidadas por área funcional", Formato = new[] { "Excel", "PDF" } },
                new { Id = 7, Nombre = "Reporte por Planta", Descripcion = "Métricas consolidadas por planta", Formato = new[] { "Excel", "PDF" } },
                new { Id = 8, Nombre = "Reporte Histórico", Descripcion = "Tendencias y evolución de métricas en el tiempo", Formato = new[] { "Excel", "PDF" } }
            };

            ViewBag.TiposReportes = tiposReportes;

            return View();
        }

        // Acción para simular descarga
        [HttpPost]
        public IActionResult DescargarReporte(int reporteId, string formato)
        {
            // Simular generación de reporte
            TempData["Success"] = $"Reporte generado exitosamente. Descargando en formato {formato}...";
            return RedirectToAction("Exportar");
        }
    }
}
