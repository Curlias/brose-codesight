using Microsoft.AspNetCore.Mvc;

namespace Brose_OnboardingDashboard.Areas.RH.Controllers
{
    [Area("RH")]
    public class LideresController : Controller
    {
        public IActionResult Index()
        {
            // Mock data de líderes
            var lideres = new List<dynamic>
            {
                new { Id = 1, Nombre = "María González", Puesto = "Gerente de Producción", Area = "Producción", Planta = "Benito Juárez", EmpleadosACargo = 12, ProgresoPromedio = 92.3, SatisfaccionPromedio = 4.7, RiesgoPromedio = "Bajo", Email = "maria.gonzalez@brose.com", Telefono = "+52 442 123 4567", FechaIngreso = "2020-03-15" },
                new { Id = 2, Nombre = "Carlos Rodríguez", Puesto = "Jefe de Calidad", Area = "Calidad", Planta = "El Marqués", EmpleadosACargo = 8, ProgresoPromedio = 88.5, SatisfaccionPromedio = 4.5, RiesgoPromedio = "Bajo", Email = "carlos.rodriguez@brose.com", Telefono = "+52 442 234 5678", FechaIngreso = "2019-07-20" },
                new { Id = 3, Nombre = "Ana Martínez", Puesto = "Coordinadora de Ingeniería", Area = "Ingeniería", Planta = "Aeropuerto", EmpleadosACargo = 15, ProgresoPromedio = 85.2, SatisfaccionPromedio = 4.3, RiesgoPromedio = "Medio", Email = "ana.martinez@brose.com", Telefono = "+52 442 345 6789", FechaIngreso = "2021-01-10" },
                new { Id = 4, Nombre = "Juan Pérez", Puesto = "Supervisor de Logística", Area = "Logística", Planta = "Puebla", EmpleadosACargo = 10, ProgresoPromedio = 90.8, SatisfaccionPromedio = 4.6, RiesgoPromedio = "Bajo", Email = "juan.perez@brose.com", Telefono = "+52 222 456 7890", FechaIngreso = "2018-11-05" },
                new { Id = 5, Nombre = "Pedro Sánchez", Puesto = "Jefe de Mantenimiento", Area = "Mantenimiento", Planta = "Benito Juárez", EmpleadosACargo = 6, ProgresoPromedio = 78.4, SatisfaccionPromedio = 4.0, RiesgoPromedio = "Alto", Email = "pedro.sanchez@brose.com", Telefono = "+52 442 567 8901", FechaIngreso = "2022-05-18" },
                new { Id = 6, Nombre = "Laura Torres", Puesto = "Gerente de IT", Area = "IT", Planta = "El Marqués", EmpleadosACargo = 7, ProgresoPromedio = 94.1, SatisfaccionPromedio = 4.8, RiesgoPromedio = "Bajo", Email = "laura.torres@brose.com", Telefono = "+52 442 678 9012", FechaIngreso = "2020-09-22" },
                new { Id = 7, Nombre = "Roberto Díaz", Puesto = "Coordinador de Compras", Area = "Compras", Planta = "Aeropuerto", EmpleadosACargo = 5, ProgresoPromedio = 82.6, SatisfaccionPromedio = 4.2, RiesgoPromedio = "Medio", Email = "roberto.diaz@brose.com", Telefono = "+52 442 789 0123", FechaIngreso = "2021-06-30" },
                new { Id = 8, Nombre = "Carmen Vega", Puesto = "Jefa de Recursos Humanos", Area = "RH", Planta = "Puebla", EmpleadosACargo = 4, ProgresoPromedio = 96.5, SatisfaccionPromedio = 4.9, RiesgoPromedio = "Bajo", Email = "carmen.vega@brose.com", Telefono = "+52 222 890 1234", FechaIngreso = "2017-04-12" }
            };

            ViewBag.Lideres = lideres;
            ViewBag.TotalLideres = lideres.Count;
            
            // Filtros
            ViewBag.Plantas = new List<string> { "Todas", "Benito Juárez", "El Marqués", "Aeropuerto", "Puebla" };
            ViewBag.Areas = new List<string> { "Todas", "Producción", "Calidad", "Ingeniería", "Logística", "Mantenimiento", "IT", "Compras", "RH" };

            return View();
        }
    }
}
