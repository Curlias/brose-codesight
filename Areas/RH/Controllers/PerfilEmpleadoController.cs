using Microsoft.AspNetCore.Mvc;

namespace Brose_OnboardingDashboard.Areas.RH.Controllers
{
    [Area("RH")]
    public class PerfilEmpleadoController : Controller
    {
        public IActionResult Index(int? id)
        {
            // Si no se proporciona ID, redirigir a la lista de empleados
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Empleados");
            }

            // Datos mock del empleado seleccionado
            var empleado = ObtenerEmpleadoPorId(id.Value);
            
            if (empleado == null)
            {
                return NotFound();
            }

            ViewBag.Empleado = empleado;
            ViewBag.Planta = empleado.Planta;
            
            return View();
        }

        private dynamic ObtenerEmpleadoPorId(int id)
        {
            // Lista de empleados mock (mismo que en EmpleadosController)
            var empleados = new List<dynamic>
            {
                new { Id = 1, Nombre = "Ana Martínez Torres", Puesto = "Supervisor de Línea", Area = "WS", Departamento = "Producción", Planta = "Puebla", Lider = "Juan Pérez", FechaIngreso = "2024-09-15", DiasOnboarding = 38, Estado = "Activo", Progreso = 95, Satisfaccion = 4.8, Riesgo = "Bajo", Email = "ana.martinez@brose.com", Telefono = "+52 222 123 4567" },
                new { Id = 2, Nombre = "Juan Pérez García", Puesto = "Ingeniero de Manufactura", Area = "GE", Departamento = "Ingeniería", Planta = "Benito Juárez", Lider = "María González", FechaIngreso = "2024-07-01", DiasOnboarding = 114, Estado = "Completado", Progreso = 100, Satisfaccion = 5.0, Riesgo = "Bajo", Email = "juan.perez@brose.com", Telefono = "+52 442 234 5678" },
                new { Id = 3, Nombre = "Laura Sánchez Mendoza", Puesto = "Analista de Calidad", Area = "GKL", Departamento = "Calidad", Planta = "El Marqués", Lider = "Pedro Ramírez", FechaIngreso = "2024-08-01", DiasOnboarding = 83, Estado = "Activo", Progreso = 75, Satisfaccion = 4.3, Riesgo = "Medio", Email = "laura.sanchez@brose.com", Telefono = "+52 442 345 6789" },
                new { Id = 4, Nombre = "Carlos Ramírez Silva", Puesto = "Técnico de Mantenimiento", Area = "FL", Departamento = "Mantenimiento", Planta = "Aeropuerto", Lider = "Ana Torres", FechaIngreso = "2024-09-01", DiasOnboarding = 52, Estado = "Activo", Progreso = 45, Satisfaccion = 3.8, Riesgo = "Alto", Email = "carlos.ramirez@brose.com", Telefono = "+52 442 456 7890" },
                new { Id = 5, Nombre = "María González López", Puesto = "Coordinadora de Logística", Area = "ATS", Departamento = "Logística", Planta = "Benito Juárez", Lider = "Roberto Díaz", FechaIngreso = "2024-07-15", DiasOnboarding = 100, Estado = "Activo", Progreso = 88, Satisfaccion = 4.6, Riesgo = "Bajo", Email = "maria.gonzalez@brose.com", Telefono = "+52 442 567 8901" }
            };

            var empleado = empleados.FirstOrDefault(e => e.Id == id);
            
            if (empleado == null) return null;

            // Agregar datos adicionales del perfil
            return new
            {
                empleado.Id,
                empleado.Nombre,
                empleado.Puesto,
                empleado.Area,
                empleado.Departamento,
                empleado.Planta,
                empleado.Lider,
                empleado.FechaIngreso,
                empleado.DiasOnboarding,
                empleado.Estado,
                empleado.Progreso,
                empleado.Satisfaccion,
                empleado.Riesgo,
                empleado.Email,
                empleado.Telefono,
                
                // Checklist completado
                ChecklistCompletado = empleado.Progreso >= 100 ? 100 : empleado.Progreso,
                TareasCompletadas = empleado.Progreso >= 100 ? 25 : (int)(25 * empleado.Progreso / 100),
                TareasTotales = 25,
                
                // Roadmap de onboarding
                Roadmap = new List<dynamic>
                {
                    new { 
                        Fase = "Inducción", 
                        Estado = "Completado", 
                        Progreso = 100, 
                        FechaInicio = empleado.FechaIngreso,
                        FechaFin = DateTime.Parse(empleado.FechaIngreso).AddDays(1).ToString("yyyy-MM-dd"),
                        Tareas = new List<string> { "Firma de contrato", "Recorrido de instalaciones", "Entrega de credencial", "Asignación de equipo" }
                    },
                    new { 
                        Fase = "Primera Semana", 
                        Estado = empleado.Progreso >= 25 ? "Completado" : "En Proceso", 
                        Progreso = empleado.Progreso >= 25 ? 100 : (empleado.Progreso * 4),
                        FechaInicio = DateTime.Parse(empleado.FechaIngreso).AddDays(1).ToString("yyyy-MM-dd"),
                        FechaFin = DateTime.Parse(empleado.FechaIngreso).AddDays(7).ToString("yyyy-MM-dd"),
                        Tareas = new List<string> { "Capacitación de seguridad", "Introducción al equipo", "Configuración de sistemas", "Primera reunión 1:1" }
                    },
                    new { 
                        Fase = "30 Días", 
                        Estado = empleado.Progreso >= 50 ? "Completado" : empleado.Progreso >= 25 ? "En Proceso" : "Pendiente", 
                        Progreso = empleado.Progreso >= 50 ? 100 : empleado.Progreso >= 25 ? ((empleado.Progreso - 25) * 4) : 0,
                        FechaInicio = DateTime.Parse(empleado.FechaIngreso).AddDays(7).ToString("yyyy-MM-dd"),
                        FechaFin = DateTime.Parse(empleado.FechaIngreso).AddDays(30).ToString("yyyy-MM-dd"),
                        Tareas = new List<string> { "Capacitación técnica", "Proyectos iniciales", "Evaluación de desempeño", "Feedback 30 días" }
                    },
                    new { 
                        Fase = "60 Días", 
                        Estado = empleado.Progreso >= 75 ? "Completado" : empleado.Progreso >= 50 ? "En Proceso" : "Pendiente", 
                        Progreso = empleado.Progreso >= 75 ? 100 : empleado.Progreso >= 50 ? ((empleado.Progreso - 50) * 4) : 0,
                        FechaInicio = DateTime.Parse(empleado.FechaIngreso).AddDays(30).ToString("yyyy-MM-dd"),
                        FechaFin = DateTime.Parse(empleado.FechaIngreso).AddDays(60).ToString("yyyy-MM-dd"),
                        Tareas = new List<string> { "Autonomía en tareas", "Colaboración en proyectos", "Encuesta de satisfacción", "Plan de desarrollo" }
                    },
                    new { 
                        Fase = "90 Días", 
                        Estado = empleado.Progreso >= 100 ? "Completado" : empleado.Progreso >= 75 ? "En Proceso" : "Pendiente", 
                        Progreso = empleado.Progreso >= 100 ? 100 : empleado.Progreso >= 75 ? ((empleado.Progreso - 75) * 4) : 0,
                        FechaInicio = DateTime.Parse(empleado.FechaIngreso).AddDays(60).ToString("yyyy-MM-dd"),
                        FechaFin = DateTime.Parse(empleado.FechaIngreso).AddDays(90).ToString("yyyy-MM-dd"),
                        Tareas = new List<string> { "Evaluación final", "Certificación completada", "Planificación de carrera", "Cierre de onboarding" }
                    }
                },
                
                // Encuestas de satisfacción
                Encuestas = new List<dynamic>
                {
                    new { Periodo = "Inducción", Fecha = DateTime.Parse(empleado.FechaIngreso).AddDays(1).ToString("yyyy-MM-dd"), Puntuacion = 4.5, Estado = "Completada" },
                    new { Periodo = "Primera Semana", Fecha = DateTime.Parse(empleado.FechaIngreso).AddDays(7).ToString("yyyy-MM-dd"), Puntuacion = empleado.Progreso >= 25 ? 4.3 : 0, Estado = empleado.Progreso >= 25 ? "Completada" : "Pendiente" },
                    new { Periodo = "30 Días", Fecha = DateTime.Parse(empleado.FechaIngreso).AddDays(30).ToString("yyyy-MM-dd"), Puntuacion = empleado.Progreso >= 50 ? empleado.Satisfaccion : 0, Estado = empleado.Progreso >= 50 ? "Completada" : "Pendiente" },
                    new { Periodo = "60 Días", Fecha = DateTime.Parse(empleado.FechaIngreso).AddDays(60).ToString("yyyy-MM-dd"), Puntuacion = empleado.Progreso >= 75 ? empleado.Satisfaccion : 0, Estado = empleado.Progreso >= 75 ? "Completada" : "Pendiente" },
                    new { Periodo = "90 Días", Fecha = DateTime.Parse(empleado.FechaIngreso).AddDays(90).ToString("yyyy-MM-dd"), Puntuacion = empleado.Progreso >= 100 ? empleado.Satisfaccion : 0, Estado = empleado.Progreso >= 100 ? "Completada" : "Pendiente" }
                },
                
                // Métricas adicionales
                DiasRestantes = empleado.Progreso >= 100 ? 0 : Math.Max(0, 90 - empleado.DiasOnboarding),
                TiempoPromedio = "85 días",
                RankingEquipo = empleado.Progreso >= 90 ? "Top 10%" : empleado.Progreso >= 75 ? "Top 25%" : "Promedio"
            };
        }
    }
}
