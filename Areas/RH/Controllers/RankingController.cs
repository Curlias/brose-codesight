using Microsoft.AspNetCore.Mvc;

namespace Brose_OnboardingDashboard.Areas.RH.Controllers
{
    [Area("RH")]
    public class RankingController : Controller
    {
        public IActionResult Index()
        {
            // Ranking de Líderes por Desempeño
            var rankingLideres = new List<dynamic>
            {
                new { Posicion = 1, Nombre = "María González", Area = "Producción", EmpleadosACargo = 12, ProgresoPromedio = 92.3, SatisfaccionPromedio = 4.8, RiesgoPromedio = "Bajo", Puntuacion = 95.5 },
                new { Posicion = 2, Nombre = "Carlos Rodríguez", Area = "Calidad", EmpleadosACargo = 8, ProgresoPromedio = 88.5, SatisfaccionPromedio = 4.7, RiesgoPromedio = "Bajo", Puntuacion = 92.0 },
                new { Posicion = 3, Nombre = "Ana Martínez", Area = "Ingeniería", EmpleadosACargo = 10, ProgresoPromedio = 87.2, SatisfaccionPromedio = 4.6, RiesgoPromedio = "Bajo", Puntuacion = 90.5 },
                new { Posicion = 4, Nombre = "Luis Fernández", Area = "Logística", EmpleadosACargo = 9, ProgresoPromedio = 85.4, SatisfaccionPromedio = 4.5, RiesgoPromedio = "Medio", Puntuacion = 88.0 },
                new { Posicion = 5, Nombre = "Patricia López", Area = "Mantenimiento", EmpleadosACargo = 7, ProgresoPromedio = 83.6, SatisfaccionPromedio = 4.4, RiesgoPromedio = "Medio", Puntuacion = 86.5 },
                new { Posicion = 6, Nombre = "Roberto Sánchez", Area = "RH", EmpleadosACargo = 5, ProgresoPromedio = 81.0, SatisfaccionPromedio = 4.3, RiesgoPromedio = "Medio", Puntuacion = 84.0 },
                new { Posicion = 7, Nombre = "Carmen Díaz", Area = "Finanzas", EmpleadosACargo = 6, ProgresoPromedio = 78.5, SatisfaccionPromedio = 4.2, RiesgoPromedio = "Medio", Puntuacion = 81.5 },
                new { Posicion = 8, Nombre = "Jorge Torres", Area = "Compras", EmpleadosACargo = 10, ProgresoPromedio = 75.0, SatisfaccionPromedio = 4.0, RiesgoPromedio = "Alto", Puntuacion = 78.0 }
            };

            // Ranking de Empleados Top por Progreso
            var rankingEmpleados = new List<dynamic>
            {
                new { Posicion = 1, Nombre = "Laura Hernández", Puesto = "Técnico de Calidad", Lider = "Carlos Rodríguez", Progreso = 98, Satisfaccion = 5.0, DiasOnboarding = 45 },
                new { Posicion = 2, Nombre = "Miguel Ramírez", Puesto = "Ingeniero de Procesos", Lider = "Ana Martínez", Progreso = 95, Satisfaccion = 4.9, DiasOnboarding = 52 },
                new { Posicion = 3, Nombre = "Sofía Castro", Puesto = "Operador de Producción", Lider = "María González", Progreso = 93, Satisfaccion = 4.8, DiasOnboarding = 38 },
                new { Posicion = 4, Nombre = "Diego Morales", Puesto = "Analista de Logística", Lider = "Luis Fernández", Progreso = 91, Satisfaccion = 4.7, DiasOnboarding = 60 },
                new { Posicion = 5, Nombre = "Valentina Ruiz", Puesto = "Técnico de Mantenimiento", Lider = "Patricia López", Progreso = 89, Satisfaccion = 4.6, DiasOnboarding = 55 },
                new { Posicion = 6, Nombre = "Andrés Vargas", Puesto = "Analista de RH", Lider = "Roberto Sánchez", Progreso = 87, Satisfaccion = 4.5, DiasOnboarding = 48 },
                new { Posicion = 7, Nombre = "Isabella Méndez", Puesto = "Contador", Lider = "Carmen Díaz", Progreso = 85, Satisfaccion = 4.4, DiasOnboarding = 42 },
                new { Posicion = 8, Nombre = "Mateo Ortiz", Puesto = "Comprador", Lider = "Jorge Torres", Progreso = 82, Satisfaccion = 4.3, DiasOnboarding = 65 },
                new { Posicion = 9, Nombre = "Camila Jiménez", Puesto = "Operador de Producción", Lider = "María González", Progreso = 80, Satisfaccion = 4.2, DiasOnboarding = 35 },
                new { Posicion = 10, Nombre = "Daniel Peña", Puesto = "Técnico de Calidad", Lider = "Carlos Rodríguez", Progreso = 78, Satisfaccion = 4.1, DiasOnboarding = 70 }
            };

            // Ranking por Área
            var rankingAreas = new List<dynamic>
            {
                new { Area = "Calidad", ProgresoPromedio = 90.5, SatisfaccionPromedio = 4.7, EmpleadosTotal = 15, RiesgoPromedio = "Bajo" },
                new { Area = "Ingeniería", ProgresoPromedio = 88.2, SatisfaccionPromedio = 4.6, EmpleadosTotal = 18, RiesgoPromedio = "Bajo" },
                new { Area = "Producción", ProgresoPromedio = 87.0, SatisfaccionPromedio = 4.5, EmpleadosTotal = 25, RiesgoPromedio = "Medio" },
                new { Area = "Logística", ProgresoPromedio = 85.5, SatisfaccionPromedio = 4.4, EmpleadosTotal = 12, RiesgoPromedio = "Medio" },
                new { Area = "Mantenimiento", ProgresoPromedio = 83.0, SatisfaccionPromedio = 4.3, EmpleadosTotal = 10, RiesgoPromedio = "Medio" },
                new { Area = "RH", ProgresoPromedio = 81.5, SatisfaccionPromedio = 4.2, EmpleadosTotal = 8, RiesgoPromedio = "Bajo" },
                new { Area = "Finanzas", ProgresoPromedio = 79.0, SatisfaccionPromedio = 4.1, EmpleadosTotal = 9, RiesgoPromedio = "Medio" },
                new { Area = "Compras", ProgresoPromedio = 76.5, SatisfaccionPromedio = 4.0, EmpleadosTotal = 11, RiesgoPromedio = "Alto" }
            };

            ViewBag.RankingLideres = rankingLideres;
            ViewBag.RankingEmpleados = rankingEmpleados;
            ViewBag.RankingAreas = rankingAreas;

            return View();
        }
    }
}
